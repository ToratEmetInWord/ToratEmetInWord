using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace תורת_אמת_בוורד_3._1
{
    [ComVisible(true)]
    public class ToratEmetRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public ToratEmetRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("תורת_אמת_בוורד_3._1.ToratEmetRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public System.Drawing.Image GetImage(Office.IRibbonControl control)
        {
            System.Drawing.Bitmap image = Properties.Resources.toratemetinWord;
            return image;
        }
        public System.Drawing.Image GetImage2(Office.IRibbonControl control)
        {
            System.Drawing.Bitmap image = Properties.Resources.Dictionary;
            return image;
        }
        public void OpenTaskPaneButton_Click(IRibbonControl control)
        {
            GlobalsX.LoadTaskPane();
        }
        public void DictionaryButton_Click(IRibbonControl control)
        {
            GlobalsX.LoadTaskPane();
            GlobalsX.ShowAramaicDictionary();
        }
        public void CopyToOpenBook_Click(IRibbonControl control)
        {
            Word.Application wordApp = Globals.ThisAddIn.Application;             // Get a reference to the Word application
            Word.Document doc = wordApp.ActiveDocument;            // Get the active document
            string selectedText = doc.Application.Selection.Text.Trim();             // Insert  at the current selection or cursor position
            GlobalsX.CopyToFileSearch(selectedText);
        }
        public void CopyToSearch_Click(IRibbonControl control)
        {
            Word.Application wordApp = Globals.ThisAddIn.Application;             // Get a reference to the Word application
            Word.Document doc = wordApp.ActiveDocument;            // Get the active document
            string selectedText = doc.Application.Selection.Text.Trim();             // Insert  at the current selection or cursor position
            GlobalsX.CopyToSearch(selectedText);           
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
