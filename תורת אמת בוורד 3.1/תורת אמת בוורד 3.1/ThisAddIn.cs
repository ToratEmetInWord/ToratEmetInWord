using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Web.WebView2.Wpf;
using System.Collections.Specialized;
using System.Windows;

namespace תורת_אמת_בוורד_3._1
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.DocumentBeforeClose += Application_DocumentBeforeClose;
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new ToratEmetRibbon();
        }

        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            Word.Window currentWindow = Globals.ThisAddIn.Application.ActiveWindow;
            if (GlobalsX.mainControlsDictionary.ContainsKey(currentWindow))
            {
                GlobalsX.mainControlsDictionary[currentWindow].tabControl.CloseAllTabs();
            }            
            if (GlobalsX.taskPanesDictionary.ContainsKey(currentWindow)) { GlobalsX.taskPanesDictionary.Remove(currentWindow); }
            if (GlobalsX.mainControlsDictionary.ContainsKey(currentWindow)) { GlobalsX.mainControlsDictionary.Remove(currentWindow); }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (GlobalsX.windowList.Count > 0) 
            {
                List<Window> list = new List<Window>();
                foreach (Window window in GlobalsX.windowList) {   list.Add(window);     }
                foreach (Window window in list)     {  window.Close();  }
            }
            if (GlobalsX.searchWindow != null) { GlobalsX.searchWindow.searchControl.webView.webView.Dispose(); }
            if (GlobalsX.aramaicDictionaryWindow != null) { GlobalsX.aramaicDictionaryWindow.dictionaryControl.ResultsWebView.Dispose(); }
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
