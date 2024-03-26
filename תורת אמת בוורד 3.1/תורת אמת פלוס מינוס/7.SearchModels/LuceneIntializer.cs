using System.IO;
using System.Windows.Forms;
using תורת_אמת_בוורד_3._1;
using תורת_אמת_בוורד_3._1._2.ViewModels;
using תורת_אמת_פלוס_מינוס;

namespace TextSearchApp.SearchModels
{
    public class LuceneIntializer: SearchMethods
    {
        public LuceneIntializer(SearchControlViewModel viewModel) : base(viewModel)
        {
        }

        public bool IndexExists()
        {
            if (Directory.Exists(StaticGlobals.indexFolder))
            {
                int filesCount = Directory.GetFileSystemEntries(StaticGlobals.indexFolder).Length;
                if (filesCount > 0)
                {
                    return true;
                }               
            }
            return false;
        }

        public void DeleteIndex()
        {
            if (Directory.Exists(StaticGlobals.indexFolder)) { Directory.Delete(StaticGlobals.indexFolder, true); Directory.CreateDirectory(StaticGlobals.indexFolder); }
        }
    }
}
