using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToratEmet.Models;

namespace ToratEmet.TreeModels
{
    public class TreeItemSearch
    {
        string searchTerm;
        public string searchId;
        public TreeItem GetItemDirectly(string searchTerm)
        {
            return StaticGlobals.treeItemsList.FirstOrDefault(fileItem => fileItem.Address == searchTerm);
        }
        public ObservableCollection<TreeItem> SearchFileList(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) { return null; }
            SetSearchTerm(searchText);
            ObservableCollection<TreeItem> itemList = ArraySearch();
            if (itemList.Count == 0) { itemList = LevenshtienSearch(); }
            return itemList;
        }
        void SetSearchTerm(string searchText) //inlcuding split bookname from adress
        {
            string[] words = searchText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 1)
            {
                int indexOfFirstComma = searchText.IndexOf(',');
                searchId = ", " + searchText.Substring(indexOfFirstComma + 1).Trim();
                searchTerm = words[0];
            }
            else { searchTerm = searchText; searchId = ""; }
        }
        ObservableCollection<TreeItem> ArraySearch()
        {
            ObservableCollection<TreeItem> itemList = new ObservableCollection<TreeItem>();
            string[] searchArray = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (TreeItem fileItem in StaticGlobals.treeItemsList)
            {
                if (searchArray.All(word => fileItem.Name.Contains(word)))
                {
                    itemList.Add(fileItem);
                }
            }
            return itemList;
        }
        ObservableCollection<TreeItem> LevenshtienSearch()
        {
            string[] searchArray = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ObservableCollection<TreeItem> itemList = new ObservableCollection<TreeItem>();
            foreach (FileTreeItem fileItem in StaticGlobals.treeItemsList)
            {
                string[] itemNameArray = fileItem.Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (Levenshtein.CompareArray(searchArray, itemNameArray, 3) == true)
                {
                    itemList.Add(fileItem);
                }
            }
            return itemList;
        }
    }
}
