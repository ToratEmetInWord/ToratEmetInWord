using System.IO;
using System.Windows.Forms;
using ToratEmet.Models;
using ToratEmet.ViewModels;

namespace ToratEmet.SearchModels
{
    public class LuceneIntializer: SearchMethods
    {
        public LuceneIntializer(SearchControlViewModel viewModel) : base(viewModel)
        {
        }

        public bool IndexExists()
        {
            if (Directory.Exists(ApplicationFolders.IndexFolder))
            {
                int filesCount = Directory.GetFileSystemEntries(ApplicationFolders.IndexFolder).Length;
                if (filesCount > 0)
                {
                    return true;
                }               
            }
            return false;
        }

        public void DeleteIndex()
        {
            if (Directory.Exists(ApplicationFolders.IndexFolder)) { Directory.Delete(ApplicationFolders.IndexFolder, true); Directory.CreateDirectory(ApplicationFolders.IndexFolder); }
        }
    }
}
