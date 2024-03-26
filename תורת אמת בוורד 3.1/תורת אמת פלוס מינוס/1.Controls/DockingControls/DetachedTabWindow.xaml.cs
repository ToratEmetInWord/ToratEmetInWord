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
using System.Windows.Shapes;

namespace אוצר_הספרים.DockingControls
{
    /// <summary>
    /// Interaction logic for DetachedTabWindow.xaml
    /// </summary>
    public partial class DetachedTabWindow : Window
    {
        TabControl tabControl;
        public LayoutControl mainLayoutControl;
        Window mainWindow;
        WindowState mainWindowState;
        public DetachedTabWindow(TabItem tabItem, LayoutControl mainControl)
        {
            InitializeComponent();
            DraggableTabControl draggableTabControl = layoutControl.dockerControl.draggableTabControl;
            draggableTabControl.detachedTabWindow = this;
            tabControl = draggableTabControl.tabControl;
            tabControl.Items.Add(tabItem);

            if (Owner != null) { this.FlowDirection = Owner.FlowDirection; }
            this.mainLayoutControl = mainControl;
            this.Loaded += DetachedTabWindow_Loaded;
        }

        private void DetachedTabWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow = mainLayoutControl.mainWindow;
            layoutControl.detachbleWindow = this;
        }


        //titlebar

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (this.WindowState == WindowState.Maximized)
            {
                button.Content = "⬜";
                this.WindowState = WindowState.Normal;
                windowBorder.Margin = new System.Windows.Thickness(0);
            }
            else
            {
                button.Content = "❐";
                this.WindowState = WindowState.Maximized;
                windowBorder.Margin = new System.Windows.Thickness(5);
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonX_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindowState = mainLayoutControl.mainWindow.WindowState;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mainWindow.WindowState = mainWindowState;
        }
    }
}

