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
        public SuffixCount<T> Suffixes { get; set; }

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
            
        }

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

            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
            return base.Equals(obj);
            
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Contains a suffix and the count of that suffix.
    /// </summary>
    /// <typeparam name="T">The type contained in the suffix</typeparam>
    public class SuffixCount<T> : IEquatable<SuffixCount<T>>
    {
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
    }
}
