using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToratEmet.TreeModels;

namespace ToratEmet.ViewModels
{
    internal class SearchExplorerControlViewModel
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<TreeItem> _resultList = new ObservableCollection<TreeItem>();
        public ObservableCollection<TreeItem> ResultList
        {
            get { return _resultList; }
            set
            {
                _resultList = value;
                OnPropertyChanged(nameof(ResultList));
            }
        }

        string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
            }
        }

        #endregion
        public void PopulateTreeView(TreeView treeView)
        {
            TreeLoader.PopulateTree(treeView);
        }

        public void Search(string searchTerm, ListBox listBox)
        {
            TreeItemSearch treeItemSearch = new TreeItemSearch();
            ResultList = treeItemSearch.SearchFileList(searchTerm);
            listBox.ItemsSource = ResultList;
            if (ResultList == null || ResultList.Count == 0) { MessageBox.Show("לא נמצאו תוצאות"); }
        }

        public void CheckAllTreeItems()
        {
            foreach (var item in StaticGlobals.RootItems)
            {
                item.IsChecked = true;
            }
        }
        public void UncheckAllTreeItems()
        {
            foreach (var item in StaticGlobals.RootItems)
            {
                item.IsChecked = false;
            }
        }
        public void CheckAllListBoxItems(ListBox listBox)
        {
            foreach (var item in listBox.Items)
            {
                if (item is TreeItem treeItem) { treeItem.IsChecked2 = true; }
            }
        }
        public void UncheckAllListBoxItems(ListBox listBox)
        {
            foreach (var item in listBox.Items)
            {
                if (item is TreeItem treeItem) { treeItem.IsChecked2 = false; }
            }
        }
    }
}
