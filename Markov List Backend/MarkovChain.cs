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

            // strip all punctuation, leaving newlines
            // The setting CharsToStrip contain all the characters to remove
            var strippedInput = new string((from c in input.ToCharArray()
                where !Properties.Settings.Default.CharsToStrip.Contains(c)
                select c).ToArray());

            return strippedInput;
        }

        public void ConsumeText(string input)
        {
            _inputText = input;
            var cleanedText = Cleanup(input);

            for (int i = -LettersToKeep; i < cleanedText.Length; i++)
            {
                // Skip -1 so that the smart parse doesn't return duplicate arrays
                // for the beginning of the input.
                if (i == -1) continue;

                var bitOfIndex = SmartParse(cleanedText, i);
                AddLink(bitOfIndex);
            }
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

            while (startingIndex < input.Length && arrayIndex < array.Length)
            {
                array[arrayIndex++] = input[startingIndex++];
            }

            return array;
        }
    }
}
