using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToratEmet.Models;
using ToratEmet.TreeModels;

namespace ToratEmet.Initializers
{
    public static class Initializer
    {
        public static void Execute()
        {
            Task.Run(() =>
            {
                ApplicationFolders.IntializeFolders();
                ShortcutsHandler.CreateShortcuts();
                TreeLoader.PopulateTree(null);
            });
        }
    }
}
