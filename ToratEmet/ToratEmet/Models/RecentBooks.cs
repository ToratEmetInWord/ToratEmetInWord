using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToratEmet.TreeModels;


namespace ToratEmet.Models
{
    public class RecentBooks
    {
        private StringCollection recentBooksHeaders = Properties.Settings.Default.RecentBooks ?? new StringCollection();
        public void PopulateMenu(ComboBox comboBox)
        {
            ObservableCollection<TreeItem> itemList = new ObservableCollection<TreeItem>();
            foreach (string bookItem in recentBooksHeaders)
            {
                TreeItem treeItem = StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address.Equals(bookItem));
                if (treeItem != null) { itemList.Add(treeItem); }
            }
            if (itemList.Count > 0) { comboBox.ItemsSource = itemList; }
        }
        public void UpdateList(string filePath)  // Add a new item to the recent items list
        {
            if (recentBooksHeaders.Contains(filePath)) { recentBooksHeaders.Remove(filePath); }
            recentBooksHeaders.Insert(0, filePath);
            if (recentBooksHeaders.Count > 11) { recentBooksHeaders.RemoveAt(recentBooksHeaders.Count - 1); }

            Properties.Settings.Default.RecentBooks = recentBooksHeaders;
            Properties.Settings.Default.Save();
        }
    }
}
