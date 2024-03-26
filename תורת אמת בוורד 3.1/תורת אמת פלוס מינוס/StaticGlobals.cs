using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_פלוס_מינוס.Properties;

namespace תורת_אמת_פלוס_מינוס
{
    public class StaticGlobals
    {
        public static MainWindow mainWindow {get; set; }
        public static string mainFolder { get; set; }
        public static string booksFolder { get; set; }
        public static string indexFolder { get; set; }
        public static List<TreeItem> treeItemsList { get; set; }
        public static ObservableCollection<TreeItem> RootItems { get; set; }

        public static void SetFoldersPaths()
        {
            if (string.IsNullOrEmpty(mainFolder))
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
        }

        public static void CopyToSearch(string input)
        {

        }

        public static void CopyToFileNameSearch(string input)
        {

        }
    }
}
