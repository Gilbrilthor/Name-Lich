using System.Collections.Generic;

namespace Name_Lich_Backend
{
    public abstract class AbstractNameReader
    {
        /// <summary>
        /// Returns a list of names from a nameType source.
        /// </summary>
        /// <returns>List of names.</returns>
        public abstract List<AbstractNameGenerator> ReadNameParts(string nameSource);
    }
}