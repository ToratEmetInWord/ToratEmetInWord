using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToratEmet.Extensions
{
    static class HebrewNumbering
    {
        static Dictionary<int, string> HebNumbers = new Dictionary<int, String>
        {

        {400, "ת"},

        {300, "ש"},

        {200, "ר"},

        {100, "ק"},

        {90, "צ"},

        {80, "פ"},

        {70, "ע"},

        {60, "ס"},

        {50, "נ"},

        {40, "מ"},

        {30, "ל"},

        {20, "כ"},

        {19, "יט"},

        {18, "יח"},

        {17, "יז"},

        {16, "טז"},

        {15, "טו"},

        {10, "י"},

        {9, "ט"},

        {8, "ח"},

        {7, "ז"},

        {6, "ו"},

        {5, "ה"},

        {4, "ד"},

        {3, "ג"},

        {2, "ב"},

        {1, "א"},

        };





        public static int ToNumber(this string numHeb)

        {

            int last = 0;

            int total = 0;



            while (numHeb.Length > 0)

            {

                var next = HebNumbers.Where(v => numHeb.EndsWith(v.Value)).OrderBy(v => v.Key).LastOrDefault();

                if (next.Key <= last)

                    return -1;



                last = next.Key;

                total += last;

                numHeb = numHeb.Remove(numHeb.Length - next.Value.Length);

            }



            return total;

        }



        public static string ToHebNumber(this int num)

        {

            string hebrewNumber = "";

            while (num > 0)

            {

                var key = HebNumbers.SkipWhile(pair => pair.Key > num).First();

                hebrewNumber += key.Value;

                num -= key.Key;

            }

            hebrewNumber = hebrewNumber.Replace("יה", "טו");
            hebrewNumber = hebrewNumber.Replace("יו", "טז");

            hebrewNumber.Replace("רעב", "ערב");
            hebrewNumber.Replace("רעד", "עדר");
            hebrewNumber.Replace("רע", "ער");
            hebrewNumber.Replace("רצח", "רחצ");
            hebrewNumber.Replace("תשמד", "תדשם");
            hebrewNumber.Replace("שמד", "שדמ");
            hebrewNumber.Replace("שד", "דש");

            return hebrewNumber;

        }
    }
}
