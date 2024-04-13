using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToratEmet.FileManaging.BookParsingModels
{
    public static class BookParsingExtensions
    {
        public static string FixUnclosedHeaderTags(this string input)
        {
            //line = Regex.Replace(line, @"<h(\d)>\Z", @"<h\$1>");
            if (input.Length >= 4 && input[input.Length - 4] == '<')
            {
                // Create a StringBuilder from the string
                StringBuilder sb = new StringBuilder(input);
                sb.Insert(input.Length - 3, '/');
                input = sb.ToString();
            }
            return input;
        }

        public static string MarkHyperlinks(this string input)
        {
            MatchCollection matches = Regex.Matches(input, @"[({]([^\s}{()]*?\s){1,5}[^\s}{()]*?[)}]");
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string markedValue = $"<span class=\"booklinks\" onclick=\"sendBookLink(this)\" onmouseover=\"setBookLinkTitle(this)\">{match.Value}</span>";
                    input = input.Replace(match.Value, markedValue);
                }
            }
            return input;
        }
    }
}
