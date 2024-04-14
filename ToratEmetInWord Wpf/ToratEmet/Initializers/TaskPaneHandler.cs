using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ToratEmet.Controls;

namespace ToratEmet.Initializers
{
    public static class TaskPaneHandler
    {
        public static CustomTaskPane LaunchTaskPane()
        {           
            CustomTaskPane taskPane = GetCurrentTaskPane();

            if (taskPane == null)
            {
                Updater.CheckForUpdates();

                HostControl hostControl = new HostControl();
                taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(hostControl, "תורת אמת");
                taskPane.Width = 500;
                taskPane.VisibleChanged += TaskPane_VisibleChanged;
                
                if (Enum.TryParse(Properties.Settings.Default.DockPosition, out Microsoft.Office.Core.MsoCTPDockPosition savedDockPosition))
                {
                    taskPane.DockPosition = savedDockPosition;
                }
                else
                {
                    taskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
                }

                taskPane.DockPositionChanged += (sender, e) =>
                {
                    Properties.Settings.Default.DockPosition = taskPane.DockPosition.ToString();
                    Properties.Settings.Default.Save();
                };
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
