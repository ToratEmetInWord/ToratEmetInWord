using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToratEmet
{
    public static class GenericExtensions
    {
        public static string[] WhiteSpaceArray(this string input)
        {
            return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] LinesArray(this string input)
        {
            return input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] CommaArray(this string input)
        {
            return input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string NormalizeHebrewText(this string text)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            return new string(text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
        }

        public static string RemoveTextTillFirstChar(this string input, char targetChar)
        {
            int index = input.IndexOf(targetChar);
            if (index != -1)
            {
                return input.Substring(index + 1);
            }
            return input;
        }

        public static string GetTextTillFirstChar(this string input, char targetChar)
        {
            int index = input.IndexOf(targetChar);
            if (index != -1)
            {
                return input.Substring(0, index);
            }
            return input;
        }

        public static string RemoveAllParenthesis(this string input)
        {
            return Regex.Replace(input, @"[\{\}\(\)\[\]<>]+", "");
        }
    }
}
