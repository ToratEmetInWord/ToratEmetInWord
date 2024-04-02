using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace ToratEmetInWord_2._0
{
    public partial class OpenFileForm : UserControl
    {
       string wordsInsideParenthesis;
       public UserControl1 taskPaneUserControl;

            public void SetTaskPaneUserControl(UserControl1 userControl)
            {
                taskPaneUserControl = userControl;
            }

        public OpenFileForm()
        {
            CheckInstallationFolder();
            InitializeComponent();
            try
            { 
            PopulateTreeView();
            loadPreviousTab();
            }
            catch (Exception ex) { MessageBox.Show("שגיאה בטעינה\r\n" + ex.Message); }

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            this.VisibleChanged += OpenFileForm_VisibleChanged;

            treeView1.AfterSelect += openFiletreeView1_AfterSelect;
            treeView2.AfterSelect += openFiletreeView2_AfterSelect;
            listBox1.KeyDown += openFileListBox1_KeyDown;
            listBox1.MouseClick += openFileListBox1_MouseClick;
        }

        private void OpenFileForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true && tabControl1.SelectedTab == tabPage3) { this.Focus(); textBox1.Focus(); }
        }

        private void loadPreviousTab()
        {
            // Load the previously selected tab index from settings
            int savedTabIndex = Properties.Settings.Default.Tabcontrol1_OpenTab;
            if (savedTabIndex >= 0 && savedTabIndex < tabControl1.TabCount)
            {
                tabControl1.SelectedIndex = savedTabIndex;
            }
            // Check if TabPage 3 is activated // Set focus to textbox1 on TabPage 3
            if (tabControl1.SelectedTab == tabPage3) { this.Focus();  textBox1.Focus(); textBox1.SelectAll(); }

            //load previous items for tabpage 3
            textBox1.Text = Properties.Settings.Default.lastSearchedBookName;
            StringCollection savedItems = Properties.Settings.Default.BookNameListBoxItems;
            if (savedItems != null)
            {
                foreach (string item in savedItems)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void PopulateTreeView()
        {          
            // Set the root directory for main books folder
            string basePath = Properties.Settings.Default.toratEmetInstallFolder;
            string rootPath = Path.Combine(basePath, "ToratEmetInstall", "Books");

            // Populate TreeView1
            if (System.IO.Directory.Exists(rootPath))
            {
                PopulateTreeViewPart2(rootPath, treeView1.Nodes, false);
            }
            else
            {
                CheckInstallationFolder();
                PopulateTreeViewPart2(rootPath, treeView1.Nodes, false);
            }

            // Set the root directory for mybooks
            rootPath = Path.Combine(basePath, "ToratEmetUserData", "MyBooks");
            if (System.IO.Directory.Exists(rootPath))
            {
                // Populate the TreeView2
                PopulateTreeViewPart2(rootPath, treeView2.Nodes, true); // Use 'true' to indicate the special case
            }
            else
            {
                TreeNode node = new TreeNode("לא הצלחנו לטעון שום ספרים");
                treeView2.Nodes.Add(node);
            }
        }


        private void CheckInstallationFolder()
        {
            try
            {
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
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void PopulateTreeViewPart2(string path, TreeNodeCollection parentNodeCollection, bool isMyBooksSubdirectory)
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
                        if (isMyBooksSubdirectory == false) { PopulateTreeViewPart2(directory, node.Nodes, false); }
                        else { PopulateTreeViewPart2(directory, node.Nodes, true); }
                    }
                }

                // For populating the main directories
                if (isMyBooksSubdirectory == false)
                {
                    // Get the files within the specified path
                    string[] files = Directory.GetFiles(path, "*.txt"); // Get only .txt files

                    // Add files as child nodes
                    foreach (string file in files)
                    {
                        string stringFilename = Path.GetFullPath(file);
                        if (!stringFilename.Contains("Interleave") && !stringFilename.Contains("merged"))
                        {

                            int index = stringFilename.IndexOf("ToratEmetInstall");

                            if (index != -1)
                            {
                                index = stringFilename.IndexOf("Books");
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
                    string[] files = Directory.GetFiles(path);

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

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save the selected tab index to settings when it changes
            Properties.Settings.Default.Tabcontrol1_OpenTab = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();

            // Check if TabPage 3 is activated // Set focus to textbox1 on TabPage 3
            if (tabControl1.SelectedTab == tabPage3) { textBox1.Focus(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchForBook();
                saveSettings();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.Focus();
                if (listBox1.SelectedIndex == -1)
                { listBox1.SelectedIndex = 0; }
                else if (listBox1.SelectedIndex > 0)
                { listBox1.SelectedIndex = listBox1.SelectedIndex - 1; }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                if (listBox1.SelectedIndex == -1)
                { listBox1.SelectedIndex = 0; }
                else if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                { listBox1.SelectedIndex = listBox1.SelectedIndex + 1; }
                e.SuppressKeyPress = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchForBook();
            saveSettings();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.lastSearchedBookName = textBox1.Text;

            // Save ListBox items to application settings
            StringCollection savedItems = new StringCollection();
            foreach (string item in listBox1.Items)
            {
                savedItems.Add(item);
            }

            Properties.Settings.Default.BookNameListBoxItems = savedItems;
            Properties.Settings.Default.Save();
        }

        public void searchForBook()
        {
            string searchText = textBox1.Text;

            Match match = Regex.Match(searchText, @"^(.*?)\((.*?)\)");
            if (match.Success)
            {
                searchText = match.Groups[1].Value;
                wordsInsideParenthesis = match.Groups[2].Value;
            }
            else
            {
                wordsInsideParenthesis = "";
            }
       
            string modifiedSearchWords = "";
            listBox1.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                SearchNodes("treeView1", treeView1.Nodes, searchText);
                if (searchText.Contains("\""))
                {
                    modifiedSearchWords = searchText.Replace("\"", "_"); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("\"", "''"); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("_"))
                {
                    modifiedSearchWords = searchText.Replace("_", "\""); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("_", "''"); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("''"))
                {
                    modifiedSearchWords = searchText.Replace("''", "\""); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("''", "_"); SearchNodes("treeView1", treeView1.Nodes, modifiedSearchWords);
                }
                
                //search treeview2 (mybooks)
                SearchNodes("treeView2", treeView2.Nodes, searchText);
                if (searchText.Contains("\""))
                {
                    modifiedSearchWords = searchText.Replace("\"", "_"); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("\"", "''"); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("_"))
                {
                    modifiedSearchWords = searchText.Replace("_", "\""); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("_", "''"); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                }
                else if (searchText.Contains("''"))
                {
                    modifiedSearchWords = searchText.Replace("''", "\""); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                    modifiedSearchWords = searchText.Replace("''", "_"); SearchNodes("treeView2", treeView2.Nodes, modifiedSearchWords);
                }
            }

            // Set the focus to the first item
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Focus();
            }
        }

        private void SearchNodes(string treeName, TreeNodeCollection nodes, string searchText)
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
                        if (wordsInsideParenthesis != "")
                        {
                            if (treeName == "treeView1") {listBox1.Items.Add(node.Text + " (" + wordsInsideParenthesis + ") ");}
                            else  {listBox1.Items.Add(node.Text + " (" + wordsInsideParenthesis + ")");}
                        }         
                        else
                        {
                            if (treeName == "treeView1") { listBox1.Items.Add(node.Text + " ");}
                            else { listBox1.Items.Add(node.Text); };
                        }
                        
                    }
                }

                if (node.Nodes.Count > 0)
                {
                    SearchNodes(treeName, node.Nodes, searchText);
                }
            }
        }

            //
            //
            //
            //
            //

        private void openFileListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            openFileFromList();
        }

        private void openFileListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                openFileFromList();
                e.Handled = true;// Make sure to set e.Handled to true to prevent the control from processing the Enter key further
            }
        }

        private void openFileFromList()
        {
            if (!string.IsNullOrEmpty(listBox1.SelectedItem?.ToString()))
            {
                string selectedBook = listBox1.SelectedItem?.ToString();
                IsexactAdress(ref selectedBook);
                taskPaneUserControl.openSelectedFile(selectedBook);
                //this.Dispose();
               this.Visible = false;
            }
        }

        public void IsexactAdress(ref string filename)
        {
            string[] words;
            if (filename.Contains("("))
            {
                words = filename.Split('(');
                filename = words[0].Trim();
                taskPaneUserControl.exactAdress = words[1].Replace(")", "").Trim();

            }
            else
            {
                taskPaneUserControl.exactAdress = "";
            }
        }

        private void openFiletreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (treeView1.SelectedNode.ImageIndex != 0)
            {
                taskPaneUserControl.openSelectedFile(treeView1.SelectedNode.Text);
                taskPaneUserControl.bookCompiler.isToratEmetBook = true;
               this.Visible = false;
                //this.Dispose();
                //shouldDisposeForm = true; // Set the flag to true if the action is complete
            }
        }

        private void openFiletreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView2.SelectedNode.ImageIndex != 0)
            {
                taskPaneUserControl.openSelectedFile(treeView2.SelectedNode.Text);
               this.Visible = false;
                //this.Dispose();
                //shouldDisposeForm = true; // Set the flag to true if the action is complete
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
           this.Visible = false;
            //this.Dispose();
        }
    }
}
