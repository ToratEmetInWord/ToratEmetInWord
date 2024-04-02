using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public class FileViewerHistory
    {
        public UserControl1 taskPaneUserControl;

        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public void PopulateVisitedFilesList()
        {
            ToolStripMenuItem visitedFilesMenuItem = new ToolStripMenuItem("סגור הכל");
            visitedFilesMenuItem.Click += VisitedFilesMenuItem_Click;
            ToolStripSeparator toolStripSeparator = new ToolStripSeparator();

            taskPaneUserControl.VisitedBooksDropDown.DropDownItems.Add(visitedFilesMenuItem);
            taskPaneUserControl.VisitedBooksDropDown.DropDownItems.Add(toolStripSeparator);
        }

        public void UpdateVisitedFilesList(string bookName)
        {
            ToolStripMenuItem visitedFilesMenuItem = new ToolStripMenuItem(bookName);
            visitedFilesMenuItem.Click += VisitedFilesMenuItem_Click;
            taskPaneUserControl.VisitedBooksDropDown.DropDownItems.Add(visitedFilesMenuItem);
        }

        public void VisitedFilesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int clickedIndex = taskPaneUserControl.VisitedBooksDropDown.DropDownItems.IndexOf(clickedItem);
            string itemName = taskPaneUserControl.VisitedBooksDropDown.DropDownItems[clickedIndex].Text;

            if (itemName == "סגור הכל") { closeAllBooks(); }
            else { taskPaneUserControl.openSelectedFile(itemName); }
        }

        public void populateHistoryList()
        {
            try
            {
                taskPaneUserControl.historyListButton.DropDownItems.Clear();

                string historyList = Properties.Settings.Default.historyList;
                if (!string.IsNullOrEmpty(historyList))
                {
                    string[] historyItems = historyList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string itemText in historyItems)
                    {
                        if (itemText != "סגור הכל")
                        {
                            ToolStripMenuItem urlMenuItem = new ToolStripMenuItem(itemText);
                            taskPaneUserControl.historyListButton.DropDownItems.Add(urlMenuItem);
                            urlMenuItem.Click += HistoryMenuItem_Click;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void updateHistoryList(string currentUrl)
        {
            string historyList = Properties.Settings.Default.historyList;
            List<string> historyItems = new List<string>(historyList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            bool urlExists = historyItems.Any(item => string.Equals(item, currentUrl, StringComparison.OrdinalIgnoreCase));

            if (urlExists) { historyItems.Remove(currentUrl); }

            historyItems.Add(currentUrl);

            if (historyItems.Count > 15) { historyItems.RemoveAt(0); }

            historyList = string.Join(",", historyItems);

            Properties.Settings.Default.historyList = historyList;
            Properties.Settings.Default.Save();
            populateHistoryList();
        }


        public void HistoryMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int clickedIndex = taskPaneUserControl.historyListButton.DropDownItems.IndexOf(clickedItem);
            string itemName = taskPaneUserControl.historyListButton.DropDownItems[clickedIndex].Text;
            taskPaneUserControl.openSelectedFile(itemName);
        }

        private void closeAllBooks()
        {
            try
            {
                taskPaneUserControl.VisitedBooksDropDown.DropDownItems.Clear();
                PopulateVisitedFilesList();

                foreach (TabPage tabPage in taskPaneUserControl.tabControl1.TabPages)
                {
                    tabPage.Dispose();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}


//public void updateHistoryList(string currentUrl)
//{
//    string[] existingItems = taskPaneUserControl.historyListButton.DropDownItems
//                .OfType<ToolStripMenuItem>()
//                .Select(item => item.Text)
//                .ToArray();

//    bool urlExists = existingItems.Any(item => string.Equals(item, currentUrl, StringComparison.OrdinalIgnoreCase));

//    if (!urlExists)
//    {
//        ToolStripMenuItem urlMenuItem = new ToolStripMenuItem(currentUrl);
//        urlMenuItem.Click += HistoryMenuItem_Click;
//        taskPaneUserControl.historyListButton.DropDownItems.Add(urlMenuItem);

//        // Remove the oldest item if the number of items exceeds the limit
//        if (taskPaneUserControl.historyListButton.DropDownItems.Count > 20)
//        {
//            //string oldestItem = taskPaneUserControl.historyListButton.DropDownItems[2].Text;
//            taskPaneUserControl.historyListButton.DropDownItems.RemoveAt(0);

//            //foreach (TabPage tabPage in taskPaneUserControl.tabControl1.TabPages)
//            //{
//            //    if (tabPage.Name.Trim() == oldestItem.Trim())
//            //    {
//            //        tabPage.Dispose();
//            //    }
//            //}
//        }
//    }

//// Assuming you want to join the text of each item in toolStripDropDownButton1.DropDownItems
//string historyList = string.Join(",", taskPaneUserControl.historyListButton.DropDownItems
//            .OfType<ToolStripMenuItem>() // Assuming the items are ToolStripMenuItem
//            .Select(item => item.Text));

//Properties.Settings.Default.historyList = historyList;
//Properties.Settings.Default.Save();

//        }
