using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms.PropertyGridInternal;
using TextSearchApp.SearchModels;
using תורת_אמת_בוורד_3._1;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._8.Extensions;
using תורת_אמת_בוורד_3._1.Properties;

namespace TextSearchApp
{
    public class SearchMethods
    {
        public SearchControlViewModel viewModel { get; set; }
        public List<string> filesList = new List<string>();
        public Dictionary<string, List<string>> resultsDictionary;
        public string[] startChars = { "!", "~", "^", "@", "<h", "<H" }; //public string[] startChars = { "!", "~", "^", "@", "הקדמה", "<h", "<H", "שער", "פתיחה" };       

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
            else if (viewModel.searchMethod is LuceneSearch luceneSearch)
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
            else if (Settings.Default.SearchExplorerTabIndex == 0)
            {
                filesList = StaticGlobals.treeItemsList.Where(item => item.IsChecked == true).Select(item => item.Address).ToList();
                if (filesList.Count == 0)
                {
                    filesList.AddRange(Settings.Default.CheckedTreeItems.Cast<string>());
                }
            }
            else if (Settings.Default.SearchExplorerTabIndex == 1)
            {
                filesList = StaticGlobals.treeItemsList.Where(item => item.IsChecked2 == true).Select(item => item.Address).ToList();
                if (filesList.Count == 0)
                {
                    filesList.AddRange(Settings.Default.CheckedListBoxItems.Cast<string>());
                }
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
            return Regex.Replace(line, @"[^\p{IsHebrew}]{2,}|[\\+<>]+", " ");
        }
    }
}
