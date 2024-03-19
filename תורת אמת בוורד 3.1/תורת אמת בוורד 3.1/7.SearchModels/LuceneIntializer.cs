using System.IO;
using System.Windows.Forms;
using תורת_אמת_בוורד_3._1;
using תורת_אמת_בוורד_3._1._2.ViewModels;

namespace TextSearchApp.SearchModels
{
    public class LuceneIntializer: SearchMethods
    {
        public LuceneIntializer(SearchControlViewModel viewModel) : base(viewModel)
        {
        }

        public bool IndexExists()
        {
            if (Directory.Exists(GlobalsX.indexFolder))
            {
                int filesCount = Directory.GetFileSystemEntries(GlobalsX.indexFolder).Length;
                if (filesCount > 0)
                {
                    return true;
                }               
            }
            return false;
        }

        public void DeleteIndex()
        {
            if (Directory.Exists(GlobalsX.indexFolder)) { Directory.Delete(GlobalsX.indexFolder, true); Directory.CreateDirectory(GlobalsX.indexFolder); }
        }
    }
}
