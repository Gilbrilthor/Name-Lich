﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Name_Lich_Backend
{
    public class NamNameGenerator : AbstractNameGenerator
    {
        private string _nameType;

        private List<string> endList;
        private List<string> middleList;
        private Random random;
        private List<string> startList;

        public NamNameGenerator(System.Random random, string nameType, IEnumerable<string> startList, IEnumerable<string> middleList, IEnumerable<string> endList)
        {
            _nameType = nameType;
            this.startList = startList.ToList();
            this.middleList = middleList.ToList();
            this.endList = endList.ToList();

            this.random = random;
        }

        public List<string> EndList
        {
            get { return endList; }
            set { endList = value; }
        }

        public List<string> MiddleList
        {
            get { return middleList; }
            set { middleList = value; }
        }

        public List<string> StartList
        {
            get { return startList; }
            set { startList = value; }
        }

        /// <summary>
        /// Generates a name.
        /// </summary>
        /// <returns>A name.</returns>
        public override string GenerateName()
        {
            string beginning = (startList.Any() ? startList[random.Next(startList.Count)] : "");
            string middle = (middleList.Any() ? middleList[random.Next(middleList.Count)] : "");
            string end = (endList.Any() ? endList[random.Next(endList.Count)] : "");

            return string.Format("{0}{1}{2}", beginning, middle, end);
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

        protected override string getNameType()
        {
            return _nameType;
        }
    }
}