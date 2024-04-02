using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Tools; 
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace ToratEmetInWord_2._0
{
    public partial class ThisAddIn
    {
        //private UserControl1 taskPaneUserControl;
        //private CustomTaskPane taskPane;

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //taskPaneUserControl = new UserControl1();
            //taskPane = this.CustomTaskPanes.Add(taskPaneUserControl, "תורת אמת");
            //taskPane.Visible = true;
            //taskPane.Width = 450; // Adjust the width as needed
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //// Perform cleanup and release resources here
            //// Close and release instances of Word interop objects
            //ReleaseComObject(taskPaneUserControl);
            //ReleaseComObject(taskPane);

            //// Release other resources as needed

            //// Important: Always set interop objects to null after releasing
            //taskPaneUserControl = null;
            //taskPane = null;
        }

        //private void ReleaseComObject(object obj)
        //{
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //            obj = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception if needed
        //    }
        //}

        #region VSTO generated code

        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
