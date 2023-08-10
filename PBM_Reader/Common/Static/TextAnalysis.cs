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
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
                if (!foundStartLine)
                {
                    if (line.Contains("pbm 127.0.0.1:9100 cluster show"))
                        foundStartLine = true;
                }
                else
                {
                    extractedLines.Add(line);

                    if (line.StartsWith("Count:"))
                        break;
                }

            return extractedLines;
        }

        public static List<string> SplitString(string input, string[] splitList)
        {
            return input.Split(splitList, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}