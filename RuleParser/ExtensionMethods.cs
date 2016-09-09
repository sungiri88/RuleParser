using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleParser
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Finds the keyword in list and returns the FieldInfo object based on Occurence.
        /// </summary>
        /// <param name="FieldInfoList"></param>
        /// <param name="KeywordToSearch"></param>
        /// <param name="Occurence"></param> // note: Occurence index is array typed index.
        /// <returns></returns>
        public static FieldInfo FindKeyword(this List<FieldInfo> FieldInfoList, string KeywordToSearch, int Occurence = 0)
        {
            var AllMatches = FieldInfoList.FindAll(F => F.Keyword.Equals(KeywordToSearch));
            if (AllMatches.Count == 0)
                Console.WriteLine("Keyword Not Found - Raise Exception");
            if (AllMatches.Count < Occurence + 1)
                Console.WriteLine("Total Occurence of Keyword is lower than passed value - Raise Exception");
            return AllMatches[Occurence];
        }
        /// <summary>
        /// Finds the keyword in list after the specified line number.
        /// </summary>
        /// <param name="FieldInfoList"></param>
        /// <param name="KeywordToSearch"></param>
        /// <param name="SearchAfterLine"></param>
        /// <param name="Occurence"></param> // note: Occurence index is array typed index.
        /// <returns></returns>
        public static FieldInfo FindKeywordAfterSpecificLine(this List<FieldInfo> FieldInfoList, string KeywordToSearch, int SearchAfterLine, int Occurence = 0)
        {
            var AllMatches = FieldInfoList.FindAll(F => F.Keyword.Equals(KeywordToSearch) && F.LineNumber > SearchAfterLine);
            if (AllMatches.Count == 0)
                Console.WriteLine("Keyword Not Found - Raise Exception");
            if (AllMatches.Count < Occurence + 1)
                Console.WriteLine("Total Occurence of Keyword is lower than passed value - Raise Exception");
            return AllMatches[Occurence];
        }
    }
}
