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
            var testText = "hel45o[ the^5re";
            testText = File.ReadAllText(@"D:\Users\Matthew\Desktop\egyptianNames.csv");
            //testText = "hello";
            var r = new Random();
            var chain = new MarkovChain(r);
            chain.TerminatorCharacter = '\n';

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

            Console.ReadKey();
        }
    }
}
