using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mshtml;
using System.Windows.Forms;


namespace ToratEmetInWord_2._0
{
    public class FileViewerSearch
    {
        public UserControl1 taskPaneUserControl;

        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public void searchPrevious(string searchText)
        {
            if (taskPaneUserControl.fileViewer != null)
                if (!string.IsNullOrEmpty(searchText))
            {
                
                // Ensure the taskPaneUserControl.fileViewer control is not null and has a valid document loaded.
                if (taskPaneUserControl.fileViewer.Document != null)
                {
                    IHTMLDocument2 doc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;
                    if (doc != null)
                    {
                        IHTMLSelectionObject sel = (IHTMLSelectionObject)doc.selection;
                        IHTMLTxtRange rng = (IHTMLTxtRange)sel.createRange();
                        rng.collapse(true); // collapse the current selection so we start from the beginning

                        if (rng.findText(searchText, -1000000000, 0)) // Notice the negative value for count
                        {
                            rng.scrollIntoView();
                            rng.select();
                        }
                        else
                        {
                            if (taskPaneUserControl.fileViewer.Document != null)
                            {
                                IHTMLDocument2 myDoc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;
                                if (doc != null)
                                {
                                    IHTMLBodyElement body = myDoc.body as IHTMLBodyElement;
                                    if (body != null)
                                    {
                                        IHTMLTxtRange docRange = body.createTextRange();
                                        docRange.collapse(false);

                                        if (docRange.findText(searchText, -1000000000, 0))
                                        {
                                            docRange.scrollIntoView();
                                            docRange.select();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Handle the case when the taskPaneUserControl.fileViewer.Document.DomDocument cannot be cast to IHTMLDocument2.
                        MessageBox.Show("Could not access the document.");
                    }
                }
            }
        }

        public void searchNext(string searchText)
        {
            if (taskPaneUserControl.fileViewer != null)
            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Ensure the taskPaneUserControl.fileViewer control is not null and has a valid document loaded.
                    if (taskPaneUserControl.fileViewer.Document != null)
                    {
                        IHTMLDocument2 doc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;

                        if (doc != null)
                        {
                            IHTMLSelectionObject sel = (IHTMLSelectionObject)doc.selection;
                            IHTMLTxtRange rng = (IHTMLTxtRange)sel.createRange();
                            rng.collapse(false); // collapse the current selection so we start from the end of the previous range

                            if (rng.findText(searchText, 1000000000, 0))
                            {
                                rng.scrollIntoView();
                                rng.select();
                            }
                            else
                            {
                                if (taskPaneUserControl.fileViewer.Document != null)
                                {
                                    IHTMLDocument2 myDoc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;
                                    if (doc != null)
                                    {
                                        IHTMLBodyElement body = myDoc.body as IHTMLBodyElement;
                                        if (body != null)
                                        {
                                            IHTMLTxtRange docRange = body.createTextRange();
                                            docRange.collapse(true);

                                            if (docRange.findText(searchText, 1000000000, 0))
                                            {
                                                docRange.scrollIntoView();
                                                docRange.select();
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        // Handle the case when the taskPaneUserControl.fileViewer.Document.DomDocument cannot be cast to IHTMLDocument2.
                        MessageBox.Show("Could not access the document.");
                    }
                }
            }
            catch (Exception) { };
        }
    }
}
