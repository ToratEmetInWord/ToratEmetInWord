using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using ToratEmet.Models;
using ToratEmet.TreeModels;
using ToratEmet.ViewModels;

namespace ToratEmet.Controls
{
    /// <summary>
    /// Interaction logic for SearchExplorerControl.xaml
    /// </summary>
    public partial class SearchExplorerControl : UserControl
    {
        SearchExplorerControlViewModel viewModel;
        SearchControl searchControl;
        public SearchExplorerControl()
        {
            viewModel = new SearchExplorerControlViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.PopulateTreeView(treeView);

            tabControl.SelectedIndex = Properties.Settings.Default.SearchExplorerTabIndex;
            Loaded += SearchExplorerControl_Loaded;
        }

        private void SearchExplorerControl_Loaded(object sender, RoutedEventArgs e)
        {
            StringCollection strings = Properties.Settings.Default.CheckedTreeItems;
            foreach (var item in StaticGlobals.treeItemsList)
            {
                if (Properties.Settings.Default.CheckedTreeItems != null &&
                        Properties.Settings.Default.CheckedTreeItems.Contains(item.Address))
                {
                    item.IsChecked = true;
                }
                if (Properties.Settings.Default.CheckedListBoxItems != null &&
                    Properties.Settings.Default.CheckedListBoxItems.Contains(item.Address))
                {
                    item.IsChecked2 = true;
                }
            }
            var list = new ObservableCollection<TreeItem>(StaticGlobals.treeItemsList.Where(item => item.IsChecked2 == true).ToList());
            viewModel.ResultList = list;
            SearchResultBox.ItemsSource = list;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search(SearchTextBox.Text, SearchResultBox);
        }
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.Search(SearchTextBox.Text, SearchResultBox);
                e.Handled = true;
            }
        }

        private void ListBoxSelectAll_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CheckAllListBoxItems(SearchResultBox);
        }
        private void ListBoxUnselectAll_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UncheckAllListBoxItems(SearchResultBox);
        }
        //private void ListBoxOkButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Properties.Settings.Default.SearchExplorerTabIndex = "ListBoxSearch";
        //}

        private void TreeViewSelectAll_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CheckAllTreeItems();
        }
        private void TreeViewUnselectAll_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UncheckAllTreeItems();
        }
        //private void TreeViewOkButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Properties.Settings.Default.SearchExplorerTabIndex = "TreeViewSearch";
        //}
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.SearchExplorerTabIndex = tabControl.SelectedIndex;
            Properties.Settings.Default.Save();
            if (tabControl.SelectedIndex == 1) { SearchTextBox.Focus(); }
        }

        private void ShowSearch_button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void ShowTree_Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void CheckAllCheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (CheckAllCheckBox.IsChecked == true) { viewModel.CheckAllListBoxItems(SearchResultBox); }
                else { viewModel.UncheckAllListBoxItems(SearchResultBox); }
            }
            else if (tabControl.SelectedIndex == 0)
            {
                if (CheckAllCheckBox.IsChecked == true) { viewModel.CheckAllTreeItems(); }
                else { viewModel.UncheckAllTreeItems(); }
            }
        }

        private void ShowSearchResults_button_Click(object sender, RoutedEventArgs e)
        {
            if (searchControl == null) { searchControl = FindParentOrChild.TryFindParent<SearchControl>(this); }
            if (searchControl != null) { searchControl.BookExplorerTabControl.SelectedIndex = 0; }
        }

        private void SearchTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var txtControl = sender as TextBox;
            txtControl.Dispatcher.BeginInvoke(new Action(() =>
            {
                txtControl.SelectAll();
            }));
        }
    }
}
