using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Controls;
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

        }
        public static void CopyToFileSearch(string input)
        {

        }


    }
}
