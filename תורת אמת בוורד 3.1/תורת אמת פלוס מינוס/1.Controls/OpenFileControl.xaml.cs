using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_פלוס_מינוס;


namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for OpenFileControl.xaml
    /// </summary>
    public partial class OpenFileControl : UserControl
    {
        OpenFileControlViewModel viewModel;
        public OpenFileControl()
        {
            InitializeComponent();            
            SearchTextBox.Text = תורת_אמת_פלוס_מינוס.Properties.Settings.Default.OpenFileControlLastSearch;
            SearchTextBox.SelectAll();
            viewModel = new OpenFileControlViewModel();
            DataContext = viewModel;
            TreeLoader treeLoader = new TreeLoader();
            treeLoader.PopulateTree(treeView);
            Loaded +=OpenFileControl_Loaded;
        }

        private void OpenFileControl_Loaded(object sender, RoutedEventArgs e)
        {
           SearchTextBox.Focus();
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (treeView.SelectedItem is FolderTreeItem folderTreeItem)
                {
                    folderTreeItem.IsExpanded = !folderTreeItem.IsExpanded;
                }
                else if (treeView.SelectedItem is FileTreeItem fileTreeItem)
                {
                    OpenSelected openSelected = new OpenSelected();
                    openSelected.OpenSelectedFile(fileTreeItem, "", null);
                }
                e.Handled = true;
            }
        }
        private void treeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             if (treeView.SelectedItem is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, "", null);
            }
        }
        private void FileItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, "", null);
            }
        }
        private void SearchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.Search(SearchTextBox.Text, SearchComboBox);
                if (SearchComboBox.HasItems) { SearchComboBox.IsDropDownOpen = true; SearchComboBox.Focus(); }
                e.Handled = true;
            }
            else if (e.Key == Key.Down || e.Key == Key.Up)
            {
                if (treeView.Items.Count > 0)
                {
                    treeView.Focus();
                    e.Handled = true;
                }
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search(SearchTextBox.Text, SearchComboBox);
            if (SearchComboBox.HasItems) { SearchComboBox.IsDropDownOpen = true; SearchComboBox.Focus(); }
        }

        private void FolderItemPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel panel && panel.Tag is FileTreeItem fileTreeItem)
            {
                viewModel.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + SearchComboBox.Tag);
            }
        }

        private void SearchComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (SearchComboBox.SelectedIndex > 0) // Move selection up
                    SearchComboBox.SelectedIndex--;
                e.Handled = true;
            }
            else if (e.Key == Key.Down)                 // Move selection down
            {
                if (SearchComboBox.SelectedIndex < SearchComboBox.Items.Count - 1)
                    SearchComboBox.SelectedIndex++;
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
               if (e.OriginalSource is ComboBoxItem comboBoxItem && comboBoxItem.Tag is FileTreeItem fileTreeItem)
                {
                    viewModel.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + SearchComboBox.Tag);
                }                    
            }

        }

        private void RecentSearchesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileRecentSearches recentSearches = new OpenFileRecentSearches();
            recentSearches.PopulateMenu(RecentSearchesCombo);
            RecentSearchesCombo.IsDropDownOpen = true;
        }

        private void RecentSearchesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = RecentSearchesCombo.SelectedValue;
            SearchTextBox.Text = selectedValue.ToString();
            SearchTextBox.Focus();
            SearchTextBox.CaretIndex = SearchTextBox.Text.Length;
        }
    }
}
