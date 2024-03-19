using FolderPicker;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using תורת_אמת_בוורד_3._1._1.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_בוורד_3._1.Properties;

namespace תורת_אמת_בוורד_3._1._2.ViewModels
{
    public class MainControlViewModel: INotifyPropertyChanged
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<FontFamily> _fontsList = new ObservableCollection<FontFamily>();
        public ObservableCollection<FontFamily> FontsList
        {
            get { return _fontsList; }
            set
            {
                _fontsList = value;
                OnPropertyChanged(nameof(FontsList));
            }
        }
        #endregion

        public MainControlViewModel() 
        {
            PopulateFontList();
        }

        void PopulateFontList()
        {
            string[] prioritizedFontNames = { "frankruehl", "times", "narkisim", "hadas", "calibri", "arial", "david", "gisha", "frank", "segoe", "guttman", "aharoni" };
            var fontFamilies = prioritizedFontNames
                .Select(name => new FontFamily(name))
                .Concat(Fonts.SystemFontFamilies.Except(prioritizedFontNames.Select(name => new FontFamily(name))));
            FontsList = new ObservableCollection<FontFamily>(fontFamilies);
        }

        public void OpenFile()
        {
            GlobalsX.ShowOpenFileWindow();
        }
        public void populateRecentBooks(ComboBox comboBox)
        {
            RecentBooks recentBooks = new RecentBooks();
            recentBooks.PopulateMenu(comboBox);
        }
        public void SetFonts(string fontFamily, int fontsize)
        {
            Properties.Settings.Default.HtmlFontFamily = fontFamily;
            Properties.Settings.Default.HtmlFontSize = fontsize;
            Properties.Settings.Default.Save();

            foreach (MainControl mainControl in GlobalsX.mainControlsDictionary.Values) 
            {
                foreach (TabItem tabItem in mainControl.tabControl.tabControl.Items)
                {
                    if (tabItem.Content is BookViewer bookViewer) 
                    {
                        WebViewCommands.SetFont(bookViewer.webViewControl.webView);
                    }
                }
            }
        }        
        public void SetApplicationFolder()
        {
            string originalFolder = GlobalsX.mainFolder;
            string newFolderPath = FolderPickerLauncher.Pick_A_Folder("בחר מיקום חדש עבור תיקיית התוסף");
            if (!string.IsNullOrEmpty(newFolderPath)) 
            {
                Settings.Default.MainFolder = newFolderPath;
                Settings.Default.Save();
                GlobalsX.SetFoldersPaths();
                Directory.Move(originalFolder, newFolderPath);
            }
            
        }
    }
}
