using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Controls;
using ToratEmet.Initializers;
using ToratEmet.Models;
using ToratEmet.TreeModels;


namespace ToratEmet
{
    internal class StaticGlobals
    {
        public static List<TreeItem> treeItemsList = new List<TreeItem>();
        public static ObservableCollection<TreeItem> RootItems { get; set; }
        public static OpenFileControl OpenFileControl { get; set; }
        public static Window OpenFileControlWindow { get; set; }
        public static SearchControl SearchControl { get; set; }
        public static Window SearchControlWindow { get; set; }
        public static Window SearchControlExplorerWindow { get; set; }
        public static Window DictionaryWindow { get; set; }

        public static List<Window> WebViewWindowList = new List<Window>();
        
        public static void CopyToSearch(string input)
        {
            input = Regex.Replace(input, @"\p{Mn}+", "");
            var taskpane = TaskPaneHandler.LaunchTaskPane();
            if(taskpane.Control is HostControl control)
            {
                CostumeWindowsHandler.ShowSearchTab(control.mainControl.tabControlX.tabControl);
                SearchControl.SearchTextBox.Text = input;
                SearchControl.SearchTextBox.SelectAll();
                SearchControl.SearchTextBox.Focus();
            }            
        }
        public static void CopyToFileSearch(string input)
        {
            input = Regex.Replace(input, @"\p{Mn}+", "");
            var taskpane = TaskPaneHandler.LaunchTaskPane();
            if (taskpane.Control is HostControl control)
            {
                CostumeWindowsHandler.ShowOpenFileTab(control.mainControl.tabControlX.tabControl);
                OpenFileControl.SearchTextBox.Text = input;
                OpenFileControl.SearchTextBox.SelectAll();
                OpenFileControl.SearchTextBox.Focus();
            }
        }
    }
}
