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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using תורת_אמת_בוורד_3._1._1.Controls;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_בוורד_3._1.Properties;

namespace תורת_אמת_בוורד_3._1._2.ViewModels
{
    public class MainControlViewModel : INotifyPropertyChanged
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
            StaticGlobals.ShowOpenFileWindow();
        }

        public void ShowOpenFileTab(TabControl tabControl)
        {
            TabItem tabItem = tabControl.Items.Cast<TabItem>().FirstOrDefault(item => item.Name == "openBook");
            if (tabItem == null) { tabItem = new TabItem {  Name="openBook", Header = "פתח ספר" }; tabControl.Items.Add(tabItem);}

            if (StaticGlobals.openFileControl == null) { StaticGlobals.openFileControl = new OpenFileControl(); }
            var parent = StaticGlobals.openFileControl.Parent;
            if (parent != null) 
            {
                if (parent is TabItem tab && tab != tabItem && tab.Parent is TabControl tabParent)
                { 
                    tabParent.Items.Remove(tab);
                }
                else if (parent == StaticGlobals.openFileWindow)
                {
                    StaticGlobals.openFileWindow.Close();
                    StaticGlobals.openFileWindow.Content = null;
                }
            }
           
            tabItem.Content = StaticGlobals.openFileControl;
            tabItem.IsSelected = true;
        }

        public void ShowSearchTab(TabControl tabControl)
        {
            TabItem tabItem = tabControl.Items.Cast<TabItem>().FirstOrDefault(item => item.Name == "search");
            if (tabItem == null) { tabItem = new TabItem { Name="search", Header = "חיפוש" }; tabControl.Items.Add(tabItem); }

            if (StaticGlobals.searchControl == null) { StaticGlobals.searchControl = new SearchControl(); }
            var parent = StaticGlobals.searchControl.Parent;
            if (parent != null)
            {
                if (parent is TabItem tab && tab != tabItem && tab.Parent is TabControl tabParent)
                {
                    tabParent.Items.Remove(tab);
                }
                else if (parent == StaticGlobals.searchWindow)
                {
                    StaticGlobals.searchWindow.Close();
                    StaticGlobals.searchWindow.Content = null;
                }
            }

            tabItem.Content = StaticGlobals.searchControl;
            tabItem.IsSelected = true;
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

            foreach (MainControl mainControl in StaticGlobals.mainControlsDictionary.Values)
            {
                foreach (TabItem tabItem in mainControl.tabControlHost.tabControl.Items)
                {
                    if (tabItem.Content is BookViewer bookViewer)
                    {
                        WebViewCommands.SetFont(bookViewer.webViewControl);
                    }
                }
            }

            foreach (Window window in StaticGlobals.windowList)
            {
                if (window.Content is TabControlX tabControl)
                {
                    foreach (TabItem tabItem in tabControl.tabControl.Items)
                    {
                        if (tabItem.Content is BookViewer bookViewer)
                        {
                            WebViewCommands.SetFont(bookViewer.webViewControl);
                        }
                    }
                }
            }
        }
        public void SetApplicationFolder()
        {
            string originalFolder = StaticGlobals.mainFolder;
            string newFolderPath = FolderPickerLauncher.Pick_A_Folder("בחר מיקום חדש עבור תיקיית התוסף");
            if (!string.IsNullOrEmpty(newFolderPath))
            {
                Settings.Default.MainFolder = newFolderPath;
                Settings.Default.Save();
                StaticGlobals.SetFoldersPaths();
                Directory.Move(originalFolder, newFolderPath);
            }

        }

        public void ShowSearchWindow()
            {
            StaticGlobals.ShowSearchWindow();
        }

        public void ShemHashemDisplayOptions()
        {
            OptionsWindow optionsWindow = new OptionsWindow
               ("תצוגת שם ה' (בחיפוש יש להזין יקוק)", "שם הוי-ה", "יי", "יקוק", "ה'")
            {
                FlowDirection = FlowDirection.RightToLeft,
                Height = 100,
                Width = 250,
                Icon = null
            };
            var result = optionsWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Settings.Default.ShemHashemDisplayOptions = optionsWindow.ClickedButton;
                Settings.Default.Save();
            }
        }

        public void DeleteIndex()
        {
            MessageBoxResult result = MessageBox.Show("האם אתה בטוח שברצונך למחוק את האינדקס?", "אישור מחיקת אינדקס", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (result == MessageBoxResult.Yes)
            {
                if (Directory.Exists(StaticGlobals.indexFolder))
                {
                    Directory.Delete(StaticGlobals.indexFolder, true);
                    Directory.CreateDirectory(StaticGlobals.indexFolder);
                }
                if (Directory.GetFileSystemEntries(StaticGlobals.indexFolder).Length == 0)
                {
                    Properties.Settings.Default.BusyIndexing = false;
                    Settings.Default.Save();
                    MessageBox.Show("האינדקס נמחק בהצלחה");
                }
            }          
        }

        public void ShowCopyRight(TabControl tabControl)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.AllowDrop = false;
            webBrowser.KeyDown += (sender, e) => { e.Handled = true; };
            webBrowser.NavigateToString(CopyRight.ToratEmetCopyRight());
            TabItem tabItem = new TabItem { Header = "זכויות יוצרים", Content = webBrowser };
            tabControl.Items.Add(tabItem);
            tabControl.SelectedItem = tabItem;
        }


        public void SetDefaultExternalFolder()
        {
            string folder = FolderPickerLauncher.Pick_A_Folder("בחר תיקיית ברירת מחדל עבור פתיחת קבצים חיצוניים");
            Properties.Settings.Default.DefaultExternalFolder = folder;
            Properties.Settings.Default.Save();
        }
    }
}
