using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToratEmet.BookParsingModels;
using ToratEmet.Models;
using ToratEmet.TreeModels;
using ToratEmet.ViewModels;
using ToratEmet.WebViewModels;

namespace ToratEmet.Controls
{
    /// <summary>
    /// Interaction logic for BookViewer.xaml
    /// </summary>
    public partial class BookViewer : UserControl
    {
        public BookViewerViewModel viewModel;
        TabItem tabItem;
        public BookViewer(BookItem bookItem, TabItem tabitem)
        {
            InitializeComponent();
            tabItem = tabitem;
            viewModel = new BookViewerViewModel(this, bookItem, webViewControl, tabItem);
            DataContext = viewModel;
            viewModel.PopulateRealtiveBooksCombo();
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
            else { SearchToolBar.Visibility = Visibility.Collapsed; }
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
            MoveTabToNewWindow.Execute(tabItem);
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt && e.Key == Key.C)
            {
                WebViewCommands.CopyToWord(webViewControl);
            }
        }

    }
}
