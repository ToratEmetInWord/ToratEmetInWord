﻿using FolderPicker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Properties;

namespace ToratEmet.Models
{
    public static class ApplicationFolders
    {
        public static string MainFolder;
        public static string BooksFolder;
        public static string IndexFolder;
        static string ToratEmetInstall = "";
        public static string ToratEmetInstallBooks = "";
        static string ToratEmetUserData = "";
        public static string ToratEmetMyBooks = "";

        public static void IntializeFolders()
        {
            SetMainFolder();
            SetSubFolders();
            SetToratEmetInstallFolder();
            ToratEmetInstallBooks = Path.Combine(ToratEmetInstall, "Books");
            SetToratEmetUserDataFolder();
        }

        static void SetMainFolder()
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            MainFolder = Path.Combine(myDocumentsPath, "תורת אמת בוורד");
            if (string.IsNullOrEmpty(Properties.Settings.Default.MainFolder))
            {
                Properties.Settings.Default.MainFolder = MainFolder;
                Properties.Settings.Default.Save();
            }         
            MainFolder = Properties.Settings.Default.MainFolder;
            if (!Directory.Exists(MainFolder)) {Directory.CreateDirectory(MainFolder); }
        }

        static void SetSubFolders()
        {
            IndexFolder = Path.Combine(MainFolder, "אינדקס חיפוש");
            BooksFolder = Path.Combine(MainFolder, "ספרים");            
            if (!Directory.Exists(IndexFolder)) { Directory.CreateDirectory(IndexFolder); }
            if (!Directory.Exists(BooksFolder)) { Directory.CreateDirectory(BooksFolder); }
        }

        static void SetToratEmetInstallFolder()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ToratEmetParentFolder))
            {
                ToratEmetInstall = Path.Combine(Properties.Settings.Default.ToratEmetParentFolder, "ToratEmetInstall");
            }
            else
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (Directory.Exists(Path.Combine(myDocumentsPath, "ToratEmetInstall")))
                {
                    ToratEmetInstall = Path.Combine(myDocumentsPath, "ToratEmetInstall");
                    Properties.Settings.Default.ToratEmetParentFolder = myDocumentsPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("לא נמצאה התקנה של תורת אמת במחשב - האם ברצונך להגדיר את מיקום ההתקנה באופן ידני?", "בחירת תיקייה", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        string pickedFolder = FolderPickerLauncher.Pick_A_Folder("בחר את תיקיית ההתקנה של תורת אמת");
                        if (!string.IsNullOrEmpty(ToratEmetInstall))
                        {
                            ToratEmetInstall = pickedFolder;
                            Properties.Settings.Default.ToratEmetParentFolder = Path.GetDirectoryName(ToratEmetInstall);
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
        }

        static void SetToratEmetUserDataFolder()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ToratEmetParentFolder))
            {
                ToratEmetUserData = Path.Combine(Properties.Settings.Default.ToratEmetParentFolder, "ToratEmetUserData");
                if (!Directory.Exists(ToratEmetUserData)) { Directory.CreateDirectory(ToratEmetUserData); }
                
                ToratEmetMyBooks = Path.Combine(ToratEmetUserData, "MyBooks");
                if (!Directory.Exists(ToratEmetMyBooks)) { Directory.CreateDirectory(ToratEmetMyBooks); }
            }
        }

        public static void SetNewMainFolder()
        {
            string originalFolder = Properties.Settings.Default.MainFolder;
            string newFolderPath = FolderPickerLauncher.Pick_A_Folder("בחר מיקום חדש עבור תיקיית התוסף");
            newFolderPath = Path.Combine(newFolderPath, "תורת אמת בוורד");
            if (!string.IsNullOrEmpty(newFolderPath))
            {
                try { 
                Directory.Move(originalFolder, newFolderPath);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                Properties.Settings.Default.MainFolder = newFolderPath;
                Settings.Default.Save();
                MessageBox.Show("המיקום שונה בהצלחה יש להתחיל את וורד מחדש");              
            }
        }

        public static void SetNewToratEmetInstallFolder()
        {
            string result = FolderPickerLauncher.Pick_A_Folder("בחר את תיקיית תורת אמת במחשב");
            if (!string.IsNullOrEmpty(ToratEmetInstall))
            {
                Properties.Settings.Default.ToratEmetParentFolder = Path.GetDirectoryName(ToratEmetInstall);
                Settings.Default.Save();
                SetToratEmetInstallFolder();
                SetToratEmetUserDataFolder();
            }
        }
    }
}
