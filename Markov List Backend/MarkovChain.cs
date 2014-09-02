using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Markov_List_Backend
{
    public class MarkovChain
    {
        private Dictionary<int, MarkovLink<char>> _links;

        private Random _r;

        private string _inputText { get; set; }

        /// <summary>
        /// Gets or sets the name type of the chain.
        /// </summary>
        /// <value>
        /// The name type of the chain.
        /// </value>
        public string ChainName { get; set; }

        public int LettersToKeep { get; set; }

        public MarkovChain(Random r)
        {
            _r = r;
            _links = new Dictionary<int, MarkovLink<char>>();
            LettersToKeep = 3;
            TerminatorCharacter = (char)0x3; // The ETX, or End Text Character
        }

        /// <summary>
        /// Cleans the specified input for consumption. Specifically, it removes
        /// all characters to be found in the CharsToStrip setting.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>cleaned string.</returns>
        private string Cleanup(string input)
        {
            var charsToStrip = Constants.CharsToStrip;


            // strip all punctuation, leaving newlines
            // The setting CharsToStrip contain all the characters to remove
            var strippedInput = new string((from c in input.ToCharArray()
                where !charsToStrip.Contains(c)
                select c).ToArray());

            // Make sure newlines are just \n
            strippedInput = strippedInput.Replace("\r", "");

            return strippedInput;
        }

        public void ConsumeText(string input)
        {
            // Make sure that no links from last consumption are there
            _links.Clear();

            _inputText = input;
            var cleanedText = Cleanup(input);

            var textQueue = new Queue<string>(cleanedText.Split(new []{TerminatorCharacter}, StringSplitOptions.RemoveEmptyEntries));

            while (textQueue.Count > 0)
            {
                var textToParse = textQueue.Dequeue();
                for (int i = -LettersToKeep; i < textToParse.Length; i++)
                {
                    // Skip -1 so that the smart parse doesn't return duplicate arrays
                    // for the beginning of the input.
                    if (i == -1) continue;

                    var bitOfIndex = SmartParse(textToParse, i);
                    AddLink(bitOfIndex);
                }
            }
        }
        public string SerializeToText()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0}{1}",ChainName, Constants.MainSeparator);
            sb.AppendFormat("{0}{2}{1}{2}",
                TerminatorCharacter,
                LettersToKeep,
                Constants.MainSeparator);

            foreach (var markovLink in _links.Values)
            {
                sb.Append(markovLink.SerializeToText(Constants.MainSeparator, Constants.SecondarySeparator));
            }

            return sb.ToString();
        }

        public static MarkovChain DeserializeFromText(string text, Random r)
        {
            var chain = new MarkovChain(r);
            var textQueue = new Queue<string>(text.Split(new []{Constants.MainSeparator}, StringSplitOptions.RemoveEmptyEntries));
            // Get the name type
            chain.ChainName = textQueue.Dequeue();

            // Get the terminator and LettersToKeep
            chain.TerminatorCharacter = textQueue.Dequeue()[0];
            chain.LettersToKeep = int.Parse(textQueue.Dequeue());
            // Get all the links
            do
            {
                var prefixString = textQueue.Dequeue();
                var suffixString = textQueue.Dequeue();

                var link = MarkovLink<char>.DeserializeFromText(prefixString,
                    suffixString,
                    Constants.SecondarySeparator,
                    r);

                chain._links.Add(link.GetHashCode(), link);
            } while (textQueue.Count > 0);

            return chain;
        }

        private MarkovLink<char> GetLink(MarkovLink<char> key)
        {
            if (_links.ContainsKey(key.GetHashCode()))
                return _links[key.GetHashCode()];
            else
                return null;
        }

        public char TerminatorCharacter { get; set; }

        private MarkovLink<char> GetRandomStartLink()
        {
            var startLinks = (from l in _links.Values
                where l.Prefixes[0] == TerminatorCharacter
                      &&
                      l.Suffixes.Any(s => s.Suffix != TerminatorCharacter)
                select l).ToList();

            return startLinks[_r.Next(startLinks.Count)];
        }

        public string BuildText(int? maxLength = null)
        {
            var sb = new StringBuilder();

            // pick a start link
            var targetLink = GetRandomStartLink();

            foreach (var prefix in targetLink.Prefixes)
            {
                sb.Append(prefix);
            }

            sb.Append(targetLink.GetRandomSuffix());

            // while havent met maxLength and not end link
            while (sb[sb.Length - 1] != TerminatorCharacter && (!maxLength.HasValue || sb.Length < maxLength.Value))
            {
                // grab the last characters of the text. LettersToKeep - 1
                var charArray = sb.ToString().ToCharArray();
                var nextPrefix =
                    (charArray.Skip(Math.Max(0, charArray.Count() - (LettersToKeep - 1))).Take(LettersToKeep)).ToArray();
                // find next suitable link and append it
                targetLink = (from l in _links.Values
                    where l.Prefixes.SequenceEqual(nextPrefix)
                    select l).First();

                sb.Append(targetLink.GetRandomSuffix(includeTerminatorSuffix:true));
            }

            //return result
            return sb.ToString().Trim(TerminatorCharacter);
        }

        private void AddLink(char[] bitOfIndex)
        {
            var link = new MarkovLink<char>(_r);
            link.Prefixes.AddRange(bitOfIndex.Take(LettersToKeep - 1));
            link.AddSuffix(bitOfIndex.Last());

            var targetLink = GetLink(link); 

            if (targetLink == null)
            {
                _links.Add(link.GetHashCode(), link);
            }
            else
            {
                targetLink.AddSuffixFromLink(link);
            }
        }

        private char[] SmartParse(string input, int index)
        {
            // Fill the array with spaces
            var array = Enumerable.Repeat(TerminatorCharacter, LettersToKeep).ToArray();
            var arrayIndex = 0;
            var startingIndex = index;

            /* If index is negative, put it in the correct array index
             * should be
             * ...
             * -3 -> 2
             * -2 -> 1
             * -1 -> 0 (junk value if enumerating over entire input)
             * 0 -> 0
             * 1 -> 1
             * ... */
            if (index < 0)
            {
                arrayIndex = -index - 1;
                startingIndex = 0;
            }

            while (startingIndex < input.Length && arrayIndex < array.Length && input[startingIndex] != TerminatorCharacter)
            {
                array[arrayIndex++] = input[startingIndex++];
            }

            return array;
        }
    }
}
