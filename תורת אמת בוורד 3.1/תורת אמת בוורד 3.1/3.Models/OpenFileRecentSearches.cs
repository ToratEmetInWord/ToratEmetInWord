using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using תורת_אמת_בוורד_3._1.TreeModels;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public class OpenFileRecentSearches
    {
        private StringCollection recentSearches = Properties.Settings.Default.OpenFileRecentSearches ?? new StringCollection();
        public void PopulateMenu(ComboBox comboBox)
        {
            ObservableCollection<string> itemList = new ObservableCollection<string>();
            foreach (string search in recentSearches) { itemList.Add(search); }
            if (itemList.Count > 0) { comboBox.ItemsSource = itemList; }
        }

        public void UpdateList(string input)  // Add a new item to the recent items list
        {
            if (recentSearches.Contains(input)) { recentSearches.Remove(input); }
            recentSearches.Insert(0, input);
            if (recentSearches.Count > 11) { recentSearches.RemoveAt(recentSearches.Count - 1); }

            Properties.Settings.Default.OpenFileRecentSearches = recentSearches;
            Properties.Settings.Default.Save();
        }
    }
}
