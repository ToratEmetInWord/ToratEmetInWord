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

namespace אוצר_הספרים.DockingControls
{
    /// <summary>
    /// Interaction logic for DraggableTabControl.xaml
    /// </summary>
    public partial class DraggableTabControl : UserControl
    {
        Window mainWindow;
        public DetachedTabWindow detachedTabWindow;
        public LayoutControl layoutControl;
        public DockerControl dockerControl;
        public OverLayPane overLayPane;
        bool isOverButton = false;
        bool isDragOver = false;

        public DraggableTabControl()
        {
            InitializeComponent();
            tabControl.SelectionChanged += TabControl_SelectionChanged;
            this.Loaded += DraggableTabControl_Loaded;
        }

        private void DraggableTabControl_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow = TryFindParent<Window>(this);
        }

        public static T TryFindParent<T>(DependencyObject current) where T : class
        {
            DependencyObject parent = VisualTreeHelper.GetParent(current);
            if (parent == null)
                parent = LogicalTreeHelper.GetParent(current);
            if (parent == null)
                return null;

            if (parent is T)
                return parent as T;
            else
                return TryFindParent<T>(parent);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            removeEmptyDocker(tabControl);
            e.Handled = true;
        }

        //private void tabControl_DragEnter(object sender, DragEventArgs e)
        //{
        //    isDragOver = true;
        //    overLayPane.Visibility = Visibility.Visible;
        //}

        private void TabItemBorder_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isOverButton == false &&
                sender is Border border &&
                border.DataContext is TabItem tabItem &&
                Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                layoutControl.currentTabControl = tabItem.Parent as TabControl;
                if (detachedTabWindow != null)
                { detachedTabWindow.mainLayoutControl.currentTabControl = tabItem.Parent as TabControl; }
                dockerControl.overlayPane.Visibility = Visibility.Visible;
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }

        private void TabItemBorder_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TabItem)) is TabItem tabItemSource &&
                sender is Border border &&
                border.DataContext is TabItem tabItemTarget &&
                tabItemTarget.Parent is TabControl TergetTabControl)
            {
                int targetIndex = TergetTabControl.Items.IndexOf(tabItemTarget);
                TabControl SourceTabControl = tabItemSource.Parent as TabControl;

                if (SourceTabControl == TergetTabControl)
                {
                    if (SourceTabControl.Items.Count > 1)
                    {
                        SourceTabControl.Items.Remove(tabItemSource);
                        TergetTabControl.Items.Insert(targetIndex, tabItemSource);
                    }
                }
                else
                {
                    SourceTabControl.Items.Remove(tabItemSource);
                    TergetTabControl.Items.Insert(targetIndex, tabItemSource);
                }
                tabItemSource.IsSelected = true;
            }

            foreach (OverLayPane pane in OverlayControlList.List)
            {
                pane.Visibility = Visibility.Collapsed;
            }
        }

        //
        //buttons
        //

        private void TabCloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            isOverButton = true;
        }

        private void TabCloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            isOverButton = false;
        }

        private void TabCloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the close button click event here
            if (sender is Button closeButton && closeButton.DataContext is TabItem tabItem)
            {
                // Your custom logic to close the tab
                // For example, remove the tab from the TabControl's Items collection
                var tabControl = TryFindParent<TabControl>(closeButton);
                (tabControl?.Items)?.Remove(tabItem);
                removeEmptyDocker(tabControl);
            }
        }

        private void TabDetachButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is TabItem tabItem)
            {
                var tabControlX = TryFindParent<TabControl>(button);
                (tabControlX?.Items)?.Remove(tabItem);

                creatNewDetachibleWindow(tabItem, tabControlX);
            }
        }

        private void creatNewDetachibleWindow(TabItem tab, TabControl tabControlY)
        {
            DetachedTabWindow detachedWindow = new DetachedTabWindow(tab, layoutControl);
            detachedWindow.Owner = mainWindow;
            detachedWindow.FlowDirection = mainWindow.FlowDirection;
            detachedWindow.Show();

            if (tabControlY.Items.Count == 0)
            { removeEmptyDocker(tabControl); }
        }

        private void TabHeaderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }

        public void removeEmptyDocker(TabControl tabControlX)
        {
            if (tabControlX.Items.Count == 0)
            {
                Grid grid = dockerControl.Parent as Grid;

                if (grid != null && grid.Parent != null)
                {
                    Grid parentGrid = grid.Parent as Grid;
                    int gridRow = Grid.GetRow(grid);
                    int gridColumn = Grid.GetColumn(grid);

                    if (dockerControl == layoutControl.MainDocker)
                    {
                        foreach (DockerControl docker in layoutControl.DockerList)
                        {
                            if (docker != dockerControl && docker.Parent != null)
                            {
                                layoutControl.MainDocker = docker;
                            }
                        }
                    }
                    if (layoutControl.MainDocker != dockerControl)
                    {
                        layoutControl.DockerList.Remove(dockerControl);
                        if (layoutControl.DockerList.Count > 0)
                        {
                            grid.Children.Remove(dockerControl);


                            List<UIElement> list = new List<UIElement>();
                            foreach (UIElement element in grid.Children)
                            {
                                if (element != grid)
                                {
                                    list.Add(element);
                                }
                            }
                            parentGrid.Children.Remove(grid);
                            foreach (UIElement element in list)
                            {
                                grid.Children.Remove(element);
                                Grid.SetColumn(element, gridColumn);
                                Grid.SetRow(element, gridRow);
                                parentGrid.Children.Add(element);
                            }
                        }
                    }
                }

                if (layoutControl.DockerList.Count == 1 &&
                    layoutControl.MainDocker.draggableTabControl.tabControl.Items.Count == 0 &&
                    layoutControl.detachbleWindow != null)
                {
                    layoutControl.detachbleWindow.Close();
                }

            }

        }

        private void TabsDropDown_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            ContextMenu contextMenu = new ContextMenu();
            foreach (TabItem tabItem in ((TabControl)button.TemplatedParent).Items)
            {
                MenuItem menuItem = new MenuItem
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

        private void TabMenuItem_Click(object sender, RoutedEventArgs e)         // Event handler for context menu item click
        {
            ((ContextMenu)((MenuItem)sender).Parent).IsOpen = false;             // Close the context menu
            TabItem selectedTab = (TabItem)((MenuItem)sender).Tag;            // Get the associated TabItem from the Tag property
            ((TabControl)selectedTab.Parent).SelectedItem = selectedTab;             // Set the selected tab in the TabControl
        }

        private void TabScrollRight_Click(object sender, RoutedEventArgs e)
        {
            var tabControl = TryFindParent<TabControl>(sender as DependencyObject);
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
            var tabControl = TryFindParent<TabControl>(sender as DependencyObject);
            if (tabControl != null)
            {
                int currentIndex = tabControl.SelectedIndex;
                if (currentIndex < tabControl.Items.Count - 1)
                {
                    tabControl.SelectedIndex = currentIndex + 1;
                }
            }
            ////if (tabControl.ActualWidth < 225)
            ////{
            //    ListBox listBox = TryFindChild<ListBox>(tabControl as DependencyObject);
            //    ScrollViewer scrollViewer = TryFindChild<ScrollViewer>(listBox as DependencyObject);
            //double desiredOffset = scrollViewer.HorizontalOffset + 50; // Adjust the offset as needed
            //scrollViewer.ScrollToHorizontalOffset(desiredOffset);
            ////}
        }

        public static T TryFindChild<T>(DependencyObject current, string childName = null) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(current);

            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(current, i);

                if (child is T && (childName == null || (child as FrameworkElement)?.Name == childName))
                    return (T)child;

                T foundChild = TryFindChild<T>(child, childName);
                if (foundChild != null)
                    return foundChild;
            }

            return null;
        }



        private void tabItemTextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            string newText = textBlock.Text;

            while (newText.Length > 20)
            {
                newText = textBlock.Text.Replace("...", "");
                if (newText.Length > 20)
                {
                    newText = newText.Remove(newText.Length - 3) + "...";
                    textBlock.Text = newText;
                }
                else
                {
                    if (newText.EndsWith(" "))
                    {
                        newText = newText.Trim();
                        textBlock.Text = newText + "...";
                    }
                    break;
                }
            }
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.ContextMenu.IsOpen = true;
        }

        private void buttonCloseAll_Click(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)((MenuItem)sender).Parent).IsOpen = false;
            List<TabItem> tabs = new List<TabItem>();
            foreach (TabItem tabItem in tabControl.Items)
            {
                tabs.Add(tabItem);
            }
            foreach (TabItem tab in tabs)
            {
                tabControl.Items.Remove(tab);
            }
            removeEmptyDocker(tabControl);
        }

        private void buttonUnpinAll_Click(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)((MenuItem)sender).Parent).IsOpen = false;
            List<TabItem> tabs = new List<TabItem>();
            foreach (TabItem tabItem in tabControl.Items)
            {
                tabs.Add(tabItem);
            }
            foreach (TabItem tab in tabs)
            {
                tabControl.Items.Remove(tab);
                creatNewDetachibleWindow(tab, tabControl);
            }
        }

        private void buttonPinAsMainControl_Click(object sender, RoutedEventArgs e)
        {
            ((ContextMenu)((MenuItem)sender).Parent).IsOpen = false;
            layoutControl.MainDocker = this.dockerControl;
            if (detachedTabWindow != null) { detachedTabWindow.mainLayoutControl.MainDocker = this.dockerControl; }
        }

        private void buttonPinAsMainControl_Loaded(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (layoutControl.detachbleWindow != null)
            {
                menuItem.Visibility = Visibility.Collapsed;
            }
            else
            {
                menuItem.Visibility = Visibility.Visible;
            }
        }

        private void ContentPanel_DragEnter(object sender, DragEventArgs e)
        {
            overLayPane.Visibility = Visibility.Visible;
            isDragOver = true;
        }


        private void tabControl_DragLeave(object sender, DragEventArgs e)
        {
            if (!isDragOver)
            {
                overLayPane.Visibility = Visibility.Collapsed;
            }
            else
            {
                isDragOver = false;
            }
        }

       
    }
}
