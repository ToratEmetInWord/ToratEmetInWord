using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TextSearchApp.SearchModels;
using TextSearchApp;
using תורת_אמת_בוורד_3._1._1.Controls;
using Microsoft.Web.WebView2.Wpf;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_בוורד_3._1._8.Extensions;

namespace תורת_אמת_בוורד_3._1._2.ViewModels
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
        bool _searchAllCheckBox = Properties.Settings.Default.SearchALL;
        bool _chooseBooksIsEnabled =! Properties.Settings.Default.SearchALL;
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
            get { return _searchAllCheckBox; }
            set
            {
                if (_searchAllCheckBox != value)
                {
                    ChooseBooksIsEnabled =! value;
                    Properties.Settings.Default.SearchALL = value;
                    Properties.Settings.Default.Save();
                    _searchAllCheckBox = value;
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
        bool isBusy = false;
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

                    TreeItem TreeItem = StaticGlobals.treeItemsList.FirstOrDefault(item => item.Address == splitMessage[0]);
                    string targetId = splitMessage[1].CleanHeaders().RemoveTextTillFirstChar(',').Trim();
                    
                    OpenSelected openSelected = new OpenSelected();
                    openSelected.OpenSelectedFile(TreeItem, targetId, null);
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

        public async void Search()
        {
            try
            { 
            if (string.IsNullOrEmpty(SearchString))
            {
                MessageBox.Show("אנא הזן טקסט לחיפוש");
            }
            else if (isBusy)
            {
                MessageBox.Show("התוכנה עסוקה בפעולות קודמות אנא המתן");
            }
            else
            {
                ProgressBarVisibility = Visibility.Visible;
                isBusy =true;
                string searchText = SearchString.ShemHashemWritingReverse();

                RecentSearches recentSearches = new RecentSearches();
                recentSearches.UpdateList(searchText);

                await searchMethod.ExcuteSearchMethod(searchText);
                resultsList = searchMethod.GetSearchResults();
                if (resultsList != null && resultsList.Count >  0)
                {
                    string result = $"<p>נמצאו {resultsList.Count} תוצאות</p>\r\n{string.Join(Environment.NewLine, resultsList)}";
                    string content = HtmlPage(result);
                    ShowResults(content);
                }
                else { MessageBox.Show("לא נמצאו תוצאות"); }               
                MaxProgress = 100;
                ProgressBarVisibility = Visibility.Collapsed;
                isBusy = false;
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
                webView.CoreWebView2.Navigate(tempFilePath);
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

