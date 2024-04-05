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
        private static Task initializationTask;

        public static void Execute()
        {
            initializationTask = Task.Run(() =>
            {
                ApplicationFolders.IntializeFolders();
                ShortcutsHandler.CreateShortcuts();
                TreeLoader.PopulateTree(null);
            });
        }

        public static async Task WaitForInitializationAsync()
        {
            if (initializationTask != null)
                await initializationTask;
        }
    }
}
