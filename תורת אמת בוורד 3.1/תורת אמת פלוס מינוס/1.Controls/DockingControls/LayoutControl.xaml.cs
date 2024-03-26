using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace אוצר_הספרים.DockingControls
{
    /// <summary>
    /// Interaction logic for LayoutControl.xaml
    /// </summary>
    public partial class LayoutControl : UserControl
    {
        public List<DockerControl> DockerList { get; set; } = new List<DockerControl>();
        public DockerControl MainDocker { get; set; }

        DockerControl newDockerControl;
        public Window mainWindow;
        DockerControl currentDockerControl;
        public DetachedTabWindow detachbleWindow;
        public TabControl currentTabControl;
        TabItem currentTabItem;
        GridSplitter newGridSplitter;
        Grid newGrid;

        public LayoutControl()
        {
            InitializeComponent();
            this.Loaded += LayoutControl_Loaded;
        }

        private void LayoutControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dockerControl.draggableTabControl.layoutControl = this;
            this.dockerControl.overlayPane.layoutControl = this;
            MainDocker = this.dockerControl;
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

        public TabControl getTabcontrol()
        {
            return MainDocker.draggableTabControl.tabControl;
        }
        public void AddNewTab(TabItem tabItem)
        {
            MainDocker.draggableTabControl.tabControl.Items.Add(tabItem);
            tabItem.IsSelected = true;
        }

        public void AddColumnBefore(TabItem tabItem, DockerControl currentDockerControl)
        {
            SetCurrentControls(currentDockerControl, tabItem);
            AddNewColumnGrid(2, 0);
        }

        public void AddColumnAfter(TabItem tabItem, DockerControl currentDockerControl)
        {
            SetCurrentControls(currentDockerControl, tabItem);
            AddNewColumnGrid(0, 2);
        }

        public void AddRowBefore(TabItem tabItem, DockerControl currentDockerControl)
        {
            SetCurrentControls(currentDockerControl, tabItem);
            AddNewRowGrid(2, 0);
        }

        public void AddRowAfter(TabItem tabItem, DockerControl currentDockerControl)
        {
            SetCurrentControls(currentDockerControl, tabItem);
            AddNewRowGrid(0, 2);
        }

        private void AddNewColumnGrid(int column0, int column2)
        {
            CreateNewDockerControl();
            CreateNewGrid();
            newGridSplitter.Width = 5;

            // Define two columns with star width and 1 with auto for splitter
            newGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            newGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            newGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(currentDockerControl, column0);
            Grid.SetColumn(newGridSplitter, 1);
            Grid.SetColumn(newDockerControl, column2);

            addControlsToGrid();
        }

        private void AddNewRowGrid(int Row0, int Row2)
        {
            CreateNewDockerControl();
            CreateNewGrid();

            newDockerControl.isInRow = true;
            newGridSplitter.Height = 5;
            newGridSplitter.HorizontalAlignment = HorizontalAlignment.Stretch; //set splitter to horizontal

            // Define two Rows with star width and 1 with auto for splitter
            newGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            newGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            newGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetRow(currentDockerControl, Row0);
            Grid.SetRow(newGridSplitter, 1);
            Grid.SetRow(newDockerControl, Row2);

            addControlsToGrid();

        }

        private void SetCurrentControls(DockerControl dockerControl, TabItem tabItem)
        {
            currentDockerControl = dockerControl;
            currentTabItem = tabItem;
        }

        private void CreateNewDockerControl() // & move tab
        {
            newDockerControl = new DockerControl();
            newDockerControl.draggableTabControl.layoutControl = this;
            newDockerControl.overlayPane.layoutControl = this;

            TabControl tabControl = currentTabItem.Parent as TabControl;
            tabControl.Items.Remove(currentTabItem);
            newDockerControl.draggableTabControl.tabControl.Items.Add(currentTabItem);
        }

        private void CreateNewGrid() // & new gridsplitter & set columns for current controls & remove docker from previous parent
        {
            newGrid = new Grid();
            Grid parentGrid = currentDockerControl.Parent as Grid;

            if (parentGrid != null)
            {

                int currentColumn = Grid.GetColumn(currentDockerControl);
                int currentRow = Grid.GetRow(currentDockerControl);

                Grid.SetColumn(newGrid, currentColumn);
                Grid.SetRow(newGrid, currentRow);

                parentGrid.Children.Add(newGrid);

                newGridSplitter = new GridSplitter
                {
                    ResizeBehavior = GridResizeBehavior.PreviousAndNext,
                    Background = Brushes.Transparent
                };
                parentGrid.Children.Remove(currentDockerControl);
            }
        }

        private void addControlsToGrid()
        {
            newGrid.Children.Add(currentDockerControl);
            newGrid.Children.Add(newGridSplitter);
            newGrid.Children.Add(newDockerControl);
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            foreach (OverLayPane pane in OverlayControlList.List)
            {
                pane.Visibility = Visibility.Collapsed;
            }
        }
    }
}
