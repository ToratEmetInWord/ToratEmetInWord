using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_פלוס_מינוס;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        SearchControlViewModel viewModel;
        public SearchControl()
        {
            viewModel = new SearchControlViewModel(this);
            DataContext = viewModel;
            InitializeComponent();
            viewModel.InitializeWebview();
            ProgressBarDelgate.AttachProgressBar(progressBar);
            SearchTypeCombo.SelectedIndex = תורת_אמת_פלוס_מינוס.Properties.Settings.Default.SearchMethodComboIndex;
            //updatePbDelegate = new UpdateProgressBarDelegate(progressBar.SetValue);            
            Loaded +=SearchControl_Loaded;
        }

        private void SearchControl_Loaded(object sender, RoutedEventArgs e)
        {
            SearchTextBox.SelectAll();
            SearchTextBox.Focus();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.Search();
                e.Handled = true;
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search();
        }

        private void SearchTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.SearchMethodComboIndex = SearchTypeCombo.SelectedIndex;
            תורת_אמת_פלוס_מינוס.Properties.Settings.Default.Save();
            ComboBoxItem comboBoxItem = SearchTypeCombo.SelectedItem as ComboBoxItem;
            viewModel.SetSearchType(comboBoxItem.Content as string);
        }

        private void RegexCharCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegexCharCombo.SelectedIndex > 0)
            {
                ComboBoxItem comboBoxItem = RegexCharCombo.SelectedItem as ComboBoxItem;
                string text = comboBoxItem.Content as string;
                text = Regex.Replace(text, "[א-ת]", "");
                if (string.IsNullOrEmpty(SearchTextBox.Text))
                {
                    SearchTextBox.Text = text;
                    SearchTextBox.Focus();
                    SearchTextBox.CaretIndex = SearchTextBox.Text.Length;
                }
                else
                {
                    int caretIndex = SearchTextBox.CaretIndex;
                    SearchTextBox.Focus();
                    SearchTextBox.SelectedText = text;
                    SearchTextBox.CaretIndex = caretIndex + text.Length;
                }
                RegexCharCombo.SelectedIndex = 0;
            }
        }

        private void ShowAllSnippetsCheckBox_CheckChanged(object sender, RoutedEventArgs e)
        {
            bool isChecked = ShowAllSnippetsCheckBox.IsChecked ?? false; // Use false as default if it's null
            WebViewCommands.ToggleSnippets(webView, isChecked);
        }

        private void SearchExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RecentSearchesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = RecentSearchesCombo.SelectedValue;
            SearchTextBox.Text = selectedValue.ToString();
            SearchTextBox.Focus();
            SearchTextBox.CaretIndex = SearchTextBox.Text.Length;
        }

        private void RecentSearches_Click(object sender, RoutedEventArgs e)
        {
            RecentSearches recentSearches = new RecentSearches();
            recentSearches.PopulateMenu(RecentSearchesCombo);
            RecentSearchesCombo.IsDropDownOpen = true; 
        }
    }
}
