using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToratEmet.GlobalMethods.Models
{
    public static class Jaccard
    {
        public static double JaccardBasic(string s1, string s2)
        {
            string[] wordsS1 = s1.Split(' ');
            string[] wordsS2 = s2.Split(' ');

            // Calculate Jaccard similarity coefficient
            double intersection = wordsS1.Intersect(wordsS2).Count();
            double union = wordsS1.Union(wordsS2).Count();

            return intersection / union;
        }

        public static double BasicIntersectCalculation(string s1, string s2)
        {
            string[] wordsS1 = s1.Split(' ');
            string[] wordsS2 = s2.Split(' ');

            return wordsS1.Intersect(wordsS2).Count();
        }
    }
}
