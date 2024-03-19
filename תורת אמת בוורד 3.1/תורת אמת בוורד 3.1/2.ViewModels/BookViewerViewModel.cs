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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Converters;
using תורת_אמת_בוורד_3._1._1.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_בוורד_3._1.TreeModels;


namespace תורת_אמת_בוורד_3._1._2.ViewModels
{
    public class BookViewerViewModel : IDisposable, INotifyPropertyChanged
    {
        BookViewer bookViewer;
        public TabItem tabItem;
        public WebView2 webView;
        public BookItem currentBook;
        public ChapterItem currentChapter;
        bool isComboView = false;
        CheckBox combinedViewCheckbox;
        public string currentId;
        bool paragraphsisExpanded = true;

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
        public void Dispose()
        {
            if (webView != null) { webView.Dispose(); }
            currentBook = null;
            currentChapter  = null;
            ComboViewlist  = null;
            combinedViewCheckbox  = null;
        }
        public BookViewerViewModel(BookViewer viewer, BookItem bookitem, WebView2 webview)
        {
            bookViewer = viewer;
            tabItem = bookViewer.tabItem;
            currentBook = bookitem;
            webView = webview;
            webview.CoreWebView2InitializationCompleted +=Webview_CoreWebView2InitializationCompleted;
        }

        private void Webview_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            NavigateToItem(currentChapter, "");
            WebViewContextMenu webViewContextMenu = new WebViewContextMenu();
            webViewContextMenu.CreateCustomContextMenu(this, currentBook.RelativeBooks, tabItem);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        /// 

        public async void ShowChapterTree()
        {
            try { 
            var result = await webView.CoreWebView2.ExecuteScriptWithResultAsync("toggleTreeview()");
            if (!result.Succeeded) { MessageBox.Show("המסמך עדיין בטעינה אנא המתינו כמה רגעים.\r\n (במקרה שהשגיאה ממשיכה לאחר מספר רגעים\r\n מומלץ ללחוץ על הלחצן \"הצג פחות\" ⇲)", "שגיאת מסמכים ארוכים", MessageBoxButton.OK, MessageBoxImage.Warning,MessageBoxResult.None ,MessageBoxOptions.RtlReading|MessageBoxOptions.RightAlign); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void ComboViewItemsCheckChange()
        {
            if (isComboView) { NavigateToItem(currentChapter, ""); }
        }
        public void NavigateToHeader(ChapterItem chapterItem)
        {
            Navigate_To_Header navigater = new Navigate_To_Header(this);
            navigater.Navigate(chapterItem);
        }
        public void NavigateToItem(ChapterItem targetChapter, string itemId)
        {
            if (string.IsNullOrEmpty(itemId)) { itemId = currentBook.Title; }

            List<TreeItem> comboViewItems = currentBook.RelativeBooks
                    .Where(checkedItem => checkedItem is TreeItem checkedTreeItem && checkedTreeItem.IsChecked3 == true)
                    .Cast<TreeItem>()
                    .ToList();

            BookExport bookExport = new BookExport();
            string content = bookExport.Export(targetChapter, itemId, isComboView,
                            comboViewItems, currentBook.RootItem);

            try { webView.NavigateToString(content); currentChapter = targetChapter; }
            catch 
            {
                if (targetChapter != currentBook.RootItem)
                {
                    webView.ExecuteScriptAsync($@"var element = document.getElementById(""contentBox"");
                                            element.innerHTML = ""טוען עמוד..."";");
                    WebViewCommands.WebViewNavigateToString(content, webView);
                    currentChapter = targetChapter;
                }
                else if ((currentChapter == null ||
                    (combinedViewCheckbox != null && combinedViewCheckbox.IsChecked == true))
                    && targetChapter == currentBook.RootItem)
                {
                    currentChapter = targetChapter.Children[0];
                    content = bookExport.Export(currentChapter, itemId, isComboView,
                            comboViewItems, currentBook.RootItem);
                    WebViewCommands.WebViewNavigateToString(content, webView);
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
                combinedViewCheckbox.Checked += (sender, e) => { isComboView = true; NavigateToItem(currentChapter, ""); };
                combinedViewCheckbox.Unchecked += (sender, e) => { isComboView = false; NavigateToItem(currentChapter, ""); };
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
                    fileTreeItem.IsChecked3 = checkBox.IsChecked;
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
                if (targetChapter != null) { NavigateToItem(targetChapter, currentId); }
                else { NavigateToItem(validChildren[0], currentId); }
            }
        }
        public void ShowMore()
        {
            if (currentChapter!= null && currentChapter.Parent != null) 
            {
                NavigateToItem(currentChapter.Parent, currentId); 
            }
        }
        public void ShowPrevious()
        {
            if (currentChapter.Parent != null)
            {
                ChapterItem parent = currentChapter.Parent;
                StringBuilder stringBuilder = new StringBuilder();

                int currentChapterIndex = parent.Children.IndexOf(currentChapter);
                if (currentChapterIndex > 0) //check if there is anywhere to go back to
                {
                    ChapterItem chapterItem = parent.Children[currentChapterIndex - 1] as ChapterItem;
                    NavigateToItem(chapterItem, chapterItem.Id);
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
                            NavigateToItem(child, child.Id);
                        }
                    }
                }
            }
        }
        public void ShowNext()
        {
            if (currentChapter.Parent != null)
            {
                ChapterItem parent = currentChapter.Parent;

                int currentChapterIndex = parent.Children.IndexOf(currentChapter);
                if (currentChapterIndex < (parent.Children.Count - 1)) // check if is last item in list
                {
                    ChapterItem chapter = parent.Children[currentChapterIndex + 1];
                    NavigateToItem(chapter, chapter.Id);
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
                                NavigateToItem(child, child.Id);
                            }
                            else
                            {
                                NavigateToItem(parent, parent.Id);
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
            NavigateToItem(currentChapter, currentChapter.Id);
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
            openSelected.OpenSelectedFile(fileTreeItem, currentChapter.Id);
        }
    }
}
