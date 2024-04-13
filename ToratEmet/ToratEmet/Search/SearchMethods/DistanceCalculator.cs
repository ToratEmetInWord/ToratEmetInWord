using System;
using System.Collections.Generic;
using System.Linq;

namespace ToratEmet.SearchModels
{
    public static class DistanceCalculator
    {
        public static bool StringContains(this string line, string[] searchPatternArray, int maxDistance)
        {
            string shortestString = searchPatternArray.OrderBy(s => s.Length).FirstOrDefault();
            maxDistance = maxDistance - shortestString.Length;
            List<List<int>> wordIndexesList = new List<List<int>>();

            // Get indexes of each word in the line
            foreach (string word in searchPatternArray)
            {
                var indexes = AllIndexesOf(line, word).ToList();
                wordIndexesList.Add(indexes);
            }

            if (wordIndexesList.Any(list => list.Count == 0))
                return false;

            // Calculate if there is an occurrence of all words within the max distance
            return IsWithinMaxDistance(wordIndexesList, maxDistance);
        }
        static IEnumerable<int> AllIndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find may not be empty", nameof(value));

            int index = 0;
            while (index < str.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
                index += value.Length;
            }
        }

        static bool IsWithinMaxDistance(List<List<int>> wordIndexesList, int maxDistance)
        {
            // Check if all words occur within the maximum distance
            for (int i = 0; i < wordIndexesList[0].Count; i++)
            {
                int startIndex = wordIndexesList[0][i];
                for (int j = 1; j < wordIndexesList.Count; j++)
                {
                    bool found = false;
                    for (int k = 0; k < wordIndexesList[j].Count; k++)
                    {
                        int endIndex = wordIndexesList[j][k];
                        int distance = Math.Abs(endIndex - startIndex);
                        if (distance <= maxDistance)
                        {
                            found = true;
                            break;
                        }
                        else if (endIndex > startIndex)
                        {
                            // No need to check further as the indexes are sorted
                            break;
                        }
                    }
                    if (!found)
                        goto NextStartIndex;
                }
                return true;

NextStartIndex:
                continue;
            }
            return false;
        }

    }
    public static class LooseDistanceCalculator
    {
        public static bool StringLooslyContains(this string line, string[] searchPatternArray, int maxDistance)
        {
            maxDistance = maxDistance  * 30;

            List<List<int>> wordIndexesList = new List<List<int>>();

            // Get indexes of each word in the line
            foreach (string word in searchPatternArray)
            {
                var indexes = AllIndexesOf(line, word).ToList();
                wordIndexesList.Add(indexes);
            }

            var validIndexes = wordIndexesList.Where(list => list.Count > 0).ToList();
            double targetcount = wordIndexesList.Count * 0.8;
            if (validIndexes.Count() < (wordIndexesList.Count * 0.8))
                return false;


            // Calculate if there is an occurrence of all words within the max distance
            return IsWithinMaxDistance(validIndexes, maxDistance);
        }

        static IEnumerable<int> AllIndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find may not be empty", nameof(value));

            int index = 0;
            while (index < str.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
                index += value.Length;
            }
        }

        static bool IsWithinMaxDistance(List<List<int>> wordIndexesList, int maxDistance)
        {
            if (wordIndexesList.Count == 0) { return false; }

            // Check if all words occur within the maximum distance
            for (int i = 0; i < wordIndexesList[0].Count; i++)
            {
                int startIndex = wordIndexesList[0][i];
                for (int j = 1; j < wordIndexesList.Count; j++)
                {
                    bool found = false;
                    for (int k = 0; k < wordIndexesList[j].Count; k++)
                    {
                        int endIndex = wordIndexesList[j][k];
                        int distance = Math.Abs(endIndex - startIndex);
                        if (distance <= maxDistance)
                        {
                            found = true;
                            break;
                        }
                        else if (endIndex > startIndex)
                        {
                            // No need to check further as the indexes are sorted
                            break;
                        }
                    }
                    if (!found)
                        goto NextStartIndex;
                }
                return true;

NextStartIndex:
                continue;
            }
            return false;
        }
    }

}
