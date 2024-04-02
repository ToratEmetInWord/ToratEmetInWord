using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Web;
using System.Drawing;

namespace ToratEmetInWord_2._0
{
    public class FileViewerHeaders
    {
        public UserControl1 taskPaneUserControl;
        public bool headerFound = false;
        public Dictionary<string, string> headerMenuStructureDictionary = new Dictionary<string, string>();
        // Create a list of HeaderItems
        List<HeaderItem> headerItems = new List<HeaderItem>();


        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public void populateHeadersMenu(string filename)
        {
            taskPaneUserControl.comboBox1.DataSource = null;
            taskPaneUserControl.comboBox1.Items.Clear();
            //taskPaneUserControl.comboBox1.Items.Add("כותרות");
            //taskPaneUserControl.comboBox1.Text = taskPaneUserControl.comboBox1.Items[0].ToString();

            headerItems.Clear();
            HeaderItem Item = new HeaderItem("כותרות:", false);
            headerItems.Add(Item);

            string inputString = "";
            taskPaneUserControl.headersButton.DropDownItems.Clear();

            headerMenuStructureDictionary.TryGetValue(filename.Trim(), out inputString);

            if (!string.IsNullOrEmpty(inputString))
            {
                if (inputString.Contains("^") && inputString.Contains("|"))
                {
                    string[] parts = inputString.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string part in parts)
                    {
                        string[] items = part.Split('|');
                        if (items.Length > 0)
                        {
                            //taskPaneUserControl.comboBox1.Items.Add(items[0]);
                            HeaderItem headerItem = new HeaderItem(items[0], true);
                            headerItems.Add(headerItem);

                            for (int i = 1; i < items.Length - 1; i++)
                            {
                                //ListItem childMenuItem = new ListItem();
                                //taskPaneUserControl.comboBox1.Items.Add("◦ " + items[i]);
                                HeaderItem subheaderItem = new HeaderItem(items[i], false);
                                headerItems.Add(subheaderItem);
                            }
                        }
                    }

                }
                else
                {
                    string[] items = null;
                    if (inputString.Contains("^")) { items = inputString.Split('^'); }
                    else if (inputString.Contains("|")) { items = inputString.Split('|'); }
                    if (items != null && items.Length > 0)
                    {
                        foreach (string item in items)
                        {
                            //taskPaneUserControl.comboBox1.Items.Add(item);
                            HeaderItem subheaderItem = new HeaderItem(item, false);
                            headerItems.Add(subheaderItem);
                        }
                    }
                }

            }

            InitializeDropdown();
            SetComboBoxWidth();
        }

        private void InitializeDropdown()
        {
            taskPaneUserControl.comboBox1.SelectionChangeCommitted += ToolStripComboBox1_SelectedIndexCommitted;

            // Bind the ComboBox to the list of HeaderItems
            taskPaneUserControl.comboBox1.DataSource = headerItems;

            // Set the ComboBox to display the 'Name' property of HeaderItem
            taskPaneUserControl.comboBox1.DisplayMember = "Name";

            // Handle the DrawItem event to customize the appearance
            taskPaneUserControl.comboBox1.DrawItem += ComboBox1_DrawItem;

            // Ensure the ComboBox draws itself
            taskPaneUserControl.comboBox1.DrawMode = DrawMode.OwnerDrawFixed;          
        }

        private void SetComboBoxWidth()
        {
            // Find the maximum width among the items
            int maxWidth = 0;
            foreach (var item in taskPaneUserControl.comboBox1.Items)
            {
                int itemWidth = TextRenderer.MeasureText(item.ToString(), taskPaneUserControl.comboBox1.Font).Width;
                maxWidth = Math.Max(maxWidth, itemWidth);
            }

            // Add extra width for dropdown button and padding
            maxWidth += SystemInformation.VerticalScrollBarWidth + 10;
            if (maxWidth > 450) { maxWidth = 450; }
            // Set the width of the ComboBox
            taskPaneUserControl.comboBox1.DropDownWidth = maxWidth;
        }

        private void ToolStripComboBox1_SelectedIndexCommitted(object sender, EventArgs e)
        {
            if (taskPaneUserControl.comboBox1.SelectedIndex != 0 && taskPaneUserControl.comboBox1.SelectedItem != null)
            {
                int selectedindex = taskPaneUserControl.comboBox1.SelectedIndex;
                string selectedText = taskPaneUserControl.comboBox1.SelectedItem.ToString();
                SearchHeadersById(selectedindex.ToString());
                if (headerFound == false) { searchHeaders(selectedText.Replace("◦", "").Trim(), "h2"); }
                if (headerFound == false) { searchHeaders(selectedText.Replace("◦", "").Trim(), "h3"); }
                taskPaneUserControl.comboBox1.Text = taskPaneUserControl.comboBox1.Items[0].ToString();
            }
        }

        public void searchHeaders(string searchText, string SearchForm)
        {
            headerFound = false;
            searchText = Regex.Replace(searchText, " {2,}", " ");

            IHTMLDocument2 doc = (IHTMLDocument2)taskPaneUserControl.fileViewer.Document.DomDocument;
            IHTMLElementCollection elements = doc.all.tags(SearchForm);

            foreach (IHTMLElement element in elements)
            {
                if (element.outerText.Trim() == searchText.Trim())
                {
                    element.scrollIntoView();
                    headerFound = true;
                    break;
                }
            }
        }

        public void SearchHeadersById(string elementId)
        {
            headerFound = false;

            IHTMLDocument3 doc = (IHTMLDocument3)taskPaneUserControl.fileViewer.Document.DomDocument;
            IHTMLElement element = doc.getElementById(elementId);

            if (element != null)
            {
                element.scrollIntoView();
                headerFound = true;
            }
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                HeaderItem item = (HeaderItem)taskPaneUserControl.comboBox1.Items[e.Index];
                Brush backgroundBrush = (item.IsHeader) ? Brushes.LightGray : Brushes.White;

                // Check if the item is selected or the mouse is over it
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected ||
                    (e.State & DrawItemState.HotLight) == DrawItemState.HotLight)
                {
                    backgroundBrush = SystemBrushes.Highlight; // Use the system's selected background color
                }

                // Draw the background
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

                // Draw the item text with right-to-left support
                Brush textBrush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected ||
                                   (e.State & DrawItemState.HotLight) == DrawItemState.HotLight)
                    ? SystemBrushes.HighlightText
                    : Brushes.Black; // Use the system's text color for selected/hovered items

                // Use StringFormat with right-to-left direction
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near; // Align text to the left
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                e.Graphics.DrawString(item.Name, e.Font, textBrush, e.Bounds, stringFormat);

                // Draw the focus rectangle if the item has focus
                e.DrawFocusRectangle();
            }
        }


    }

    public class HeaderItem
    {
        public string Name { get; set; }
        public bool IsHeader { get; set; }

        public HeaderItem(string name, bool isHeader)
        {
            Name = name;
            IsHeader = isHeader;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}



//private void MenuItem_Click(object sender, EventArgs e)
//{
//    ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
//    {
//        SearchHeadersById(menuItem.AccessibleName);
//        if (headerFound == false) { searchHeaders(menuItem.Text, "h2"); }
//        if (headerFound == false) { searchHeaders(menuItem.Text, "h3"); }
//    }
//}

//private void ChildMenuItem_Click(object sender, EventArgs e)
//{
//    ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
//    if (menuItem != null)
//    {
//        SearchHeadersById(menuItem.AccessibleName);
//        if (headerFound == false) { searchHeaders(menuItem.Text, "h3"); } 
//        if (headerFound == false) { searchHeaders(menuItem.Text, "h2"); }
//    }
//}