using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_פלוס_מינוס;


namespace תורת_אמת_בוורד_3._1._4.TreeModels
{
    public class TreeItemSearch
    {
        string searchTerm;
        public string searchId;
        public TreeItem GetItemDirectly(string searchTerm)
        {
            foreach (TreeItem fileItem in StaticGlobals.treeItemsList)
            {
                if (fileItem.Address == searchTerm) return fileItem;
            }
            return null;
        }
        public ObservableCollection<TreeItem> SearchFileList(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) { return null; }
            SetSearchTerm(searchText);
            ObservableCollection<TreeItem> itemList = ArraySearch();
            if (itemList.Count == 0) { itemList = LevenshtienSearch(); }
            return itemList;
        }
        public void SetSearchTerm(string searchText) //inlcuding split bookname from adress
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
            string[] saerchArray = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ObservableCollection<TreeItem> itemList = new ObservableCollection<TreeItem>();
            foreach (FileTreeItem fileItem in StaticGlobals.treeItemsList)
            {
                string[] itemNameArray = fileItem.Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (Levenshtein.CompareArray(saerchArray, itemNameArray, 3) == true)
                {
                    itemList.Add(fileItem);
                }
            }
            return itemList;
        }
    }
}
