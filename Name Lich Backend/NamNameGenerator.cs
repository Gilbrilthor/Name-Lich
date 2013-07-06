using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Name_Lich_Backend
{
    public class NamNameGenerator : AbstractNameGenerator
    {
        private string _nameType;

        private List<string> startList;
        private List<string> middleList;
        private List<string> endList;

        private Random random;

        public NamNameGenerator(System.Random random, string nameType, IEnumerable<string> startList, IEnumerable<string> middleList, IEnumerable<string> endList)
        {
            _nameType = nameType;
            this.startList = startList.ToList();
            this.middleList = middleList.ToList();
            this.endList = endList.ToList();

            this.random = random;
        }

        /// <summary>
        /// Generates a name.
        /// </summary>
        /// <returns>A name.</returns>
        public override string GenerateName()
        {
            string beginning = (startList.Any()? startList[random.Next(startList.Count)]: "");
            string middle = (middleList.Any()? middleList[random.Next(middleList.Count)]: "");
            string end = (endList.Any()? endList[random.Next(endList.Count)]: "");

            return string.Format("{0}{1}{2}", beginning, middle, end);
        }

        protected override string getNameType()
        {
            return _nameType;
        }

        public override string ToString()
        {
#if DEBUG
            return base.ToString() + string.Format(": {0} | {1} | {2}",
                startList.Count, middleList.Count, endList.Count);
#else
            return NameType;
#endif
        }
    }
}
