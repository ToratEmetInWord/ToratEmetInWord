using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using LuceneDirectory = Lucene.Net.Store.Directory;
using SystemDirectory = System.IO.Directory;
using System;
using System.IO;
using Lucene.Net.Analysis;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using Lucene.Net.Search.Highlight;
using Lucene.Net.QueryParsers;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;

namespace ToratEmetInWord_2._0
{
    public class LuceneSearch
    {
        SimpleSearchForm form1;
        string documentsFolder = Properties.Settings.Default.toratEmetInstallFolder;
        private readonly string IndexPath;
        //public Dictionary<string, string> resultList;
        public List<string> searchResults;
        int DocNumber = 0;

        public void setForm(SimpleSearchForm form)
        { form1 = form; }

        public LuceneSearch()
        {
            CheckInstallationFolder();
            IndexPath = Path.Combine(documentsFolder, "ToratEmetInWord", "Index");
        }

        public void DeleteIndex()
        {
            try
            {
                // Check if the index directory exists
                if (SystemDirectory.Exists(IndexPath))
                {
                    // Delete the index directory and its contents
                    SystemDirectory.Delete(IndexPath, true);
                    MessageBox.Show("האינדקס נמחק");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log or display an error message
                Console.WriteLine($"Error deleting index: {ex.Message}");
            }
        }

        // Indexing documents
        public void Indexall()
        {
            // Check if the index directory exists
            if (SystemDirectory.Exists(IndexPath))
            { SystemDirectory.Delete(IndexPath, true); }

            string directoryPath1 = Path.Combine(documentsFolder, "ToratEmetInstall", "Books");
            string directoryPath2 = Path.Combine(documentsFolder, "ToratEmetUserData", "MyBooks");

            List<string> files = new List<string>();
            if (SystemDirectory.Exists(directoryPath1))
            {
                files.AddRange(System.IO.Directory.GetFiles(directoryPath1, "*", System.IO.SearchOption.AllDirectories));
                if (SystemDirectory.Exists(directoryPath2))
                {
                    files.AddRange(System.IO.Directory.GetFiles(directoryPath2, "*", System.IO.SearchOption.AllDirectories));
                }           
                ProcessFiles(files);
            }
        }

        public void IndexFolder()
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

        public void indexIndivisualFiles()
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
                    try
                    {
                        List<string> selectedFilesList = filePicker.FileNames.ToList();
                    ProcessFiles(selectedFilesList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error indexing documents: {ex.Message}");
                    }
                }
            }
        }


        private async void ProcessFiles(List<string> files)
        {
            DocNumber = 0;
            if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Maximum = files.Count + 25; form1.progressBar.Value = 25; })); }
            await Task.Run(() =>
            {
                foreach (var filePath in files)
                {
                    if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Value++; })); }
                    else {MessageBox.Show("אירעה שגיאה באינדוקס (" + filePath + ") יש למחוק את האינדקס ולהתחיל שוב"); break; }
                    try { IndexFile(filePath); }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            });
            if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Value = 0; })); }
        }

        private void IndexFile(string filePath)
        {
            string fileName = getFileName(filePath);
            string chapterName = "";
            bool hasAtHeading = false;

            using (var directory = FSDirectory.Open(new DirectoryInfo(IndexPath)))
            using (var analyzer = new WhitespaceAnalyzer())
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (line.StartsWith("@ "))
                    {
                        chapterName = Regex.Replace(line, @"[^\w'""]", " "); // Process the chapter heading.                                       
                        chapterName = getLast2Words(chapterName);
                    }
                    else if (line.StartsWith("~ ") && hasAtHeading == false)
                    {
                        chapterName = Regex.Replace(line, @"[^\w'""]", " "); // Process the chapter heading.                                       
                        chapterName = getLast2Words(chapterName);
                    }

                    else if (!linesToSkip(line))
                    {
                        line = NormalizeHebrewText(line);
                        line = Regex.Replace(line, @"<.*?>|[^א-ת\.""':, \(\)\[\]\{\}\\\+]", "");

                        List<string> snippets = SplitStringIntoSnippets(line, 30);

                        foreach (string snippet in snippets)
                        {
                            DocNumber++;
                            var doc = new Document();
                            doc.Add(new Field("docNumber", DocNumber.ToString(), Field.Store.YES, Field.Index.NO));
                            doc.Add(new Field("location", fileName + "%" + chapterName, Field.Store.YES, Field.Index.NO));
                            doc.Add(new Field("snippet", snippet, Field.Store.YES, Field.Index.ANALYZED));
                            writer.AddDocument(doc);

                        }
                    }
                }
                writer.Commit();
            }
        }

        private string getFileName(string fileName)
        {
            if (File.Exists(fileName))
            {
                int index = fileName.IndexOf("ToratEmetInstall");

                if (index != -1)
                {
                    index = fileName.IndexOf("Books");
                    fileName = fileName.Substring(index);
                    fileName = TranslatorClass.TranslateFilename(fileName);
                }
                else
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName);
                }
            }
            return fileName;
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

        private string NormalizeHebrewText(string text)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            text = new string(text.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
            return text; // Return the normalized text.
        }

        //
        //Searching documents

        public void SearchDocuments(string searchTerm)
        {
            try
            {
                var bookNamesFilter = Properties.Settings.Default.searchBookList?.Split(',').ToHashSet();

                if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Value = 0; })); }
                if (System.IO.Directory.Exists(IndexPath))
                {
                    //resultList = new Dictionary<string, string>();
                    searchResults = new List<string>();

                    using (FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath)))
                    using (IndexReader reader = IndexReader.Open(directory, readOnly: true))
                    using (IndexSearcher searcher = new IndexSearcher(reader))
                    {
                        BooleanQuery booleanQuery = new BooleanQuery();
                        PhraseQuery phraseQuery = new PhraseQuery();
                        phraseQuery.Slop = 3; // Adjust the slop value based on your requirements

                        Sort sort = new Sort(new SortField("fileOrder", SortField.INT)); // Sort by file order as an integer
                        TopDocs topDocs;
                        Highlighter highlighter;


                        string[] searchWords = searchTerm.Split(' ');

                        foreach (string word in searchWords)
                        {
                            if (searchTerm.Contains("?") || searchTerm.Contains("*")) // Use a wildcard query
                            {
                                var term = new Term("snippet", word);
                                var wildcardQuery = new WildcardQuery(term);
                                booleanQuery.Add(wildcardQuery, Occur.MUST); // Adjust Occur based on your logic
                            }
                            else
                            {
                                phraseQuery.Add(new Term("snippet", word));
                            }
                        }

                        if (searchTerm.Contains("?") || searchTerm.Contains("*"))
                        {
                            topDocs = searcher.Search(booleanQuery, null, int.MaxValue, sort);
                            highlighter = new Highlighter(new SimpleHTMLFormatter("<span style=\"color: red;\">", "</span>"), new QueryScorer(booleanQuery));

                        }
                        else
                        {
                            highlighter = new Highlighter(new SimpleHTMLFormatter("<span style=\"color: red;\">", "</span>"), new QueryScorer(phraseQuery));
                            topDocs = searcher.Search(phraseQuery, null, int.MaxValue, sort);
                        }

                        if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Maximum = topDocs.ScoreDocs.Count(); })); }

                        foreach (var sdoc in topDocs.ScoreDocs)
                        {
                            if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Value++; })); }
                            Document mdoc = searcher.Doc(sdoc.Doc);

                            // Use Any to check if any item in bookNamesFilter is contained in filePath
                            bool matchingFile = bookNamesFilter.Any(bookName => mdoc.Get("location").Contains(bookName));
                            if (matchingFile || form1.searchAllCheckBox.Checked)
                            {
                                // Get the snippet field
                                var snippetField = mdoc.Get("snippet");
                                // Get the highlighted text
                                var highlightedSnippet = highlighter.GetBestFragment(new WhitespaceAnalyzer(), "snippet", snippetField);
                                searchResults.Add($"<li><a href='#{HttpUtility.HtmlEncode(mdoc.Get("location"))}%{snippetField}' onclick='openBookLink(this)'>{mdoc.Get("location").Replace("%", " ")}</a><br>{highlightedSnippet}</li>\r\n");
                            }
                        }
                    }
                    if (!form1.IsDisposed) { form1.Invoke(new Action(() => { form1.progressBar.Value = 0; })); }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and possibly inform the user.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}

