using System;
using System.Windows;
using System.Windows.Input;

namespace ToratEmetInWordInstaller
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Installer.CopyFiles();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Installer.DeleteFiles();
        }

        private void SetupButton_Click(object sender, RoutedEventArgs e)
        {
            Installer.RunInstaller(false);
        }

        private void VstoButton_Click(object sender, RoutedEventArgs e)
        {
            Installer.RunInstaller(true);
        }
    }
}
