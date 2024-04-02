using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Models;

namespace ToratEmet.Models
{
    public static class ShortcutsHandler
    {
        public static void CreateShortcuts()
        {
            string[] shortcuts = Directory.GetFileSystemEntries(ApplicationFolders.BooksFolder);
            if (shortcuts.Length == 0)
            {
                if (Directory.Exists(ApplicationFolders.ToratEmetInstallBooks)) { CreateToratEmetShortcuts(ApplicationFolders.ToratEmetInstallBooks); }
                if (Directory.Exists(ApplicationFolders.ToratEmetMyBooks)) { CreateShortcut(ApplicationFolders.ToratEmetMyBooks, ApplicationFolders.BooksFolder); }
            }
        }
        static void CreateToratEmetShortcuts(string toratEmetInstall)
        {
            string[] toratEmetFolders = Directory.GetDirectories(toratEmetInstall);
            foreach (string toratEmetFolder in toratEmetFolders)
            {
                if (!Regex.IsMatch(toratEmetFolder, @"000_ACCESORIES|500_MY_BOOKS|170_GROUPS"))
                {
                    CreateShortcut(toratEmetFolder, ApplicationFolders.BooksFolder);
                }
            }
        }
        static void CreateShortcut(string sourcePath, string destinationPath)
        {
            string folderName = GetFolderName(sourcePath);
            string shortcutPath = Path.Combine(destinationPath, $"{folderName}.lnk");
            ShellLink shellLink = new ShellLink();
            shellLink.CreateShortcut(shortcutPath, sourcePath, "", "");
        }

        static string GetFolderName(string sourcePath)
        {
            string folderName = Path.GetFileName(sourcePath);
            if (sourcePath.Contains("ToratEmetInstall"))
            {
                folderName = folderName.Replace("000_HORADOT", "500_HORADOT");
                folderName = folderName.TranslateFolderName();
            }
            else
            {
                folderName = folderName.Replace("MyBooks", "הספרים שלי");
            }
            return folderName;
        }
    }
}
