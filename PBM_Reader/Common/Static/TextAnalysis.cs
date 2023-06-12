using System.Collections.Generic;
using System;
using System.Linq;

namespace PBM_Reader.Common.Static
{
    public static class TextAnalysis
    {
        public static List<string> SplitString(string input, string[] splitList)
        {
            return input.Split(splitList, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}