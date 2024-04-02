using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using LuceneDirectory = Lucene.Net.Store.Directory;
using Lucene.Net.Store;
using Lucene.Net.Util;
using static Lucene.Net.Documents.Field;
using System.Text.RegularExpressions;
using System.Globalization;
using mshtml;
using ToratEmetInWord_2._0;
using Contrib.Regex;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net;
using Lucene.Net.Messages;
using Microsoft.Office.Interop.Word;
using System.Threading;
using static Lucene.Net.Index.SegmentReader;
using static System.Windows.Forms.LinkLabel;
using System.Runtime.InteropServices;



namespace ToratEmetInWord_2._0
{
    public partial class SearchForm : Form
    {
        public UserControl1 taskPaneUserControl;
        private SearchOptions searchOptions;
        //public UserControlFileView userControlFileView;

        private string indexPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "toratEmetIndex");
        private IndexWriter writer;
        private IndexReader reader;
        private LuceneDirectory directory;
        private Analyzer analyzer;

        public HtmlElement previouslyClickedLink;
        private int lineCounter = 1; // Initialize line counter
        public bool isLinkClicked = true;
        private bool hasAtHeading = false;
        private string currentChapterHeading = string.Empty;
        private int resultSum = 0;
        public bool firstLoad = true;

        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        //public void SetUserControlFileView(UserControlFileView userControl)
        //{
        //    userControlFileView = userControl;
        //}


        public SearchForm()
        {
            InitializeComponent();

            webBrowser1.Navigate("about:blank");

            searchAllCheckBox.Checked = Properties.Settings.Default.SearchAllBooks;
            regexCheckBox.Checked = Properties.Settings.Default.SearchRegex;
            checkBoxOpenSearch.Checked = Properties.Settings.Default.SearchOpenSearch;
            checkBox1.Checked = Properties.Settings.Default.StayOnTop;

            // Set the ObjectForScripting property before navigating
            //webBrowser1.ObjectForScripting = new ScriptManager(this);

            // Create a common event handler for all dropdown items
            EventHandler dropdownItemClick = (sender, e) =>
            {
                ToolStripItem item = (ToolStripItem)sender; insertText(item.Text);
            };

            // Assign the event handler to each dropdown item
            foreach (ToolStripItem item in toolStripDropDownButton1.DropDownItems)
            {
                if (item is ToolStripMenuItem dropdownItem) { dropdownItem.Click += dropdownItemClick; }
            }

            //eventhandlers
            textBox1.KeyPress += SearchTextBox_KeyPress;
            SearchButton.Click += SearchButton_Click;

            //webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            webBrowser1.Navigating += WebBrowser1_Navigating;
            this.Shown += new EventHandler(SearchForm_Shown);

            //other
            panel5.Visible = false;
            textBox1.Text = Properties.Settings.Default.LastSearchTerm;

            //// Display the saved HTML file in the WebBrowser control
            //string tempFilePath = Path.Combine(Path.GetTempPath(), "SearchResults.html");

            //if (File.Exists(tempFilePath))
            //{
            //    isLinkClicked = false;
            //    webBrowser1.Navigate(tempFilePath);
            //}

            populateHistoryList();
            this.ActiveControl = toolStrip2;
            textBox1.Focus();
        }

        public string instructionsHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=8"">
    <meta charset=""UTF-8"">
</head>
<body>
    <h2 style=""direction: rtl;"">הוראות:</h2>
    <ol style=""text-align: justify; direction: rtl;"">
        <li>החיפוש אינו יכול לכלול יותר מ- 10 מילים.</li>
        <li>החיפוש אינו יכול לכלול טקסט משני מקטעים (כגון שני חצאי פסוקים).</li>
        <li>קבצים שנוספו לתיקיית הספרים שלי לאחר יצירת האינדקס לא יופיעו בתוצאות החיפוש עד להחלת האינדקס עליהם באפרויות האינדקס.</li>
        <li>תוצאות החיפוש מוצגות לפי סדר הספרים בתוך התיקיות, או לפי סדר ההוספה לאינדקס (המאוחר מבין שני הם).</li>
        <li>בחיפוש בנוסח חופשי, הסדר נקבע לפי מספר המופעים ולא לפי סדר הקבצים.</li>
    </ol>
</body>
</html>

";
        }

        private void populateHistoryList()
        {
            HistoryButton.DropDownItems.Clear();

            string historyList = Properties.Settings.Default.searchHistoryList;
            if (!string.IsNullOrEmpty(historyList))
            {
                string[] historyItems = historyList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string itemText in historyItems)
                {
                    if (itemText != "סגור הכל")
                    {
                        ToolStripMenuItem historyMenuItem = new ToolStripMenuItem(itemText);
                        HistoryButton.DropDownItems.Add(historyMenuItem);
                        historyMenuItem.Click += historyMenuItem_Click;
                    }
                }
            }
        }

        private void updateHistoryList(string currentUrl)
        {
            this.BeginInvoke((Action)(() =>
            {
                string[] existingItems = HistoryButton.DropDownItems
                            .OfType<ToolStripMenuItem>()
                            .Select(item => item.Text)
                            .ToArray();

                bool itemExists = existingItems.Any(item => string.Equals(item, currentUrl, StringComparison.OrdinalIgnoreCase));

                if (!itemExists)
                {
                    ToolStripMenuItem urlMenuItem = new ToolStripMenuItem(currentUrl);
                    urlMenuItem.Click += historyMenuItem_Click;
                    HistoryButton.DropDownItems.Add(urlMenuItem);

                    // Remove the oldest item if the number of items exceeds the limit
                    if (HistoryButton.DropDownItems.Count > 10)
                    {
                        string oldestItem = HistoryButton.DropDownItems[0].Text;
                        HistoryButton.DropDownItems.RemoveAt(0);
                    }
                }
                // Assuming you want to join the text of each item in toolStripDropDownButton1.DropDownItems
                string historyList = string.Join(",", HistoryButton.DropDownItems
                        .OfType<ToolStripMenuItem>() // Assuming the items are ToolStripMenuItem
                        .Select(item => item.Text));

                Properties.Settings.Default.searchHistoryList = historyList;
                Properties.Settings.Default.Save();
            }));
        }

        private void historyMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int clickedIndex = HistoryButton.DropDownItems.IndexOf(clickedItem);
            string itemName = HistoryButton.DropDownItems[clickedIndex].Text;
            textBox1.Text = itemName;
            performSearch();
        }

        private void SearchForm_Shown(Object sender, EventArgs e)
        {
            try
            {
                Start_engine();
                if (reader.NumDocs() == 0)
                {
                    string message = "האינדקס ריק. האם ברצונך ליצור אינדקס כעת?";
                    DialogResult result = MessageBox.Show(message, "אינדקס", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    if (result == DialogResult.Yes)
                    {
                        createIndex();
                    }
                    else
                    {
                        Close_Engine();
                    }
                }
                
            }
            catch (Exception ex) { MessageBox.Show($"Error initializing Lucene: {ex.Message}"); }
        }

        private void Start_engine()
        {
            directory = FSDirectory.Open(indexPath);
            //analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            analyzer = new WhitespaceAnalyzer();
            writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            reader = IndexReader.Open(directory, true);
        }

        private void Close_Engine()
        {
            IndexWriter.Unlock(directory);
            if (writer != null) { writer.Dispose(); }
            if (reader != null) { reader.Dispose(); }
            if (analyzer != null) { analyzer.Dispose(); }
            if (directory != null) { directory.Dispose(); }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                Close_Engine();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing resources: {ex.Message}");
            }
            base.OnFormClosing(e);
        }

        private void insertText(string myText) // for regex dropdown
        {
            //Split the selected item's text by spaces
            string[] words = myText.Split(' ');

            // Get the last word from the array
            myText = words[words.Length - 1].Trim();

            if (textBox1.SelectionLength > 0)
            {
                // If there's a selected text, replace it with the new text
                textBox1.SelectedText = myText;
            }
            else
            {
                // If no text is selected, insert the new text at the caret position
                int caretPosition = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(caretPosition, myText);
                textBox1.SelectionStart = caretPosition + myText.Length;
            }
            textBox1.Focus();
        }

        private void chooseBooksToSearch_Click(object sender, EventArgs e)
        {
            if (searchOptions == null || searchOptions.IsDisposed)
            {
                searchOptions?.Dispose(); // Dispose the existing form if it's disposed or null
                searchOptions = new SearchOptions();
                searchOptions.TopLevel = false; // This allows ChildForm to be embedded
                searchOptions.ControlBox = false;
                searchOptions.FormBorderStyle = FormBorderStyle.None;
                searchOptions.Dock = DockStyle.Fill;

                this.Controls.Add(searchOptions);
                searchOptions.BringToFront();
                //searchOptions.SetSearchForm(this);
                searchOptions.Show();
                panel2.Visible = false;
            }
            else
            {
                searchOptions.Show();
                searchOptions.BringToFront();
                panel2.Visible = false;
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





        //
        //
        //
        //
        //
        //part 1 indexing codes

        public void indexAll()
        {
            string directoryPath1 = Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInstall", "Books");
            string directoryPath2 = Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetUserData", "MyBooks");

            var files = new List<string>();
            files.AddRange(System.IO.Directory.GetFiles(directoryPath1, "*", System.IO.SearchOption.AllDirectories));
            files.AddRange(System.IO.Directory.GetFiles(directoryPath2, "*", System.IO.SearchOption.AllDirectories));

            ProcessFiles(files);
        }

        private void indexIndivisualFiles()
        {
            using (var filePicker = new OpenFileDialog
            {
                Multiselect = true,
                Title = "בחר קבצים",
                Filter = "Text Files|*.txt",
            })
            {
                if (filePicker.ShowDialog() == DialogResult.OK)
                {
                    List<string> selectedFilesList = filePicker.FileNames.ToList();
                    ProcessFiles(selectedFilesList);
                }
            }
        }

        private void indexFolders()
        {

            using (var folderPicker = new FolderPicker())
            {
                if (folderPicker.ShowDialog(IntPtr.Zero) == true)
                {
                    string directoryPath = folderPicker.ResultPath;
                    try
                    {
                        List<string> selectedFilesList = new List<string>(System.IO.Directory.GetFiles(directoryPath, "*.txt", System.IO.SearchOption.AllDirectories));
                        ProcessFiles(selectedFilesList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error indexing documents: {ex.Message}");
                    }
                }
            }
        }

        public async void ProcessFiles(List<string> files)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.toratEmetInstallFolder)) { CheckInstallationFolder(); }

            Close_Engine();
            Start_engine();

            await System.Threading.Tasks.Task.Run(() =>
            {
                this.BeginInvoke((Action)(() =>
                {
                    progressBar.Value = 0;
                    progressBar.Maximum = files.Count;
                }));
                try
                {
                    foreach (var filePath in files)
                    {
                        if (filePath.Contains("ToratEmetInstall"))
                        {
                            if (!Regex.IsMatch(filePath, "Interleave|000_ACCESORIES|500_MY_BOOKS"))
                            {
                                int takeindex = filePath.IndexOf("Books");
                                if (takeindex != -1)
                                {
                                    string translatedFileName = filePath.Substring(takeindex);
                                    translatedFileName = TranslatorClass.TranslateFilename(translatedFileName);
                                    IndexFile(filePath, translatedFileName);
                                }
                                else
                                {
                                    string fileName = Path.GetFileName(filePath);
                                    IndexFile(filePath, fileName);
                                }
                            }
                        }
                        else
                        {
                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            IndexFile(filePath, fileName);
                        }
                        this.BeginInvoke((Action)(() => { progressBar.Value++; }));

                        writer.Commit();
                    }
                    writer.Commit();
                    
                this.BeginInvoke((Action)(() => { progressBar.Value = 0; }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error indexing documents: {ex.Message}");
                }
            });

            Close_Engine();
        }


        public void IndexFile(string filePath, string filename)
        {
            hasAtHeading = false; // Flag to track if the file has an "@" heading.
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                {
                    {
                        string line;
                        string chapterHeading = "";

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            chapterHeading = ExtractChapterHeading(line);
                            line = Regex.Replace(line, "<!--.*?-->", "");

                            if (!linesToSkip(line))
                            {
                                line = NormalizeHebrewText(line);
                                // Replace text enclosed in angle brackets with a space
                                line = Regex.Replace(line, "<.*?>|nbsp[א-ת]{1,}|nbsp|&", "");

                                Regex hebrewRegex = new Regex(@"\p{IsHebrew}+(?<=\p{IsHebrew})\""(?=\p{IsHebrew})\p{IsHebrew}+|\p{IsHebrew}{2,}|{[א-ת]+}|\([א-ת]+\)|\p{IsHebrew}{1,}\""\p{IsHebrew}{1,}||\p{IsHebrew}{1,}''\p{IsHebrew}{1,}|\.");

                                line = RemoveNonMatching(line, hebrewRegex);

                                string[] words = line.Split(' ');
                                if (words.Length > 30)
                                {
                                    string[] chunks = SplitIntoChunks(line, 30).ToArray(); // Split the line into chunks

                                    foreach (string chunk in chunks)
                                    {
                                        var document = new Lucene.Net.Documents.Document();
                                        document.Add(new Lucene.Net.Documents.Field("content", chunk, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED));
                                        document.Add(new Lucene.Net.Documents.Field("path", filename, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED));
                                        if (chapterHeading != null) { document.Add(new Lucene.Net.Documents.Field("chapter", chapterHeading, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED)); }
                                        //document.Add(new Field("lineNumber", lineCounter.ToString(), Field.Store.YES, Field.Index.NO)); // Optionally, index line numbers                                                                                               // Add a custom field for file order (line number)
                                        document.Add(new Lucene.Net.Documents.Field("fileOrder", lineCounter.ToString(), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO));
                                        lineCounter++;
                                        writer.AddDocument(document);
                                    }

                                }
                                else
                                {
                                    var document = new Lucene.Net.Documents.Document();
                                    document.Add(new Lucene.Net.Documents.Field("content", line, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED));
                                    document.Add(new Lucene.Net.Documents.Field("path", filename, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED));
                                    if (chapterHeading != null) { document.Add(new Lucene.Net.Documents.Field("chapter", chapterHeading, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED)); }
                                    //document.Add(new Field("lineNumber", lineCounter.ToString(), Field.Store.YES, Field.Index.NO)); // Optionally, index line numbers                                                                                                 // Add a custom field for file order (line number)
                                    document.Add(new Lucene.Net.Documents.Field("fileOrder", lineCounter.ToString(), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO));
                                    lineCounter++;
                                    writer.AddDocument(document);
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Handle indexing errors here
                Console.WriteLine($"Error indexing file {filePath}: {ex.Message}");
            }
        }

        private bool linesToSkip(string lineToCheck)
        {
            if (lineToCheck.Contains("UniqueId") || lineToCheck.Contains("LastLevelIndex") || lineToCheck.Contains("Comments") || lineToCheck.Contains("TextSource") || lineToCheck.Contains("ForcedBookName") || lineToCheck.Contains("RavMechaber"))
            {
                return true; // Skip this line
            }
            else if (!Regex.IsMatch(lineToCheck, "[א-ת]"))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith(@"//"))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("~ "))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("^ "))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("@ "))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("$ "))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("# "))
            {
                return true; // Skip this line
            }
            else if (lineToCheck.StartsWith("! "))
            {
                return true; // Skip this line
            }
            return false;
        }

        public string ExtractChapterHeading(string lineContent)
        {
            // Check if the line starts with "@" or "~" to detect chapter headings
            if (lineContent.StartsWith("@"))
            {
                currentChapterHeading = Regex.Replace(lineContent, @"[^\w'""]", " "); // Process the chapter heading.                                                                                   
                currentChapterHeading = GetLastTwoWords(currentChapterHeading); // Extract the last two words of the heading.
                hasAtHeading = true; // Set the flag to indicate the presence of "@" heading.
            }
            else if (hasAtHeading == false && lineContent.StartsWith("~"))
            {
                currentChapterHeading = Regex.Replace(lineContent, @"[^\w'""]", " "); // Process the chapter heading.
                currentChapterHeading = GetLastTwoWords(currentChapterHeading); // Extract the last two words of the heading.
            }
            return currentChapterHeading;
        }

        static string GetLastTwoWords(string input)
        {
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length >= 2)
            {
                // Get the last two words
                return words[words.Length - 2] + " " + words[words.Length - 1]; // Return the last two words separated by a space.
            }
            else if (words.Length == 1)
            {
                // If there's only one word in the string, treat it as the last word
                return words[0]; // Return the single word.
            }
            else
            {
                // Handle the case where there are no words in the string
                return null; // Return null to indicate no words.
            }
        }

        static string RemoveNonMatching(string input, Regex pattern)
        {
            string[] words = input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] matchingWords = Array.FindAll(words, word => pattern.IsMatch(word));
            return string.Join(" ", matchingWords);
        }

        //private List<string> SplitIntoChunks(string input, int chunkSize)
        //{
        //    List<string> chunks = new List<string>();

        //    string[] words = input.Split(' ');

        //    for (int i = 0; i < words.Length; i += chunkSize)
        //    {
        //        int remainingWords = Math.Min(chunkSize, words.Length - i);
        //        string chunk = string.Join(" ", words.Skip(i).Take(remainingWords));
        //        chunks.Add(chunk);
        //    }

        //    return chunks;
        //}

        private List<string> SplitIntoChunks(string input, int chunkSize)
        {
            List<string> chunks = new List<string>();

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i += chunkSize)
            {
                int remainingWords = Math.Min(chunkSize, words.Length - i);
                int previousWordsToInclude = Math.Min(10, i); // Include up to 10 words from the previous chunk.

                List<string> currentChunkWords = new List<string>();

                if (previousWordsToInclude > 0)
                {
                    currentChunkWords.AddRange(words.Skip(i - previousWordsToInclude).Take(previousWordsToInclude));
                }

                currentChunkWords.AddRange(words.Skip(i).Take(remainingWords));

                string chunk = string.Join(" ", currentChunkWords);
                chunks.Add(chunk);
            }

            return chunks;
        }

        private string NormalizeHebrewText(string text)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            text = new string(text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
            return text; // Return the normalized text.
        }



        //
        //
        //
        //
        //part 2 search codes


        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                performSearch();
                e.Handled = true; // Prevent the "ding" sound
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            performSearch();
        }


        private async void performSearch()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.toratEmetInstallFolder)) { CheckInstallationFolder(); }
            updateHistoryList(textBox1.Text);

            //if (textBox1.Text.Contains(":"))
            //{
            //    MessageBox.Show("הזנתם תו לא חוקי בחיפוש! (\":\")", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //}
            //else
            //{
            isLinkClicked = false;
            Properties.Settings.Default.LastSearchTerm = textBox1.Text;
            Properties.Settings.Default.Save();

            await System.Threading.Tasks.Task.Run(() =>
            {
                this.Invoke((Action)(() =>
                {
                    Start_engine();

                    SearcherVoid();

                    Close_Engine();
                }));
            });
            //}
        }

        private void SearcherVoid()
        {
            resultSum = 0;
            try
            {
                string queryText = textBox1.Text.Trim(); // Get the user's query text
                var bookNamesFilter = Properties.Settings.Default.searchBookList?.Split(',').ToHashSet();

                // Create a query parser to parse the user's query
                QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "content", analyzer);
                queryParser.AllowLeadingWildcard = true; // Allow leading wildcards if needed

                Query query;
                IndexSearcher searcher = new IndexSearcher(reader);
                TopDocs topDocs = null;

                if (checkBoxOpenSearch.Checked)
                {
                    query = queryParser.Parse(queryText);
                    queryParser.AllowLeadingWildcard = false;
                    topDocs = searcher.Search(query, null, 100000); // Adjust the number of results as needed
                }
                else if (regexCheckBox.Checked)
                {
                    int previousCount = 0;
                    string minimumSearchResults = "";

                    string[] queryTerms = queryText.Split(' '); // Split the query text into individual terms

                    foreach (string term in queryTerms)
                    {
                        query = new RegexQuery(new Term("content", term));
                        topDocs = searcher.Search(query, null, 10000); // Adjust the number of results as needed
                        if (topDocs.ScoreDocs.Length < previousCount || previousCount == 0)
                        {
                            previousCount = topDocs.ScoreDocs.Length;
                            minimumSearchResults = term;
                        }
                    }
                    query = new RegexQuery(new Term("content", minimumSearchResults));
                    topDocs = searcher.Search(query, null, 100000);

                }
                else
                {
                    queryText = queryText.Replace("\"", "\\\"");
                    query = queryParser.Parse("\"" + queryText + "\"");
                    Sort sort = new Sort(new SortField("fileOrder", SortField.INT)); // Sort by file order as an integer
                    topDocs = searcher.Search(query, null, 100000, sort); // Adjust the number of results as needed
                }

                // Use a StringBuilder to build the HTML content for search results
                StringBuilder htmlBuilder = new StringBuilder(GenerateHtmlHeader());

                progressBar.Maximum = topDocs.ScoreDocs.Length;

                foreach (var scoreDoc in topDocs.ScoreDocs)
                {
                    progressBar.Value++;
                    Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                    string filePath = System.Net.WebUtility.HtmlDecode(doc.Get("path")).Trim();
                    string fileContent = doc.Get("content");
                    string chapterHeading = doc.Get("chapter");

                    // Use Any to check if any item in bookNamesFilter is contained in filePath
                    bool matchingFiles = bookNamesFilter.Any(bookName => filePath.Contains(bookName));

                    if (matchingFiles || searchAllCheckBox.Checked)
                    {
                        if (resultSum < 1000)
                        {
                            ProcessMatchingFile(htmlBuilder, filePath, fileContent, chapterHeading, queryText);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                htmlBuilder.Append("</ol>"); // End the ordered list
                htmlBuilder.Append("</body></html>");

                // Generate a unique file name in the temp folder
                string tempFileName = Path.Combine(Path.GetTempPath(), "SearchResults.html");
                // Save the UTF-8 encoded HTML content to the temp file
                //File.WriteAllText(tempFileName, htmlBuilder.ToString(), Encoding.UTF8);
                //webBrowser1.Navigate(tempFileName);
                webBrowser1.Navigate("about:blank");
                webBrowser1.DocumentText = htmlBuilder.ToString();

                searcher.Dispose(); // Close the searcher when done
            }
            catch (Exception ex)
            {
                // Handle search errors here
                MessageBox.Show($"Error searching: {ex.Message}");
            }
            finally
            {
                progressBar.Value = 0;
            }
        }

        private string GenerateHtmlHeader()
        {
            string htmlHeader = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <style>
        body {
            direction: rtl; /* Set text direction to right-to-left */
            text-align: justify; /* Set text alignment to justified */
        }
    </style>
</head>
<body>
<ol>";
            return htmlHeader;
        }

        private void ProcessMatchingFile(StringBuilder htmlBuilder, string filePath, string fileContent, string chapterHeading, string queryText)
        {
            filePath = WebUtility.HtmlEncode(filePath);
            fileContent = WebUtility.HtmlEncode(fileContent);

            if (checkBoxOpenSearch.Checked)
            {
                resultSum++;
                // Generate a dummy link for the file path
                //filePath = $" <a href=\"#\" onclick=\"handleLinkClick('{filePath}%{fileContent}')\">{filePath} {chapterHeading}</a>";
                filePath = $"<a href='#{filePath}%{fileContent}%{chapterHeading}'>{filePath} {chapterHeading}</a>";

                // Split the input string into words based on space as the delimiter
                string[] words = queryText.Split(' ');

                // Display each word separately
                foreach (string word in words)
                {
                    fileContent = fileContent.Replace(word, "<span style='color: red;'>" + word + "</span>");
                }

                // Add a list item for each search result
                htmlBuilder.Append("<li>");
                htmlBuilder.Append(filePath + "</br>");
                htmlBuilder.Append(fileContent);
                htmlBuilder.Append("</li>");
            }
            else if (regexCheckBox.Checked)
            {
                // Generate a dummy link for the file path
                //filePath = $" <a href=\"#\" onclick=\"handleLinkClick('{filePath}%{fileContent}')\">{filePath} {chapterHeading}</a>";

                Regex regex = new Regex(textBox1.Text.Trim());

                if (regex.IsMatch(fileContent))
                {
                    filePath = $"<a href='#{filePath}%{fileContent}%{chapterHeading}'>{filePath} {chapterHeading}</a>";
                    resultSum++;
                    // Use the Regex.Matches method to find all matches of the pattern in the content
                    MatchCollection matches = regex.Matches(fileContent);

                    // If there are matches, replace each match separately
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            string matchedTerm = match.Value;

                            // Replace each matched term with highlighting
                            fileContent = fileContent.Replace(matchedTerm, "<span style='color: red;'>" + matchedTerm + "</span>");
                        }
                    }
                }

                // Add a list item for each search result
                htmlBuilder.Append("<li>");
                htmlBuilder.Append(filePath + "</br>");
                htmlBuilder.Append(fileContent);
                htmlBuilder.Append("</li>");
            }
            else
            {
                //if (fileContent.Contains(queryText))
                if (ContainsQuery(fileContent, queryText))
                {
                    resultSum++;
                    // Generate a dummy link for the file path
                    //filePath = $" <a href=\"#\" onclick=\"handleLinkClick('{filePath}%{fileContent}')\">{filePath} {chapterHeading}</a>";

                    //filePath = $"<a href=\"#\" onclick=\"handleLinkClick('{filePath}%{fileContent}')\">{filePath} {chapterHeading}</a>";
                    filePath = $"<a href='#{filePath}%{fileContent}%{chapterHeading}'>{filePath} {chapterHeading}</a>";

                    // Split the input string into words based on space as the delimiter
                    string[] words = queryText.Split(' ');

                    // Display each word separately
                    foreach (string word in words)
                    {
                        fileContent = fileContent.Replace(word, "<span style='color: red;'>" + word + "</span>");
                    }

                    // Add a list item for each search result
                    htmlBuilder.Append("<li>");
                    htmlBuilder.Append(filePath + "</br>");
                    htmlBuilder.Append(fileContent);
                    htmlBuilder.Append("</li>");
                }

            }
        }

        private bool ContainsQuery(string fileContent, string queryText)
        {
            var bookFilter = queryText?.Split(',').ToHashSet();
            bool matching = bookFilter.All(bookName => fileContent.Contains(bookName));
            if (matching == true) { return true; }
            else { return false; }
        }


        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Check if the URL being navigated to  is a link
            if (isLinkClicked == true)
            {
                // cancel navigation
                e.Cancel = true;
            }
        }

        private void eraseIndex_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Close_Engine();
                Start_engine();

                writer.DeleteAll();
                writer.Commit();

                Close_Engine();

                DirectoryInfo directoryInfo = new DirectoryInfo(@"toratEmetIndex");
                Parallel.ForEach(directoryInfo.GetFiles(), file =>
                {
                    file.Delete();
                });

                webBrowser1.Navigate("about:blank");
                webBrowser1.DocumentText = string.Empty;

                MessageBox.Show("האינדקס נמחק", "אינדקס", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void createIndex_Button_Click(object sender, EventArgs e)
        {
            createIndex();
        }

        private void createIndex()
        {
            string message = "יצירת האינדקס עלולה לארוך כמה שעות (תלוי בכמות הקבצים בתיקיית 'הספרים שלי' בתוכנת תורת אמת) האם להמשיך?";
            DialogResult result = MessageBox.Show(message, "אינדקס", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            if (result == DialogResult.Yes)
            {
                indexAll();
            }
        }

        private void addFolderToIndex_Button_Click(object sender, EventArgs e)
        {
            indexFolders();
        }

        private void addFilesToIndex_Button_Click(object sender, EventArgs e)
        {
            indexIndivisualFiles();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { this.TopMost = true; Properties.Settings.Default.StayOnTop = true; }
            else { this.TopMost = false; Properties.Settings.Default.StayOnTop = false; }
            Properties.Settings.Default.Save();
        }

        private void searchAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (searchAllCheckBox.Checked) { Properties.Settings.Default.SearchAllBooks = true; }
            else { Properties.Settings.Default.SearchAllBooks = false; }
            Properties.Settings.Default.Save();
        }

        private void checkBoxOpenSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOpenSearch.Checked) { regexCheckBox.Checked = false; panel5.Visible = false; Properties.Settings.Default.SearchOpenSearch = true; }
            else { Properties.Settings.Default.SearchOpenSearch = false; }
            Properties.Settings.Default.Save();
        }
        private void regexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (panel5.Visible) { panel5.Visible = false; }
            else { panel5.Visible = true; }
            if (regexCheckBox.Checked)
            {
                MessageBox.Show("שימו לב! תכונה זו הינה נסיונית ואיננה מושלמת לעת עתה. אנא עזרו לנו להמשיך ולעזור לכם ולחצו על לחצן התרומות כעת.");
                checkBoxOpenSearch.Checked = false;
                Properties.Settings.Default.SearchRegex = true;
            }
            else { Properties.Settings.Default.SearchRegex = false; }
            Properties.Settings.Default.Save();
        }


        //[ComVisible(true)] // Add this attribute
        //public class ScriptManager
        //{
        //    private SearchForm form;

        //    public ScriptManager(SearchForm form)
        //    {
        //        this.form = form;
        //    }

        //    public async void CSharpInsertLinkText(string linkText)
        //    {
        //        // Update TextBox1 with the link text
        //        string decodedString = WebUtility.HtmlDecode(linkText);
        //        string[] parts = decodedString.Split('%');
        //        MessageBox.Show(linkText);

        //        await System.Threading.Tasks.Task.Run(() =>
        //        {
        //            form.Invoke(new Action(() =>
        //            {
        //                form.taskPaneUserControl.shouldDisposeForm = true;
        //                form.taskPaneUserControl.shouldautoNavigate = true;
        //                form.taskPaneUserControl.autoNavigateText = parts[1];
        //                form.taskPaneUserControl.openFileFromList(parts[0]);
        //            }));
        //        });
        //    }

        //}
    }
}
