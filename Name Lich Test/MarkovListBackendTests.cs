using System;
using System.Collections.Generic;
using Markov_List_Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Name_Lich_Test
{
    [TestClass]
    public class MarkovListBackendTests
    {
        [TestMethod]
        public void MarkovLink_IsPrefix_CorrectPrefix_ReturnTrue()
        {
            var r = new Random();
            var chain = new MarkovLink<string>(r);

            var prefix = new[] {"one", "two"};

            chain.Prefixes = new List<string>(prefix);

            CollectionAssert.AreEqual(prefix, chain.Prefixes);

            Assert.IsTrue(chain.IsPrefix(prefix));
        }

        [TestMethod]
        public void MarkovLink_IsPrefix_IncorrectPrefix_ReturnFalse()
        {
            var r = new Random();
            var chain = new MarkovLink<string>(r);

            var prefix = new[] {"one", "two"};

            chain.Prefixes = new List<string>(prefix);

            var differentPrefix = new[] {"two", "three"};

            var outOfOrderPrefix = new[] {"two", "one"};

            Assert.IsFalse(chain.IsPrefix(differentPrefix));
            Assert.IsFalse(chain.IsPrefix(outOfOrderPrefix));
        }

        [TestMethod]
        public void MarkovLink_IsPrefix_DifferentSizePrefix_ReturnFalse()
        {
            var r = new Random();
            var chain = new MarkovLink<string>(r);

            var prefix = new[] {"one"};

            chain.Prefixes = new List<string>(prefix);

            var differentPrefix = new[] {"two", "three"};

            Assert.IsFalse(chain.IsPrefix(differentPrefix));

            chain.Prefixes = new List<string>(differentPrefix);

            Assert.IsFalse(chain.IsPrefix(prefix));

        }
    }
}
