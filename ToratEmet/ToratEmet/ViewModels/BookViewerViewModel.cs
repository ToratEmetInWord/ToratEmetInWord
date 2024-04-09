using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToratEmet.BookParsingModels;
using ToratEmet.Controls;
using ToratEmet.Models;
using ToratEmet.TreeModels;
using ToratEmet.WebViewModels;


namespace ToratEmet.ViewModels
{
    public class BookViewerViewModel : INotifyPropertyChanged
    {
        BookViewer bookViewer;
        public TabItem tabItem;
        public WebView2 webView;
        public BookItem currentBook;
        public ChapterItem currentChapter;
        bool isComboView = false;
        public double scrollPosition = 0;
        CheckBox combinedViewCheckbox;
        public string currentId { get; set; }   

        private string _adressBlocktext = "";

        #region bindings
        private ObservableCollection<object> _comboViewlist = new ObservableCollection<object>();
        public string AdressBlockText
        {
            get { return _adressBlocktext; }
            set
            {
                if (_adressBlocktext != value)
                {
                    _adressBlocktext = value;
                    OnPropertyChanged(nameof(AdressBlockText));
                }
            }
        }
        public ObservableCollection<object> ComboViewlist
        {
            get { return _comboViewlist; }
            set
            {
                _comboViewlist = value;
                OnPropertyChanged(nameof(ComboViewlist));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        //public void Dispose()
        //{
        //    if (webView != null) { webView.Dispose(); }
        //    currentBook = null;
        //    currentChapter  = null;
        //    ComboViewlist  = null;
        //    combinedViewCheckbox  = null;
        //}
       
        public BookViewerViewModel(BookViewer viewer, BookItem bookitem, WebView2 webview, TabItem tabitem)
        {
            bookViewer = viewer;
            tabItem = tabitem;
            currentBook = bookitem;
            webView = webview;
            webview.CoreWebView2InitializationCompleted +=Webview_CoreWebView2InitializationCompleted;
        }

        private void Webview_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            NavigateToItem(currentChapter, currentId != null ? currentId : "", null);
            WebViewContextMenu webViewContextMenu = new WebViewContextMenu();
            webViewContextMenu.CreateCustomContextMenu(this, currentBook.RelativeBooks, tabItem);
            bookViewer.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        /// 

        public async void ShowChapterTree()
        {
            try
            {
                var result = await webView.CoreWebView2.ExecuteScriptWithResultAsync("toggleTreeview()");
                if (!result.Succeeded)
                {
                    MessageBox.Show("המסמך עדיין בטעינה אנא המתינו כמה רגעים.\r\n (במקרה שהשגיאה ממשיכה לאחר מספר רגעים\r\n מומלץ ללחוץ על הלחצן \"הצג פחות\" ⇲)", "שגיאת מסמכים ארוכים", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                }
            }
            catch
            {
                try
                {
                    var result = await webView.ExecuteScriptAsync("toggleTreeview()");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ComboViewItemsCheckChange()
        {
            if (isComboView) { NavigateToItem(currentChapter, "", false); }
        }
        public void NavigateToHeader(ChapterItem chapterItem)
        {
            Navigate_To_Header navigater = new Navigate_To_Header(this);
            navigater.Navigate(chapterItem);
        }
        
        public void NavigateToItem(ChapterItem targetChapter, string itemId, bool? IsShowingMore)
        {
            if (currentBook == null) { return; }
            if (string.IsNullOrEmpty(itemId)) { itemId = currentBook.Title; }

            List<TreeItem> comboViewItems = currentBook.RelativeBooks
                    .Where(checkedItem => checkedItem is TreeItem checkedTreeItem && checkedTreeItem.IsChecked == true)
                    .Cast<TreeItem>()
                    .ToList();

            BookExport bookExport = new BookExport();
            string content = bookExport.Export(targetChapter, itemId, scrollPosition,
                isComboView, comboViewItems, currentBook.RootItem);

            try { webView.NavigateToString(content); currentChapter = targetChapter; }
            catch 
            {
                if (targetChapter != currentBook.RootItem || IsShowingMore == false)
                {
                    WebViewCommands.WebViewNavigateToString(content, webView);
                    currentChapter = targetChapter;
                }
                else if (IsShowingMore == null)
                {
                    currentChapter = targetChapter.Children[0];
                    content = bookExport.Export(currentChapter, itemId, scrollPosition, isComboView,
                            comboViewItems, currentBook.RootItem);
                    WebViewCommands.WebViewNavigateToString(content, webView);
                }
                else 
                {
                    MessageBox.Show("אין אפשרות להציג עוד - הקובץ גדול מדאי");
                }
            }

            if (!string.IsNullOrEmpty(targetChapter.Id)) { AdressBlockText = currentChapter.Id; }
            else { AdressBlockText = currentBook.Title; }

            WebViewMessageHandler webViewMessageHandler = new WebViewMessageHandler();
            webViewMessageHandler.BookViewAttachEvent(this, webView);
        }
        public void PopulateRealtiveBooksCombo()
        {
            if (ComboViewlist.Count == 0)
            {
                ComboViewlist = currentBook.RelativeBooks;

                ComboViewlist.Insert(0, new Separator());

                combinedViewCheckbox = new CheckBox { Content = "תצוגה משולבת", Margin = new Thickness(0, -1, 0, 0) }; ;
                combinedViewCheckbox.Checked += (sender, e) => { isComboView = true; NavigateToItem(currentChapter, "", false); };
                combinedViewCheckbox.Unchecked += (sender, e) => { isComboView = false; NavigateToItem(currentChapter, "", false); };
                ComboViewlist.Insert(0, combinedViewCheckbox);

                CheckBox checkAllCheckBox = new CheckBox { Content = "סמן הכל", };
                checkAllCheckBox.Checked += (sender, e) => { CheckAllCheckBox_CheckChanged(checkAllCheckBox); };
                checkAllCheckBox.Unchecked += (sender, e) => { CheckAllCheckBox_CheckChanged(checkAllCheckBox); };
                ComboViewlist.Insert(1, checkAllCheckBox);
            }
        }
        private void CheckAllCheckBox_CheckChanged(CheckBox checkBox)
        {
            foreach (var item in ComboViewlist)
            {
                if (item is FileTreeItem fileTreeItem)
                {
                    fileTreeItem.IsChecked = checkBox.IsChecked;
                }
            }
        }
        public void ViewInfo()
        {
            if (string.IsNullOrEmpty(currentBook.Info)) { MessageBox.Show("אין מידע עבור ספר זה"); }
            else
            {
                BookInfoBox infoBox = new BookInfoBox(currentBook.Info) { Title = "מידע וזכויות יוצרים עבור: " + currentBook.Title, };
                infoBox.Show();
            }
        }
        public void ShowLess()
        {
            var validChildren = currentChapter.Children
                    .Where(child => child is ChapterItem chapter && chapter.Content != null && !string.IsNullOrEmpty(chapter.Id))
                    .ToList();

            if (validChildren.Any())
            {
                ChapterItem targetChapter = validChildren.FirstOrDefault(target => target.Id.StartsWith(currentId));
                scrollPosition = 0;
                if (targetChapter != null) { NavigateToItem(targetChapter, currentId, false); }
                else { NavigateToItem(validChildren[0], currentId, false); }
            }
        }
        public void ShowMore()
        {
            if (currentChapter!= null && currentChapter.Parent != null) 
            {
                scrollPosition = 0;
                NavigateToItem(currentChapter.Parent, currentId, true); 
            }
        }
        public void ShowPrevious()
        {
            if (currentChapter.Parent != null)
            {
                scrollPosition = 0;
                ChapterItem parent = currentChapter.Parent;
                StringBuilder stringBuilder = new StringBuilder();

                int currentChapterIndex = parent.Children.IndexOf(currentChapter);
                if (currentChapterIndex > 0) //check if there is anywhere to go back to
                {
                    ChapterItem chapterItem = parent.Children[currentChapterIndex - 1] as ChapterItem;
                    NavigateToItem(chapterItem, chapterItem.Id, false);
                }
                else //if item is first item - attempt to go back to last item prevoius section
                {
                    if (parent.Parent != null)
                    {
                        ChapterItem grandParent = currentChapter.Parent.Parent;
                        int currentParentIndex = grandParent.Children.IndexOf(parent);
                        if (currentParentIndex > 0) //check if there is anywhere to go back to
                        {
                            parent = grandParent.Children[currentParentIndex - 1] as ChapterItem;
                            var child = parent.Children[parent.Children.Count - 1] as ChapterItem;
                            NavigateToItem(child, child.Id, false);
                        }
                    }
                }
            }
        }
        public void ShowNext()
        {
            if (currentChapter.Parent != null)
            {
                scrollPosition = 0;
                ChapterItem parent = currentChapter.Parent;

                int currentChapterIndex = parent.Children.IndexOf(currentChapter);
                if (currentChapterIndex < (parent.Children.Count - 1)) // check if is last item in list
                {
                    ChapterItem chapter = parent.Children[currentChapterIndex + 1];
                    NavigateToItem(chapter, chapter.Id, false);
                }
                else // if is last item - attempt to fetch first iem in next section
                {
                    if (parent.Parent != null)
                    {
                        ChapterItem grandParent = currentChapter.Parent.Parent;
                        int currentParentIndex = grandParent.Children.IndexOf(parent);
                        if (currentParentIndex < (grandParent.Children.Count - 1))
                        {
                            parent = grandParent.Children[currentParentIndex + 1] as ChapterItem;
                            if (parent.Children.Count > 0)
                            {
                                ChapterItem child = parent.Children[0] as ChapterItem;
                                NavigateToItem(child, child.Id, false);
                            }
                            else
                            {
                                NavigateToItem(parent, parent.Id, false);
                            }
                        }
                    }
                }
            }
        }
        public void ToggleHideNikud()
        {
            WebViewCommands.ToggleHideNikud(webView);
        }
        public void ToggleHideCantillations()
        {
            WebViewCommands.ToggleHideCantillations(webView);
        }
        public void RefreshPage()
        {
            NavigateToItem(currentChapter, currentChapter.Id, false);
        }
        public void SearchNext(string searchText)
        {
            WebViewCommands.SearchNext(searchText, webView);
        }
        public void SearchPrevious(string searchText)
        {
            WebViewCommands.SearchPrevious(searchText, webView);
        }
        public void OpenRelativeBook(FileTreeItem fileTreeItem)
        {
            OpenSelected openSelected = new OpenSelected();
            openSelected.OpenSelectedFile(fileTreeItem, currentChapter.Id, "", tabItem.Parent as TabControl);
        }

        //public void CreateBookMark()
        //{
        //    string bookMark = $"{currentBook.FilePath}|{AdressBlockText}|{currentId}";
        //}
    }
}
