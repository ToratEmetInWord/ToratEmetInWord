using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace תורת_אמת_בוורד_3._1._3.Models
{
    public static class BooksFolder
    {
        public static void CreateShortcuts()
        {
            string[] shortcuts = Directory.GetFiles(StaticGlobals.booksFolder, "*.lnk");
            if (shortcuts.Length == 0)
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string toratEmetInstall = Path.Combine(myDocumentsPath, "ToratEmetInstall", "Books");
                string myBooksFolder = Path.Combine(myDocumentsPath, "ToratEmetUserData", "MyBooks");

                if (Directory.Exists(toratEmetInstall)){ CreateToratEmetShortcuts(toratEmetInstall); }
                if (Directory.Exists(myBooksFolder)) { createShortcut(myBooksFolder, StaticGlobals.booksFolder);  }

                shortcuts = Directory.GetFiles(StaticGlobals.booksFolder, "*.lnk");
                if (shortcuts.Length == 0)
                {
                    MessageBox.Show("לא נמצאו ספרים במחשב אנא התקינו את ספריית תורת אמת");
                }
            }
        }
        static void CreateToratEmetShortcuts(string toratEmetInstall)
        {
            string[] toratEmetFolders = Directory.GetDirectories(toratEmetInstall);
            foreach (string toratEmetFolder in toratEmetFolders)
            {
                if (!Regex.IsMatch(toratEmetFolder, @"000_ACCESORIES|500_MY_BOOKS|170_GROUPS"))
                {
                    createShortcut(toratEmetFolder, StaticGlobals.booksFolder);
                }
            }
        }
        static void createShortcut(string sourcePath, string destinationPath)
        {
            string folderName = GetFolderName(sourcePath);

            var wshShell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(Path.Combine(destinationPath, $"{folderName}.lnk"));

            shortcut.TargetPath = sourcePath;
            shortcut.Description = $"Shortcut to {folderName}";
            shortcut.Save();
        }
        static string GetFolderName(string sourcePath)
        {
            string folderName = Path.GetFileName(sourcePath).Replace("MyBooks", "הספרים שלי");
            if (sourcePath.Contains("ToratEmetInstall"))
            {
                folderName = folderName.Replace("000_HORADOT", "500_HORADOT");
                folderName = TransaltorClass.TranslateFolderName(folderName);
            }
            return folderName;
        }
        public static string GetShortcutTarget(string shortcutFilePath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutFilePath);
            return shortcut.TargetPath;
        }
    }
}
