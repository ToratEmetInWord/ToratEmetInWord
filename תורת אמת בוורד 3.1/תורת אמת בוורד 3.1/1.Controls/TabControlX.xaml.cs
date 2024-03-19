using Microsoft.Web.WebView2.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using תורת_אמת_בוורד_3._1._3.Models;

namespace תורת_אמת_בוורד_3._1._1.Controls
{
    /// <summary>
    /// Interaction logic for TabControlX.xaml
    /// </summary>
    public partial class TabControlX : UserControl
    {
        public TabControlX()
        {
            InitializeComponent();
        }
        private void Button_TabClose_Click(object sender, RoutedEventArgs e)
        {
            UIElement uIElement = sender as UIElement;
            TabItem tabItem = FindParentOrChild.TryFindParent<TabItem>(uIElement);
            TabControl tabControl = tabItem.Parent as TabControl;

            DiposeTabContent(tabItem);

            int currentIndex = tabControl.Items.IndexOf(tabItem);
            tabControl.Items.Remove(tabItem);
            selectPreviousItem(tabControl, currentIndex);
        }

        private void selectPreviousItem(TabControl tabControl, int currentIndex)
        {
            if (tabControl.Items.Count > 0)
            {
                if (currentIndex > 0)
                {
                    tabControl.SelectedIndex = currentIndex - 1;
                }
                else
                {
                    tabControl.SelectedIndex = currentIndex + 1;
                }
            }
        }

        private void TabBorder_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                TabItem tabItem = FindParentOrChild.TryFindParent<TabItem>((DependencyObject)e.OriginalSource);
                if (tabItem != null)
                {
                    DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.Move);
                }
            }
        }

        private void TabBorder_Drop(object sender, DragEventArgs e)
        {
            if (sender is Border border)
            {
                border.Effect = null;
            }

            TabItem droppedTab = e.Data.GetData(typeof(TabItem)) as TabItem;
            TabItem destinationTab = FindParentOrChild.TryFindParent<TabItem>((DependencyObject)e.OriginalSource);

            if (droppedTab != null && destinationTab != null)
            {
                TabControl tabControl = destinationTab.Parent as TabControl;

                if (tabControl != null)
                {
                    int insertionIndex = tabControl.Items.IndexOf(destinationTab);

                    if (insertionIndex != -1)
                    {
                        tabControl.Items.Remove(droppedTab);
                        tabControl.Items.Insert(insertionIndex, droppedTab);
                        tabControl.SelectedIndex = insertionIndex;
                    }
                }
            }
        }

        private void TabBorder_DragEnter(object sender, DragEventArgs e)
        {
            if (sender is Border border)
            {
                border.Effect = new DropShadowEffect
                {
                    Color = Colors.LightGray,
                    ShadowDepth = 1
                };
            }
        }

        private void TabBorder_DragLeave(object sender, DragEventArgs e)
        {
            if (sender is Border border)
            {
                border.Effect = null;
            }
            //TabItem tabItem = FindParentControl.FindParent<TabItem>((DependencyObject)sender);
            //tabItem.IsSelected = false;
            //tabItem = e.Data.GetData(typeof(TabItem)) as TabItem;
            //tabItem.IsSelected = true;
        }


        private void TabsDropDown_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            ContextMenu contextMenu = new ContextMenu();

            MenuItem menuItem = new MenuItem
            {
                Header = "סגור הכל"
            };
            menuItem.Click += CloseAll_Click;
            contextMenu.Items.Add(menuItem);
            Separator separator = new Separator();
            contextMenu.Items.Add(separator);

            foreach (TabItem tabItem in ((TabControl)button.TemplatedParent).Items)
            {
                menuItem = new MenuItem
                {
                    Header = tabItem.Header,
                    Tag = tabItem
                };
                menuItem.Click += TabMenuItem_Click;

                contextMenu.Items.Add(menuItem);
            }
            button.ContextMenu = contextMenu;
            button.ContextMenu.IsOpen = true;
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)         // Event handler for context menu item click
        {
            CloseAllTabs();
        }

        public void CloseAllTabs()
        {
            List<TabItem> tabs = new List<TabItem>();
            foreach (TabItem tabItem in tabControl.Items)
            {
                tabs.Add(tabItem);
            }
            foreach (TabItem tabItem in tabs)
            {
                DiposeTabContent(tabItem);
                tabControl.Items.Remove(tabItem);
            }
        }

        void DiposeTabContent(TabItem tabItem)
        {
            if (tabItem.Content is BookViewer bookViewer)
            {
                bookViewer.Dispose();
                //GlobalsX.webViewList.Remove(bookViewer.webView2);
            }
            else if (tabItem.Content is WebViewControl webViewControl)
            {
                webViewControl.webView.Dispose();
            }
        }

        private void TabMenuItem_Click(object sender, RoutedEventArgs e)         // Event handler for context menu item click
        {
            ((ContextMenu)((MenuItem)sender).Parent).IsOpen = false;             // Close the context menu
            TabItem selectedTab = (TabItem)((MenuItem)sender).Tag;            // Get the associated TabItem from the Tag property
            ((TabControl)selectedTab.Parent).SelectedItem = selectedTab;             // Set the selected tab in the TabControl
        }

        private void TabScrollRight_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = FindParentOrChild.TryFindParent<TabControl>(sender as DependencyObject);
            if (tabControl != null)
            {
                int currentIndex = tabControl.SelectedIndex;
                if (currentIndex > 0)
                {
                    tabControl.SelectedIndex = currentIndex - 1;
                }
                else
                {
                    tabControl.SelectedIndex = 0;
                }
            }
        }

        private void TabscrollLeft_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = FindParentOrChild.TryFindParent<TabControl>(sender as DependencyObject);
            if (tabControl != null)
            {
                int currentIndex = tabControl.SelectedIndex;
                if (currentIndex < tabControl.Items.Count - 1)
                {
                    tabControl.SelectedIndex = currentIndex + 1;
                }
            }
        }

        private void TabHeaderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
    }
}
