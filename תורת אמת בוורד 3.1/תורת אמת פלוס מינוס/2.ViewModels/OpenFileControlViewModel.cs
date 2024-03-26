using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._4.TreeModels;
using תורת_אמת_בוורד_3._1.TreeModels;

namespace תורת_אמת_בוורד_3._1._2.ViewModels
{
    public class OpenFileControlViewModel : INotifyPropertyChanged
    {
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
        public void Search(string searchTerm, ComboBox resultBox)
        {
            OpenFileRecentSearches recentSearches = new OpenFileRecentSearches();
            recentSearches.UpdateList(searchTerm);

            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.OpenFileControlLastSearch = searchTerm;
            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.Save();

            TreeItemSearch treeItemSearch = new TreeItemSearch();
            ObservableCollection<TreeItem>  results = treeItemSearch.SearchFileList(searchTerm);
            resultBox.Tag = treeItemSearch.searchId;  
            ResultList = results;
            if (results.Count == 0) {  MessageBox.Show("לא נמצאו תוצאות"); }
        }

        public void OpenSelectedFile(FileTreeItem fileTreeItem, string adress)
        {
            OpenSelected openSelected = new OpenSelected();
            openSelected.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + adress, null);
        }
    }
}
