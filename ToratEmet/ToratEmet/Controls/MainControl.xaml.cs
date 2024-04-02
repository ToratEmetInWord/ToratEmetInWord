using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToratEmet.Controls.ViewModels;
using ToratEmet.Models;
using ToratEmet.TreeModels;
using ToratEmet.WebViewModels;

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
            CostumeWindowsHandler.ShowOpenFileTab(tabControlX.tabControl);
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
            RecentBooks recentBooks = new RecentBooks();
            recentBooks.PopulateMenu(RecentBooksComboBox);
            if (RecentBooksComboBox.Items.Count > 0) { RecentBooksComboBox.IsDropDownOpen = true; }
        }

        private void FolderItemPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel stackPanel)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(stackPanel.Tag as TreeItem, "", null);
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

       
    }
}
