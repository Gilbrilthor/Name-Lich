using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Name_Lich_Backend
{
    public class NamFileNameReader : AbstractNameReader
    {
        private const string COMMENT_IDENTIFIER = "/*";
        private const string NAME_FILE_SUFFIX = "*.nam";
        private Random random;

        public NamFileNameReader(Random random)
        {
            this.random = random;
        }

        public override List<AbstractNameGenerator> ReadNameParts(string directoryPath)
        {
            var files = QueryDirectory(directoryPath);

            var nameGenerators = new List<AbstractNameGenerator>();

            foreach (var file in files)
            {
                var l = File.ReadAllLines(file, Encoding.Default);
                List<string> lines;

                lines =
                    (from line in l
                     where (!line.StartsWith(COMMENT_IDENTIFIER))
                     select line).ToList();

                var start = lines.IndexOf("<start>");
                var middle = lines.IndexOf("<middle>");
                var end = lines.IndexOf("<end>");

                // Grab the beginning lines until the middle marker
                var startLines = lines.TakeWhile(line => line != "<middle>");

                // Grab both the middle and end parts
                var middleEndLines = lines.SkipWhile(line => line != "<middle>");

                // Grab the end parts from the middle and end parts
                var endLines = middleEndLines.SkipWhile(line => line != "<end>");

                // Grab the middle parts from the middle and end parts
                var middleLines = middleEndLines.TakeWhile(line => line != "<end>");

                // Add it to the list of name generators. Skip the markers
                var gen = new NamNameGenerator(random, Path.GetFileNameWithoutExtension(file),
                    startLines.Skip(1), middleLines.Skip(1), endLines.Skip(1));

                nameGenerators.Add(gen);
            }

            return nameGenerators;
        }

        private IEnumerable<string> QueryDirectory(string directoryPath)
        {
            return Directory.EnumerateFiles(directoryPath, NAME_FILE_SUFFIX);
        }
    }
}