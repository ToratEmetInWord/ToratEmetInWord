using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OverLayPane.xaml
    /// </summary>
    /// 
    public static class OverlayControlList
    {
        public static List<OverLayPane> List = new List<OverLayPane>();
    }

    public partial class OverLayPane : UserControl
    {
        Window mainWindow;
        public LayoutControl layoutControl;
        public Location location = Location.N;
        public DockerControl dockerControl;
        public DraggableTabControl draggableTabControl;
        public TabControl tabControl;

        public enum Location
        {
            R,  // right
            L,  // left
            T,  // top
            B,  // bottom
            C,   // center
            N, //null
        };



        public OverLayPane()
        {
            InitializeComponent();
            this.Loaded += OverLayPane_Loaded;
            this.IsVisibleChanged += OverLayPane_IsVisibleChanged;
        }

        private void OverLayPane_Loaded(object sender, RoutedEventArgs e)
        {
            OverlayControlList.List.Add(this);
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

        private void OverLayPane_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                BottomBorder.Visibility = Visibility.Collapsed;
                TopBorder.Visibility = Visibility.Collapsed;
                LeftBorder.Visibility = Visibility.Collapsed;
                RightBorder.Visibility = Visibility.Collapsed;
                CenterBorder.Visibility = Visibility.Visible;

                if (layoutControl.currentTabControl != null &&
                    layoutControl.currentTabControl.Items.Count == 1 &&
                layoutControl.currentTabControl == draggableTabControl.tabControl)
                {
                    borderCenter.Visibility = Visibility.Collapsed;
                    borderBottom.Visibility = Visibility.Collapsed;
                    borderTop.Visibility = Visibility.Collapsed;
                    borderLeft.Visibility = Visibility.Collapsed;
                    borderRight.Visibility = Visibility.Collapsed;
                }
                else
                {
                    borderCenter.Visibility = Visibility.Visible;
                    borderBottom.Visibility = Visibility.Visible;
                    borderTop.Visibility = Visibility.Visible;
                    borderLeft.Visibility = Visibility.Visible;
                    borderRight.Visibility = Visibility.Visible;
                }

                ButtonBottom.Background = SystemColors.ScrollBarBrush;
                ButtonTop.Background = SystemColors.ScrollBarBrush;
                ButtonLeft.Background = SystemColors.ScrollBarBrush;
                ButtonRight.Background = SystemColors.ScrollBarBrush;
                ButtonCenter.Background = SystemColors.ScrollBarBrush;

                Timer timer = new Timer(TimerCallback, this, 20000, Timeout.Infinite);
            }
        }

        private void TimerCallback(object state)
        {
            // Access the user control instance from the state parameter
            OverLayPane userControl = state as OverLayPane;

            if (userControl != null)
            {
                // Set the visibility of the user control to Collapsed
                Application.Current.Dispatcher.Invoke(() =>
                {
                    userControl.Visibility = Visibility.Collapsed;
                });
            }
        }

        private void ButtonTop_DragEnter(object sender, DragEventArgs e)
        {
            ButtonTop.Background = SystemColors.MenuHighlightBrush;
            TopBorder.Visibility = Visibility.Visible;
            location = Location.T;
        }

        private void ButtonTop_DragLeave(object sender, DragEventArgs e)
        {
            ButtonTop.Background = SystemColors.ScrollBarBrush;
            TopBorder.Visibility = Visibility.Collapsed;
            location = Location.N;
        }

        private void ButtonRight_DragEnter(object sender, DragEventArgs e)
        {
            ButtonRight.Background = SystemColors.MenuHighlightBrush;
            RightBorder.Visibility = Visibility.Visible;
            location = Location.R;
        }

        private void ButtonRight_DragLeave(object sender, DragEventArgs e)
        {
            ButtonRight.Background = SystemColors.ScrollBarBrush;
            RightBorder.Visibility = Visibility.Collapsed;
            location = Location.N;
        }

        private void ButtonCenter_DragEnter(object sender, DragEventArgs e)
        {
            ButtonCenter.Background = SystemColors.MenuHighlightBrush;
            CenterBorder.Visibility = Visibility.Visible;
            location = Location.C;
        }

        private void ButtonCenter_DragLeave(object sender, DragEventArgs e)
        {
            ButtonCenter.Background = SystemColors.ScrollBarBrush;
            CenterBorder.Visibility = Visibility.Collapsed;
            location = Location.N;
        }

        private void ButtonLeft_DragEnter(object sender, DragEventArgs e)
        {
            ButtonLeft.Background = SystemColors.MenuHighlightBrush;
            LeftBorder.Visibility = Visibility.Visible;
            location = Location.L;
        }

        private void ButtonLeft_DragLeave(object sender, DragEventArgs e)
        {
            ButtonLeft.Background = SystemColors.ScrollBarBrush;
            LeftBorder.Visibility = Visibility.Collapsed;
            location = Location.N;
        }

        private void ButtonBottom_DragEnter(object sender, DragEventArgs e)
        {
            ButtonBottom.Background = SystemColors.MenuHighlightBrush;
            BottomBorder.Visibility = Visibility.Visible;
            location = Location.B;
        }

        private void ButtonBottom_DragLeave(object sender, DragEventArgs e)
        {
            ButtonBottom.Background = SystemColors.ScrollBarBrush;
            BottomBorder.Visibility = Visibility.Collapsed;
            location = Location.N;
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TabItem)) is TabItem tabItemSource)
            {
                TabControl parentTabControl = tabItemSource.Parent as TabControl;

                if (location == Location.R)
                {
                    layoutControl.AddColumnBefore(tabItemSource, dockerControl);
                    //borderBottom.Visibility = Visibility.Collapsed;
                    //borderTop.Visibility = Visibility.Collapsed;
                }
                else if (location == Location.L)
                {
                    layoutControl.AddColumnAfter(tabItemSource, dockerControl);
                    //borderBottom.Visibility = Visibility.Collapsed;
                    //borderTop.Visibility = Visibility.Collapsed;
                }
                else if (location == Location.T)
                {
                    layoutControl.AddRowBefore(tabItemSource, dockerControl);
                    //borderLeft.Visibility = Visibility.Collapsed;
                    //borderRight.Visibility = Visibility.Collapsed;
                }
                else if (location == Location.B)
                {
                    layoutControl.AddRowAfter(tabItemSource, dockerControl);
                    //borderLeft.Visibility = Visibility.Collapsed;
                    //borderRight.Visibility = Visibility.Collapsed;
                }
                else if (location == Location.N || location == Location.C)
                {
                    if (parentTabControl != tabControl)
                    {
                        parentTabControl.Items.Remove(tabItemSource);
                        tabControl.Items.Add(tabItemSource);
                        tabItemSource.IsSelected = true;
                    }
                }
                location = Location.N;
            }



            foreach (OverLayPane pane in OverlayControlList.List)
            {
                pane.Visibility = Visibility.Collapsed;
            }
        }

        private void DetachTab(TabItem tabItem)
        {
            if (tabItem != null)
            {
                // Remove tab from current tab control
                TabControl tabControl = (TabControl)tabItem.Parent;
                tabControl.Items.Remove(tabItem);

                // Create a new window and add the tab to its tab control
                DetachedTabWindow detachedWindow = new DetachedTabWindow(tabItem, layoutControl);
                detachedWindow.Show();
            }
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}