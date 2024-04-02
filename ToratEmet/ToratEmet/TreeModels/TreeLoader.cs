using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToratEmet.Models;

namespace ToratEmet.TreeModels
{
    public static class TreeLoader
    {
        public static void PopulateTree(TreeView treeView)
        {
            CreateTree();
            if (treeView != null) { treeView.ItemsSource = StaticGlobals.RootItems; };
        }
        static void CreateTree()
        {
            if (StaticGlobals.RootItems == null)
            {
                StaticGlobals.RootItems = new ObservableCollection<TreeItem>();
                string[] items = Directory.GetFileSystemEntries(ApplicationFolders.BooksFolder);
                foreach (string item in items)
                {  
                    processEntries(item); 
                }
            }
        }

        static void processEntries(string path)
        {
            if (path.ToLower().EndsWith(".lnk"))  
            {
                ShellLink shellLink = new ShellLink();
                path = shellLink.ReadShortcutPath(path);
            }           
            else if (path.ToLower().EndsWith(".txt") && File.Exists(path)) {  AddRootFileItem(path); }
            
            if (Directory.Exists(path)) 
            {
                AddRootFolderItem(path); 
            }
        }

        static void AddRootFileItem(string filePath)
        {
            FileTreeItem rootItem = NewFileTreeItem(filePath);
            StaticGlobals.RootItems.Add(rootItem);
        }
        static void AddRootFolderItem(string folderPath)
        {
            FolderTreeItem rootItem = NewFolderTreeItem(folderPath);
            StaticGlobals.RootItems.Add(rootItem);
            PopulateSubFolders(folderPath, rootItem);
        }
        static void PopulateSubFolders(string parentFolder, TreeItem parentItem)
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
        static void PopulateFiles(string parentFolder, TreeItem parentItem)
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
        static FolderTreeItem NewFolderTreeItem(string folderPath)
        {
            return new FolderTreeItem
            {
                Name = folderPath.GetCleanFolderName(),
                Address = folderPath
            };
        }
        static FileTreeItem NewFileTreeItem(string filePath)
        {
            FileTreeItem fileTreeItem = new FileTreeItem
            {
                Name = filePath.GetCleanFileName(),
                Address = filePath
            };
            StaticGlobals.treeItemsList.Add(fileTreeItem);
            return fileTreeItem;
        }
    }
}
