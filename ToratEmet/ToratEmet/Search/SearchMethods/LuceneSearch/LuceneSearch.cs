using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Extensions;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet.SearchModels
{
    public class LuceneSearch : LuceneIntializer
    {
        FSDirectory directory;
        IndexReader reader;
        IndexSearcher searcher;
        Sort sort;
        TopDocs topDocs;
        string searchTerm;

        public LuceneSearch(SearchControlViewModel viewModel) : base(viewModel) { }

        public async Task ExecuteSearch(string searchterm)
        {
            if (Properties.Settings.Default.BusyIndexing == true) { MessageBox.Show("המערכת זיהתה שהתחלתם פעולת אינדוקס אנא השלימו פעולה זו"); }
            else if (IndexExists())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        sort = new Sort(new SortField("DocNumber", SortField.INT)); // Sort by file order as an integer
                        resultsDictionary = new Dictionary<string, List<string>>();
                        using (directory = FSDirectory.Open(new DirectoryInfo(ApplicationFolders.IndexFolder)))
                        using (reader = IndexReader.Open(directory, readOnly: true))
                        using (searcher = new IndexSearcher(reader))
                        {
                            this.searchTerm = searchterm;
                            string[] searchWords = searchTerm.Split(' ');
                            
                                PhraseQuery phraseQuery = new PhraseQuery();
                                phraseQuery.Slop = 3;
                                foreach (string word in searchWords)
                                {
                                    phraseQuery.Add(new Term("Snippet", word));
                                }
                                topDocs = searcher.Search(phraseQuery, null, int.MaxValue, sort);
                            
                            processResults();
                        }
                    });

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("כדי להשתמש בתכונה זו יש ליצור אינדקס באפשרויות התוכנה");
            }
        }

        void processResults()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            viewModel.MaxProgress = topDocs.ScoreDocs.Length;

            List<string> resultList = new List<string>();
            string[] searchWords = searchTerm.WhiteSpaceArray();
            foreach (ScoreDoc scoreDoc in topDocs.ScoreDocs)
            {
                if (token.IsCancellationRequested) { break; }
                viewModel.UpdateProgressBar(1);
                Document resultDoc = searcher.Doc(scoreDoc.Doc);
                string filePath = resultDoc.Get("FilePath");

                if (filesList.Contains(filePath))
                {
                    string header = resultDoc.Get("HeaderId");
                    string content = resultDoc.Get("Snippet");

                    content = Regex.Replace(content, @"<.*?>", "");
                    List<string> snippetList = SnippetBuilder.SplitStringIntoSnippets(content, 400, searchTerm.Length + 10);
                    for (int i = 0; i < snippetList.Count; i++)
                    {
                        if (snippetList[i].StringContains(searchWords, searchTerm.Length))
                        {
                            foreach (string word in searchWords) 
                            {
                                snippetList[i] = snippetList[i].Replace(word, $"<span style=\"color:magenta\">{word}</span>"); 
                            }
                            resultList.Add(ResultItem(filePath, snippetList[i], header));
                        }
                    }
                }
            }
            resultsDictionary.Add("", resultList);
        }
    }
}
