using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public class MergedBooksCompiler
    {
        public void MergeFiles(string outputFilePath, params string[] filePaths)
        {
            // Check if there are at least two files to merge
            if (filePaths.Length < 2)
            {
                MessageBox.Show("Please provide at least two file paths to merge.");
                return;
            }

            // Read the content of all files
            List<List<string>> allFileLines = filePaths.Select(path => File.ReadAllLines(path).ToList()).ToList();

            // Merge the lines with the same markers
            List<string> mergedLines = MergeAllLines(allFileLines);

            // Write the merged content to a new file
            File.WriteAllLines(outputFilePath, mergedLines.ToArray());

            Console.WriteLine("Files merged successfully.");
        }

        static List<string> MergeAllLines(List<List<string>> allLines)
        {
            int minLinesCount = allLines.Min(lines => lines.Count);
            List<string> mergedLines = new List<string>();

            for (int i = 0; i < minLinesCount; i++)
            {
                // Use LINQ to check if all lines at index i start with the same marker
                if (allLines.All(lines => lines[i].StartsWith(allLines[0][i][0].ToString())))
                {
                    // Combine lines with the same markers
                    mergedLines.Add(string.Join(Environment.NewLine, allLines.Select(lines => lines[i])));
                }
                else
                {
                    // Add lines without merging
                    mergedLines.AddRange(allLines.Select(lines => lines[i]));
                }
            }
            return mergedLines;
        }
    }
}
