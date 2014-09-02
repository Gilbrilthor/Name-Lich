using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Markov_List_Backend;

namespace MarkovTestDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
#if true
            var testText = "hel45o[ the^5re";
            testText = File.ReadAllText(@"D:\Users\Matthew\Desktop\egyptianNames.csv");
            //testText = "hello";
            var chain = new MarkovChain(r)
            {
                TerminatorCharacter = '\n',
                ChainName = "Egyptian"
            };

            for (int ltk = 2; ltk < 10; ltk++)
            {
                var sw = Stopwatch.StartNew();
                chain.LettersToKeep = ltk;
                chain.ConsumeText(testText);
                Console.WriteLine("Keeping {0}", ltk);
                for (var i = 0; i < 15; i++)
                {
                    var output = chain.BuildText();
                    Console.WriteLine(output);
                }

                Console.WriteLine("Time Taken: {0} millisec", sw.ElapsedMilliseconds);
                Console.WriteLine();
            } 
#endif

#if false
            var serializedChain = File.ReadAllText("egyptian.nampak");
            var chain = MarkovChain.DeserializeFromText(serializedChain, r);

            for (var i = 0; i < 15; i++)
            {
                var output = chain.BuildText();
                Console.WriteLine(output);
            } 
#endif

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

#if true
            var serialOutput = chain.SerializeToText();

            File.WriteAllText("egyptian.nampak", serialOutput); 
#endif

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
