using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1._8.Extensions
{
    public static class SearchExtensions
    {
        public static string CleanHeaders(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }
            input = Regex.Replace(input, @"[-\{\}]", " ").TrimEnd(',', ' ');
            return Regex.Replace(input, @"\s{2,}", " ");
        }

        public static string ModifyRegexPattern(this string pattern)
        {
            StringBuilder modifiedPattern = new StringBuilder();
            bool prevCharWasSpace = false;

            foreach (char c in pattern)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!prevCharWasSpace)
                    {
                        modifiedPattern.Append(@"\s?[^ ]*\s?");
                        prevCharWasSpace = true;
                    }
                }
                else
                {
                    modifiedPattern.Append(c + @"[\p{Mn}\\+]*");
                    prevCharWasSpace = false;
                }
            }


            if (prevCharWasSpace)            // If the last character was a space, we need to append the required pattern for that
            {
                modifiedPattern.Append(@"\s?[^ ]*\s?");
            }
            return modifiedPattern.ToString();
        }
    }
}
