using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using ToratEmet.Initializers;
using ToratEmet.WebViewModels;
using System.Collections.Specialized;
using ToratEmet.Controls;

namespace ToratEmet
{
    public partial class ThisAddIn
    {
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon1();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Initializer.Execute();
            Application.DocumentBeforeClose += Application_DocumentBeforeClose;
        }

        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            try
            {
                var taskPane = TaskPaneHandler.GetCurrentTaskPane();
                if (taskPane != null)
                {
                    HostControl control = taskPane.Control as HostControl;
                    control.mainControl.tabControlX.DisposeWebViews();
                }
            }
            catch { }
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            SaveCheckedStatus();
            if (StaticGlobals.SearchControl != null) StaticGlobals.SearchControl.webView.Dispose();
        }

        void SaveCheckedStatus()
        {
            try {
                if (StaticGlobals.SearchExplorerHasBeenIntialized == true)
                {
                    StringCollection checkedTreeItems = new StringCollection();
                    checkedTreeItems.AddRange(
                        StaticGlobals.treeItemsList
                            .Where(item => item.IsChecked == true)
                            .Select(item => item.Address)
                            .ToArray());
                    Properties.Settings.Default.CheckedTreeItems = checkedTreeItems;

                    StringCollection checkedListBoxItems = new StringCollection();
                    checkedListBoxItems.AddRange(
                        StaticGlobals.treeItemsList
                            .Where(item => item.IsChecked2 == true)
                            .Select(item => item.Address)
                            .ToArray());
                    Properties.Settings.Default.CheckedListBoxItems = checkedListBoxItems;

                    Properties.Settings.Default.Save();
                }
            }
            catch { }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
