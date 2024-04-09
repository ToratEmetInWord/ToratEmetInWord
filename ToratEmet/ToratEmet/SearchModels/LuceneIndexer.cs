using System.Collections.Generic;
using SIO = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System.IO;
using Lucene.Net.Documents;
using System.Text.RegularExpressions;
using ToratEmet.BookParsingModels;
using ToratEmet.ViewModels;
using ToratEmet.Models;
using ToratEmet.Controls;

namespace ToratEmet.SearchModels
{

    public class LuceneIndexer : LuceneIntializer
    {
        #region Variables

        ProgressBarX progressBar;
        ToratEmetTemplates templates;
        int docNumber = 0;
        string currentHeader = "";
        FSDirectory directory;
        WhitespaceAnalyzer analyzer;
        IndexWriter writer;
        List<string> filePaths;

        #endregion

        public LuceneIndexer(SearchControlViewModel viewModel, ProgressBarX progressbar) : base(viewModel)
        {
            progressBar = progressbar;
        }

        public async Task CreateIndex()
        {
            filePaths = StaticGlobals.treeItemsList.Select(item => item.Address).ToList();
            progressBar.progressBar.Maximum = filePaths.Count;
            await Task.Run(() =>
            {
                if (SIO.Directory.Exists(ApplicationFolders.IndexFolder)) { DeleteIndex(); }
                processFiles();
            });
        }

        void processFiles()
        {
            using (directory = FSDirectory.Open(new DirectoryInfo(ApplicationFolders.IndexFolder)))
            using (analyzer = new WhitespaceAnalyzer())
            using (writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (string filePath in filePaths)
                {
                    templates  = new ToratEmetTemplates();
                    ProcessHeaders processHeaders = new ProcessHeaders();
                    progressBar.ReportProgress();
                    List<string> currentReslutList = new List<string>();

                    using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(1255)))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (startChars.Any(c => line.StartsWith(c)))
                            {
                                currentHeader = processHeaders.Execute(line, filePath);
                                continue;
                            }
                            else
                            {
                                commitLine(line, filePath);
                            }
                        }
                    }
                }
                writer.Commit();
            }
        }

        void commitLine(string line, string filePath) 
        {
            if (string.IsNullOrEmpty(line)) { return; }
            if (filePath.Contains("ToratEmetInstall"))
            {
               line = templates.ApplyTemplates(line, filePath, null, false);
            }

            line = Regex.Replace(line, @"[\p{Mn}\\+]*|<.*?>", "");

            docNumber++;
            var doc = new Document();
            doc.Add(new Field("DocNumber", docNumber.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("FilePath", filePath, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("HeaderId", currentHeader, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("Snippet", line, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
        }
    }
}