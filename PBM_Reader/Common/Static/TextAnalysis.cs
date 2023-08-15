using System.Collections.Generic;
using System;
using System.Linq;

namespace PBM_Reader.Common.Static
{
    public static class TextAnalysis
    {
        public static List<string> GetPBMStatusString(string input)
        {
            bool foundStartLine = false;
            List<string> extractedLines = new List<string>();
            string[] lines = input.Split(new[] { "\n", Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (foundStartLine && line.StartsWith("Count:"))
                    break;

                if (!foundStartLine && line.Contains("cluster show"))
                    foundStartLine = true;
                else
                    extractedLines.Add(line);
            }
            return extractedLines;
        }

        public static List<string> SplitString(string input, string[] splitList)
        {
            return input.Split(splitList, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}