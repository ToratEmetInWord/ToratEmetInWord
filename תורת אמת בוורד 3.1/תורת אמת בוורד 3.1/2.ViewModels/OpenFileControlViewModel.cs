using FolderPicker;
using Lucene.Net.Search;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._4.TreeModels;
using תורת_אמת_בוורד_3._1.TreeModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

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
        public void Search(string searchTerm, ListBox resultListBox)
        {
            Properties.Settings.Default.OpenFileControlLastSearch = searchTerm;
            Properties.Settings.Default.Save();

            TreeItemSearch treeItemSearch = new TreeItemSearch();
            ObservableCollection<TreeItem>  results = treeItemSearch.SearchFileList(searchTerm);
            ResultList = results;  resultListBox.Tag = treeItemSearch.searchId;
            if (results.Count == 0) {  MessageBox.Show("לא נמצאו תוצאות");    }
        }
    }
}
