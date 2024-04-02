using Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Controls;

namespace ToratEmet.Initializers
{
    public static class TaskPaneHandler
    {
        public static CustomTaskPane LaunchTaskPane()
        {
            Updater.CheckForUpdates();

            CustomTaskPane taskPane = GetCurrentTaskPane();

            if (taskPane == null)
            {
                HostControl hostControl = new HostControl();
                taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(hostControl, "תורת אמת");
                taskPane.Width = 500;
                taskPane.VisibleChanged += TaskPane_VisibleChanged;
            }

            taskPane.Visible = true;

            return taskPane;
        }

        private static void TaskPane_VisibleChanged(object sender, EventArgs e)
        {
            if (sender is null)
            {
                MessageBox.Show("aaaa");
            }
        }

        public static CustomTaskPane GetCurrentTaskPane()
        {
             return Globals.ThisAddIn.CustomTaskPanes
                       .OfType<CustomTaskPane>()
                       .FirstOrDefault(pane =>
                           pane.Control is HostControl &&
                           pane.Window == Globals.ThisAddIn.Application.ActiveWindow);
        }
    }
}
