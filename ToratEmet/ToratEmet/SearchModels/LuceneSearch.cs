using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ToratEmet.Extensions;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet.SearchModels
{
    public class LuceneSearch: LuceneIntializer, IDisposable
    {
        FSDirectory directory;
        IndexReader reader;
        IndexSearcher searcher;
        WildcardQuery wildcardQuery;
        Sort sort;
        TopDocs topDocs;

        string searchTerm;
        public void Dispose()
        {
            reader.Dispose();
            searcher.Dispose();
            directory.Dispose();
        }
        public LuceneSearch(SearchControlViewModel viewModel) : base(viewModel)
        {

        }

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
                            foreach (string word in searchWords)
                            {
                                Term term = new Term("Snippet", word);
                                wildcardQuery = new WildcardQuery(term);
                                topDocs = searcher.Search(wildcardQuery, null, int.MaxValue, sort);
                            }
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
            viewModel.MaxProgress = topDocs.ScoreDocs.Length;
            string searchPattern = searchTerm.ModifyRegexPattern();
            List<string> resultList = new List<string>();
            foreach (ScoreDoc scoreDoc in topDocs.ScoreDocs)
            {
                viewModel.UpdateProgressBar(1);
                Document resultDoc = searcher.Doc(scoreDoc.Doc);
                string filePath = resultDoc.Get("FilePath");
                string content = resultDoc.Get("Snippet");
                string header = resultDoc.Get("HeaderId");

                if (filesList.Contains(filePath))
                {
                    List<string> snippetList = SnippetBuilder.SplitStringIntoSnippets(content, 400, searchPattern.Length + 10);
                    for (int i = 0; i < snippetList.Count; i++)
                    {
                        MatchCollection matches = Regex.Matches(snippetList[i], searchPattern);
                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                string markedValue = $"<span style=\"color:magenta\">{match.Value}</span>";
                                snippetList[i] = snippetList[i].Replace(match.Value, markedValue);
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
