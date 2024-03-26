using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using תורת_אמת_בוורד_3._1.TreeModels;

namespace תורת_אמת_פלוס_מינוס
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StaticGlobals.SetFoldersPaths();
            TreeLoader treeLoader = new TreeLoader();
            treeLoader.PopulateTree(null);
        }
    }
}
