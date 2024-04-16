using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ToratEmet.Controls.ViewModels;
using ToratEmet.Models;
using ToratEmet.TreeModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToratEmet.Controls
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        MainControlViewModel viewModel;
        public MainControl()
        {
            InitializeComponent();
            viewModel = new MainControlViewModel(this);
            DataContext = viewModel;    
            if (Properties.Settings.Default.UpdatesDisabled) { ToggleUpdates.Content = "הפעל בדיקת עדכונים אוטומטית"; }
            else { ToggleUpdates.Content = "כבה בדיקת עדכונים אוטומטית"; }
            Loaded += MainControl_Loaded;
        }

        private void MainControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.IsOpenLastSessionEnabled)
            {
                RecentBooks.ResumeSession(tabControlX.tabControl);
                Properties.Settings.Default.IsOpenLastSessionEnabled = false;
                Properties.Settings.Default.LastSessionCollection = null;
                Properties.Settings.Default.Save();               
            }
            else { CostumeWindowsHandler.ShowOpenFileTab(tabControlX.tabControl); }
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuComboBox.IsDropDownOpen = true;
        }

        #region MainMenu
        private void OpenExternalFile_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.OpenExternalFile();
        }
        private void SetExternalDefaultFolder_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.SetExternalDefaultFolder();
        }
        private void ShowFilesFolder_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.ShowApplicationFilesFolder();
        }
        private void ChangeFolderLocation_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.ChangeApplicationFolderLocation();
        }
        private void ChangeToratEmetLocation_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.ChangeToratEmetLocation();
        }
        private void CreateNewIndex_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.CreateNewIndex();
        }
        private void DeleteIndex_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.DeleteIndex();
        }
        private void ResetFontSettings_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.ResetFontSettings();
        }
        private void ShemHashemDisplayOptions_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.ShemHashemDisplayOptions();
        }
        private void AboutButton_Selected(object sender, RoutedEventArgs e)
        {
            MainMenuCommands.AboutButton();
        }

        private void MainMenuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainMenuComboBox.SelectedIndex = -1;
        }
        #endregion

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            CostumeWindowsHandler.ShowOpenFileTab(tabControlX.tabControl);
        }

        private void OpenFileButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CostumeWindowsHandler.ShowOpenFileWindow();
        }

        private void RecentBooksButton_Click(object sender, RoutedEventArgs e)
        {
            RecentBooks.PopulateMenu(RecentBooksComboBox);
            if (RecentBooksComboBox.Items.Count > 0) { RecentBooksComboBox.IsDropDownOpen = true; }
        }


        private void RecentBooksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecentBooksComboBox.SelectedItem is TreeItem treeItem)
            {
                viewModel.OpenRecentBook(treeItem);
            }
            RecentBooksComboBox.SelectedIndex = -1;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            CostumeWindowsHandler.ShowSearchTab(tabControlX.tabControl);
        }

        private void SearchButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CostumeWindowsHandler.ShowSearchWindow();
        }

        private void FontFamilyButton_Click(object sender, RoutedEventArgs e)
        {
            FontsCombo.IsDropDownOpen = true;
        }

        private void FontsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontsCombo.SelectedItem is FontFamily fontFamily)
            {
                Properties.Settings.Default.HtmlFontFamily = fontFamily.ToString();
                Properties.Settings.Default.Save();
            }
            FontsCombo.SelectedIndex = -1;
        }

        private void IncreaseFontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HtmlFontSize = Properties.Settings.Default.HtmlFontSize + 10;
            Properties.Settings.Default.Save();
        }

        private void DecreaseFontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HtmlFontSize = Properties.Settings.Default.HtmlFontSize - 10;
            Properties.Settings.Default.Save();
        }

        private void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            CostumeWindowsHandler.ShowDictionaryWindow();
        }

        private void CopyRightButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowCopyRight(tabControlX.tabControl);
        }

        private void ToggleUpdates_Selected(object sender, RoutedEventArgs e)
        {
            bool updatesDisabled = Properties.Settings.Default.UpdatesDisabled;
            MainMenuCommands.ToggleUpdates();
            if (Properties.Settings.Default.UpdatesDisabled) { ToggleUpdates.Content = "הפעל בדיקת עדכונים אוטומטית"; }
            else { ToggleUpdates.Content = "כבה בדיקת עדכונים אוטומטית"; }
            if (updatesDisabled != Properties.Settings.Default.UpdatesDisabled) { MessageBox.Show("ההגדרות שונו בהצלחה"); }
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowInstructions();
        }

       
    }
}
