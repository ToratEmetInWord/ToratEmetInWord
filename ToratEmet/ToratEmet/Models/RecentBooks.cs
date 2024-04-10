using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToratEmet.TreeModels;


namespace ToratEmet.Models
{
    public static class RecentBooks
    {
        public static void PopulateMenu(ComboBox comboBox)
        {
            StringCollection recentBooksCollection = Properties.Settings.Default.RecentBooks ?? new StringCollection();

            TreeItem treeItem;
            ObservableCollection<TreeItem> itemList = new ObservableCollection<TreeItem>();
            
            foreach (string bookItem in recentBooksCollection)
            {
                if (bookItem.Contains("|")) 
                {
                    string[] splitBookItem = bookItem.Split('|');
                    treeItem = StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address.Equals(splitBookItem[0]));
                    if (treeItem == null && File.Exists(splitBookItem[0]))
                    {
                        treeItem = new TreeItem { Address = splitBookItem[0], Name = Path.GetFileNameWithoutExtension(splitBookItem[0]) }; 
                    }
                    treeItem.RecentChapter = new string[] { splitBookItem[1], splitBookItem[2] };
                }
                else 
                {
                    treeItem = StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address.Equals(bookItem));
                    if (treeItem == null && File.Exists(bookItem))
                    {
                        treeItem = new TreeItem { Address = bookItem, Name = Path.GetFileNameWithoutExtension(bookItem) };
                    }
                }              
                if (treeItem != null) { itemList.Add(treeItem); }
            }
            if (itemList.Count > 0) { comboBox.ItemsSource = itemList; }
        }

        public static void UpdateList(string filePath)  // Add a new item to the recent items list
        {
            StringCollection recentBooksCollection = Properties.Settings.Default.RecentBooks ?? new StringCollection();

            string BookToRemove = recentBooksCollection.Cast<string>()
                                           .FirstOrDefault(book => book == filePath|| book.StartsWith(filePath +"|"));
            if (BookToRemove != null)
            {
                recentBooksCollection.Remove(BookToRemove);
            }
            recentBooksCollection.Insert(0, filePath);
            if (recentBooksCollection.Count > 15) { recentBooksCollection.RemoveAt(recentBooksCollection.Count - 1); }

            Properties.Settings.Default.RecentBooks = recentBooksCollection;
            Properties.Settings.Default.Save();
        }

        public static void UpdateListWhileClosingBook(string filePath, string currentChapter, double currentLocation)  // Add a new item to the recent items list
        {
            StringCollection recentBooksCollection = Properties.Settings.Default.LastSessionCollection ?? new StringCollection();

            string BookToRemove = recentBooksCollection.Cast<string>()
                                          .FirstOrDefault(book => book == filePath || book.StartsWith(filePath + "|"));
            if (BookToRemove != null)
            {
                recentBooksCollection.Remove(BookToRemove);
            }

            recentBooksCollection.Insert(0, filePath + "|" + currentChapter + "|" + currentLocation);
            if (recentBooksCollection.Count > 15) { recentBooksCollection.RemoveAt(recentBooksCollection.Count - 1); }

            Properties.Settings.Default.LastSessionCollection = recentBooksCollection;
            Properties.Settings.Default.Save();
        }

        public static void ResumeSession(TabControl tabControl)
        {
            try
            {
                TreeItem treeItem;
                List<string> recentBooksCopy = Properties.Settings.Default.LastSessionCollection.Cast<string>().ToList();

                foreach (string bookItem in recentBooksCopy)
                {
                    if (bookItem.Contains("|"))
                    {
                        string[] splitBookItem = bookItem.Split('|');
                        treeItem = StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address.Equals(splitBookItem[0]));
                        if (treeItem != null)
                        {
                            if (splitBookItem[1] == treeItem.Name) { splitBookItem[1] = ""; }
                            OpenSelected openSelected = new OpenSelected();
                            openSelected.OpenSelectedFile(treeItem, splitBookItem[1], splitBookItem[2], tabControl);
                        }
                    }
                    else
                    {
                        treeItem = StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address.Equals(bookItem));
                        if (treeItem != null)
                        {
                            OpenSelected openSelected = new OpenSelected();
                            openSelected.OpenSelectedFile(treeItem, "", "", tabControl);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
