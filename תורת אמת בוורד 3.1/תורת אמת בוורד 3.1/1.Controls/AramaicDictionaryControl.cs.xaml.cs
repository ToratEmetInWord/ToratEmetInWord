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
using אוצר_הספרים_לוורד.ViewModels;
using תורת_אמת_בוורד_3._1;

namespace אוצר_הספרים_לוורד.Controls
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
            AramaicToHebrew.IsChecked = תורת_אמת_בוורד_3._1.Properties.Settings.Default.UseArmaicDictionary;
            HebrewtoAramaic.IsChecked = !תורת_אמת_בוורד_3._1.Properties.Settings.Default.UseArmaicDictionary;
            SearchBox.Focus();
            isLoaded = true;
            Loaded +=AramaicDictionaryControl_Loaded;
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
                תורת_אמת_בוורד_3._1.Properties.Settings.Default.UseArmaicDictionary = AramaicToHebrew.IsChecked.GetValueOrDefault();
                תורת_אמת_בוורד_3._1.Properties.Settings.Default.Save();
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
