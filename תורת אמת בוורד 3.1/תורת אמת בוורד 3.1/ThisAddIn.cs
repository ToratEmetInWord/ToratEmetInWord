using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using תורת_אמת_בוורד_3._1._3.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using תורת_אמת_בוורד_3._1.TreeModels;



namespace תורת_אמת_בוורד_3._1
{
    public partial class ThisAddIn
    {      
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Tasks.Task.Delay(100000000);
                StaticGlobals.SetFoldersPaths();
                TreeLoader treeLoader = new TreeLoader();
                treeLoader.PopulateTree(null);
            });

            Application.DocumentBeforeClose += Application_DocumentBeforeClose;
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new ToratEmetRibbon();
        }

        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            Word.Window currentWindow = Globals.ThisAddIn.Application.ActiveWindow;
            if (StaticGlobals.mainControlsDictionary.ContainsKey(currentWindow))
            {
                StaticGlobals.mainControlsDictionary[currentWindow].tabControlHost.CloseAllTabs();
            }            
            if (StaticGlobals.taskPanesDictionary.ContainsKey(currentWindow)) { StaticGlobals.taskPanesDictionary.Remove(currentWindow); }
            if (StaticGlobals.mainControlsDictionary.ContainsKey(currentWindow)) { StaticGlobals.mainControlsDictionary.Remove(currentWindow); }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            StaticGlobals.SaveCheckedStatus();

            if (StaticGlobals.windowList.Count > 0) 
            {
                List<Window> list = new List<Window>();
                foreach (Window window in StaticGlobals.windowList) {   list.Add(window);     }
                foreach (Window window in list)     {  window.Close();  }
            }
            if (StaticGlobals.searchControl != null) { StaticGlobals.searchControl.webView.Dispose(); }
            if (StaticGlobals.aramaicDictionaryWindow != null) { StaticGlobals.aramaicDictionaryWindow.dictionaryControl.ResultsWebView.Dispose(); }
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


