using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToratEmetInWord_2._0
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        Microsoft.Office.Tools.CustomTaskPane taskPane;
        private Word.Document lastDoc;
        private UserControlContainer container;
        private UserControl1 ToratEmetTaskPane;
        private bool windowSnap;
        private bool windowclose;

        public Ribbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ToratEmetInWord_2._0.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            //Globals.ThisAddIn.Application.DocumentChange += Application_DocumentChange;
            //Globals.ThisAddIn.Application.WindowDeactivate += Application_WindowDeactivate;
            //Globals.ThisAddIn.Application.DocumentBeforeClose += Application_DocumentBeforeClose;
        }

        public System.Drawing.Image GetImage(Office.IRibbonControl control)
        {
            System.Drawing.Bitmap image = Properties.Resources.תורת_אמת2;
            return image;
        }

        public System.Drawing.Image GetImage2(Office.IRibbonControl control)
        {
            System.Drawing.Bitmap image = Properties.Resources.selected_book;
            return image;
        }

        public void dictionaryButton_Click(IRibbonControl control)
        {
            loadPanel();
            ToratEmetTaskPane.LoadDictionaryForm();
        }

        public void CopyToSearch_Click(IRibbonControl control)
        {
            windowSnap = true;
            loadPanel();
            taskPane.Visible = true;

            // Get a reference to the Word application
            Word.Application wordApp = Globals.ThisAddIn.Application;
            // Get the active document
            Word.Document doc = wordApp.ActiveDocument;
            // Insert  at the current selection or cursor position
            string texttoseacrh = doc.Application.Selection.Text;

            ToratEmetTaskPane.CopyTosearch(texttoseacrh);
        }

        public void OpenBook_Click(IRibbonControl control)
        {
            windowSnap = true;
            loadPanel();
            taskPane.Visible = true;

            // Get a reference to the Word application
            Word.Application wordApp = Globals.ThisAddIn.Application;
            // Get the active document
            Word.Document doc = wordApp.ActiveDocument;
            // Insert  at the current selection or cursor position
            string texttoseacrh = doc.Application.Selection.Text;

            OpenBookNameSearch(texttoseacrh.Trim()); ;
        }

        public void OpenBookNameSearch(string bookName)
        {
            bookName = ToratEmetTaskPane.NormalizeHebrewText(bookName);
            ToratEmetTaskPane.loadOpenFileForm();
            ToratEmetTaskPane.openFileForm.tabControl1.SelectTab(0);

            ToratEmetTaskPane.openFileForm.textBox1.Text = bookName;
            ToratEmetTaskPane.openFileForm.searchForBook();
            ToratEmetTaskPane.openFileForm.textBox1.Focus();
        }

        public void toratEmetButton_Click(IRibbonControl control)
        {
            loadPanel();
            taskPane.Visible = true;
        }

        private async void loadPanel()
        {
            Properties.Settings.Default.DonationsReminder++;
            if (Properties.Settings.Default.DonationsReminder > 500) { Properties.Settings.Default.DonationsReminder = 0; }
            Properties.Settings.Default.Save();

            if (ToratEmetTaskPane == null || taskPane.Window != Globals.ThisAddIn.Application.ActiveWindow)
            { 
            ToratEmetTaskPane = new UserControl1();
            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(ToratEmetTaskPane, "תורת אמת");
            taskPane.Width = 450;
            
                try { await UpdatesCheck.CheckForUpdates(); } catch { }
            
            }
        }

        //private void Application_DocumentBeforeClose(Document Doc, ref bool Cancel)
        //{
        //    windowSnap = false; windowclose = true;
        //}

        //private void Application_WindowDeactivate(Document Doc, Window Wn)
        //{
        //    if (taskPane != null && windowclose == false)
        //    {
        //        if (taskPane.Visible) { windowSnap = true; }
        //    }
        //}

        //private void Application_DocumentChange()
        //{
        //    if (Properties.Settings.Default.snapWithWindow == true && windowSnap ==true)
        //    {
        //       loadPanel();
        //        try { if (taskPane != null) { taskPane.Visible = true; } } catch { }              
        //    }
        //}



        //public void toratEmetButton_Click(IRibbonControl control)
        //{
        //    windowSnap = true;
        //    //loadPanel();
        //    //try
        //    //{ taskPane.Visible = true; }
        //    //catch (Exception) { }

        //}

        //private void loadPanel()
        //{
        //    windowclose = false;

        //    if (Globals.ThisAddIn.Application.Documents.Count == 0 || lastDoc == Globals.ThisAddIn.Application.ActiveDocument)
        //        return;

        //    lastDoc = Globals.ThisAddIn.Application.ActiveDocument;
        //    if (taskPane != null)
        //    {
        //        container.Controls.Remove(ToratEmetTaskPane);
        //        Globals.ThisAddIn.CustomTaskPanes.Remove(taskPane);
        //    }

        //    container = new UserControlContainer(ToratEmetTaskPane);
        //    taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(container, "תורת אמת");
        //    taskPane.Visible = true;
        //    taskPane.Width = 450;
        //    taskPane.VisibleChanged += TaskPane_VisibleChanged;
        //}

        //private void TaskPane_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (!taskPane.Visible) { windowSnap = false; } else {  windowSnap = true; }
        //}







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

    public class UserControlContainer : UserControl
    {
        public UserControlContainer(UserControl1 control)
        {
            Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }

}

//
//
//
//private void loadTaskpane()
//{
//    if (taskPane == null || taskPane.Window != Globals.ThisAddIn.Application.ActiveWindow)
//    {
//        UserControl1 taskPaneUserControl;
//        taskPaneUserControl = new UserControl1();
//        taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPaneUserControl, "תורת אמת");
//        taskPane.Visible = true;
//        taskPane.Width = 450; // Adjust the width as needed
//    }
//    else
//    {
//        taskPane.Visible = true;
//    }
//}
