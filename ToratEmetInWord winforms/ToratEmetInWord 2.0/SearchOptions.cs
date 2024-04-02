using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public partial class SearchOptions : Form
    {
        private UserControl1 taskPaneUserControl;
        private SimpleSearchForm searchForm;
        public SearchOptions()
        {
            InitializeComponent();
            CheckInstallationFolder();
            this.FormClosing += SearchOptions_FormClosing;
            treeView1.AfterCheck += TreeView1_AfterCheck;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            textBox1.KeyDown += textBox1_KeyDown;
        }

        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public void SetSearchForm(SimpleSearchForm form)
        {
            searchForm = form;
        }

        private void SearchOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Prevent the form from being disposed
            searchForm.panel2.Visible = true;
            this.Hide();      // Hide the form instead of closing it
            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.SearchOptions_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void SearchOptions_Load(object sender, EventArgs e)
        {
            // Create a new root node for  (Books)
            TreeNode booksRootNode = new TreeNode("ספרי תורת אמת");

            // Associate the file icon from the ImageList with the node
            booksRootNode.ImageIndex = 0; // The index of the file icon in the ImageList
            booksRootNode.SelectedImageIndex = 0; // The index of the file icon to be displayed when the node is selected

            // Set the root directory to be displayed in the TrefeView
            string basePath = Properties.Settings.Default.toratEmetInstallFolder;
            string rootPath = Path.Combine(basePath, "ToratEmetInstall", "Books");

            if (System.IO.Directory.Exists(rootPath))
            {
                PopulateTreeView(rootPath, booksRootNode.Nodes, false); // Use 'true' to indicate the special case
            }

            // Add the "הספרים שלי" node to the existing TreeView nodes collection
            treeView1.Nodes.Add(booksRootNode);

            // Create a new root node for "הספרים שלי" (My Books)
            TreeNode myBooksRootNode = new TreeNode("הספרים שלי");

            // Associate the file icon from the ImageList with the node
            myBooksRootNode.ImageIndex = 0; // The index of the file icon in the ImageList
            myBooksRootNode.SelectedImageIndex = 0; // The index of the file icon to be displayed when the node is selected

            // Set the root directory to be displayed in the TrefeView
            rootPath = Path.Combine(basePath, "ToratEmetUserData", "MyBooks");
            
            if (System.IO.Directory.Exists(rootPath))
            {
                // Populate the TreeView starting from the new root node
                PopulateTreeView(rootPath, myBooksRootNode.Nodes, true); // Use 'true' to indicate the special case
            }

            // Add the "הספרים שלי" node to the existing TreeView nodes collection
            treeView1.Nodes.Add(myBooksRootNode);

            //tabControl1.SelectedTab = tabPage1;
            LoadPreviousSettings_checkListBox1();
            LoadPreviousSettings_treeView1();

            // Load the previously selected tab index from settings
            int savedTabIndex = Properties.Settings.Default.SearchOptions_OpenTab;
            if (savedTabIndex >= 0 && savedTabIndex < tabControl1.TabCount)
            {
                tabControl1.SelectedIndex = savedTabIndex;
            }
        }

        private void LoadPreviousSettings_treeView1()
        {
            // Load the comma-separated string from settings
            string treeViewCheckedString = Properties.Settings.Default.treeViewChecked;

            if (!string.IsNullOrEmpty(treeViewCheckedString))
            {
                // Split the string into an array of item names
                string[] checkedItems = treeViewCheckedString.Split(',');

                // Iterate through the TreeView nodes and check the ones that match the loaded items
                CheckNodesByNames(treeView1.Nodes, checkedItems);
            }
        }

        // Recursively check TreeView nodes by name
        private void CheckNodesByNames(TreeNodeCollection nodes, string[] checkedItems)
        {
            foreach (TreeNode node in nodes)
            {
                // Check if the node's text is in the loaded array of checked items
                if (checkedItems.Contains(node.Text))
                {
                    node.Checked = true;
                }

                // Recursively check child nodes
                CheckNodesByNames(node.Nodes, checkedItems);
            }
        }

        private void LoadPreviousSettings_checkListBox1()
        {
            // Load the saved searchTerm from settings if it exists
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SearchListBoxTerm))
            { 
            textBox1.Text = Properties.Settings.Default.SearchListBoxTerm;
            }

                // Load the saved SearchList from settings if it exists
                if (!string.IsNullOrEmpty(Properties.Settings.Default.SearchListBox))
            {
                string savedSearchListString = Properties.Settings.Default.SearchListBox;
                string[] savedItems = savedSearchListString.Split(',');

                foreach (string item in savedItems)
                {
                    checkedListBox1.Items.Add(item);
                }
            }

            // Load the saved CheckedSearchList from settings if it exists
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SearchListBoxChecked))
            {
                string savedSearchListString = Properties.Settings.Default.SearchListBoxChecked;
                string[] savedItems = savedSearchListString.Split(',');

                foreach (string item in savedItems)
                {
                    int index = checkedListBox1.Items.IndexOf(item);
                    if (index >= 0)
                    {
                        checkedListBox1.SetItemChecked(index, true);
                    }
                }
            }
        }


        private void PopulateTreeView(string path, TreeNodeCollection parentNodeCollection, bool isMyBooksSubdirectory)
        {

            try
            {
                // Get the directories within the specified path
                string[] directories = Directory.GetDirectories(path);

                // Add directories as child nodes
                foreach (string directory in directories)
                {
                    // Create a new TreeNode for the current directory
                    string translatedFolderName = TranslatorClass.TranslateFolderName(Path.GetFileName(directory));

                    if (translatedFolderName != "עזרים שונים" && translatedFolderName != "הספרים שלי")
                    {
                        TreeNode node = new TreeNode(translatedFolderName);

                        // Add the node to the parent node collection
                        parentNodeCollection.Add(node);

                        // Associate the file icon from the ImageList with the node
                        node.ImageIndex = 0; // The index of the file icon in the ImageList
                        node.SelectedImageIndex = 0; // The index of the file icon to be displayed when the node is selected

                        // Recursively populate the child nodes for the current directory
                        if (isMyBooksSubdirectory == false) { PopulateTreeView(directory, node.Nodes, false); }
                        else { PopulateTreeView(directory, node.Nodes, true); }
                    }
                }

                // For populating the main directories
                if (isMyBooksSubdirectory == false)
                {
                    // Get the files within the specified path
                    string[] files = Directory.GetFiles(path);

                    // Add files as child nodes
                    foreach (string file in files)
                    {
                        string stringFilename = Path.GetFullPath(file);
                        if (!stringFilename.Contains("Interleave"))
                        {
                            if (stringFilename.Contains("ToratEmetInstall"))
                            {
                                int index = stringFilename.IndexOf("Books");
                                stringFilename = stringFilename.Substring(index);
                                stringFilename = TranslatorClass.TranslateFilename(stringFilename);
                            }

                            TreeNode node = new TreeNode(stringFilename);
                            parentNodeCollection.Add(node);
                        }
                    }
                }
                else
                {
                    // Get the files within the specified path
                    string[] files = Directory.GetFiles(path, "*.txt"); // Get only .txt files

                    // Add files as child nodes
                    foreach (string file in files)
                    {
                        // Extract the filename without path
                        string fileName = Path.GetFileNameWithoutExtension(file);

                        TreeNode node = new TreeNode(fileName);
                        parentNodeCollection.Add(node);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle any UnauthorizedAccessException that may occur when accessing certain folders or files.
                // You can decide how you want to handle this exception (e.g., skip the folder or file, display an error message, etc.).
            }

        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                // Handle the current node's descendants
                CheckAllChildNodes(e.Node, e.Node.Checked);

                // Handle the current node's ancestors
                UpdateAncestorNodes(e.Node.Parent);
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool isChecked)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
            {
                childNode.Checked = isChecked;
                if (childNode.Nodes.Count > 0)
                {
                    CheckAllChildNodes(childNode, isChecked);
                }
            }
        }

        private void UpdateAncestorNodes(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                bool allChildNodesUnchecked = true;

                foreach (TreeNode childNode in treeNode.Nodes)
                {
                    if (childNode.Checked)
                    {
                        allChildNodesUnchecked = false;
                        break;
                    }
                }

                treeNode.Checked = !allChildNodesUnchecked;

                UpdateAncestorNodes(treeNode.Parent);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if TabPage 3 is activated
            if (tabControl1.SelectedTab == tabPage3)
            {
                // Set focus to textbox1 on TabPage 3
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchForBook();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchForBook();

                //// Set the focus to the first item
                //if (checkedListBox1.Items.Count > 0)
                //{
                //    checkedListBox1.SelectedIndex = 0;
                //    checkedListBox1.Focus();
                //}

                // Make sure to set e.Handled to true to prevent the control from processing the Enter key further
                e.Handled = true;
            }

        }

        private void searchForBook()
        {
            string searchText = textBox1.Text.Trim();
            string modifiedSearchWords = "";

            checkedListBox1.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                SearchNodes(treeView1.Nodes, searchText);
                if (searchText.Contains("\""))
                {
                    modifiedSearchWords = searchText.Replace("\"", "_"); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("\"", "''"); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("_"))
                {
                    modifiedSearchWords = searchText.Replace("_", "\""); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("_", "''"); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("''"))
                {
                    modifiedSearchWords = searchText.Replace("''", "\""); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("''", "_"); SearchNodes(treeView1.Nodes, modifiedSearchWords);
                }
            }
        }

        private void SearchNodes(TreeNodeCollection nodes, string searchText)
        {
            // Split the search text into individual words
            string[] searchWords = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (TreeNode node in nodes)
            {
                // Check if the node's image index is not 0
                if (node.ImageIndex != 0)
                {
                    // Check if the node's text contains all the search words
                    bool containsAllWords = searchWords.All(word => node.Text.Contains(word));

                    if (containsAllWords)
                    {
                        checkedListBox1.Items.Add(node.Text);
                    }
                }

                if (node.Nodes.Count > 0)
                {
                    SearchNodes(node.Nodes, searchText);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex) == false)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
            else
            {
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchForm.panel2.Visible = true;
            this.Hide();
            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.SearchOptions_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();
            LoadPreviousSettings_checkListBox1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox2.Checked;
            UpdateAllNodes(treeView1.Nodes, isChecked);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateAllNodes(treeView1.Nodes, false);
            checkBox2.Checked = false;
        }

        private void UpdateAllNodes(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = isChecked;

                if (node.Nodes.Count > 0)
                {
                    UpdateAllNodes(node.Nodes, isChecked);
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            searchForm.panel2.Visible = true;
            this.Hide();
            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.SearchOptions_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();           
            LoadPreviousSettings_treeView1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Save the checked items to the CheckedSearchList setting
            string[] checkedSearchList = checkedListBox1.CheckedItems.Cast<string>().ToArray();
            string searchListString = string.Join(",", checkedSearchList);
            Properties.Settings.Default.SearchListBoxChecked = searchListString;
            Properties.Settings.Default.searchBookList = searchListString;

            // Save List items to the SearchList setting
            string[] searchList = checkedListBox1.Items.Cast<string>().ToArray();
            searchListString = string.Join(",", searchList);
            Properties.Settings.Default.SearchListBox = searchListString;

            // Save searchTerm to the SearchList setting
            Properties.Settings.Default.SearchListBoxTerm = textBox1.Text;
            
            //Save settings
            Properties.Settings.Default.Save();
            searchForm.searchAllCheckBox.Checked = false;
            searchForm.panel2.Visible = true;
            this.Hide();

            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.SearchOptions_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            List<string> checkedTreeviewList = new List<string>();

            GetAllCheckedChildNodes(treeView1.Nodes, checkedTreeviewList);
            string[] checkedTreeviewArray = checkedTreeviewList.ToArray();// Convert the list to an array
            string treeViewString = string.Join(",", checkedTreeviewArray); // Convert the array to a comma-separated string
            Properties.Settings.Default.searchBookList = treeViewString;// Save the comma-separated string to settings

            GetAllCheckedNodes(treeView1.Nodes, checkedTreeviewList);
            checkedTreeviewArray = checkedTreeviewList.ToArray();
            treeViewString = string.Join(",", checkedTreeviewArray);
            Properties.Settings.Default.treeViewChecked = treeViewString;

            Properties.Settings.Default.Save();

            searchForm.searchAllCheckBox.Checked = false;
            searchForm.panel2.Visible = true;
            this.Hide();

            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.SearchOptions_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();
            
        }

        // Recursively get all checked nodes and add their text to the list
        private void GetAllCheckedChildNodes(TreeNodeCollection nodes, List<string> checkedItems)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.ImageIndex != 0)
                {
                    checkedItems.Add(node.Text);
                }

                // Recursively process child nodes
                GetAllCheckedChildNodes(node.Nodes, checkedItems);
            }
        }

        private void GetAllCheckedNodes(TreeNodeCollection nodes, List<string> checkedItems)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    checkedItems.Add(node.Text);
                }

                // Recursively process child nodes
                GetAllCheckedNodes(node.Nodes, checkedItems);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            searchForm.panel2.Visible = true;
            this.Dispose();           
        }

        private void CheckInstallationFolder()
        {
            try { 
            if (!System.IO.Directory.Exists(Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInstall")))
            {
                //set ToratEmet install folder
                string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folderToCheck = Path.Combine(documentsFolder, "ToratEmetInstall");
                if (System.IO.Directory.Exists(folderToCheck))
                {
                    Properties.Settings.Default.toratEmetInstallFolder = documentsFolder;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("תיקיית ההתקנה של תורת אמת לא זוהתה! אנא הזן את מיקום התיקייה באופן ידני.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    var folderPicker = new FolderPicker();

                    if (folderPicker.ShowDialog(IntPtr.Zero) == true)
                    {
                        string resultFolder = folderPicker.ResultPath;
                        if (resultFolder.Contains("ToratEmetInstall")) { resultFolder = Path.GetDirectoryName(resultFolder); }
                        Properties.Settings.Default.toratEmetInstallFolder = resultFolder;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
