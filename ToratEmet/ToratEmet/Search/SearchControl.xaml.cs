using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToratEmet.Models;
using ToratEmet.Properties;
using ToratEmet.ViewModels;
using ToratEmet.WebViewModels;

namespace ToratEmet.Controls
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
            ProgressBarDelgate.AttachProgressBar(progressBar);
            SearchTypeCombo.SelectedIndex = Settings.Default.SearchMethodComboIndex;
            //updatePbDelegate = new UpdateProgressBarDelegate(progressBar.SetValue);            
            Loaded += SearchControl_Loaded;
        }

        private void SearchControl_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.InitializeWebview();
            SearchTextBox.SelectAll();
            SearchTextBox.Focus();
        }

        private async void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && SearchButton.Content.ToString() == "חפש")
            {
                SearchButton.Content = "עצור";
                BookExplorerTabControl.SelectedIndex = 0;
                await viewModel.Search();
                Dispatcher.Invoke((Action)(() => SearchButton.Content = "חפש"));
                e.Handled = true;
            }
        }
        private 
            
        async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content.ToString() == "חפש")
            {
                button.Content = "עצור";
                BookExplorerTabControl.SelectedIndex = 0;
                await viewModel.Search();
                Dispatcher.Invoke((Action)(() => SearchButton.Content = "חפש"));
            }
            else if (button.Content.ToString() == "עצור")
            {
                if (viewModel.searchMethod.cancellationTokenSource != null)
                {
                    viewModel.searchMethod.cancellationTokenSource.Cancel();
                    Dispatcher.Invoke((Action)(() => SearchButton.Content = "חפש"));
                    viewModel.searchMethod.cancellationTokenSource.Dispose();
                }
            }
        }

        private void SearchTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Default.SearchMethodComboIndex = SearchTypeCombo.SelectedIndex;
            Settings.Default.Save();
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
            BookExplorerTabControl.SelectedIndex = 1;
        }

        private void SearchExplorerButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CostumeWindowsHandler.ShowSearchExplorerWindow();
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

        private void SearchAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (BookExplorerTabControl != null) { BookExplorerTabControl.SelectedIndex = 0; }
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
