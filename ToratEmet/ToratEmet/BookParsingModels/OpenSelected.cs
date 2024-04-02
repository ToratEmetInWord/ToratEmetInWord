using Microsoft.Win32;
using Stfu.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using ToratEmet.Controls;
using ToratEmet.BookParsingModels;
using ToratEmet.TreeModels;
using ToratEmet.Initializers;


namespace ToratEmet.Models
{
    public class OpenSelected
    {
        public void OpenExternalFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "(*.pdf;*.txt;*.html)|*.pdf;*.txt;*.html",
                InitialDirectory = Properties.Settings.Default.DefaultExternalFolder,
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                string extension = System.IO.Path.GetExtension(filePath).ToLower();

                if (extension == ".txt")
                {
                    BookItem newBook = CreateBook(fileName, filePath);
                    ChapterItem targitItem = GetTargetItem("", newBook);
                    TabItem tabItem = CreateNewTab(fileName, null);
                    BookViewer bookViewer = new BookViewer(newBook, tabItem);
                    bookViewer.viewModel.currentChapter = targitItem;
                    tabItem.Content = bookViewer;
                    bookViewer.viewModel.currentChapter = targitItem;
                }
                else if (extension == ".pdf")
                {
                    WebViewControl webViewControl = new WebViewControl();
                    webViewControl.CoreWebView2InitializationCompleted += (sender, e) =>
                    {
                        webViewControl.CoreWebView2.Navigate(filePath); 
                    };
                    TabItem tabItem = CreateNewTab(fileName, null);
                    tabItem.Content = webViewControl;
                    var taskPane = TaskPaneHandler.GetCurrentTaskPane();
                    taskPane.Width = Math.Max(taskPane.Width, 600);
                }
                else if (extension == ".html")
                {
                    WebViewControl webViewControl = new WebViewControl();
                    webViewControl.CoreWebView2InitializationCompleted += (sender, e) =>
                    {
                        webViewControl.CoreWebView2.Navigate(filePath);
                    };
                    TabItem tabItem = CreateNewTab(fileName, null);
                    tabItem.Content = webViewControl;
                }
            }
        }
        public void OpenSelectedFile(TreeItem selectedItem, string targetItemId, TabControl tabControl)
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
                    TabItem tabItem = CreateNewTab(fileName, tabControl);
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
        ObservableCollection<object> GetRelativeBooks(TreeItem sourceTreeItem)
        {
            List<TreeItem> itemList = new List<TreeItem>();
            if (sourceTreeItem.Parent != null)
            {
                foreach (TreeItem item in sourceTreeItem.Parent.Children)
                {
                    if (item != sourceTreeItem)
                    {
                        itemList.Add(item);
                    }
                    else
                    {
                        sourceTreeItem = item;
                    }
                }
            }

            string nameFragment;
            List<TreeItem> Relatives;
            string[] splitFileName = sourceTreeItem.Name.Split(' ');
            if (splitFileName.Length > 0) 
            {
                nameFragment = splitFileName[0].Trim(',').Trim(' ');
                Relatives = StaticGlobals.treeItemsList.Where(item => (item.Name.EndsWith(nameFragment) 
                || item.Name.StartsWith(nameFragment)) && !itemList.Contains(item)).ToList() ;
                if (Relatives.Count > 0) { itemList.AddRange(Relatives); }
                nameFragment = splitFileName[splitFileName.Length - 1].Trim(',').Trim(' ');
            }
            else { nameFragment = sourceTreeItem.Name; }
            Relatives =  StaticGlobals.treeItemsList.Where(item => (item.Name.EndsWith(nameFragment)
                || item.Name.StartsWith(nameFragment)) && !itemList.Contains(item)).ToList();
            if (Relatives.Count > 0) { itemList.Concat(Relatives); }

            itemList.Remove(sourceTreeItem);
            return new ObservableCollection<object>(itemList.Select(item => item.DeepCopyFileTreeItem()).ToList());
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
        TabItem CreateNewTab(string fileName, TabControl tabControl)
        {
            if (tabControl == null) { tabControl = GetTabControl(); }
            TabItem tabItem = new TabItem
            {
                Header = fileName,
            };
            tabControl.Items.Add(tabItem);
            tabItem.IsSelected = true;
            return tabItem;
        }
        TabControl GetTabControl()
        {
            var taskPane = TaskPaneHandler.LaunchTaskPane();     
            HostControl control = taskPane.Control as HostControl;
            return control.mainControl.tabControlX.tabControl;
        }
        void updateRecentBooks(string filePath)
        {
            RecentBooks recentBooks = new RecentBooks();
            recentBooks.UpdateList(filePath);
        }
    }
}
