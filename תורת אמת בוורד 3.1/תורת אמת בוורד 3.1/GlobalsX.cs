using Word = Microsoft.Office.Interop.Word;
using OfficeTools = Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using תורת_אמת_בוורד_3._1._1.Controls;
using System.IO;
using System.Collections.ObjectModel;
using תורת_אמת_בוורד_3._1.TreeModels;
using System.Collections.Specialized;
using תורת_אמת_בוורד_3._1.Properties;
using System.Windows;
using תורת_אמת_בוורד_3._1._3.Models;
namespace תורת_אמת_בוורד_3._1
{
    public static class GlobalsX
    {
        public static Dictionary<Word.Window, OfficeTools.CustomTaskPane> taskPanesDictionary = new Dictionary<Word.Window, OfficeTools.CustomTaskPane>();
        public static Dictionary<Word.Window, MainControl> mainControlsDictionary = new Dictionary<Word.Window, MainControl>();
        public static List<Window> windowList = new List<Window>();
        //public static List<WebView2> webViewList = new List<WebView2>();
        public static List<TreeItem> treeItemsList = new List<TreeItem>();
        public static ObservableCollection<TreeItem> RootItems { get; set; }
        public static OpenFileControlWindow openFileWindow { get; set; }
        public static SearchControlWindow searchWindow { get; set; }
        public static SearchExplorerWindow searchExplorerWindow  { get; set; }
        public static AramaicDictionaryWindow aramaicDictionaryWindow { get; set; }
        public static string mainFolder { get; set; }
        public static string booksFolder { get; set; }
        public static string indexFolder { get; set; }
        public static void LoadTaskPane()
        {
            Word.Window currentWindow = Globals.ThisAddIn.Application.ActiveWindow;
            if (!taskPanesDictionary.ContainsKey(currentWindow))
            {
                Updater.CheckForUpdates();
                SetFoldersPaths();
                TreeLoader treeLoader = new TreeLoader();
                treeLoader.PopulateTree(null);

                  if (Settings.Default.CheckedTreeItems == null)
                {
                    Settings.Default.CheckedTreeItems = new StringCollection();
                }
                if (Settings.Default.CheckedTreeItems == null)
                {
                    Settings.Default.CheckedListBoxItems = new StringCollection();
                }
                Settings.Default.Save();

                HostControl hostControl = new HostControl();
                OfficeTools.CustomTaskPane taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(hostControl, "תורת אמת בוורד");
                taskPane.Width = Properties.Settings.Default.TaskPaneWidth;

                taskPanesDictionary[currentWindow] = taskPane;
                mainControlsDictionary[currentWindow] = hostControl.mainControl;                    
            }
            taskPanesDictionary[currentWindow].Visible = true;
        }

        public static void SetFoldersPaths()
        {
            if (string.IsNullOrEmpty(Settings.Default.MainFolder))
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                mainFolder = Path.Combine(myDocumentsPath, "תורת אמת בוורד");
                Settings.Default.MainFolder = mainFolder;
                Settings.Default.Save();
            }
            else
            {
                mainFolder = Settings.Default.MainFolder;
            }
            
            indexFolder = Path.Combine(mainFolder, "אינדקס חיפוש");
            booksFolder = Path.Combine(mainFolder, "ספרים");
            if (!Directory.Exists(mainFolder)) { Directory.CreateDirectory(mainFolder); }
            if (!Directory.Exists(indexFolder)) { Directory.CreateDirectory(indexFolder); }
            if (!Directory.Exists(booksFolder)) { Directory.CreateDirectory(booksFolder); }
        }
        public static void ShowOpenFileWindow()
        {
            if (openFileWindow == null) 
            { 
                openFileWindow = new OpenFileControlWindow();
                openFileWindow.Show();
            }
            openFileWindow.SetOwner();
            openFileWindow.Visibility = System.Windows.Visibility.Visible;
            openFileWindow.WindowState = System.Windows.WindowState.Normal;
            
        }

        public static void ShowSearchWindow()
        {
            if (searchWindow == null) 
            {
                searchWindow = new SearchControlWindow();
                searchWindow.Show();
            }
            searchWindow.SetOwner();
            searchWindow.Visibility = System.Windows.Visibility.Visible;
            searchWindow.WindowState = System.Windows.WindowState.Normal;
        }

        public static void ShowSearchExplorerWindow()
        {
            if (searchExplorerWindow == null) { searchExplorerWindow = new SearchExplorerWindow(); }
            searchExplorerWindow.SetOwner();
            searchExplorerWindow.Show();
            searchExplorerWindow.Visibility = System.Windows.Visibility.Visible;
            searchExplorerWindow.WindowState = System.Windows.WindowState.Normal;
        }

        public static void ShowAramaicDictionary()
        {
            if (aramaicDictionaryWindow == null) { aramaicDictionaryWindow = new AramaicDictionaryWindow(); }
            aramaicDictionaryWindow.SetOwner();
            aramaicDictionaryWindow.Show();
            aramaicDictionaryWindow.Visibility = System.Windows.Visibility.Visible;
            aramaicDictionaryWindow.WindowState = System.Windows.WindowState.Normal;
        }

        public static void CopyToSearch(string input)
        {
            GlobalsX.LoadTaskPane();
            GlobalsX.ShowSearchWindow();
            GlobalsX.searchWindow.searchControl.SearchTextBox.Text = input;
            GlobalsX.searchWindow.searchControl.SearchTextBox.SelectAll();
            GlobalsX.searchWindow.searchControl.SearchTextBox.Focus();
        }

        public static void CopyToFileSearch(string input)
        {
            GlobalsX.LoadTaskPane();
            GlobalsX.ShowOpenFileWindow();
            GlobalsX.openFileWindow.openFileControl.SearchTextBox.Text = input;
            GlobalsX.openFileWindow.openFileControl.tabControl.SelectedIndex = 1;
            GlobalsX.openFileWindow.openFileControl.SearchTextBox.SelectAll();
            GlobalsX.openFileWindow.openFileControl.SearchTextBox.Focus();
        }        
    }
}
