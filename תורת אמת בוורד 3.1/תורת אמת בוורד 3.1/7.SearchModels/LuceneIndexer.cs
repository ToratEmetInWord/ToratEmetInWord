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
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_בוורד_3._1;
using תורת_אמת_בוורד_3._1._5.BookParsingModels;
using אוצר_הספרים_לוורד.Controls;

namespace TextSearchApp.SearchModels
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
                if (SIO.Directory.Exists(StaticGlobals.indexFolder)) { DeleteIndex(); }
                processFiles();
            });
        }

        void processFiles()
        {
            using (directory = FSDirectory.Open(new DirectoryInfo(StaticGlobals.indexFolder)))
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
            if (filePath.Contains("ToratEmetInstall"))
            {
                templates.ApplyTemplates(line, filePath, null, false);
            }

            string cleanedLine = Regex.Replace(line, @"[\p{Mn}\\+]*", "").Replace("<", " <").Replace(">", "> ");
            
            docNumber++;
            var doc = new Document();
            doc.Add(new Field("DocNumber", docNumber.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("FilePath", filePath, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("HeaderId", currentHeader, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("Snippet", cleanedLine, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
        }
    }
}