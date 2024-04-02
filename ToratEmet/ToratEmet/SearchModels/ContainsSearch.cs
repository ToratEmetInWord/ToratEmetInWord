using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet
{
    public class ContainsSearch : SearchMethods
    {
        public ContainsSearch(SearchControlViewModel viewModel) : base(viewModel){ }  
        public async Task SearchAsync(string searchPattern)
        {
            resultsDictionary = new Dictionary<string, List<string>>();
            List<Task> searchTasks = new List<Task>();
            foreach (string filePath in filesList)
            {
                resultsDictionary.Add(filePath, new List<string>());
                searchTasks.Add(Task.Run(() => { processFile(filePath, searchPattern); }));
            }
            await Task.WhenAll(searchTasks);
            viewModel.UpdateProgressBar(1);
        }
        void processFile(string filePath, string searchPattern)
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
                    else if (line.Contains(searchPattern))
                    {
                        line = CleanContent(line);
                        List<string> snippetList = SnippetBuilder.SplitStringIntoSnippets(line, 500, searchPattern.Length + 10);
                        foreach (string snippet in snippetList) 
                        {
                            if (snippet.Contains(searchPattern))
                            {
                                currentReslutList.Add(ResultItem(
                                    filePath,
                                    snippet.Replace(searchPattern, $"<span style=\"color:magenta\">{searchPattern}</span>"),
                                    currentHeader
                                    ));
                            }
                        }
                    }
                }
            }
            resultsDictionary[filePath] = currentReslutList;
        }
    }
}
