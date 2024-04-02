using Lucene.Net.Search;
using Microsoft.Office.Interop.Word;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ToratEmetInWord_2._0
{
    public class FileViewerExactLocation
    {
        public UserControl1 taskPaneUserControl;
        public bool isTanachBook;
        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public bool SearchNext(string searchText)
        {
            searchText = Regex.Replace(searchText, "<.*?>", "").Trim();
            bool foundText = false;
            try
            {
                if (!string.IsNullOrEmpty(searchText) && taskPaneUserControl.fileViewer.Document != null)
                {
                    IHTMLDocument2 myDoc = taskPaneUserControl.fileViewer.Document.DomDocument as IHTMLDocument2;
                    IHTMLBodyElement body = myDoc.body as IHTMLBodyElement;
                    IHTMLTxtRange docRange = body.createTextRange();
                    docRange.collapse(true);

                    if (docRange.findText(searchText, 1000000000, 0))
                    {
                        docRange.scrollIntoView();
                        docRange.select();
                        foundText = true;
                    }
                }
                else
                {
                    // Handle the case when the taskPaneUserControl.fileViewer.Document.DomDocument cannot be cast to IHTMLDocument2.
                    MessageBox.Show("הקובץ לא נגיש");
                }
                if (taskPaneUserControl.searchForm != null && !taskPaneUserControl.searchForm.IsDisposed)
                { taskPaneUserControl.SearchTextBox.Text = taskPaneUserControl.searchForm.textBox1.Text; taskPaneUserControl.SearchTextBox.Focus(); }
            }
            catch (Exception ex) { MessageBox.Show("Error In: FileViewerExactLocation,SearchNext.\r\n" + ex.Message); }
            return foundText;
        }

        public void NavigateHeaders(string searchText)
        {
            searchText = searchText.Replace("-", " ");
            if (searchText.Contains("דף"))
            { searchText = DafReplacemnts(searchText); }
            string[] parts = searchText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string searchPart = "";
            if (parts.Length > 0) { searchPart = parts[0].Trim(); }
            else { searchPart = searchText.Trim(); }
          
            // Assuming you have a WebBrowser control named 'webBrowser' on your form
            IHTMLDocument2 doc = (IHTMLDocument2)taskPaneUserControl.fileViewer.Document.DomDocument;
            IHTMLTxtRange textRange = ((IHTMLBodyElement)doc.body).createTextRange();
            IHTMLElement parentDiv = null;
            IHTMLElement foundElement = null;
            IHTMLElementCollection elements = doc.all.tags("h2");

            foreach (IHTMLElement element in elements)
            {
                if (element.outerText.Trim().Contains("דף"))
                {
                    searchPart = DafReplacemnts(searchText);
                }

                if (searchTermMatched(searchPart, element.outerText.Trim()))
                {
                    //element.scrollIntoView();
                    foundElement = element;
                    parentDiv = element.parentElement;
                    textRange.moveToElementText(parentDiv);
                    textRange.scrollIntoView();
                    break;
                }
            }

            if (parentDiv != null && parts.Length > 1)
            {
                IHTMLElementCollection childElements = parentDiv.all.tags("h3");
                foreach (IHTMLElement childElement in childElements)
                {
                    if (searchTermMatched(parts[1], childElement.outerText.Trim())
                        && childElement.outerText.Trim().EndsWith(parts[1]))
                    {
                        textRange.moveToElementText(childElement);
                        textRange.scrollIntoView();
                        break;
                    }
                }
            }
            else if (parentDiv == null)
            {
                IHTMLElementCollection childElements = doc.all.tags("h3");
                foreach (IHTMLElement childElement in childElements)
                {
                    if (childElement.outerText.Trim().Contains("דף"))
                    {
                        searchPart = DafReplacemnts(searchText);
                    }
                    if (searchTermMatched(searchPart, childElement.outerText.Trim()))
                    {
                        textRange.moveToElementText(childElement);
                        textRange.scrollIntoView();
                        break;
                    }
                }
            }

            //only select if found result; also do this for div elemnt;
            if (parentDiv == null && isTanach(taskPaneUserControl.currentFileName) && parts.Length > 1)
            {
                string searchPasuk = "";
                searchPasuk = parts[1].Trim();
                if (searchPasuk.Contains("פסוק") || !searchPasuk.Contains("}")) { searchPasuk = "{" + searchPasuk.Replace("פסוק", "").Trim() + "}"; }
                textRange.collapse(false); // collapse the current selection so we start from the end of the previous range

                if (textRange.findText(searchPasuk, 1000000000, 0))
                {
                    textRange.select();
                    textRange.scrollIntoView();
                }
            }
            if (textRange.text != doc.body.outerText)
            {
                if (parentDiv != null && textRange.text == parentDiv.outerText) { textRange.moveToElementText(foundElement); }
                textRange.select();
                textRange.scrollIntoView();
            }
            SearchHeadersById(textRange.htmlText);
            searchText = "";
            if (taskPaneUserControl.searchForm != null && !taskPaneUserControl.searchForm.IsDisposed)
            { taskPaneUserControl.SearchTextBox.Text = taskPaneUserControl.searchForm.textBox1.Text; taskPaneUserControl.SearchTextBox.Focus(); }
        }

        public void SearchHeadersById(string elementId)
        {
            elementId = Regex.Match(elementId, @"=.\d+").ToString();
            elementId = Regex.Match(elementId, @"\d+").ToString();
            IHTMLDocument3 doc = (IHTMLDocument3)taskPaneUserControl.fileViewer.Document.DomDocument;
            if (elementId != null)
            {
                IHTMLElement element = doc.getElementById(elementId); 
            if (element != null)
            {
                element.scrollIntoView();
            }
            }
        }

        private string DafReplacemnts(string dafReplacemnts)
        {
            dafReplacemnts = dafReplacemnts.Replace(",", " ");
            dafReplacemnts = dafReplacemnts.Replace(":", " ב");
            dafReplacemnts = dafReplacemnts.Replace(".", " א");
            return dafReplacemnts;
        }

        public bool isTanach(string bookName)
        {
            string tanachBooks = "\r\n|בראשית - עם ניקוד\r\n|בראשית - עם טעמים\r\n|בראשית - ללא ניקוד\r\n|בראשית - רש''י\r\n|בראשית - רש''י (ב)\r\n|בראשית - שפתי חכמים\r\n|בראשית - רמב''ן\r\n|בראשית - תרגום יונתן\r\n|בראשית - אור החיים\r\n|בראשית - אבן עזרא\r\n|בראשית - בעל הטורים\r\n|בראשית - תרגום אונקלוס\r\n|בראשית - ספורנו\r\n|בראשית - כלי יקר\r\n|בראשית - דעת זקנים\r\n|מדרש רבה - חומש בראשית\r\n|מדרש תנחומא - בראשית\r\n|ילקוט שמעוני - בראשית\r\n|חק לישראל - בראשית\r\n|חק לישראל - בראשית  (ט)\r\n|שמות  -עם ניקוד\r\n|שמות  -עם טעמים\r\n|שמות  - ללא ניקוד\r\n|שמות - רש''י\r\n|שמות - רש''י (ב)\r\n|שמות - שפתי חכמים\r\n|שמות - רמב''ן\r\n|שמות - תרגום יונתן\r\n|שמות - אור החיים\r\n|שמות - אבן עזרא\r\n|שמות - בעל הטורים\r\n|שמות - תרגום אונקלוס\r\n|שמות - ספורנו\r\n|שמות - כלי יקר\r\n|שמות - דעת זקנים\r\n|מדרש רבה - חומש שמות\r\n|מדרש תנחומא - שמות\r\n|ילקוט שמעוני - שמות\r\n|חק לישראל - שמות\r\n|חק לישראל - שמות  (ט)\r\n|ויקרא - עם ניקוד\r\n|ויקרא - עם טעמים\r\n|ויקרא  - ללא ניקוד\r\n|ויקרא - רש''י\r\n|ויקרא - רש''י (ב)\r\n|ויקרא - שפתי חכמים\r\n|ויקרא - רמב''ן\r\n|ויקרא - תרגום יונתן\r\n|ויקרא אור החיים\r\n|ויקרא - אבן עזרא\r\n|ויקרא - בעל הטורים\r\n|ויקרא - תרגום אונקלוס\r\n|ויקרא - ספורנו\r\n|ויקרא - כלי יקר\r\n|ויקרא - דעת זקנים\r\n|מדרש רבה - חומש ויקרא\r\n|מדרש תנחומא - ויקרא\r\n|ילקוט שמעוני - ויקרא\r\n|חק לישראל - ויקרא\r\n|חק לישראל - ויקרא  (ט)\r\n|במדבר - עם ניקוד\r\n|במדבר - עם טעמים\r\n|במדבר - ללא ניקוד\r\n|במדבר - רש''י\r\n|במדבר - רש''י (ב)\r\n|במדבר - שפתי חכמים\r\n|במדבר - רמב''ן\r\n|במדבר - תרגום יונתן\r\n|במדבר אור החיים\r\n|במדבר - אבן עזרא\r\n|במדבר - בעל הטורים\r\n|במדבר - תרגום אונקלוס\r\n|במדבר - ספורנו\r\n|במדבר - כלי יקר\r\n|במדבר - דעת זקנים\r\n|מדרש רבה - חומש במדבר\r\n|מדרש תנחומא - במדבר\r\n|ילקוט שמעוני - במדבר\r\n|חק לישראל - במדבר\r\n|חק לישראל - במדבר  (ט)\r\n|דברים - עם ניקוד\r\n|דברים - עם טעמים\r\n|דברים - ללא ניקוד\r\n|דברים - רש''י\r\n|דברים - רש''י (ב)\r\n|דברים - שפתי חכמים\r\n|דברים - רמב''ן\r\n|דברים - תרגום יונתן\r\n|דברים אור החיים\r\n|דברים - אבן עזרא\r\n|דברים - בעל הטורים\r\n|דברים - תרגום אונקלוס\r\n|דברים - ספורנו\r\n|דברים - כלי יקר\r\n|דברים - דעת זקנים\r\n|מדרש רבה - חומש דברים\r\n|מדרש תנחומא - דברים\r\n|ילקוט שמעוני - דברים\r\n|חק לישראל - דברים\r\n|חק לישראל - דברים  (ט)\r\n|יהושע - עם ניקוד\r\n|יהושע - עם טעמים\r\n|יהושע - ללא ניקוד\r\n|יהושע - רש''י\r\n|יהושע - מצודת דוד\r\n|יהושע - מצודת ציון\r\n|יהושע - רלב''ג\r\n|שופטים - עם ניקוד\r\n|שופטים - עם טעמים\r\n|שופטים - ללא ניקוד\r\n|שופטים - רש''י\r\n|שופטים - מצודת דוד\r\n|שופטים - מצודת ציון\r\n|שופטים - רלב''ג\r\n|שמואל א - עם ניקוד\r\n|שמואל א - עם טעמים\r\n|שמואל א - ללא ניקוד\r\n|שמואל א - רש''י\r\n|שמואל א - מצודת דוד\r\n|שמואל א - מצודת ציון\r\n|שמואל א - רלב''ג\r\n|שמואל א - מלבי''ם\r\n|שמואל ב - עם ניקוד\r\n|שמואל ב - עם טעמים\r\n|שמואל ב - ללא ניקוד\r\n|שמואל ב - רש''י\r\n|שמואל ב - מצודת דוד\r\n|שמואל ב - מצודת ציון\r\n|שמואל ב - רלב''ג\r\n|שמואל ב - מלבי''ם\r\n|מלכים א - עם ניקוד\r\n|מלכים א - עם טעמים\r\n|מלכים א - ללא ניקוד\r\n|מלכים א - רש''י\r\n|מלכים א - מצודת דוד\r\n|מלכים א - מצודת ציון\r\n|מלכים א - רלב''ג\r\n|מלכים א - מלבי''ם\r\n|מלכים ב - עם ניקוד\r\n|מלכים ב - עם טעמים\r\n|מלכים ב - ללא ניקוד\r\n|מלכים ב - רש''י\r\n|מלכים ב - מצודת דוד\r\n|מלכים ב - מצודת ציון\r\n|מלכים ב - רלב''ג\r\n|מלכים ב - מלבי''ם\r\n|ישעיה - עם ניקוד\r\n|ישעיה - עם טעמים\r\n|ישעיה - ללא ניקוד\r\n|ישעיה - רש''י\r\n|ישעיה - מצודת דוד\r\n|ישעיה - מצודת ציון\r\n|ישעיה - מלבי''ם - ב. הענין\r\n|ישעיה - מלבי''ם - ב. המילת\r\n|ירמיה - עם ניקוד\r\n|ירמיה - עם טעמים\r\n|ירמיה - ללא ניקוד\r\n|ירמיה - רש''י\r\n|ירמיה - מצודת דוד\r\n|ירמיה - מצודת ציון\r\n|ירמיה- מלבי''ם - ב. הענין\r\n|ירמיה - מלבי''ם - ב. המילת\r\n|יחזקאל - עם ניקוד\r\n|יחזקאל - עם טעמים\r\n|יחזקאל - ללא ניקוד\r\n|יחזקאל - רש''י\r\n|יחזקאל - מצודת דוד\r\n|יחזקאל - מצודת ציון\r\n|יחזקאל - מלבי''ם - ב. הענין\r\n|(2) יחזקאל - מלבי''ם - ב. הענין\r\n|הושע - עם ניקוד\r\n|הושע - עם טעמים\r\n|הושע - ללא ניקוד\r\n|הושע - רש''י\r\n|הושע - מצודת דוד\r\n|הושע - מצודת ציון\r\n|יואל - עם ניקוד\r\n|יואל - עם טעמים\r\n|יואל - ללא ניקוד\r\n|יואל - רש''י\r\n|יואל - מצודת דוד\r\n|יואל - מצודת ציון\r\n|עמוס - עם ניקוד\r\n|עמוס - עם טעמים\r\n|עמוס - ללא ניקוד\r\n|עמוס - רש''י\r\n|עמוס - מצודת דוד\r\n|עמוס - מצודת ציון\r\n|עובדיה - עם ניקוד\r\n|עובדיה - עם טעמים\r\n|עובדיה - ללא ניקוד\r\n|עובדיה - רש''י\r\n|עובדיה - מצודת דוד\r\n|עובדיה - מצודת ציון\r\n|יונה - עם ניקוד\r\n|יונה - עם טעמים\r\n|יונה - ללא ניקוד\r\n|יונה - רש''י\r\n|יונה - מצודת דוד\r\n|יונה - מצודת ציון\r\n|מיכה - עם ניקוד\r\n|מיכה - עם טעמים\r\n|מיכה - ללא ניקוד\r\n|מיכה - רש''י\r\n|מיכה - מצודת דוד\r\n|מיכה - מצודת ציון\r\n|נחום - עם ניקוד\r\n|נחום - עם טעמים\r\n|נחום - ללא ניקוד\r\n|נחום - רש''י\r\n|נחום - מצודת דוד\r\n|נחום - מצודת ציון\r\n|חבקוק - עם ניקוד\r\n|חבקוק - עם טעמים\r\n|חבקוק - ללא ניקוד\r\n|חבקוק - רש''י\r\n|חבקוק - מצודת דוד\r\n|חבקוק - מצודת ציון\r\n|צפניה - עם ניקוד\r\n|צפניה - עם טעמים\r\n|צפניה - ללא ניקוד\r\n|צפניה - רש''י\r\n|צפניה - מצודת דוד\r\n|צפניה - מצודת ציון\r\n|חגי - עם ניקוד\r\n|חגי - עם טעמים\r\n|חגי - ללא ניקוד\r\n|חגי - רש''י\r\n|חגי - מצודת דוד\r\n|חגי - מצודת ציון\r\n|זכריה - עם ניקוד\r\n|זכריה - עם טעמים\r\n|זכריה - ללא ניקוד\r\n|זכריה - רש''י\r\n|זכריה - מצודת דוד\r\n|זכריה - מצודת ציון\r\n|מלאכי - עם ניקוד\r\n|מלאכי - עם טעמים\r\n|מלאכי - ללא ניקוד\r\n|מלאכי - רש''י\r\n|מלאכי - מצודת דוד\r\n|מלאכי - מצודת ציון\r\n|תהילים - עם ניקוד\r\n|תהילים - עם טעמים\r\n|תהילים - ללא ניקוד\r\n|תהילים - רש''י\r\n|תהילים - מצודת דוד\r\n|תהילים - מצודת ציון\r\n|תהילים - מלבי''ם - ב. הענין\r\n|תהילים - מלבי''ם - ב. המלות\r\n|תהילים - מחולק לספרים\r\n|תהילים - מחולק לימי השבוע\r\n|תהילים - מחולק לימי החודש\r\n|משלי - עם ניקוד\r\n|משלי - עם טעמים\r\n|משלי - ללא ניקוד\r\n|משלי - רש''י\r\n|משלי - מצודת דוד\r\n|משלי - מצודת ציון\r\n|משלי - רלב''ג\r\n|איוב - עם ניקוד\r\n|איוב - עם טעמים\r\n|איוב - ללא ניקוד\r\n|איוב - רש''י\r\n|איוב - מצודת דוד\r\n|איוב - מצודת ציון\r\n|איוב - רלב''ג\r\n|שיר השירים - עם ניקוד\r\n|שיר השירים - עם טעמים\r\n|שיר השירים - ללא ניקוד\r\n|שיר השירים - רש''י\r\n|שיר השירים - מצודת דוד\r\n|שיר השירים - מצודת ציון\r\n|מדרש רבה - שיר השירים רבה\r\n|רות - עם ניקוד\r\n|רות - עם טעמים\r\n|רות - ללא ניקוד\r\n|רות - רש''י\r\n|מדרש רבה - רות רבה\r\n|איכה - עם ניקוד\r\n|איכה - עם טעמים\r\n|איכה - ללא ניקוד\r\n|איכה - רש''י\r\n|מדרש רבה - איכה רבתי\r\n|קהלת - עם ניקוד\r\n|קהלת - עם טעמים\r\n|קהלת - ללא ניקוד\r\n|קהלת - רש''י\r\n|קהלת - מצודת דוד\r\n|קהלת - מצודת ציון\r\n|מדרש רבה - קהלת רבה\r\n|אסתר - עם ניקוד\r\n|אסתר - עם טעמים\r\n|אסתר - ללא ניקוד\r\n|אסתר - רש''י\r\n|אסתר - מלבי''ם\r\n|מדרש רבה - אסתר רבה\r\n|דניאל - עם ניקוד\r\n|דניאל - עם טעמים\r\n|דניאל - ללא ניקוד\r\n|דניאל - רש''י\r\n|דניאל - מצודת דוד\r\n|דניאל - מצודת ציון\r\n|עזרא - עם ניקוד\r\n|עזרא - עם טעמים\r\n|עזרא - ללא ניקוד\r\n|עזרא - רש''י\r\n|עזרא - מצודת דוד\r\n|עזרא - מצודת ציון\r\n|עזרא - רלב''ג\r\n|נחמיה - עם ניקוד\r\n|נחמיה - עם טעמים\r\n|נחמיה - ללא ניקוד\r\n|נחמיה - רש''י\r\n|נחמיה - מצודת דוד\r\n|נחמיה - מצודת ציון\r\n|נחמיה - רלב''ג\r\n|דברי הימים א - עם ניקוד\r\n|דברי הימים א - עם טעמים\r\n|דברי הימים א - ללא ניקוד\r\n|דברי הימים א - רש''י\r\n|דברי הימים א - מצודת דוד\r\n|דברי הימים א - מצודת ציון\r\n|דברי הימים א - רלב''ג\r\n|דברי הימים ב - עם ניקוד\r\n|דברי הימים ב - עם טעמים\r\n|דברי הימים ב - ללא ניקוד\r\n|דברי הימים ב - רש''י\r\n|דברי הימים ב - מצודת דוד\r\n|דברי הימים ב - מצודת ציון\r\n|דברי הימים ב - רלב''ג";
            string[] books = tanachBooks.Split(new[] { "\r\n|" }, StringSplitOptions.RemoveEmptyEntries);
            bool searchMatch = books.Any(word => bookName.Trim().Equals(word.Trim()));
            return searchMatch;
            //if (bookName.Contains("") || bookName.Contains("בראשית") || bookName.Contains("שמות") || bookName.Contains("ויקרא") || bookName.Contains("במדבר") || bookName.Contains("דברים") || bookName.Contains("יהושע") || bookName.Contains("שופטים") || bookName.Contains("שמואל א") || bookName.Contains("שמואל ב") || bookName.Contains("מלכים א") || bookName.Contains("מלכים ב") || bookName.Contains("ישעיה") || bookName.Contains("ירמיה") || bookName.Contains("יחזקאל") || bookName.Contains("הושע") || bookName.Contains("יואל") || bookName.Contains("עמוס") || bookName.Contains("עובדיה") || bookName.Contains("יונה") || bookName.Contains("מיכה") || bookName.Contains("נחום") || bookName.Contains("חבקוק") || bookName.Contains("צפניה") || bookName.Contains("חגי") || bookName.Contains("זכריה") || bookName.Contains("מלאכי") || bookName.Contains("תהילים") || bookName.Contains("משלי") || bookName.Contains("איוב") || bookName.Contains("שיר השירים") || bookName.Contains("רות") || bookName.Contains("איכה") || bookName.Contains("קהלת") || bookName.Contains("אסתר") || bookName.Contains("דניאל") || bookName.Contains("עזרא") || bookName.Contains("נחמיה") || bookName.Contains("דברי הימים א") || bookName.Contains("דברי הימים ב")
            //            if (bookName.Contains("בראשית - עם ניקוד")
            //                || bookName.Contains("תרגום")
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
            //)
            //{ return true; }
            //else { return false; }
        }

        private bool searchTermMatched(String searchTerm, string headerText)
        {
            headerText = Regex.Replace(headerText, "[^א-ת\"']", " ");
            string[] searchTermParts = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] headerTextParts = headerText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int hitScore = 0;

            foreach (String part in searchTermParts)
            {
                bool searchTermExists = headerTextParts.Any(item => string.Equals(item, part, StringComparison.OrdinalIgnoreCase));
                if (searchTermExists) { hitScore++; }
            }

            if (hitScore == searchTermParts.Count()) { return true; }
            else { return false; }
        }
    }
}
//        public void navigateExact(string searchTerm)
//        {
//            try
//            {
//                isTanachBook = isTanach(taskPaneUserControl.currentFileName.Trim());
//                searchTerm = searchTerm.Replace("-", " ");
//                IHTMLDocument2 doc = (IHTMLDocument2)taskPaneUserControl.fileViewer.Document.DomDocument;

//                if (!isTanachBook)
//                {
//                    bool isDafHeader = false;
//                    if (searchTerm.Contains("דף")) { isDafHeader = true; }
//                    if (!isDafHeader) isDafHeader = dafCheck(doc, searchTerm, "h3");
//                    if (!isDafHeader) isDafHeader = dafCheck(doc, searchTerm, "h2");
//                    if (isDafHeader)
//                    {
//                        searchTerm = searchTerm.Replace(",", " ");
//                        searchTerm = searchTerm.Replace(":", " ב");
//                        searchTerm = searchTerm.Replace(".", " א");
//                        taskPaneUserControl.fileViewerHeaders.searchHeaders(searchTerm, "h3");
//                        if (taskPaneUserControl.fileViewerHeaders.headerFound == false)
//                        { taskPaneUserControl.fileViewerHeaders.searchHeaders(searchTerm, "h2"); }
//                    }
//                    else
//                    {
//                        NavigateHeaders(searchTerm);
//                    }
//                }
//                else
//                {
//                    NavigateHeaders(searchTerm);
//                }
//            }
//            catch(Exception ex) { MessageBox.Show(ex.Message); }
//        }

//        private bool dafCheck(IHTMLDocument2 doc, string searchTerm, string searchMethod)
//        {
//            IHTMLElementCollection elements = doc.all.tags(searchMethod);
//            bool containsWord = elements.Cast<IHTMLElement>()
//            .Any(element => element.innerText.Contains("דף"));
//            return containsWord;
//        }

//        public void NavigateHeaders(string searchText)
//        {
//            string[] parts = searchText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//            if (parts.Length > 1)
//            {
//                search2Parts(parts[0].Trim(), parts[1].Trim());
//            }
//            else { search1part(searchText.Trim()); }
//        }

//        private void search1part(string searchTerm)
//        {
//            searchTerm = searchTerm.Replace(",", "");
//            taskPaneUserControl.fileViewerHeaders.searchHeaders(searchTerm, "h3");
//            if (taskPaneUserControl.fileViewerHeaders.headerFound == false)
//            { taskPaneUserControl.fileViewerHeaders.searchHeaders(searchTerm, "h2"); }
//        }

//        private void search2Parts(string part1, string part2)
//        {
//            taskPaneUserControl.fileViewerHeaders.searchHeaders(part1, "h2");
//            if (taskPaneUserControl.fileViewerHeaders.headerFound == true)
//            { taskPaneUserControl.fileViewerHeaders.searchHeaders(part2, "h3"); }
//            else
//            {
//                taskPaneUserControl.fileViewerHeaders.searchHeaders(part1, "h3");
//                if (taskPaneUserControl.fileViewerHeaders.headerFound == true)
//                { PasukSearch(part2); }
//            }
//        }

//        private void PasukSearch(string searchText)
//        {
//            //searchnext
//        }
//        private void Tanach2PartSearch()
//        { 

//            else { taskPaneUserControl.fileViewerHeaders.searchHeaders(part2, "h3"); }


//            if (taskPaneUserControl.fileViewerHeaders.headerFound == false)
//            {
//                taskPaneUserControl.fileViewerHeaders.searchHeaders(part1, "h2");
//                if (taskPaneUserControl.fileViewerHeaders.headerFound == false)
//                { taskPaneUserControl.fileViewerHeaders.searchHeaders(part1, "h3"); }
//            }

//                // Assuming you have a WebBrowser control named 'webBrowser' on your form
//                IHTMLDocument2 doc = (IHTMLDocument2)taskPaneUserControl.fileViewer.Document.DomDocument;
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
//            if (parentDiv == null && isTanach(taskPaneUserControl.fileViewer.Name) && parts.Length > 1)
//            {
//                string searchPasuk = "";
//                searchPasuk = parts[1].Trim();
//                if (searchPasuk.Contains("פסוק") || !searchPasuk.Contains("}")) { searchPasuk = "{" + searchPasuk.Replace("פסוק", "").Trim() + "}"; }
//                textRange.collapse(false); // collapse the current selection so we start from the end of the previous range

//                if (textRange.findText(searchPasuk, 1000000000, 0))
//                {
//                    textRange.scrollIntoView();
//                    textRange.select();
//                }
//            }
//            if (textRange.text != doc.body.outerText)
//            {
//                if (parentDiv != null && textRange.text == parentDiv.outerText) { textRange.moveToElementText(foundElement); }
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

//        public bool isTanach(string bookName)
//        {
//            if (bookName.Contains("בראשית - עם ניקוד")
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
//    }
//}
