using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToratEmet.Models;
using ToratEmet.Properties;

namespace ToratEmet.Extensions
{
    public static class AppSpecificExtensions
    {

        public static string ShemHashemWriting(this string input)
        {
            if (Properties.Settings.Default.ShemHashemDisplayOptions == 2)//
            {
                return Regex.Replace(input, @"(י)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ו)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)(ה)([\u05B0-\u05BD\u05C1\u05C2\u05C4\u05C5]*)([\u0591-\u05AF]*)",
                                       "יְ$3$6יָ$9$12");
            }
            else if (Properties.Settings.Default.ShemHashemDisplayOptions == 3)
            {
                return Regex.Replace(input, @"(י\p{Mn}*)(ה)(\p{Mn}*)(ו\p{Mn}*)(ה)(\p{Mn}*)", "$1ק$3$4ק$6");
            }
            else if (Properties.Settings.Default.ShemHashemDisplayOptions == 4)
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

        public static string FixBookLink(this string input)
        {
            input = input.Replace("' ", ", "); // link format = '
            input = Regex.Replace(input, @" *(\S*?)-", ", $1, "); //link format = בראשית א-יד replace to בראשית, א, יד
            input = Regex.Replace(input, @" *(\S*?['""]+\S*) ", ", $1,"); //linkformat = בראשית א' or בראשית י"ד  replace to 
            

            input = input.Trim(',')
                        .Replace("\'", "")
                        .Replace("\"", "")
                        .Replace(".", "")
                        .Replace(":", " ב")
                .Replace("ב\"ק", "בבא קמא")
                 .Replace("ב\"מ", "בבא מציעא")
                  .Replace("ב\"ב", "בבא בתרא")
                   .Replace("ר\"ה", "ראש השנה")
                    .Replace("ע\"ז", "עבודה זרה")
                    .Replace("ב\"ר", "בראשית רבה")
                    .Replace("שמ\"ר", "שמות רבה")
                     .Replace("שמו\"ר", "שמות רבה")
                      .Replace("ויקר\"ר", "ויקרא רבה")
                       .Replace("במ\"ר", "במדבר רבה")
                        .Replace("דב\"ר", "דברים רבה")                       
                       ;

            return input;
        }

        //public static string GetCleanFileName(this string input)
        //{
        //    if (input.Contains("ToratEmetInstall")) { input = TransaltorClass.TranslateFilename(input); }
        //    string output = Path.GetFileNameWithoutExtension(input);
        //    output = Regex.Replace(output, @"\d+_?", "");
        //    return output;
        //}

        //public static string GetCleanFolderName(this string input)
        //{
        //    if (input.Contains("ToratEmetInstall")) { input = TransaltorClass.TranslateFolderName(input); }
        //    string output = Path.GetFileName(input);
        //    output = Regex.Replace(output, @"\d+_?", "").Replace("MyBooks", "הספרים שלי");
        //    return output;
        //}

        //public static string CleanBookName(this string input)
        //{
        //    input = input.Replace("תלמוד בבלי - ", "");
        //    return input;
        //}
    }
}
