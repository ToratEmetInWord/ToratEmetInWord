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

        public static string ShemHashemWriting(this string input)
        {
            if (תורת_אמת_פלוס_מינוס.Properties.Settings.Default.ShemHashemDisplayOptions == 2)//
            {
                return Regex.Replace(input, @"(י)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ו)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)",
                                       "יְ$3$6יָ$9$12");
            }
            else if (תורת_אמת_פלוס_מינוס.Properties.Settings.Default.ShemHashemDisplayOptions == 3)
            {
                return Regex.Replace(input, @"(י\p{Mn}*)(ה)(\p{Mn}*)(ו\p{Mn}*)(ה)(\p{Mn}*)", "$1ק$3$4ק$6");
            }
            else if (תורת_אמת_פלוס_מינוס.Properties.Settings.Default.ShemHashemDisplayOptions == 4)
            {
                return Regex.Replace(input, @"(י)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ו)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)",
                                        "ה$3$6$9$12'");
            }
            return input;
        }

        public static string ShemHashemWritingReverse(this string input)
        {
            string pattern = @"(י\p{Mn}*)(ק)(\p{Mn}*)(ו\p{Mn}*)(ק)(\p{Mn}*)";
            return Regex.Replace(input, pattern, "$1ה$3$4ה$6");
        }
    }
}
