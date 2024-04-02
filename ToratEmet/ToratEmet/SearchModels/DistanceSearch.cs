using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet.SearchModels
{
    public class DistanceSearch : SearchMethods
    {
        public DistanceSearch(SearchControlViewModel viewModel) : base(viewModel) { }
        public async Task SearchAsync(string searchPattern)
        {
            resultsDictionary = new Dictionary<string, List<string>>();
            string[] searchPatternArray = searchPattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Task> searchTasks = new List<Task>();
            foreach (string filePath in filesList)
            { 
                resultsDictionary.Add(filePath, new List<string>());
                searchTasks.Add(Task.Run(() => { processFile(filePath, searchPatternArray, searchPattern); }));
            }
            await Task.WhenAll(searchTasks);
            
        }
        void processFile(string filePath, string[] searchPatternArray, string searchPattern)
        {
            ProcessHeaders processHeaders = new ProcessHeaders();
            string currentHeader = "";
            viewModel.UpdateProgressBar(1);
            List<string> currentReslutList = new List<string>();

            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (startChars.Any(c => line.StartsWith(c)))
                    {
                        currentHeader = processHeaders.Execute(line, filePath);
                        continue;
                    }
                    //else if (searchPatternArray.All(word => line.Contains(word)))
                    else if (line.StringContains(searchPatternArray, searchPattern.Length))
                    {
                        line = CleanContent(line);
                        List<string> snippetList = SnippetBuilder.SplitStringIntoSnippets(line, 400, searchPattern.Length + 10);
                        for (int i = 0; i < snippetList.Count; i++)
                        {
                            if (snippetList[i].StringContains(searchPatternArray, searchPattern.Length))
                            {
                                for (int x = 0; x < searchPatternArray.Length; x++)
                                {
                                    snippetList[i] = snippetList[i].Replace(searchPatternArray[x], $"<span style=\"color:magenta\">{searchPatternArray[x]}</span>");
                                }
                                currentReslutList.Add(ResultItem(filePath, snippetList[i], currentHeader));
                            }
                        }
                    }
                }
            }
            resultsDictionary[filePath] = currentReslutList;
        }
    }
}
