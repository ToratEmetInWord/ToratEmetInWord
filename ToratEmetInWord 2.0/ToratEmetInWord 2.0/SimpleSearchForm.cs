using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Word;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace ToratEmetInWord_2._0
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class SimpleSearchForm : Form
    {
        public UserControl1 taskPaneUserControl;
        private SearchOptions searchOptions;

        TranslatorClass TranslatorClass = new TranslatorClass();

        List<string> searchResults; // Step 1: Create a list for search results
        Dictionary<string, List<string>> fileIndexes = new Dictionary<string, List<string>>();

        int currentResultPage = 0;
        int resultPagesSum = 0;
        string searchTerm = "";
        //int MaxearchResults = 100;

        private bool firstTime = true;
        string searchStyle = "";

        //public bool isBusy = false;
        private CancellationTokenSource cancellationTokenSource;


        public void SetTaskPaneUserControl(UserControl1 userControl)
        {
            taskPaneUserControl = userControl;
        }

        public SimpleSearchForm()
        {
            InitializeComponent();
            CheckInstallationFolder();

            webBrowser1.ObjectForScripting = this;
            comboBox1.Text = comboBox1.Items[Properties.Settings.Default.SearchStyle].ToString();
            searchStyle = comboBox1.Items[Properties.Settings.Default.SearchStyle].ToString();
            if (string.IsNullOrEmpty(searchStyle)){ searchStyle = "חיפוש רגיל"; }

            onTopCheckBOx.CheckedChanged += OnTopCheckBOx_CheckedChanged;
            luceneSearchCheckBox.CheckedChanged += LuceneSearchCheckBox_CheckedChanged;
            SearchButton.Click += SearchButton_Click;
            textBox1.KeyDown += TextBox1_KeyDown;
            showNextButton.Click += ShowNextButton_Click;
            showPreviousButton.Click += ShowPreviousButton_Click;
            chooseBooksToSearch.Click += ChooseBooksToSearch_Click;
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            eraseIndex_Button.Click += EraseIndex_Button_Click;
            createIndex_Button.Click += CreateIndex_Button_Click;
            addFolderToIndex_Button.Click += AddFolderToIndex_Button_Click;
            addFilesToIndex_Button.Click += AddFilesToIndex_Button_Click;
            comboBox1.SelectionChangeCommitted += ComboBox1_SelectionChangeCommitted;
            this.FormClosing += SimpleSearchForm_FormClosing;

            regexCheckBox.Checked = Properties.Settings.Default.SearchRegex;
            luceneSearchCheckBox.Checked = Properties.Settings.Default.fastSearch;
            openSearchCheckBox.Checked = Properties.Settings.Default.SearchOpenSearch;
            nikudCheckBox.Checked = Properties.Settings.Default.searchWithNikud;
            this.ActiveControl = toolStrip2; // Assuming toolStripTextBox1 is your ToolStripTextBox
            textBox1.Focus();
        }

        private void SimpleSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHistorylist();

            //if (isBusy == true)
            //{
            //    e.Cancel = true;
            //    this.Visible = false;
            //}
            //else if (cancellationTokenSource != null)
            { cancellationTokenSource?.Cancel(); }
        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchStyle = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();
            searchStyle = comboBox1.SelectedItem.ToString();
            if (searchStyle == "חיפוש מהיר")
            {
                checkForIndex();
            }

        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           if (firstTime)
            { LoadInstructions(); firstTime = false; }
        }

        private void LoadInstructions()
        {
            webBrowser1.DocumentText = @"
<!DOCTYPE html>
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
        <li>קבצים שנוספו לתיקיית הספרים שלי לאחר יצירת האינדקס לא יופיעו בתוצאות החיפוש עד להחלת האינדקס עליהם באפשרויות האינדקס.</li>
        <li>תוצאות החיפוש מוצגות לפי סדר הספרים בתוך התיקיות, או לפי סדר ההוספה לאינדקס (המאוחר מבין שניהם).</li>
        <li>כדי להשתמש בתכונת החיפוש המהיר יש ליצור קבצי אינדקס תחילה</li>
		<li>בחיפוש המהיר אפשר להשתמש עם תווים מיוחדים כגון ? עבור תו כלשהו או * עבור תווים מרובים. חיפוש באופן זה ייהפך אוטומטית לחיפוש בנוסח חופשי</li>
    </ol>
</body>
</html>
";
        }

        private void ChooseBooksToSearch_Click(object sender, EventArgs e)
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
                searchOptions.SetSearchForm(this);
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

        private void OnTopCheckBOx_CheckedChanged(object sender, EventArgs e)
        {
            if (onTopCheckBOx.Checked) { this.TopMost = true; Properties.Settings.Default.StayOnTop = true; }
            else { this.TopMost = false; Properties.Settings.Default.StayOnTop = false; }
            Properties.Settings.Default.Save();
        }

        private void SimpleSearchForm_Load(object sender, EventArgs e)
        {
            populateHistoryList();
            //webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            //webBrowser1.Document.Body.InnerHtml = instructionsHtml();
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
                string[] existingItems = HistoryButton.DropDownItems
                            .OfType<ToolStripMenuItem>()
                            .Select(item => item.Text)
                            .ToArray();

                bool itemExists = existingItems.Any(item => string.Equals(item, currentUrl, StringComparison.OrdinalIgnoreCase));

                if (!itemExists)
                {
                    ToolStripMenuItem urlMenuItem = new ToolStripMenuItem(currentUrl);
                    urlMenuItem.Click += historyMenuItem_Click;
                if (!this.IsDisposed) { this.Invoke((Action)(() => { HistoryButton.DropDownItems.Add(urlMenuItem); })); }

                // Remove the oldest item if the number of items exceeds the limit
                if (HistoryButton.DropDownItems.Count > 10)
                    {
                        string oldestItem = HistoryButton.DropDownItems[0].Text;
                    if (!this.IsDisposed) { this.Invoke((Action)(() => { HistoryButton.DropDownItems.RemoveAt(0); })); }
                }
                }
        }

        private void SaveHistorylist()
        {
            string[] historyList = HistoryButton.DropDownItems
                    .OfType<ToolStripMenuItem>()
                    .Select(item => item.Text)
                    .ToArray();

            string historyListString = string.Join(",", historyList);

            Properties.Settings.Default.searchHistoryList = historyListString;
            Properties.Settings.Default.Save();
        }

        private void historyMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int clickedIndex = HistoryButton.DropDownItems.IndexOf(clickedItem);
            string itemName = HistoryButton.DropDownItems[clickedIndex].Text;
            textBox1.Text = itemName;
            performSearch();
        }

        private void ShowPreviousButton_Click(object sender, EventArgs e)
        {
            if (currentResultPage > 1 && currentResultPage <= resultPagesSum)
            {
                webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
                currentResultPage--;
                int skipNum = currentResultPage - 1;

                StringBuilder htmlResult = new StringBuilder();

                if (currentResultPage > 1) { htmlResult.Append(Htmlheading() + "<ol start=\"" + 100 * skipNum + 1 + "\">"); }
                else { htmlResult.Append(Htmlheading() + "<ol>\r\n"); }

                if (currentResultPage > 1) { htmlResult.Append(string.Join(Environment.NewLine, searchResults.Skip(1000 * skipNum).Take(1000))); }
                else { htmlResult.Append(string.Join(Environment.NewLine, searchResults.Take(1000))); }
                htmlResult.Append("</ol></body></html>");

                webBrowser1.DocumentText = htmlResult.ToString();
            }
        }

        private void ShowNextButton_Click(object sender, EventArgs e)
        {
            if (resultPagesSum > 1 && currentResultPage < resultPagesSum)
            {
                webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);

                StringBuilder htmlResult = new StringBuilder();
                htmlResult.Append(Htmlheading() + "<ol start=\"" + 100 * currentResultPage + 1 + "\">");

                htmlResult.Append(string.Join(Environment.NewLine, searchResults.Skip(1000 * currentResultPage).Take(1000)));

                htmlResult.Append("</ol></body></html>");

                webBrowser1.DocumentText = htmlResult.ToString();
                currentResultPage++;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                performSearch();
                e.Handled = true;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            performSearch(); 
        }

        private void performLuceneSearch()
        {
            if (checkForIndex())
            {
                updateHistoryList(textBox1.Text);

                LuceneSearch luceneSearch = new LuceneSearch();
                luceneSearch.setForm(this);
                luceneSearch.SearchDocuments(textBox1.Text);

                if (luceneSearch.searchResults != null && luceneSearch.searchResults.Count > 0)
                {
                    searchResults = new List<string>();
                    searchResults = luceneSearch.searchResults;

                    StringBuilder htmlResult = new StringBuilder();
                    htmlResult.Append(Htmlheading() + "<ol>\r\n");

                    // Use LINQ to take the first 1000 items from the list.
                    htmlResult.Append(string.Join(Environment.NewLine, searchResults.Take(1000)));
                    currentResultPage = 1;

                    htmlResult.Append("</ol></body></html>");

                    webBrowser1.DocumentText = htmlResult.ToString();
                    resultPagesSum = searchResults.Count / 1000 + 1;
                }
                else
                {
                    MessageBox.Show("לא נמצאו תוצאות");
                }
            }
        }

        private bool checkForIndex()
        {
            string documentsFolder = Properties.Settings.Default.toratEmetInstallFolder;
            string IndexPath = Path.Combine(documentsFolder, "ToratEmetInWord", "Index");

            if (!Directory.Exists(IndexPath))
            {
                string message = "האינדקס ריק. האם ברצונך ליצור אינדקס כעת?";
                DialogResult result = MessageBox.Show(message, "אינדקס", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (result == DialogResult.Yes)
                {
                    LuceneSearch luceneSearch = new LuceneSearch();
                    luceneSearch.setForm(this);
                    luceneSearch.Indexall();
                }
                return false;
            }
            else { return true; }
        }

        private void performSearch()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            searchStyle = comboBox1.Items[Properties.Settings.Default.SearchStyle].ToString();
            if (string.IsNullOrEmpty(searchStyle)) { searchStyle = "חיפוש רגיל"; }

            //if (luceneSearchCheckBox.Checked) { performLuceneSearch(); }
            if (searchStyle == "חיפוש מהיר") { performLuceneSearch(); }
            else
            {
                webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
                
                string directoryPath1 = Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetInstall", "Books");
                string directoryPath2 = Path.Combine(Properties.Settings.Default.toratEmetInstallFolder, "ToratEmetUserData", "MyBooks");

                List<string> files = new List<string>();
                if (Directory.Exists(directoryPath1))
                {
                    files.AddRange(System.IO.Directory.GetFiles(directoryPath1, "*", System.IO.SearchOption.AllDirectories));
                    if (Directory.Exists(directoryPath2))
                    {
                        files.AddRange(System.IO.Directory.GetFiles(directoryPath2, "*", System.IO.SearchOption.AllDirectories));
                    }
                }
                else
                {
                    MessageBox.Show("לא נמצאה התקנה של תוכנת תורת אמת במחשב");
                }

                try
                {
                    ProcessFiles(files);
                    updateHistoryList(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        private async void ProcessFiles(List<string> files)
        {
            // Create a new CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;


            resultPagesSum = 0;
            currentResultPage = 0;

            if (progressBar.Value == 0) { progressBar.Maximum = files.Count; }
            searchTerm = textBox1.Text.Trim();

            foreach (var filePath in files)
            {
                fileIndexes[filePath] = new List<string>();
            }

            // Create a list of tasks to perform the search on multiple files concurrently.
            List<System.Threading.Tasks.Task> searchTasks = new List<System.Threading.Tasks.Task>();

            foreach (var filePath in files)
            {
                // Start a new search task for each file.
                searchTasks.Add(System.Threading.Tasks.Task.Run(() =>
                {
                    try
                    {
                        // Check for cancellation before starting the search
                        cancellationToken.ThrowIfCancellationRequested();

                        SearchFile(searchTerm, filePath);

                        if (!this.IsDisposed)
                        {
                            this.Invoke((Action)(() =>
                            {
                                if (progressBar.Maximum == files.Count) { progressBar.Value++; }
                            }));
                        }
                    }
                    catch
                    {
                        return;
                    }
                }, cancellationToken));
            }

            try
            {
                // Wait for all search tasks to complete or for cancellation
                await System.Threading.Tasks.Task.WhenAll(searchTasks);
            }
            catch (OperationCanceledException)
            {
                GC.Collect();
            }


            ShowSearchResults();

            if (!this.IsDisposed)
            {
                this.Invoke((Action)(() => {
                    if (progressBar.Value > progressBar.Maximum - 10) { progressBar.Value = 0; }
                }));
            }
        }


        private void ShowSearchResults()
        {

            List<string> tempSearchResults = new List<string>();
            tempSearchResults = fileIndexes.Values.SelectMany(list => list).ToList();

            if (tempSearchResults.Count > 0)
            {
                searchResults = new List<string>();
                searchResults = tempSearchResults;
                
                currentResultPage = 1;
                resultPagesSum = resultPagesSum / 1000 + 1;

                StringBuilder htmlResult = new StringBuilder();
                htmlResult.Append(Htmlheading() + "<ol>\r\n");
                // Use LINQ to take the first 1000 items from the list.
                htmlResult.Append(string.Join(Environment.NewLine, searchResults.Take(1000)));             
                htmlResult.Append("</ol></body></html>");

                if (!this.IsDisposed ){ webBrowser1.DocumentText = htmlResult.ToString(); }

                //this.Invoke(new Action(() => Clipboard.SetText(htmlResult.ToString())));
                //SaveHtmlToFile(htmlResult.ToString());
            }
            else
            {
                MessageBox.Show("לא נמצאו תוצאות");
            }
        }

        private string Htmlheading()
        {
            return
                "<html>\r\n" +
                "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n" +
                "<head>\r\n" +
                "<style>" +
                "ol { text-align: justify; }" +
                "li {\r\n            margin-bottom: 10px; \r\n        }" +
                "</style>\r\n" +
                "</head>\r\n" +
                  "<script type='text/javascript'>\r\n" +
                "function openBookLink(link)\r\n" +
                " {var href = link; window.external.OpenBookLink('Link clicked: ' + href);}\r\n" +
                "</script>\r\n" +
                "<body dir='rtl'>\r\n";
        }

        private void SearchFile(string searchTerm, string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            if (File.Exists(filePath))
            {
                int index = filePath.IndexOf("ToratEmetInstall");

                if (index != -1)
                {
                    index = filePath.IndexOf("Books");
                    fileName = filePath.Substring(index);
                    fileName = TranslatorClass.TranslateFilename(fileName);
                }

                if (Regex.IsMatch(fileName, "[א-ת]"))
                {
                    var bookNamesFilter = Properties.Settings.Default.searchBookList?.Split(',').ToHashSet();
                    bool matchingFile = bookNamesFilter.Any(bookName => fileName.Trim().Contains(bookName));

                    if (matchingFile || searchAllCheckBox.Checked)
                    {
                        if (searchStyle == "חיפוש חופשי") { openSearchNoRegex(filePath, fileName); }
                        else if (searchStyle == "רגקס + חופשי") { openSearchRegex(filePath, fileName); }
                        else if  (searchStyle == "חיפוש רגקס") { regexSearch(filePath, fileName); }
                        else if (searchStyle == "חיפוש רגיל") { noRegexSearch(filePath, fileName); }
                    }
                }
            }
        }

        private void noRegexSearch(string filePath, string fileName)
        {
            string chapterName = "";
            bool hasAtHeading = false;

            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        if (line.StartsWith("@ "))
                        {
                            chapterName = getLast2Words(line);
                            hasAtHeading = true;
                        }
                        else if (line.StartsWith("~ ") && hasAtHeading == false)
                        {
                            chapterName = getLast2Words(line);
                        }

                        else if ( !line.StartsWith("# ")
                           && !line.StartsWith("! ")
                           && !line.StartsWith("$ ")
                           && !line.StartsWith("^ ")
                           )
                        {

                            //string pattern = "(\\b\\w+\\W+){0,10}" + Regex.Escape(searchTerm) + "(\\W+\\w+\\b){0,10}";
                            //MatchCollection matches = Regex.Matches(line, pattern);

                            //if (matches.Count > 0)
                            //{
                            //    foreach (Match match in matches)
                            //    {
                            //        string result = match.Value;
                            //        result = Regex.Replace(result, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}]", " ");
                            //        result = result.Replace(searchTerm, "<span style=\"color: red;\">" + searchTerm + "</span>");
                            //        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                            //        resultPagesSum++;
                            //    }
                            //}

                            if (nikudCheckBox.Checked) { line = NormalizeHebrewText(line); }

                            if (line.Contains(searchTerm))
                            {
                                line = Regex.Replace(line, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}\\\+]", "");
                                List<string> snippets = SplitStringIntoSnippets(line, 30);

                                foreach (string snippet in snippets)
                                {
                                    if (snippet.Contains(searchTerm))
                                    {
                                        string result = snippet.Replace(searchTerm, "<span style=\"color: red;\">" + searchTerm + "</span>");
                                        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                                        resultPagesSum++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void regexSearch(string filePath, string fileName)
        {
            string chapterName = "";
            bool hasAtHeading = false;

            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        if (line.StartsWith("@ "))
                        {
                            chapterName = getLast2Words(line);
                            hasAtHeading = true;
                        }
                        else if (line.StartsWith("~ ") && hasAtHeading == false)
                        {
                            chapterName = getLast2Words(line);
                        }

                        else if ( !line.StartsWith("# ")
                           && !line.StartsWith("! ")
                           && !line.StartsWith("$ ")
                           && !line.StartsWith("^ ")
                           )
                        {
                            if (nikudCheckBox.Checked) { line = NormalizeHebrewText(line); }
                            if (Regex.IsMatch(line, searchTerm))
                            {
                                line = Regex.Replace(line, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}\\\+]", "");
                                List<string> snippets = SplitStringIntoSnippets(line, 30);

                                foreach (string snippet in snippets)
                                {
                                    if (Regex.IsMatch(snippet, searchTerm))
                                    {
                                        string result = Regex.Replace(snippet, searchTerm, m => $"<span style=\"color: red;\">{m.Value}</span>");
                                        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                                        resultPagesSum++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openSearchNoRegex(string filePath, string fileName)
        {
            string chapterName = "";
            bool hasAtHeading = false;
            string[] words = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        if (line.StartsWith("@ "))
                        {
                            chapterName = getLast2Words(line);
                            hasAtHeading = true;
                        }
                        else if (line.StartsWith("~ ") && hasAtHeading == false)
                        {
                            chapterName = getLast2Words(line);
                        }

                        else if (!line.StartsWith("# ")
                           && !line.StartsWith("! ")
                           && !line.StartsWith("$ ")
                           && !line.StartsWith("^ ")
                           )
                        {

                            //string pattern = "(\\b\\w+\\W+){0,10}" + Regex.Escape(searchTerm) + "(\\W+\\w+\\b){0,10}";
                            //MatchCollection matches = Regex.Matches(line, pattern);

                            //if (matches.Count > 0)
                            //{
                            //    foreach (Match match in matches)
                            //    {
                            //        string result = match.Value;
                            //        result = Regex.Replace(result, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}]", " ");
                            //        result = result.Replace(searchTerm, "<span style=\"color: red;\">" + searchTerm + "</span>");
                            //        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                            //        resultPagesSum++;
                            //    }
                            //}

                            if (nikudCheckBox.Checked) { line = NormalizeHebrewText(line); }
                            if (containsAll(words, line))
                            {
                                line = Regex.Replace(line, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}\\\+]", "");
                                List<string> snippets = SplitStringIntoSnippets(line, 30);

                                foreach (string snippet in snippets)
                                {
                                    if (containsAll(words, snippet))
                                    {
                                        string result = opensearchResult(words, snippet);
                                        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                                        resultPagesSum++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool containsAll(string[] words, string text)
        {
            bool searchMatch = words.All(word => text.Contains(word));
            return searchMatch;
        }

        //public static bool ContainsAll<list>(IEnumerable<T> source, IEnumerable<T> values)
        //{
        //    return values.All(value => source.Contains(value));
        //}

        private void openSearchRegex(string filePath, string fileName)
        {
            string chapterName = "";
            bool hasAtHeading = false;
            string[] words = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        if (line.StartsWith("@ "))
                        {
                            chapterName = getLast2Words(line);
                            hasAtHeading = true;
                        }
                        else if (line.StartsWith("~ ") && hasAtHeading == false)
                        {
                            chapterName = getLast2Words(line);
                        }

                        else if (!line.StartsWith("# ")
                           && !line.StartsWith("! ")
                           && !line.StartsWith("$ ")
                           && !line.StartsWith("^ ")
                           )
                        {
                            if (nikudCheckBox.Checked) { line = NormalizeHebrewText(line); }

                            if (openSearchScore(words, line))
                            {
                                line = Regex.Replace(line, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}\\\+]", "");
                                List<string> snippets = SplitStringIntoSnippets(line, 30);

                                foreach (string snippet in snippets)
                                {
                                    if (openSearchScore(words, snippet))
                                    {
                                        string result = opensearchResult(words, snippet);
                                        fileIndexes[filePath].Add($"<li><a href='#{HttpUtility.HtmlEncode(fileName)}%{HttpUtility.HtmlEncode(chapterName)}%{HttpUtility.HtmlEncode(result)}' onclick='openBookLink(this)'>{fileName} {chapterName}</a>\r\n<br>{result}</li>\r\n");
                                        resultPagesSum++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool openSearchScore(string[] words, string line)
        {
            int score = 0;
            int scoreNeeded = words.Length;
            foreach (string word in words)
            {
                if ((Regex.IsMatch(line, word))) { score++; }
            }
            if (score == scoreNeeded) { return true; }
            else { return false; }
        }

        private string opensearchResult(string[] words, string snippet)
        {
            foreach (string word in words)
            {
                snippet = Regex.Replace(snippet, word, m => $"<span style=\"color: red;\">{m.Value}</span>");
            }
            return snippet;
        }


        private string getLast2Words(string inputString)
        {
            inputString = Regex.Replace(inputString, @"[@\-~ ]+", " ");
            string[] words = inputString.Split(' ');
            if (words.Length >= 2)
            {
                inputString = words[words.Length - 2] + " " + words[words.Length - 1];
            }
            return inputString;
        }

        private string NormalizeHebrewText(string text)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            text = new string(text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
            return text; // Return the normalized text.
        }

        private List<string> SplitStringIntoSnippets(string input, int chunkSize)
        {
            List<string> chunks = new List<string>();

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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

        //static List<string> SplitStringIntoSnippets(string input, int maxSnippetLength)
        //{
        //    List<string> snippets = new List<string>();

        //    string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //    int wordCount = 0;
        //    int currentIndex = 0;

        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        wordCount++;
        //        if (wordCount >= maxSnippetLength)
        //        {
        //            snippets.Add(string.Join(" ", words, currentIndex, maxSnippetLength));
        //            currentIndex = i + 1;
        //            wordCount = 0;
        //        }
        //    }

        //    if (currentIndex < words.Length)
        //    {
        //        snippets.Add(string.Join(" ", words, currentIndex, words.Length - currentIndex));
        //    }

        //    return snippets;
        //}

        public void OpenBookLInk(string message)
        {
            try { 
            message = HttpUtility.HtmlDecode(message);
            string[] parts = message.Split('#');
            parts = parts[1].Split('%');
            string chapterName = parts[1];
            if (string.IsNullOrEmpty(chapterName) ) { chapterName = textBox1.Text.Trim(); }
            string bookName = parts[0];

            taskPaneUserControl.openSelectedFile(bookName);
            if (parts.Length > 1) { taskPaneUserControl.exactAdress = chapterName + "%" + parts[2]; }
            else { taskPaneUserControl.exactAdress = chapterName; }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
            //taskPaneUserControl.linkElementOpen(bookName, chapterName);
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


        //indexButtons

        private void AddFilesToIndex_Button_Click(object sender, EventArgs e)
        {
            LuceneSearch luceneSearch = new LuceneSearch();
            luceneSearch.setForm(this);
            luceneSearch.indexIndivisualFiles();
        }

        private void AddFolderToIndex_Button_Click(object sender, EventArgs e)
        {
            LuceneSearch luceneSearch = new LuceneSearch();
            luceneSearch.setForm(this);
            luceneSearch.IndexFolder();
        }

        private void CreateIndex_Button_Click(object sender, EventArgs e)
        {
            LuceneSearch luceneSearch = new LuceneSearch();
            luceneSearch.setForm(this);
            luceneSearch.Indexall();
        }

        private void EraseIndex_Button_Click(object sender, EventArgs e)
        {
            LuceneSearch luceneSearch = new LuceneSearch();
            luceneSearch.setForm(this);
            luceneSearch.DeleteIndex();
        }

        private void LuceneSearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (luceneSearchCheckBox.Checked)
            {
                string documentsFolder = Properties.Settings.Default.toratEmetInstallFolder;
                if (!Directory.Exists(Path.Combine(documentsFolder, "ToratEmetInWord", "Index")))
                {
                    MessageBox.Show("יש ליצור אינדקס (באפשרויות החיפוש המהיר) לפני שתוכלו להשתמש בתכונה זו");
                }
                else
                {
                    regexCheckBox.Checked = false;
                    openSearchCheckBox.Checked = false;
                    Properties.Settings.Default.fastSearch = true;
                }
            }
            else
            {
                Properties.Settings.Default.fastSearch = false;
            }
            Properties.Settings.Default.Save();
        }

        private void openSearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (openSearchCheckBox.Checked)
            {
                luceneSearchCheckBox.Checked = false;
                Properties.Settings.Default.SearchOpenSearch = true;
            }
            else { Properties.Settings.Default.SearchOpenSearch = false; }
            Properties.Settings.Default.Save();
        }

        private void regexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (regexCheckBox.Checked)
            {
                luceneSearchCheckBox.Checked = false;
            Properties.Settings.Default.SearchRegex = true;
            }
            else { Properties.Settings.Default.SearchRegex = false; }
            Properties.Settings.Default.Save();
        }

        private void searchAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (searchAllCheckBox.Checked)
            { Properties.Settings.Default.SearchAllBooks = true; }
            else { Properties.Settings.Default.SearchAllBooks = false; }
            Properties.Settings.Default.Save();
        }

        private void nikudCheckBox_CheckedChanged(object sender, EventArgs e)
        {
                if (nikudCheckBox.Checked)
                { Properties.Settings.Default.searchWithNikud = true; }
                else { Properties.Settings.Default.searchWithNikud = false; }
                Properties.Settings.Default.Save();
        }

    }
}
