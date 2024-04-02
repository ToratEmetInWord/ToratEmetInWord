using Microsoft.Office.Interop.Word;
using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ToratEmetInWord_2._0
{
    public class FileViewerContextMenu
    {
        public UserControl1 taskPaneUserControl;
        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public void selectAll()
        {
            try
            {
                if (taskPaneUserControl.fileViewer.Document != null)
                {
                    IHTMLDocument2 doc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;
                    if (doc != null)
                    {
                        IHTMLBodyElement body = doc.body as IHTMLBodyElement;
                        if (body != null)
                        {
                            IHTMLTxtRange range = body.createTextRange();
                            range.select();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public string copyText()
        {
            try
            {
                IHTMLDocument2 htmlDocument = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;

                IHTMLSelectionObject currentSelection = htmlDocument.selection;

                if (currentSelection != null)
                {
                    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

                    if (range.text != null)
                    {
                        return range.text;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return null; // Return null if no text was copied
        }

        public string copycleantext()
        {
            try
            {
                string selectedText = copyText();
                if (selectedText != null)
                {
                    // Define a regular expression pattern to match curly braces and their contents
                    string pattern = @"\{[א-ת]*\}|[א-ת]*\}|\{[א-ת]*|\}|\{";

                    // Use Regex.Replace to remove all occurrences of the pattern
                    string result = Regex.Replace(selectedText, pattern, "");

                    result = result.Replace(":", ".");

                    return result;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return null;
        }

        public void copyToWord()
        {
            try
            {
                string selectedText = copyText();
                if (selectedText != null)
                {
                    // Get a reference to the Word application
                    Word.Application wordApp = Globals.ThisAddIn.Application;
                    // Get the active document
                    Word.Document doc = wordApp.ActiveDocument;
                    // Insert  at the current selection or cursor position
                    doc.Application.Selection.TypeText(selectedText);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void CopyCleanTextDirctlyToWord()
        {
            try
            {
                string selectedText = copycleantext();
                if (selectedText != null)
                {
                    // Get a reference to the Word application
                    Word.Application wordApp = Globals.ThisAddIn.Application;
                    // Get the active document
                    Word.Document doc = wordApp.ActiveDocument;
                    // Insert  at the current selection or cursor position
                    doc.Application.Selection.TypeText(selectedText);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
