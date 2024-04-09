using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToratEmet.Controls.ViewModels;
using ToratEmet.Models;
using ToratEmet.TreeModels;

namespace ToratEmet.Controls
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

            viewModel = new OpenFileControlViewModel();
            DataContext = viewModel;
            TreeLoader.PopulateTree(treeView);
            SearchTextBox.SelectAll();
            SearchTextBox.Text = Properties.Settings.Default.OpenFileControlLastSearch;          
            Loaded += (sender, e) => 
            {                   
                SearchTextBox.Focus(); 
            };
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
                    viewModel.OpenSelectedFile(fileTreeItem, "");
                }
                e.Handled = true;
            }
        }
        private void treeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (treeView.SelectedItem is FileTreeItem fileTreeItem) { viewModel.OpenSelectedFile(fileTreeItem, "");}
        }
        private void FileItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is FileTreeItem fileTreeItem){  viewModel.OpenSelectedFile(fileTreeItem, "");}
        }
        private void SearchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.Search(SearchTextBox.Text);
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
            viewModel.Search(SearchTextBox.Text);
            if (SearchComboBox.HasItems) { SearchComboBox.IsDropDownOpen = true; SearchComboBox.Focus(); }
        }

        private void ItemPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel panel && panel.Tag is FileTreeItem fileTreeItem)
            {
                viewModel.OpenSelectedFile(fileTreeItem, SearchComboBox.Tag.ToString());
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
                    viewModel.OpenSelectedFile(fileTreeItem, SearchComboBox.Tag.ToString());
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

        private void SearchTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var txtControl = sender as TextBox;
            txtControl.Dispatcher.BeginInvoke(new Action(() =>
            {
                txtControl.SelectAll();
            }));
        }

        private void SearchComboBoxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ComboBoxItem comboBoxItem && comboBoxItem.Content is FileTreeItem treeItem) 
            {
                OpenSelected openSelected = new OpenSelected(); 
                openSelected.OpenSelectedFile(treeItem, "", "", null);
                e.Handled = true;
            }
        }
    }
}
