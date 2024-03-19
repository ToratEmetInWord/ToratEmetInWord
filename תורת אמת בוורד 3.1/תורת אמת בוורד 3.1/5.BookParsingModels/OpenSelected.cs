using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using תורת_אמת_בוורד_3._1._1.Controls;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using תורת_אמת_בוורד_3._1.TreeModels;


namespace תורת_אמת_בוורד_3._1._3.Models
{
    public class OpenSelected
    {
        public void OpenExternalFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.pdf;*.txt;*.html)|*.pdf;*.txt;*.html";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                string extension = System.IO.Path.GetExtension(filePath).ToLower();

                if (extension == ".txt")
                {
                    BookItem newBook = CreateBook(fileName, filePath);
                    ChapterItem targitItem = GetTargetItem("", newBook);
                    TabItem tabItem = CreateNewTab(fileName);
                    BookViewer bookViewer = new BookViewer(newBook, tabItem);
                    bookViewer.viewModel.currentChapter = targitItem;
                    tabItem.Content = bookViewer;
                    bookViewer.viewModel.currentChapter = targitItem;
                }
                if (extension == ".pdf"|| extension == ".html")
                {
                    WebViewControl webViewControl = new WebViewControl();
                    webViewControl.webView.CoreWebView2InitializationCompleted += (sender, e) =>
                    {
                        webViewControl.webView.CoreWebView2.Navigate(filePath); 
                    };
                    TabItem tabItem = CreateNewTab(fileName);
                    tabItem.Content = webViewControl;
                }
            }
        }
        public void OpenSelectedFile(TreeItem selectedItem, string targetItemId)
        {
            if (selectedItem is FileTreeItem fileTreeItem)
            {
                string filePath = fileTreeItem.Address;
                string fileName = fileTreeItem.Name;

                if (File.Exists(filePath) && filePath.ToLower().EndsWith(".txt"))
                {
                    BookItem newBook = CreateBook(fileName, filePath);
                    newBook.RelativeBooks = GetRelativeBooks(fileTreeItem);
                    ChapterItem targitItem = GetTargetItem(targetItemId, newBook);
                    TabItem tabItem = CreateNewTab(fileName);
                    BookViewer bookViewer = new BookViewer(newBook, tabItem);
                    bookViewer.viewModel.currentChapter = targitItem;
                    tabItem.Content = bookViewer;
                    updateRecentBooks(filePath);
                }
            }
        }
        BookItem CreateBook(string fileName, string filePath)
        {
            BookParser bookParser = new BookParser();
            return bookParser.Parse(filePath, fileName);
        }
        ObservableCollection<object> GetRelativeBooks(TreeItem treeItem)
        {
            ObservableCollection<object> itemList = new ObservableCollection<object>();
            if (treeItem.Parent != null)
            {
                foreach (TreeItem item in treeItem.Parent.Children)
                {
                    if (item != treeItem)
                    {
                        itemList.Add(item);
                    }
                    else
                    {
                        treeItem = item;
                    }
                }
            }
            return itemList;
        }
        ChapterItem GetTargetItem(string targetItemId, BookItem BookItem)
        {
            ChapterItem targetItem = null;
            if (!string.IsNullOrEmpty(targetItemId))
            {
                targetItem = BookItem.AllChapters.FirstOrDefault(chapter => chapter.Id.EndsWith(targetItemId));
                if (targetItem == null) { targetItem = FIndTargetItem.SearchForItem(BookItem.RootItem, targetItemId); }
                if (targetItem == null) { targetItem = FIndTargetItem.JaccardSearch(BookItem, targetItemId); }
            }
            if (targetItem == null) { targetItem = BookItem.RootItem; }
            return targetItem;
        }
        TabItem CreateNewTab(string fileName)
        {
            TabItem tabItem = new TabItem
            {
                Header = fileName,
            };
            TabControl().Items.Add(tabItem);
            tabItem.IsSelected = true;
            return tabItem;
        }
        TabControl TabControl()
        {
            var currentWindow = Globals.ThisAddIn.Application.ActiveWindow;
            if (!GlobalsX.mainControlsDictionary.ContainsKey(currentWindow))
            {
                GlobalsX.LoadTaskPane();
            }
            return GlobalsX.mainControlsDictionary[currentWindow].tabControl.tabControl;
        }
        void updateRecentBooks(string filePath)
        {
            RecentBooks recentBooks = new RecentBooks();
            recentBooks.UpdateList(filePath);
        }
    }
}
