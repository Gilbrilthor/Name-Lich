using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markov_List_Backend
{
    /// <summary>
    /// Link that contains a single prefix and all the associated suffixes.
    /// </summary>
    /// <typeparam name="T">Type contained within the link.</typeparam>
    public class MarkovLink<T>
    {
        private Random _r;

        private static int _nextId;

        public int Id { get; private set; }

        public MarkovLink(Random r)
        {
            _r = r;
            Id = _nextId++;
            Prefixes = new List<T>();
            Suffixes = new HashSet<SuffixCount<T>>();
        }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public List<T> Prefixes { get; set; }
        /// <summary>
        /// Gets or sets the suffixes.
        /// </summary>
        /// <value>
        /// The suffixes.
        /// </value>
        public HashSet<SuffixCount<T>> Suffixes { get; set; }

        /// <summary>
        /// Determines whether the specified prefixes is prefix.
        /// </summary>
        /// <param name="prefixes">The prefixes.</param>
        /// <returns></returns>
        public bool IsPrefix(params T[] prefixes)
        {
            if (prefixes.Length != Prefixes.Count)
            {
                return false;
            }

            for (var i = 0; i < Prefixes.Count; i++)
            {
                if (!Prefixes[i].Equals(prefixes[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Adds the suffix.
        /// </summary>
        /// <param name="suffixToAdd">The suffix to add.</param>
        public void AddSuffix(T suffixToAdd)
        {
            AddSuffixCount(suffixToAdd, 1);
        }

        private void AddSuffixCount(T suffixToAdd, int count)
        {
            var sfx = Suffixes.FirstOrDefault(s => s.Suffix.Equals(suffixToAdd));
            if (sfx != null)
            {
                sfx.Count += count;
            }
            else
            {
                sfx = new SuffixCount<T>(suffixToAdd);
                Suffixes.Add(sfx);
            }
        }

        public void AddSuffixFromLink(MarkovLink<T> otherLink)
        {
            foreach (var suffixCount in otherLink.Suffixes)
            {
                AddSuffixCount(suffixCount.Suffix, suffixCount.Count);
            }
        }

        public T GetRandomSuffix(bool includeTerminatorSuffix = false)
        {
            var countSum = Suffixes.Sum(s => s.Count);
            var randomNumber = _r.Next(countSum);
            List<SuffixCount<T>> suffixesToSearch = null;
            if (includeTerminatorSuffix)
            {
                suffixesToSearch = Suffixes.OrderBy(s => s.Count).ToList();
            }
            else
            {
                suffixesToSearch = Suffixes.Where(s => !s.Suffix.Equals(Terminator)).OrderBy(s => s.Count).ToList();
            }

            var suffixQueue = new Queue<SuffixCount<T>>(suffixesToSearch);

            SuffixCount<T> targetSuffix = suffixQueue.Dequeue();

            while (randomNumber > 0 && suffixQueue.Count > 0)
            {
                randomNumber -= targetSuffix.Count;
                targetSuffix = suffixQueue.Dequeue();
            }

            return targetSuffix.Suffix;
        }

        public T Terminator { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }


            return Equals(otherLink:obj as MarkovLink<T>);

        }

        public bool Equals(MarkovLink<T> otherLink)
        {
            return IsPrefix(otherLink.Prefixes.ToArray());
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var sb = new StringBuilder();

            foreach (var prefix in Prefixes)
            {
                sb.Append(prefix.GetHashCode());
            }

            return sb.ToString().GetHashCode();
            // Compute hash by exponentiating the individual prefixes hash codes
            unchecked
            {
                var hash = Prefixes.Aggregate(17, (acc, c) => acc * 23 + c.GetHashCode());
                return hash;
            } 
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("<{0} ", Id);

            foreach (var prefix in Prefixes)
            {
                sb.AppendFormat("{0} ", prefix);
            }

            sb.Append(":");

            foreach (var suffixCount in Suffixes.OrderByDescending(s => s.Count))
            {
                sb.AppendFormat("{0} ", suffixCount.ToString());
            }

            sb.Append(">");

            return sb.ToString();
        }
    }

    /// <summary>
    /// Contains a suffix and the count of that suffix.
    /// </summary>
    /// <typeparam name="T">The type contained in the suffix</typeparam>
    public class SuffixCount<T> : IEquatable<SuffixCount<T>>
    {
        public SuffixCount(T suffixValue)
        {
            Suffix = suffixValue;
            Count = 1;
        }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public T Suffix { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="otherSuffix">The other suffix.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SuffixCount<T> otherSuffix)
        {
            return Suffix.Equals(otherSuffix.Suffix);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var suffixToCheck = (SuffixCount<T>) obj;

            return Equals(suffixToCheck);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Suffix.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Suffix, Count);
        }
    }
}
