using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class Levenshtein
    {
        public static bool LevenshtienByArray(string shortString, string longStrong, int distance)
        {
            string[] words1 = shortString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = longStrong.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return CompareArray(words1, words2, distance);
        }
        public static bool CompareArray(string[] shortString, string[] longStrong, int distance)
        {
            return shortString.All(word1 => longStrong.Any(word2 => LevenshteinDistance(word1, word2) < distance));
        }
        public static int LevenshteinDistance(string s, string t)
        {
            // Special cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;
            // Initialize the distance matrix
            int[,] distance = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++) distance[i, 0] = i;
            for (int j = 0; j <= t.Length; j++) distance[0, j] = j;
            // Calculate the distance
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }
            // Return the distance
            return distance[s.Length, t.Length];
        }
    }
}
