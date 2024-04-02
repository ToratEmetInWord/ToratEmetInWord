using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ToratEmetInWord_2._0
{
    public partial class DictionaryForm : Form
    {
        private bool stopSearch = false;
        string[] splitToLines = null;
        public DictionaryForm()
        {
            InitializeComponent();
            //SearchButton.Click += SearchButton_Click;
            aramaicListbox.SelectedIndexChanged += AramaicListbox_SelectedIndexChanged;
            aramaicTextBox.TextChanged += AramaicTextBox_TextChanged;
            hebrewListbox.SelectedIndexChanged += HebrewListbox_SelectedIndexChanged;
            hebrewTextBox.TextChanged += HebrewTextBox_TextChanged;
            hebrewTextBox.GotFocus += HebrewTextBox_GotFocus;
            aramaicTextBox.GotFocus += AramaicTextBox_GotFocus;
            TranslateAramaicToHebrew.CheckedChanged += TranslateAramaicToHebrew_CheckedChanged;
            TranslateAramaicToHebrew.Checked = true;

            CheckInstallationFolder();
            string documentsFolder = Properties.Settings.Default.toratEmetInstallFolder;
            string filePath = Path.Combine(documentsFolder, "ToratEmetInstall", "Dictionaries", "FinalDictionary.txt");
            if (File.Exists(filePath))
            {
                // Read the content of the text file using the Windows-1255 encoding
                string textContent = File.ReadAllText(filePath, Encoding.GetEncoding(1255));
                // Split the text content into lines
                splitToLines = textContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private void TranslateAramaicToHebrew_CheckedChanged(object sender, EventArgs e)
        {
            if (translateHebrewToAramaic.Checked)
            { hebrewTextBox.BackColor = Color.White; aramaicTextBox.BackColor = Color.Snow; hebrewTextBox.Focus(); }
            else { hebrewTextBox.BackColor = Color.Snow; aramaicTextBox.BackColor = Color.White; aramaicTextBox.Focus(); }
        }

        private void AramaicTextBox_GotFocus(object sender, EventArgs e)
        {
            TranslateAramaicToHebrew.Checked = true;
        }

        private void HebrewTextBox_GotFocus(object sender, EventArgs e)
        {
            translateHebrewToAramaic.Checked = true;
        }

        private void AramaicTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(aramaicTextBox.Text) && TranslateAramaicToHebrew.Checked
                && stopSearch == false)
            {
                stopSearch = true;
                SearchDictionary(aramaicTextBox.Text.Trim());
                stopSearch = false;
            }

        }

        private void AramaicListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TranslateAramaicToHebrew.Checked)
            {
                hebrewTextBox.Text = "";
                stopSearch = true;
                aramaicTextBox.Text = aramaicListbox.SelectedItem as string;
                SearchDictionary(aramaicTextBox.Text.Trim());
                stopSearch = false;
            }
            else
            {
                Clipboard.SetText(aramaicListbox.Text.Trim());
                MessageBox.Show("התרגום הועתק ללוח");
            }
        }

        private void HebrewTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hebrewTextBox.Text) && translateHebrewToAramaic.Checked
                && stopSearch == false)
            {
                aramaicTextBox.Text = "";
                stopSearch = true;
                SearchDictionary(hebrewTextBox.Text.Trim());
                stopSearch = false;
            }
        }

        private void HebrewListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (translateHebrewToAramaic.Checked)
            {
                stopSearch = true;
                hebrewTextBox.Text = hebrewListbox.SelectedItem as string;
                SearchDictionary(hebrewTextBox.Text.Trim());
                stopSearch = false;
            }
            else
            {
                Clipboard.SetText(hebrewListbox.Text.Trim());
                MessageBox.Show("התרגום הועתק ללוח");
            }
        }

        //private void SearchButton_Click(object sender, EventArgs e)
        //{
        //    if (TranslateAramaicToHebrew.Checked) { SearchDictionary(aramaicTextBox.Text.Trim()); }
        //    if (translateHebrewToAramaic.Checked) { SearchDictionary(hebrewTextBox.Text.Trim()); }
        //}

        public void SearchDictionary(string searchTerm)
        {
            aramaicListbox.Items.Clear();
            hebrewListbox.Items.Clear();

            string documentsFolder = Properties.Settings.Default.toratEmetInstallFolder;
            string filePath = Path.Combine(documentsFolder, "ToratEmetInstall", "Dictionaries", "FinalDictionary.txt");
            if (File.Exists(filePath))
            {
                // Read the content of the text file using the Windows-1255 encoding
                string textContent = File.ReadAllText(filePath, Encoding.GetEncoding(1255));
                // Split the text content into lines
                string[] splitToLines = textContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            }

            foreach (string line in splitToLines)
            {

                if (!line.StartsWith("//"))
                {
                    string normalizedline = NormalizeHebrewText(line);
                    Regex pattern = new Regex("[0-9] .*?=");
                    Match match = pattern.Match(normalizedline);
                    string aramaicWord = Regex.Replace(match.Value, "=|[0-9] ", "").Trim();

                    if (translateHebrewToAramaic.Checked)
                    {
                        string hebrewWord = Regex.Replace(normalizedline, @"[0-9].*?=|\{.*?\}|\(.*?\)", "").Trim();
                        hebrewWord = Regex.Replace(hebrewWord, @"\*\*\*", "|").Trim();
                        if (hebrewWord.Contains(searchTerm))
                        {
                            if (hebrewWord.Contains("|"))
                            {
                                string[] words = hebrewWord.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string word in words)
                                {
                                    string word2add = word.Trim();
                                    if (!string.IsNullOrEmpty(word2add))
                                    {
                                        if (word.StartsWith(searchTerm)) { hebrewListbox.Items.Add(word.Trim()); }
                                        if (word.Trim() == searchTerm) { aramaicListbox.Items.Add(aramaicWord); };
                                    }
                                }
                            }
                            else
                            { if (hebrewWord.StartsWith(searchTerm)) { hebrewListbox.Items.Add(hebrewWord); } }
                        }
                        if (hebrewWord.Equals(searchTerm))
                        {
                            aramaicListbox.Items.Add(aramaicWord);
                        }
                    }
                    else
                    {
                        if (aramaicWord.StartsWith(searchTerm)) { aramaicListbox.Items.Add(aramaicWord); }
                        if (aramaicWord.Equals(searchTerm))
                        {
                            if (line.Contains("*"))
                            {
                                string[] words = line.Split(new[] { "***" }, StringSplitOptions.None);
                                foreach (string word in words)
                                {
                                    hebrewListbox.Items.Add(Regex.Replace(word, "[0-9].*?=", "").Trim());
                                }
                            }
                            else
                            {
                                hebrewListbox.Items.Add(Regex.Replace(normalizedline, "[0-9].*?=", "").Trim());
                            }
                        }
                    }
                }
            }
        }

        private string NormalizeHebrewText(string textContent)
        {
            // Normalize Hebrew text (e.g., remove diacritics)
            // You may need to implement this normalization based on your specific requirements.
            // Example: Normalize to remove diacritics (NFD normalization)
            textContent = new string(textContent.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray()); // Normalize Hebrew text.
            return textContent;
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
                    if (Directory.Exists(folderToCheck))
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
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
