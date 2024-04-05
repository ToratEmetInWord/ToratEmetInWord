using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet;
using ToratEmet.Controls;
using ToratEmet.Extensions;
using ToratEmet.Models;
using ToratEmet.SearchModels;
using ToratEmet.TreeModels;
using ToratEmet.WebViewModels;

namespace ToratEmet.ViewModels
{
    public class SearchControlViewModel : INotifyPropertyChanged
    {
        #region bindings
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _searchString;
        private double _maxProgress = 100;
        bool _regexComboisEnabled;
        bool _SearchAllCheckBox = Properties.Settings.Default.SearchAll;
        bool _chooseBooksIsEnabled = !Properties.Settings.Default.SearchAll;
        bool _expandSnippets;
        Visibility _progressBarVisibility = Visibility.Collapsed;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString != value)
                {
                    _searchString = value;
                    OnPropertyChanged(nameof(SearchString));
                }
            }
        }
        public Visibility ProgressBarVisibility
        {
            get { return _progressBarVisibility; }
            set
            {
                if (_progressBarVisibility != value)
                {
                    _progressBarVisibility = value;
                    OnPropertyChanged(nameof(ProgressBarVisibility));
                }
            }
        }
        public double MaxProgress
        {
            get { return _maxProgress; }
            set
            {
                if (_maxProgress != value)
                {
                    _maxProgress = value;
                    OnPropertyChanged(nameof(MaxProgress));
                }
            }
        }
        public bool RegexComboisEnabled
        {
            get { return _regexComboisEnabled; }
            set
            {
                if (_regexComboisEnabled != value)
                {
                    _regexComboisEnabled = value;
                    OnPropertyChanged(nameof(RegexComboisEnabled));
                }
            }
        }
        public bool SearchAll
        {
            get { return _SearchAllCheckBox; }
            set
            {
                if (_SearchAllCheckBox != value)
                {
                    ChooseBooksIsEnabled = !value;
                    Properties.Settings.Default.SearchAll = value;
                    Properties.Settings.Default.Save();
                    _SearchAllCheckBox = value;
                    OnPropertyChanged(nameof(SearchAll));
                }
            }
        }

        public bool ChooseBooksIsEnabled
        {
            get { return _chooseBooksIsEnabled; }
            set
            {
                if (_chooseBooksIsEnabled != value)
                {
                    _chooseBooksIsEnabled = value;
                    OnPropertyChanged(nameof(ChooseBooksIsEnabled));
                }
            }
        }

        public bool ExpandSnippets
        {
            get { return _expandSnippets; }
            set
            {
                if (_expandSnippets != value)
                {
                    _expandSnippets = value;
                    OnPropertyChanged(nameof(ExpandSnippets));
                }
            }
        }

        #endregion

        SearchControl searchControl;
        public WebView2 webView;
        public SearchMethods searchMethod;
        List<string> resultsList = new List<string>();
        public SearchControlViewModel(SearchControl searchcontrol)
        {
            searchControl = searchcontrol;
        }
        public void UpdateProgressBar(double value)
        {
            ProgressBarDelgate.progressReporter.Report(value);
        }

        public void InitializeWebview()
        {
            webView = searchControl.webView;
            webView.WebMessageReceived += (sender, e) =>
            {
                try
                {
                    string message = e.TryGetWebMessageAsString();
                    message = message.Replace("\r", "").Replace("\n", "");
                    message = Regex.Replace(message, @"\s{2,}", "");
                    string[] splitMessage = message.Split('|');

                    TreeItem treeItem = StaticGlobals.treeItemsList.FirstOrDefault(item => item.Address == splitMessage[0]);
                    string targetId = splitMessage[1].CleanHeaders().RemoveTextTillFirstChar(',').Trim();

                    OpenSelected openSelected = new OpenSelected();
                    openSelected.OpenSelectedFile(treeItem, targetId, null);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            };
        }

        public void SetSearchType(string searchType)
        {
            if (searchType == "חיפוש רגיל") { searchMethod = new DistanceSearch(this); RegexComboisEnabled = false; }
            else if (searchType == "חיפוש רגקס") { searchMethod = new RegexSearch(this, false); RegexComboisEnabled = true; }
            else if (searchType == "חיפוש רגקס רחב") { searchMethod = new RegexSearch(this, true); RegexComboisEnabled = true; }
            else if (searchType == "חיפוש בנוסח חופשי") { searchMethod = new FreeFormSearch(this); RegexComboisEnabled = false; }
            else if (searchType == "חיפוש מהיר") { searchMethod = new LuceneSearch(this); RegexComboisEnabled = false; }
        }

        public async Task Search()
        {
            try
            {
                if (string.IsNullOrEmpty(SearchString))
                {
                    MessageBox.Show("אנא הזן טקסט לחיפוש");
                }
                else
                {
                    ProgressBarVisibility = Visibility.Visible;
                    string searchText = SearchString.ShemHashemWritingReverse();

                    RecentSearches recentSearches = new RecentSearches();
                    recentSearches.UpdateList(searchText);

                    await searchMethod.ExcuteSearchMethod(searchText);
                    resultsList = searchMethod.GetSearchResults();
                    if (resultsList != null && resultsList.Count > 0)
                    {
                        string result = $"<p>נמצאו {resultsList.Count} תוצאות</p>\r\n{string.Join(Environment.NewLine, resultsList)}";
                        string content = HtmlPage(result);
                        ShowResults(content);
                    }
                    else { MessageBox.Show("לא נמצאו תוצאות"); }
                    MaxProgress = 100;
                    ProgressBarVisibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ShowResults(string content)
        {
            try
            {
                // Try navigating directly to the content
                webView.NavigateToString(content);
            }
            catch
            {
                // If navigating to content fails, create a temporary file and navigate to it
                string tempFilePath = Path.Combine(Path.GetTempPath(), "temp.html");
                File.WriteAllText(tempFilePath, content);
                webView.Dispatcher.Invoke((Action)(() =>
                {
                    webView.CoreWebView2.Navigate(tempFilePath);
                }));               
           }
            if (ExpandSnippets) { WebViewCommands.ToggleSnippets(webView, true); }
        }

        string HtmlPage(string content)
        {
            string head = $"<html lang=\"en\">\r\n<head>\r\n<meta charset=\"UTF-8\"></head>{Css()}<body dir=\"rtl\"";
            return $"{head}\r\n{content}{Js()}</body></html>";
        }
        string Css()
        {
            return $@"<style>
                    body{{
                    font-family:{Properties.Settings.Default.HtmlFontFamily} ;
                    font-size: {Properties.Settings.Default.HtmlFontSize}%;
                    }}
                    p{{text-align: justify; margin:5px;}}
                    details{{margin-bottom:10px;}}
                    a {{ text-decoration: none; color: blue; }}
                    a:active {{ color: blue; }}
                    summary:hover{{background-color:whitesmoke;}}
                    </style>";
        }
        string Js()
        {
            return $@"<script>
function sendMessage(item) {{
    window.chrome.webview.postMessage(item.id + '|' + item.innerHTML);
}}
var isDetailsCollapsed = true;
</script>
";
        }
    }
}


