using Lucene.Net.Support;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using ToratEmet.Models;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace ToratEmet.Initializers
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
            return GetResourceText("ToratEmet.Initializers.ToratEmetRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

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
            TaskPaneHandler.LaunchTaskPane();
        }

        public void DictionaryButton_Click(IRibbonControl control)
        {
            CostumeWindowsHandler.ShowDictionaryWindow();
        }
        public void CopyToOpenBook_Click(IRibbonControl control)
        {
            string selectedText = Globals.ThisAddIn.Application.Selection.Text.Trim();        // Insert  at the current selection or cursor position
            StaticGlobals.CopyToFileSearch(selectedText);
        }
        public void CopyToSearch_Click(IRibbonControl control)
        {
            string selectedText = Globals.ThisAddIn.Application.Selection.Text.Trim();          // Insert  at the current selection or cursor position
            StaticGlobals.CopyToSearch(selectedText);
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
