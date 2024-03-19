using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._8.Extensions
{
    public static class PrivateExtensions
    {
        public static string GetCleanFileName(this string input)
        {
            if (input.Contains("ToratEmetInstall")) { input = TransaltorClass.TranslateFilename(input); }
            string output = Path.GetFileNameWithoutExtension(input);
            output = Regex.Replace(output, @"\d+_?", "");
            return output;
        }

        public static string GetCleanFolderName(this string input)
        {
            if (input.Contains("ToratEmetInstall")) { input = TransaltorClass.TranslateFolderName(input); }
            string output = Path.GetFileName(input);
            output = Regex.Replace(output, @"\d+_?", "").Replace("MyBooks", "הספרים שלי");
            return output;
        }
    }
}
