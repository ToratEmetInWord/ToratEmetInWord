using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1.TreeModels;


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
            SearchTextBox.Text = Properties.Settings.Default.OpenFileControlLastSearch;
            SearchTextBox.SelectAll();
            tabControl.SelectedIndex = Properties.Settings.Default.OpenFileControlSelectedTab;
            viewModel = new OpenFileControlViewModel();
            DataContext = viewModel;
            TreeLoader treeLoader = new TreeLoader();
            treeLoader.PopulateTree(treeView);
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.OriginalSource != SearchListBox)
            {
                Properties.Settings.Default.OpenFileControlSelectedTab = tabControl.SelectedIndex;
                Properties.Settings.Default.Save();
                if (tabControl.SelectedIndex == 0) { treeView.Focus(); }
                else { SearchTextBox.Focus(); SearchTextBox.SelectAll(); }
            }
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
                    openSelected.OpenSelectedFile(fileTreeItem, "");
                }
                e.Handled = true;
            }
        }
        private void treeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             if (treeView.SelectedItem is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, "");
            }
        }
        private void FileItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, "");
            }
        }
        private void SearchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.Search(SearchTextBox.Text, SearchListBox);
                e.Handled = true;
            }
            else if (e.Key == Key.Down || e.Key == Key.Up)
            {
                if (SearchListBox.Items.Count > 0)
                {
                    if (SearchListBox.SelectedIndex < 0) { SearchListBox.SelectedIndex = 0; }
                    var itemSlected = SearchListBox.ItemContainerGenerator.ContainerFromItem(SearchListBox.SelectedItem);
                    if (itemSlected != null && itemSlected is ListBoxItem listBoxItem) { listBoxItem.Focus(); }
                    e.Handled = true;
                }
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search(SearchTextBox.Text, SearchListBox);
        }
        private void SearchListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (SearchListBox.SelectedItem is FileTreeItem fileTreeItem)
                {
                    OpenSelected openSelected = new OpenSelected();
                    openSelected.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + SearchListBox.Tag);
                }
                e.Handled = true;
            }
        }
        private void SearchListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SearchListBox.SelectedItem is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + SearchListBox.Tag);
            }
            e.Handled = true;
        }
        private void FileListItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is FileTreeItem fileTreeItem)
            {
                OpenSelected openSelected = new OpenSelected();
                openSelected.OpenSelectedFile(fileTreeItem, fileTreeItem.Name + SearchListBox.Tag);
            }
        }
    }
}
