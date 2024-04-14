using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Models;
using ToratEmet.TreeModels;

namespace ToratEmet.Controls.ViewModels
{
    public class OpenFileControlViewModel:INotifyPropertyChanged
    {
        #region Bindings
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _targetId;
        public string TargetId
        {
            get { return _targetId; }
            set
            {
                _targetId = value;
                OnPropertyChanged(nameof(TargetId));
            }
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

        #endregion

        public void Search(string searchTerm) 
        {
            OpenFileRecentSearches recentSearches = new OpenFileRecentSearches();
            recentSearches.UpdateList(searchTerm);

            Properties.Settings.Default.OpenFileControlLastSearch = searchTerm;
            Properties.Settings.Default.Save();

            TreeItemSearch treeItemSearch = new TreeItemSearch();
            ObservableCollection<TreeItem> results = treeItemSearch.SearchFileList(searchTerm);
            TargetId = treeItemSearch.searchId;
            ResultList = results;
            if (results.Count == 0) { MessageBox.Show("לא נמצאו תוצאות"); }
        }

        public void OpenSelectedFile(TreeItem fileTreeItem, string targetId)
        {
            OpenSelected openSelected = new OpenSelected();
            openSelected.OpenSelectedFile(fileTreeItem, targetId,"", null);
        }
    }
}
