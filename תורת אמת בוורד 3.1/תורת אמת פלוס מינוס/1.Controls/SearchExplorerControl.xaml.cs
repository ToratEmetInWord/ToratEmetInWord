using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using תורת_אמת_בוורד_3._1.TreeModels;
using תורת_אמת_פלוס_מינוס;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for SearchExplorerControl.xaml
    /// </summary>
    public partial class SearchExplorerControl : UserControl
    {
        SearchExplorerControlViewModel viewModel;
        public SearchExplorerControl()
        {
            InitializeComponent();
            viewModel = new SearchExplorerControlViewModel();
            viewModel.PopulateTreeView(treeView);
            DataContext = viewModel;
            tabControl.SelectedIndex = תורת_אמת_פלוס_מינוס.Properties.Settings.Default.SearchExplorerTabIndex;
            Loaded +=SearchExplorerControl_Loaded;
        }

        private void SearchExplorerControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in StaticGlobals.treeItemsList)
            {
                if (תורת_אמת_פלוס_מינוס.Properties.Settings.Default.CheckedTreeItems != null &&
                        תורת_אמת_פלוס_מינוס.Properties.Settings.Default.CheckedTreeItems.Contains(item.Address))
                {
                    item.IsChecked = true;
                }
                if (תורת_אמת_פלוס_מינוס.Properties.Settings.Default.CheckedListBoxItems != null &&
                    תורת_אמת_פלוס_מינוס.Properties.Settings.Default.CheckedListBoxItems.Contains(item.Address))
                {
                    item.IsChecked2 = true;
                }
            }
            var list = new ObservableCollection<TreeItem>(StaticGlobals.treeItemsList.Where(item => item.IsChecked2 == true).ToList());
            viewModel.ResultList = list;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search(SearchTextBox.Text);
        }
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                viewModel.Search(SearchTextBox.Text);
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
            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.SearchExplorerTabIndex = tabControl.SelectedIndex;
            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.Save();
        }
    }
}
