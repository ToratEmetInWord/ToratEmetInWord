using Microsoft.Web.WebView2.Wpf;
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
using תורת_אמת_בוורד_3._1._3.Models;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using תורת_אמת_בוורד_3._1._6.WebViewModels;
using תורת_אמת_בוורד_3._1.TreeModels;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for BookViewer.xaml
    /// </summary>
    public partial class BookViewer : UserControl, IDisposable
    {
        public BookViewerViewModel viewModel;
        public TabItem tabItem;
        public BookViewer(BookItem bookItem, TabItem tabitem)
        {
            tabItem = tabitem;
            InitializeComponent();
            viewModel = new BookViewerViewModel (this, bookItem, webViewControl);
            DataContext = viewModel;
            viewModel.PopulateRealtiveBooksCombo();           
        }
        public void Dispose()
        {
            webViewControl.Dispose();
            if (viewModel != null) { viewModel.Dispose(); }
            viewModel = null;
        }

        private void BookInfoButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ViewInfo();
        }
        private void ReltiveBooks_FileItemButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock && textBlock.Tag is FileTreeItem treeItem)
            {
                viewModel.OpenRelativeBook(treeItem);
            }
        }
        private void RelativeBooks_CheckChanged(object sender, RoutedEventArgs e)
        {
            viewModel.ComboViewItemsCheckChange();
        }
        private void RealtiveBooksButton_Click(object sender, RoutedEventArgs e)
        {
            RelativeBooksCombo.IsDropDownOpen = true;
        }
        private void ChapterTreeButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowChapterTree();
        }
        private void ShowLessButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowLess();
        }
        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowMore();
        }
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowPrevious();
        }
        private void NikkudButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ToggleHideNikud();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowNext();
        }
        private void CatillationsButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ToggleHideCantillations();
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RefreshPage();
        }
        private void ToggleSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleSearchButton.IsChecked == true) 
            {
                SearchToolBar.Visibility = Visibility.Visible; 
                SearchTextBox.SelectAll();
                SearchTextBox.Focus();
            }
            else { SearchToolBar.Visibility = Visibility.Collapsed;}
        }
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                viewModel.SearchNext(SearchTextBox.Text);
                e.Handled = true;
            }
        }
        private void SearchNextButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SearchNext(SearchTextBox.Text);
        }
        private void SearchPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SearchPrevious(SearchTextBox.Text);
        }

        private void OpenInNewWIndowButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
