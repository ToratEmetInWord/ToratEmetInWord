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
    /// Interaction logic for DockerControl.xaml
    /// </summary>
    public partial class DockerControl : UserControl
    {
        public bool isInRow;
        LayoutControl layoutControl;
        public DockerControl()
        {
            InitializeComponent();
            this.Loaded += DockerControl_Loaded;
        }

        private void DockerControl_Loaded(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            while (parent != null && !(parent is LayoutControl))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            layoutControl = parent as LayoutControl;

            if (!layoutControl.DockerList.Contains(this))
            {
                layoutControl.DockerList.Add(this);
            }


            draggableTabControl.dockerControl = this;
            draggableTabControl.overLayPane = this.overlayPane;
            draggableTabControl.layoutControl = layoutControl;

            overlayPane.dockerControl = this;
            overlayPane.draggableTabControl = this.draggableTabControl;
            overlayPane.tabControl = this.draggableTabControl.tabControl;
            overlayPane.layoutControl = layoutControl;
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
