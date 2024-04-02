//using mshtml;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;


//namespace ToratEmetInWord_2._0
//{
//    public partial class UserControlFileView : UserControl
//    {
//        public UserControl1 taskPaneUserControl;
//        private float currentZoomLevel = 1.0f; // Initial zoom level.
//        public string htmlText = "";
//        public string exactAdress = "";

//        public bool shouldautoNavigate = false;
//        public string autoNavigateText = "";
//        private bool autoNavigateFound = false;
//        public string autoNavigateAlternative = "";
//        public string searchformChpaterNavigate = "";

//        public void SetTaskPaneUserControl(UserControl1 userControl)
//        {
//            taskPaneUserControl = userControl;
//        }
//        public UserControlFileView()
//        {
//            InitializeComponent();
//            textBox1.KeyDown += textBox1_KeyDown;
//            selectAllButton.Click += SelectAllButton_Click;
//            copyButton.Click += CopyButton_Click;
//            copyCleanButton.Click += CopyCleanButton_Click;
//            copyToWordButton.Click += CopyToWordButton_Click;
//            copyCleanTextToWordButton.Click += CopyCleanTextToWordButton_Click;
//            copyToSearchButton.Click += CopyToSearchButton_Click;
//            this.ActiveControl = textBox1;
//            this.AccessibleName = " ";
//        }

//        private void CopyToSearchButton_Click(object sender, EventArgs e)
//        {
//            string texttosearch = copyText();
//           taskPaneUserControl.CopyTosearch(texttosearch);
//        }

//        private void CopyCleanTextToWordButton_Click(object sender, EventArgs e)
//        {
//            CopyCleanTextDirctlyToWord();
//        }

//        private void CopyToWordButton_Click(object sender, EventArgs e)
//        {
//            copyToWord();
//        }

//        private void CopyCleanButton_Click(object sender, EventArgs e)
//        {
//            System.Windows.Clipboard.SetText(copycleantext());
//        }

//        private void CopyButton_Click(object sender, EventArgs e)
//        {
//            System.Windows.Clipboard.SetText(copyText());
//        }

//        private void SelectAllButton_Click(object sender, EventArgs e)
//        {
//            selectAll();
//        }

//        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
//        {
//            try
//            {
//                //if (keyData == (Keys.Control | Keys.A))
//                //{
//                //    if (textBox1.Focused) {textBox1.SelectAll(); }
//                //    else if (webBrowser1.Focused) { selectAll(); webBrowser1.Focus(); }
//                //    return true; // Indicates that the key press has been handled
//                //}
//                if (keyData == (Keys.Control | Keys.C))
//                {
//                    if (textBox1.Focused) { System.Windows.Clipboard.SetText(textBox1.Text); }
//                    else if (webBrowser1.Focused) { System.Windows.Clipboard.SetText(copyText()); }
//                    return true; // Indicates that the key press has been handled
//                }
//                if (keyData == (Keys.Control | Keys.Shift | Keys.C))
//                {
//                    if (webBrowser1.Focused) { System.Windows.Clipboard.SetText(copycleantext()); }
//                    return true; // Indicates that the key press has been handled
//                }
//                if (keyData == (Keys.Control | Keys.V))
//                {
//                    if (webBrowser1.Focused) { copyToWord(); }
//                    return true; // Indicates that the key press has been handled
//                }
//                if (keyData == (Keys.Control | Keys.Shift | Keys.V))
//                {
//                    if (webBrowser1.Focused) { CopyCleanTextDirctlyToWord(); }
//                    return true; // Indicates that the key press has been handled
//                }
//            }
//            catch (Exception ex) { MessageBox.Show(ex.Message); }
//            return base.ProcessCmdKey(ref msg, keyData);
//        }

//        //
//        //
//        // rightclickmenu
//        //
//        //

//        private void selectAll()
//        {
//            if (webBrowser1.Document != null)
//            {
//                IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//                if (doc != null)
//                {
//                    IHTMLBodyElement body = doc.body as IHTMLBodyElement;
//                    if (body != null)
//                    {
//                        IHTMLTxtRange range = body.createTextRange();
//                        range.select();
//                    }
//                }
//            }
//        }

//        private string copyText()
//        {
//            IHTMLDocument2 htmlDocument = webBrowser1.Document.DomDocument as IHTMLDocument2;

//            IHTMLSelectionObject currentSelection = htmlDocument.selection;

//            if (currentSelection != null)
//            {
//                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

//                if (range.text != null)
//                {
//                    return range.text;
//                }
//            }
//            return null; // Return null if no text was copied
//        }

//        private string copycleantext()
//        {
//            string selectedText = copyText();
//            if (selectedText != null)
//            {
//                // Define a regular expression pattern to match curly braces and their contents
//                string pattern = @"\{[א-ת]*\}|[א-ת]*\}|\{[א-ת]*|\}|\{";

//                // Use Regex.Replace to remove all occurrences of the pattern
//                string result = Regex.Replace(selectedText, pattern, "");

//                result = result.Replace(":", ".");

//                return result;
//            }
//            return null;
//        }

//        private void copyToWord()
//        {
//            string selectedText = copyText();
//            if (selectedText != null)
//            {
//                // Get a reference to the Word application
//                Word.Application wordApp = Globals.ThisAddIn.Application;
//                // Get the active document
//                Word.Document doc = wordApp.ActiveDocument;
//                // Insert  at the current selection or cursor position
//                doc.Application.Selection.TypeText(selectedText);
//            }
//        }

//        private void CopyCleanTextDirctlyToWord()
//        {
//            string selectedText = copycleantext();
//            if (selectedText != null)
//            {
//                // Get a reference to the Word application
//                Word.Application wordApp = Globals.ThisAddIn.Application;
//                // Get the active document
//                Word.Document doc = wordApp.ActiveDocument;
//                // Insert  at the current selection or cursor position
//                doc.Application.Selection.TypeText(selectedText);
//            }
//        }


////
////
////
////
////
//        public void puplateHeadersMenu(string htmlFilename)
//        {
//            headersButton.DropDownItems.Clear();

//            string inputString = taskPaneUserControl.headerMenuStructure;

//            //menuStructureDictionary.TryGetValue(htmlFilename, out inputString);

//            if (!string.IsNullOrEmpty(inputString))
//            {
//                if (inputString.Contains("^"))
//                {
//                    string[] parts = inputString.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);

//                    foreach (string part in parts)
//                    {
//                        string[] items = part.Split(',');
//                        if (items.Length > 0)
//                        {
//                            ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(items[0]);
//                            headersButton.DropDownItems.Add(rootMenuItem);
//                            rootMenuItem.Click += MenuItem_Click;
//                            //rootMenuItem.Click += (clickSender, clickEventArgs) => { searchNext(rootMenuItem.Text); };

//                            for (int i = 1; i < items.Length - 1; i++)
//                            {
//                                ToolStripMenuItem childMenuItem = new ToolStripMenuItem(items[i]);
//                                rootMenuItem.DropDownItems.Add(childMenuItem);
//                                childMenuItem.Click += ChildMenuItem_Click;
//                                //childMenuItem.Click += (clickSender, clickEventArgs) => { searchNext(childMenuItem.Text); };
//                            }
//                        }
//                    }

//                }
//                else
//                {
//                    string[] items = inputString.Split(',');
//                    if (items.Length > 0)
//                    {
//                        foreach (string item in items)
//                        {
//                            ToolStripMenuItem menuItem = new ToolStripMenuItem(item);
//                            headersButton.DropDownItems.Add(menuItem);
//                            menuItem.Click += MenuItem_Click;
//                            //menuItem.Click += (clickSender, clickEventArgs) => { searchNext(menuItem.Text); };

//                        }
//                    }
//                }

//            }
//        }

//        private void MenuItem_Click(object sender, EventArgs e)
//        {
//            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
//            if (menuItem != null) { searchHeaders(menuItem.Text); }
//        }

//        private void ChildMenuItem_Click(object sender, EventArgs e)
//        {
//            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
//            if (menuItem != null) { searchChildHeaders(menuItem.Text); }
//        }

//        public void searchHeaders(string searchText)
//        {
//            searchText = Regex.Replace(searchText, " {2,}", " ");
//            // Assuming you have a WebBrowser control named 'webBrowser' on your form
//            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
//            IHTMLElementCollection elements = doc.all.tags("h2");

//            foreach (IHTMLElement element in elements)
//            {
//                if (element.outerText.Trim() == searchText.Trim())
//                {
//                    element.scrollIntoView();
//                    //IHTMLTxtRange textRange = ((IHTMLBodyElement)doc.body).createTextRange();
//                    //textRange.moveToElementText(element);
//                    //textRange.select();
//                    searchText = "";
//                    break;
//                }
//            }

//            if (!string.IsNullOrEmpty(searchText))
//            {
//                elements = doc.all.tags("h3");

//                foreach (IHTMLElement element in elements)
//                {
//                    System.Windows.Clipboard.SetText(element.outerText.Trim() + ":" + searchText.Trim());
//                    if (element.outerText.Trim() == searchText.Trim())
//                    {
                        
//                        element.scrollIntoView();
//                        //element.click();
//                        break;
//                    }
//                }
//            }
//        }

//        public void reverseSearchHeaders(string searchText)
//        {
//            searchText = Regex.Replace(searchText, " {2,}", " ");
//            // Assuming you have a WebBrowser control named 'webBrowser' on your form
//            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
//            IHTMLElementCollection elements = doc.all.tags("h3");

//            foreach (IHTMLElement element in elements)
//            {
//                if (element.outerText.Trim().EndsWith(searchText.Trim()))
//                {
//                    element.scrollIntoView();
//                    //IHTMLTxtRange textRange = ((IHTMLBodyElement)doc.body).createTextRange();
//                    //textRange.moveToElementText(element);
//                    //textRange.select();
//                    searchText = "";
//                    break;
//                }
//            }

//            if (!string.IsNullOrEmpty(searchText))
//            {
//                elements = doc.all.tags("h2");

//                foreach (IHTMLElement element in elements)
//                {
//                    System.Windows.Clipboard.SetText(element.outerText.Trim() + ":" + searchText.Trim());
//                    if (element.outerText.Trim().EndsWith(searchText.Trim()))
//                    {

//                        element.scrollIntoView();
//                        //element.click();
//                        break;
//                    }
//                }
//            }
//        }

//        private void searchChildHeaders(string searchText)
//        {
//            searchText = Regex.Replace(searchText, " {2,}", " ");
//            // Assuming you have a WebBrowser control named 'webBrowser' on your form
//            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
//            IHTMLElementCollection elements = doc.all.tags("h3");

//            foreach (IHTMLElement element in elements)
//            {
//                if (element.outerText.Trim() == searchText.Trim())
//                {
//                    element.scrollIntoView();
//                    //IHTMLTxtRange textRange = ((IHTMLBodyElement)doc.body).createTextRange();
//                    //textRange.moveToElementText(element);
//                    //textRange.select();
//                    searchText = "";
//                    break;
//                }
//            }
//        }

//        public void NavigaetHeaders(string searchText)
//        {
//            searchText = searchText.Replace("-", " ");
//            if (searchText.Contains("דף"))
//            { searchText = DafReplacemnts(searchText); }
//            string[] parts = searchText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//            string searchPart = "";
//            if (parts.Length > 0) { searchPart = parts[0].Trim(); }
//            else { searchPart = searchText.Trim(); }

//            // Assuming you have a WebBrowser control named 'webBrowser' on your form
//            IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
//            IHTMLTxtRange textRange = ((IHTMLBodyElement)doc.body).createTextRange();
//            IHTMLElement parentDiv = null;
//            IHTMLElement foundElement = null;
//            IHTMLElementCollection elements = doc.all.tags("h2");

//            foreach (IHTMLElement element in elements)
//            {
//                if (element.outerText.Trim().Contains("דף"))
//                {
//                    searchPart = DafReplacemnts(searchText);
//                }
//                if (searchTermMatched(searchPart, element.outerText.Trim()))
//                {
//                    //element.scrollIntoView();
//                    foundElement = element;
//                    parentDiv = element.parentElement;
//                    textRange.moveToElementText(parentDiv);
//                    break;
//                }
//            }

//            if (parentDiv != null && parts.Length > 1)
//            {
//                IHTMLElementCollection childElements = parentDiv.all.tags("h3");
//                foreach (IHTMLElement childElement in childElements)
//                {
//                    if (searchTermMatched(parts[1], childElement.outerText.Trim())
//                        && childElement.outerText.Trim().EndsWith(parts[1]))
//                    {
//                        textRange.moveToElementText(childElement);
//                        break;
//                    }
//                }
//            }
//            else if (parentDiv == null)
//            {
//                IHTMLElementCollection childElements = doc.all.tags("h3");
//                foreach (IHTMLElement childElement in childElements)
//                {
//                    if (childElement.outerText.Trim().Contains("דף"))
//                    {
//                        searchPart = DafReplacemnts(searchText);
//                    }
//                    if (searchTermMatched(searchPart, childElement.outerText.Trim()))
//                    {
//                        textRange.moveToElementText(childElement);
//                        break;
//                    }
//                }
//            }

//            //only select if found result; also do this for div elemnt;
//            if (parentDiv == null && isTanach(labelBookName.Text) && parts.Length > 1)
//            {
//                string searchPasuk = "";
//                searchPasuk = parts[1].Trim();
//                if (searchPasuk.Contains("פסוק")|| !searchPasuk.Contains("}")) { searchPasuk = "{" + searchPasuk.Replace("פסוק","").Trim() + "}"; }
//                textRange.collapse(false); // collapse the current selection so we start from the end of the previous range

//                if (textRange.findText(searchPasuk, 1000000000, 0))
//                {
//                    textRange.scrollIntoView();
//                    textRange.select();
//                }
//            }
//            if (textRange.text != doc.body.outerText)
//            {
//                if (parentDiv != null && textRange.text == parentDiv.outerText) { textRange.moveToElementText(foundElement);}
//                textRange.scrollIntoView();
//                textRange.select();
//            }
//            searchText = "";
//        }

//        private string DafReplacemnts(string dafReplacemnts)
//        {
//            dafReplacemnts = dafReplacemnts.Replace(",", " ");
//            dafReplacemnts = dafReplacemnts.Replace(":", " ב");
//            dafReplacemnts = dafReplacemnts.Replace(".", " א");
//            return dafReplacemnts;
//        }

//        public bool isTanach(string bookName)
//        {
//            if ( bookName.Contains("בראשית - עם ניקוד")
//|| bookName.Contains("בראשית - עם טעמים")
//|| bookName.Contains("בראשית - ללא ניקוד")
//|| bookName.Contains("שמות  -עם ניקוד")
//|| bookName.Contains("שמות  -עם טעמים")
//|| bookName.Contains("שמות  - ללא ניקוד")
//|| bookName.Contains("ויקרא - עם ניקוד")
//|| bookName.Contains("ויקרא - עם טעמים")
//|| bookName.Contains("ויקרא  - ללא ניקוד")
//|| bookName.Contains("במדבר - עם ניקוד")
//|| bookName.Contains("במדבר - עם טעמים")
//|| bookName.Contains("במדבר - ללא ניקוד")
//|| bookName.Contains("דברים - עם ניקוד")
//|| bookName.Contains("דברים - עם טעמים")
//|| bookName.Contains("דברים - ללא ניקוד")
//|| bookName.Contains("יהושע - עם ניקוד")
//|| bookName.Contains("יהושע - עם טעמים")
//|| bookName.Contains("יהושע - ללא ניקוד")
//|| bookName.Contains("שופטים - עם ניקוד")
//|| bookName.Contains("שופטים - עם טעמים")
//|| bookName.Contains("שופטים - ללא ניקוד")
//|| bookName.Contains("שמואל א - עם ניקוד")
//|| bookName.Contains("שמואל א - עם טעמים")
//|| bookName.Contains("שמואל א - ללא ניקוד")
//|| bookName.Contains("שמואל ב - עם ניקוד")
//|| bookName.Contains("שמואל ב - עם טעמים")
//|| bookName.Contains("שמואל ב - ללא ניקוד")
//|| bookName.Contains("מלכים א - עם ניקוד")
//|| bookName.Contains("מלכים א - עם טעמים")
//|| bookName.Contains("מלכים א - ללא ניקוד")
//|| bookName.Contains("מלכים ב - עם ניקוד")
//|| bookName.Contains("מלכים ב - עם טעמים")
//|| bookName.Contains("מלכים ב - ללא ניקוד")
//|| bookName.Contains("ישעיה - עם ניקוד")
//|| bookName.Contains("ישעיה - עם טעמים")
//|| bookName.Contains("ישעיה - ללא ניקוד")
//|| bookName.Contains("ירמיה - עם ניקוד")
//|| bookName.Contains("ירמיה - עם טעמים")
//|| bookName.Contains("ירמיה - ללא ניקוד")
//|| bookName.Contains("יחזקאל - עם ניקוד")
//|| bookName.Contains("יחזקאל - עם טעמים")
//|| bookName.Contains("יחזקאל - ללא ניקוד")
//|| bookName.Contains("הושע - עם ניקוד")
//|| bookName.Contains("הושע - עם טעמים")
//|| bookName.Contains("הושע - ללא ניקוד")
//|| bookName.Contains("יואל - עם ניקוד")
//|| bookName.Contains("יואל - עם טעמים")
//|| bookName.Contains("יואל - ללא ניקוד")
//|| bookName.Contains("עמוס - עם ניקוד")
//|| bookName.Contains("עמוס - עם טעמים")
//|| bookName.Contains("עמוס - ללא ניקוד")
//|| bookName.Contains("עובדיה - עם ניקוד")
//|| bookName.Contains("עובדיה - עם טעמים")
//|| bookName.Contains("עובדיה - ללא ניקוד")
//|| bookName.Contains("יונה - עם ניקוד")
//|| bookName.Contains("יונה - עם טעמים")
//|| bookName.Contains("יונה - ללא ניקוד")
//|| bookName.Contains("מיכה - עם ניקוד")
//|| bookName.Contains("מיכה - עם טעמים")
//|| bookName.Contains("מיכה - ללא ניקוד")
//|| bookName.Contains("נחום - עם ניקוד")
//|| bookName.Contains("נחום - עם טעמים")
//|| bookName.Contains("נחום - ללא ניקוד")
//|| bookName.Contains("חבקוק - עם ניקוד")
//|| bookName.Contains("חבקוק - עם טעמים")
//|| bookName.Contains("חבקוק - ללא ניקוד")
//|| bookName.Contains("צפניה - עם ניקוד")
//|| bookName.Contains("צפניה - עם טעמים")
//|| bookName.Contains("צפניה - ללא ניקוד")
//|| bookName.Contains("חגי - עם ניקוד")
//|| bookName.Contains("חגי - עם טעמים")
//|| bookName.Contains("חגי - ללא ניקוד")
//|| bookName.Contains("זכריה - עם ניקוד")
//|| bookName.Contains("זכריה - עם טעמים")
//|| bookName.Contains("זכריה - ללא ניקוד")
//|| bookName.Contains("מלאכי - עם ניקוד")
//|| bookName.Contains("מלאכי - עם טעמים")
//|| bookName.Contains("מלאכי - ללא ניקוד")
//|| bookName.Contains("תהילים - עם ניקוד")
//|| bookName.Contains("תהילים - עם טעמים")
//|| bookName.Contains("תהילים - ללא ניקוד")
//|| bookName.Contains("משלי - עם ניקוד")
//|| bookName.Contains("משלי - עם טעמים")
//|| bookName.Contains("משלי - ללא ניקוד")
//|| bookName.Contains("איוב - עם ניקוד")
//|| bookName.Contains("איוב - עם טעמים")
//|| bookName.Contains("איוב - ללא ניקוד")
//|| bookName.Contains("שיר השירים - עם ניקוד")
//|| bookName.Contains("שיר השירים - עם טעמים")
//|| bookName.Contains("שיר השירים - ללא ניקוד")
//|| bookName.Contains("רות - עם ניקוד")
//|| bookName.Contains("רות - עם טעמים")
//|| bookName.Contains("רות - ללא ניקוד")
//|| bookName.Contains("איכה - עם ניקוד")
//|| bookName.Contains("איכה - עם טעמים")
//|| bookName.Contains("איכה - ללא ניקוד")
//|| bookName.Contains("קהלת - עם ניקוד")
//|| bookName.Contains("קהלת - עם טעמים")
//|| bookName.Contains("קהלת - ללא ניקוד")
//|| bookName.Contains("אסתר - עם ניקוד")
//|| bookName.Contains("אסתר - עם טעמים")
//|| bookName.Contains("אסתר - ללא ניקוד")
//|| bookName.Contains("דניאל - עם ניקוד")
//|| bookName.Contains("דניאל - עם טעמים")
//|| bookName.Contains("דניאל - ללא ניקוד")
//|| bookName.Contains("עזרא - עם ניקוד")
//|| bookName.Contains("עזרא - עם טעמים")
//|| bookName.Contains("עזרא - ללא ניקוד")
//|| bookName.Contains("נחמיה - עם ניקוד")
//|| bookName.Contains("נחמיה - עם טעמים")
//|| bookName.Contains("נחמיה - ללא ניקוד")
//|| bookName.Contains("דברי הימים א - עם ניקוד")
//|| bookName.Contains("דברי הימים א - עם טעמים")
//|| bookName.Contains("דברי הימים א - ללא ניקוד")
//|| bookName.Contains("דברי הימים ב - עם ניקוד")
//|| bookName.Contains("דברי הימים ב - עם טעמים")
//|| bookName.Contains("דברי הימים ב - ללא ניקוד")
//                )
//            { return true; }
//            else { return false; }
//        }

//        private bool searchTermMatched(String searchTerm, string headerText)
//        {
//            headerText = Regex.Replace(headerText, "[^א-ת\"']", " ");
//            string[] searchTermParts = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            string[] headerTextParts = headerText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            int hitScore = 0;

//            foreach (String part in searchTermParts)
//            {
//                bool searchTermExists = headerTextParts.Any(item => string.Equals(item, part, StringComparison.OrdinalIgnoreCase));
//                if (searchTermExists) { hitScore++; }
//            }

//            if (hitScore == searchTermParts.Count()) { return true; }
//            else { return false; }
//        }

//        public void loadRelatedFiles(string rFilePath, string htmlFileName)
//        {
//            List<string> RelatedFiles = new List<string>();

//            relatedBooksButton.DropDownItems.Clear();
//            rFilePath = Path.GetDirectoryName(rFilePath);
//            string[] filesInSameFolder = Directory.GetFiles(rFilePath);

//            foreach (string rFile in filesInSameFolder)
//            {
//                string rFileHebrewName = "";
//                if (!rFile.Contains("Interleave")) { rFileHebrewName = rFilename(rFile); }
//                if (!string.IsNullOrEmpty(rFileHebrewName))
//                {
//                    RelatedFiles.Add(rFileHebrewName);
//                    ToolStripMenuItem item = new ToolStripMenuItem(rFileHebrewName);
//                    relatedBooksButton.DropDownItems.Add(item);
//                    item.Click += (sender, e) => { taskPaneUserControl.openFileFromList(item.Text); };
//                }
//            }
//            //listsWithHeadings.AddList(htmlFileName, RelatedFiles);
//        }

//        string rFilename(string rFilePath)
//        {
//            int index = rFilePath.IndexOf("ToratEmetInstall");

//            if (index != -1)
//            {
//                index = rFilePath.IndexOf("Books");
//                rFilePath = rFilePath.Substring(index);
//                return TranslatorClass.TranslateFilename(rFilePath) + " ";
//            }
//            else
//            {
//                return Path.GetFileNameWithoutExtension(rFilePath);
//            }
//        }

//        private void textBox1_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter) { searchNext(textBox1.Text); e.Handled = true; }
//        }

//        private void searchNextButton_Click(object sender, EventArgs e)
//        {
//            searchNext(textBox1.Text);
//        }

//        private void searchPreviousButton_Click(object sender, EventArgs e)
//        {
//            searchPrevious();
//        }


//        private void searchPrevious()
//        {
//            string searchText = textBox1.Text;

//            if (!string.IsNullOrEmpty(searchText))
//            {
//                // Ensure the webBrowser1 control is not null and has a valid document loaded.
//                if (webBrowser1.Document != null)
//                {
//                    IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//                    if (doc != null)
//                    {
//                        IHTMLSelectionObject sel = (IHTMLSelectionObject)doc.selection;
//                        IHTMLTxtRange rng = (IHTMLTxtRange)sel.createRange();
//                        rng.collapse(true); // collapse the current selection so we start from the beginning

//                        if (rng.findText(searchText, -1000000000, 0)) // Notice the negative value for count
//                        {
//                            rng.scrollIntoView();
//                            rng.select();                            
//                        }
//                        else
//                        {
//                            if (webBrowser1.Document != null)
//                            {
//                                IHTMLDocument2 myDoc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//                                if (doc != null)
//                                {
//                                    IHTMLBodyElement body = myDoc.body as IHTMLBodyElement;
//                                    if (body != null)
//                                    {
//                                        IHTMLTxtRange docRange = body.createTextRange();
//                                        docRange.collapse(false);

//                                        if (docRange.findText(searchText, -1000000000, 0))
//                                        {
//                                            docRange.scrollIntoView();
//                                            docRange.select();
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        // Handle the case when the webBrowser1.Document.DomDocument cannot be cast to IHTMLDocument2.
//                        MessageBox.Show("Could not access the document.");
//                    }
//                }
//            }
//        }

//        public void searchNext(string searchText)
//        {
//            try
//            {
//                if (!string.IsNullOrEmpty(searchText))
//                {
//                    // Ensure the webBrowser1 control is not null and has a valid document loaded.
//                    if (webBrowser1.Document != null)
//                    {
//                        IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;

//                        if (doc != null)
//                        {
//                            IHTMLSelectionObject sel = (IHTMLSelectionObject)doc.selection;
//                            IHTMLTxtRange rng = (IHTMLTxtRange)sel.createRange();
//                            rng.collapse(false); // collapse the current selection so we start from the end of the previous range

//                            if (rng.findText(searchText, 1000000000, 0))
//                            {
//                                rng.scrollIntoView();
//                                rng.select();
//                                if (shouldautoNavigate == true) { autoNavigateFound = true; }
//                            }
//                            else
//                            {
//                                if (webBrowser1.Document != null)
//                                {
//                                    IHTMLDocument2 myDoc = webBrowser1.Document.DomDocument as IHTMLDocument2;
//                                    if (doc != null)
//                                    {
//                                        IHTMLBodyElement body = myDoc.body as IHTMLBodyElement;
//                                        if (body != null)
//                                        {
//                                            IHTMLTxtRange docRange = body.createTextRange();
//                                            docRange.collapse(true);

//                                            if (docRange.findText(searchText, 1000000000, 0))
//                                            {
//                                                docRange.scrollIntoView();
//                                                docRange.select();
//                                                if (shouldautoNavigate == true) { autoNavigateFound = true; }
//                                            }
//                                        }
//                                    }
//                                }

//                            }
//                        }
//                    }
//                    else
//                    {
//                        // Handle the case when the webBrowser1.Document.DomDocument cannot be cast to IHTMLDocument2.
//                        MessageBox.Show("Could not access the document.");
//                    }
//                }
//            }
//            catch (Exception) { };
//        }

        

//        public void ZoomOut()
//        {
//            // Incrementally zoom out when the "Zoom Out" button is clicked.
//            currentZoomLevel -= 0.1f; // Increase this value to zoom out faster.
//            SetWebBrowserZoom(currentZoomLevel);
//        }

//        public void ZoomIN()
//        {
//            // Incrementally zoom in when the "Zoom In" button is clicked.
//            currentZoomLevel += 0.1f; // Increase this value to zoom in faster.
//            SetWebBrowserZoom(currentZoomLevel);
//        }

//        private void SetWebBrowserZoom(float zoomLevel)
//        {
//            // Check if the WebBrowser control has a Document and its body is not null.
//            if (webBrowser1.Document != null && webBrowser1.Document.Body != null)
//            {
//                // Adjust the zoom level using CSS.
//                webBrowser1.Document.Body.Style = $"zoom: {zoomLevel}";
//            }
//        }

//        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {
//            SetWebBrowserZoom(currentZoomLevel);

//            if (webBrowser1.DocumentText == "")
//            { webBrowser1.DocumentText = htmlText; }

//            if (!string.IsNullOrEmpty(exactAdress))
//            {
//                NavigaetHeaders(exactAdress); exactAdress = "";
//            }

//            if (shouldautoNavigate == true)
//            {
//                searchNext(autoNavigateText);
//                shouldautoNavigate = false;
//                if (autoNavigateFound == false)
//                {
//                    AutoNavigateAlternative();
//                }
//            }

//            if (!string.IsNullOrEmpty(searchformChpaterNavigate))
//            {
//                reverseSearchHeaders(searchformChpaterNavigate);
//                taskPaneUserControl.searchformChpaterNavigate = "";
//            }
//            //if (pageloaded == false)
//            //{
//            ////webBrowser1.Document.Body.InnerHtml = htmlText;
//            //webBrowser1.DocumentText = htmlText;
//            //pageloaded = true;
//            //}
//            textBox1.Focus();                 
//        }

//        private void AutoNavigateAlternative()
//        {
//            NavigaetHeaders(autoNavigateAlternative);
//        }

//        private void CloseButton_Click(object sender, EventArgs e)
//        {
//            taskPaneUserControl.disposedFile = this.AccessibleName;
//            taskPaneUserControl.xButtonClicked = true;
//            this.Dispose();
//        }
//    }
//}
