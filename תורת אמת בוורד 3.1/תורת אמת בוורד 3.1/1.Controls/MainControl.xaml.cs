using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using אוצר_הספרים_לוורד.Controls;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1.TreeModels;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        public MainControlViewModel viewModel;
        public MainControl()
        {
            viewModel = new MainControlViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.ShowOpenFileTab(tabControlHost.tabControl);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuCombo.SelectedIndex = -1;
            MainMenuCombo.IsDropDownOpen= true;
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowOpenFileTab(tabControlHost.tabControl);
        }
        private void OpenFile_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.OpenFile();
        }
        private void RecentBooksButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.populateRecentBooks(RecentBooksCombo);
            if (RecentBooksCombo.Items.Count > 0){ RecentBooksCombo.IsDropDownOpen = true;  }
        }
        private void RecentBooksItem_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel stackPanel)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(stackPanel.Tag as TreeItem, "", null);
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowSearchTab(tabControlHost.tabControl);
        }
        private void SearchButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.ShowSearchWindow();
        }
        private void FontsButton_Click(object sender, RoutedEventArgs e)
        {
            FontsCombo.IsDropDownOpen = true;
        }

        #region MainMenu
        private void OpenExternalFile_Selected(object sender, RoutedEventArgs e)
        {
            OpenSelected openSelected = new OpenSelected();
            openSelected.OpenExternalFile();
        }
        private void OpenFilesFolder_Selected(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", StaticGlobals.mainFolder);
        }
        private void CreateNewIndex_Selected(object sender, RoutedEventArgs e)
        {
            IndexerWindow indexerWindow = new IndexerWindow();
            indexerWindow.Show();
        }
        private void ResetFontSettings_Selected(object sender, RoutedEventArgs e)
        {
            viewModel.SetFonts("", 100);
        }
        private void ChangeFolderLocation_Selected(object sender, RoutedEventArgs e)
        {
            viewModel.SetApplicationFolder();
        }

        #endregion

        private void FontsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontsCombo.SelectedItem is FontFamily fontFamily)
            {
                // If it is, extract the font family name and call SetFonts method
                viewModel.SetFonts(fontFamily.ToString(), Properties.Settings.Default.HtmlFontSize);
            }
        }

        private void DecreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            int currentScale = Properties.Settings.Default.HtmlFontSize;
            viewModel.SetFonts(Properties.Settings.Default.HtmlFontFamily, 
                Math.Max(currentScale - 10, 20));
        }

        private void IncreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            int currentScale = Properties.Settings.Default.HtmlFontSize;
            viewModel.SetFonts(Properties.Settings.Default.HtmlFontFamily,
               currentScale + 10);
        }

        private void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            StaticGlobals.ShowAramaicDictionary();
        }

        private void AboutButton_Selected(object sender, RoutedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://mitmachim.top/post/704012"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ShemHashemDisplayOptions_Selected(object sender, RoutedEventArgs e)
        {
            viewModel.ShemHashemDisplayOptions();
        }

        private void DeleteIndex_Selected(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteIndex();
        }

        private void CopyRightButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowCopyRight(tabControlHost.tabControl);
        }

        private void SetExternalDefaultFolder_Selected(object sender, RoutedEventArgs e)
        {
            viewModel.SetDefaultExternalFolder();
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                viewModel.ShowOpenFileTab(tabControlHost.tabControl);
            }
        }



    }
}
