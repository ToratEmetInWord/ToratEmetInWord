using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToratEmet.Models;

namespace ToratEmet.ViewModels
{
    internal class AramaicDictionaryViewModel
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        List<string> resultsList;
        string filePath;

        WebView2 webView;
        Regex regex = new Regex(@"\{.*?\}|\(.*?\)");
        Regex rosheiTevotRegex = new Regex(@"^[א-ת]+""[א-ת]+");

        public AramaicDictionaryViewModel(WebView2 webview, ListBox listBox)
        {
            webView = webview;
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(myDocumentsPath, "ToratEmetInstall", "Dictionaries", "FinalDictionary.txt");
        }

        public void PopulateAramaicDictionary()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("מילון תורת אמת לא נמצא! אנא בדקו אם הקובץ שונה או נמחק");
            }
            else
            {
                dictionary.Clear();
                using (StreamReader reader = StreamReaderX.Reader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        ProcessAramaicLine(reader.ReadLine());
                    }
                }
            }
        }
        public void PopulateHebrewDictionary()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("מילון תורת אמת לא נמצא! אנא בדקו אם הקובץ שונה או נמחק");
            }
            else
            {
                dictionary.Clear();
                using (StreamReader reader = StreamReaderX.Reader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        ProcessHebrewLine(reader.ReadLine());
                    }
                }
            }
        }
        void ProcessAramaicLine(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                line = Replacements(line);
                string[] words = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 1) { dictionary[words[0]] = words[1]; }
            }
        }
        void ProcessHebrewLine(string line)
        {
            if (!string.IsNullOrEmpty(line) && !rosheiTevotRegex.IsMatch(line))
            {
                line = Replacements(line);
                string[] words = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 1)
                {
                    string hebrewString = regex.Replace(words[1], "").Replace("|", ",");
                    string[] hebrewWords = hebrewString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string hebrewWord in hebrewWords)
                    {
                        if (!hebrewWord.StartsWith("[") && !hebrewWord.StartsWith("א ") && !hebrewWord.StartsWith("ד ") && !hebrewWord.Contains("*"))
                            dictionary[hebrewWord.Trim()] = words[0];
                    }
                }
            }
        }

        string Replacements(string line)
        {
            line = Regex.Replace(line, @"\d+ *", "")
                .Replace("(=", "(");
            return line;
        }
        public void Search(string searchTerm, ListBox listBox, WebView2 webView2, bool withNewList)
        {
            resultsList = new List<string>();
            try { webView2.NavigateToString(""); } catch { }

            ArraySearch(searchTerm);
            LevenshtienSearch(searchTerm);
            resultsList.Sort();

            if (withNewList == true) { listBox.ItemsSource = resultsList; }
        }
        void ArraySearch(string searchTerm)
        {
            foreach (var entry in dictionary)
            {
                string key = entry.Key.NormalizeHebrewText();
                if (key.StartsWith(searchTerm) || entry.Key.StartsWith(searchTerm))
                {
                    resultsList.Add(entry.Key);
                }

                if (key == searchTerm)
                {
                    ShowTranslation(entry);
                }
            }
        }
        void LevenshtienSearch(string searchTerm)
        {
            if (resultsList.Count == 0)
            {
                string[] searchArray = searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (KeyValuePair<string, string> entry in dictionary)
                {
                    string key = entry.Key.NormalizeHebrewText();
                    string[] keyArray = key.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] entryKeyArray = entry.Key.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (Levenshtein.CompareArray(searchArray, keyArray, 2) || Levenshtein.CompareArray(searchArray, entryKeyArray, 2))
                    {
                        resultsList.Add(entry.Key);
                    }

                    if (key == searchTerm)
                    {
                        ShowTranslation(entry);
                    }
                }
            }
        }
        void ShowTranslation(KeyValuePair<string, string> entry)
        {
            try
            {
                webView.NavigateToString
                (
                                "<h2 dir=\"rtl\">" + entry.Key +
                "</h2><p dir=\"rtl\">" +
                                entry.Value.Replace(" | ", "<br>")
                            );
            }
            catch { }
        }
    }
}
