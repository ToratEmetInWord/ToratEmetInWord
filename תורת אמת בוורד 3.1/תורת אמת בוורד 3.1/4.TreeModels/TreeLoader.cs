using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._8.Extensions;

namespace תורת_אמת_בוורד_3._1.TreeModels
{
    internal class TreeLoader
    {
        public void PopulateTree(TreeView treeView)
        {            
            CreateTree();
            if (treeView != null) { treeView.ItemsSource = StaticGlobals.RootItems; };
        }              
        void CreateTree()
        {
            if (StaticGlobals.RootItems == null)
            {
                StaticGlobals.RootItems = new ObservableCollection<TreeItem>();

                BooksFolder.CreateShortcuts();
                string[] items = Directory.GetFiles(StaticGlobals.booksFolder, "*.lnk");
                foreach (string item in items)
                {
                    string path = BooksFolder.GetShortcutTarget(item);
                    if (item.ToLower().EndsWith(".txt") && File.Exists(path))
                    {
                        AddRootFileItem(path);
                    }
                    else if (path.ToLower().EndsWith(".txt") && File.Exists(path))
                    {
                        AddRootFileItem(path);
                    }
                    else if (Directory.Exists(path))
                    {
                        AddRootFolderItem(path);
                    }
                }

                string[] folders = Directory.GetDirectories(StaticGlobals.booksFolder);
                foreach (string folder in folders) 
                {
                    AddRootFolderItem(folder);
                }
            }
        }

        void AddRootFileItem(string filePath)
        {
            FileTreeItem rootItem = NewFileTreeItem(filePath);
            StaticGlobals.RootItems.Add(rootItem);
        }
        void AddRootFolderItem(string folderPath)
        {
            FolderTreeItem rootItem = NewFolderTreeItem(folderPath);            
            StaticGlobals.RootItems.Add(rootItem);
            PopulateSubFolders(folderPath, rootItem);
        }
        void PopulateSubFolders(string parentFolder, TreeItem parentItem)
        {
            PopulateFiles(parentFolder, parentItem);
            string[] folders = Directory.GetDirectories(parentFolder);
            foreach (string folderPath in folders)
            {
                if (Directory.Exists(folderPath))
                {
                    FolderTreeItem folderItem = NewFolderTreeItem(folderPath);
                    parentItem.AddChild(folderItem);
                    PopulateSubFolders(folderPath, folderItem);
                }
            }
        }
        void PopulateFiles(string parentFolder, TreeItem parentItem)
        {
            string[] files = Directory.GetFiles(parentFolder);
            foreach (string filePath in files)
            {
                if (File.Exists(filePath) && !Regex.IsMatch(filePath, @"DebugMix|Interleave|merged|HavTempNotes|RAMMBAM.*?L1|99999_00001_RAMBAM"))
                {
                    FileTreeItem fileItem = NewFileTreeItem(filePath);
                    parentItem.AddChild(fileItem);                  
                }
            }
        }
        FolderTreeItem NewFolderTreeItem(string folderPath)
        {
            return new FolderTreeItem
            {
                Name = folderPath.GetCleanFolderName(),
                Address = folderPath
            };
        }
        FileTreeItem NewFileTreeItem(string filePath)
        {
            FileTreeItem fileTreeItem =  new FileTreeItem
            {
                Name = filePath.GetCleanFileName(),
                Address = filePath
            };
            StaticGlobals.treeItemsList.Add(fileTreeItem);
            return fileTreeItem;
        }
    }
}
