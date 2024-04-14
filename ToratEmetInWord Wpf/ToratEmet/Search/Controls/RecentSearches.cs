﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToratEmet.Models
{
    public class RecentSearches
    {
        private StringCollection recentSearches = Properties.Settings.Default.RecentSearches ?? new StringCollection();
        public void PopulateMenu(ComboBox comboBox)
        {
            ObservableCollection<string> itemList = new ObservableCollection<string>();
            foreach (string search in recentSearches) { itemList.Add(search);}
            if (itemList.Count > 0) { comboBox.ItemsSource = itemList; }
        }

        public void UpdateList(string input)  // Add a new item to the recent items list
        {
            if (recentSearches.Contains(input)) { recentSearches.Remove(input); }
            recentSearches.Insert(0, input);
            if (recentSearches.Count > 11) { recentSearches.RemoveAt(recentSearches.Count - 1); }

            Properties.Settings.Default.RecentSearches = recentSearches;
            Properties.Settings.Default.Save();
        }
    }
}
