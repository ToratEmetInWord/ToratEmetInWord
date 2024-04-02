using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToratEmet.ViewModels;

namespace ToratEmet.Controls
{
    /// <summary>
    /// Interaction logic for AramaicDictionaryControl.xaml
    /// </summary>
    public partial class AramaicDictionaryControl : UserControl
    {
        AramaicDictionaryViewModel viewModel;
        bool isLoaded;
        public AramaicDictionaryControl()
        {
            InitializeComponent();
            viewModel = new AramaicDictionaryViewModel(ResultsWebView, SuggestionsBox);
            AramaicToHebrew.IsChecked = Properties.Settings.Default.UseArmaicDictionary;
            HebrewtoAramaic.IsChecked = !Properties.Settings.Default.UseArmaicDictionary;
            SearchBox.Focus();
            isLoaded = true;
            Loaded += AramaicDictionaryControl_Loaded;
        }

        private void AramaicDictionaryControl_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.InitializeWebViewAsync();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Search(SearchBox.Text, SuggestionsBox, ResultsWebView, true);
        }
        private void AramaicToHebrew_CheckedChange(object sender, RoutedEventArgs e)
        {
            if (AramaicToHebrew.IsChecked == true)
            {
                HebrewtoAramaic.IsChecked = false;
                viewModel.PopulateAramaicDictionary();
                viewModel.Search(SearchBox.Text, SuggestionsBox, ResultsWebView, true);
            }
            if (isLoaded)
            {
                Properties.Settings.Default.UseArmaicDictionary = AramaicToHebrew.IsChecked.GetValueOrDefault();
                Properties.Settings.Default.Save();
            }
            SearchBox.Focus();
        }
        private void HebrewtoAramaic_CheckedChange(object sender, RoutedEventArgs e)
        {
            if (HebrewtoAramaic.IsChecked == true)
            {
                AramaicToHebrew.IsChecked = false;
                viewModel.PopulateHebrewDictionary();
            }
            viewModel.Search(SearchBox.Text, SuggestionsBox, ResultsWebView, true);
        }
        private void SuggestionTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                viewModel.Search(textBlock.Text.NormalizeHebrewText(), SuggestionsBox, ResultsWebView, false);
            }
        }
    }
}

