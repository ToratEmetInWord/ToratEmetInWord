using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToratEmet.ViewModels;
using ToratEmet;
using ToratEmet.SearchModels;
using ToratEmet.Extensions;
using ToratEmet.Models;
using System.Threading;

namespace ToratEmet
{
    public class SearchMethods
    {
        public SearchControlViewModel viewModel { get; set; }
        public List<string> filesList = new List<string>();
        public Dictionary<string, List<string>> resultsDictionary;
        public string[] startChars = { "!", "~", "^", "@", "<h", "<H" }; //public string[] startChars = { "!", "~", "^", "@", "הקדמה", "<h", "<H", "שער", "פתיחה" };       
        public CancellationTokenSource cancellationTokenSource { get; set; }

        public SearchMethods(SearchControlViewModel viewmodel)
        {
            viewModel = viewmodel;            
        }

        public async Task ExcuteSearchMethod(string searchString)
        {
            SetFilesList();

            if (viewModel.searchMethod is DistanceSearch directMethod)
            {
                await directMethod.SearchAsync(searchString);
            }
            else if (viewModel.searchMethod is RegexSearch regexMethod)
            {
                await regexMethod.SearchAsync(searchString);
            }
            else if (viewModel.searchMethod is FreeFormSearch freeFormMethod)
            {
                await freeFormMethod.SearchAsync(searchString);
            }
            else if (viewModel.searchMethod is LuceneWildCardSearch luceneSearch)
            {
                await luceneSearch.ExecuteSearch(searchString);
            }
            viewModel.UpdateProgressBar(-1);
        }

        void SetFilesList()
        {
            if (viewModel.SearchAll == true)
            {
                filesList = StaticGlobals.treeItemsList.Select(item => item.Address).ToList();
            }
            else if (Properties.Settings.Default.SearchExplorerTabIndex == 0)
            {
                filesList = StaticGlobals.treeItemsList.Where(item => item.IsChecked == true).Select(item => item.Address).ToList();
                if (filesList.Count == 0)
                {
                    filesList.AddRange(Properties.Settings.Default.CheckedTreeItems.Cast<string>());
                }
            }
            else if (Properties.Settings.Default.SearchExplorerTabIndex == 1)
            {
                filesList = StaticGlobals.treeItemsList.Where(item => item.IsChecked2 == true).Select(item => item.Address).ToList();
                if (filesList.Count == 0)
                {
                    filesList.AddRange(Properties.Settings.Default.CheckedListBoxItems.Cast<string>());
                }
            }

            if (filesList.Count == 0) 
            {
                filesList = StaticGlobals.treeItemsList.Select(item => item.Address).ToList();
            }
            
            viewModel.MaxProgress = filesList.Count;
        }

        public List<string> GetSearchResults()
        {
            if (resultsDictionary == null) { return  null; }
            return resultsDictionary.Values.SelectMany(list => list).ToList();
        }
        public string ResultItem(string filePath, string content, string currentHeader)
        {
            return $@"
                            <details>
                                <summary>
                                    <a href=""#result"" id='{filePath}' onclick=""sendMessage(this)"">
                                    {TransaltorClass.TranslateFilename(filePath)}, {currentHeader}
                                    </a>
                                </summary>
                                <p>
                                {content.ShemHashemWriting()}
                                </p>
                            </details>";
        }
        public string CleanContent(string line)
        {
            line = Regex.Replace(line, @"<.*?>", "");
            return Regex.Replace(line, @"[^\p{IsHebrew}']{2,}|[\\+<>]+", " ");
        }
    }
}
