using System;
using System.Windows;
using System.Windows.Controls;
using TextSearchApp.SearchModels;
using תורת_אמת_בוורד_3._1.Properties;

namespace אוצר_הספרים_לוורד.Controls
{
    /// <summary>
    /// Interaction logic for ProgressBarX.xaml
    /// </summary>
    public partial class ProgressBarX : UserControl
    {
        Window hostWindow;        
        public ProgressBarX(Window window)
        {
            InitializeComponent();
            hostWindow = window;
            IndexerProgressBarDelgate.AttachProgressBar(progressBar);

        }
        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            Settings.Default.BusyIndexing = true;
            Settings.Default.Save();

            LuceneIndexer luceneIndexer = new LuceneIndexer(null, this);
            await luceneIndexer.CreateIndex();

            MessageBlock.Text = "יצירת האינדקס נגמרה בהצלחה!";
            OkButton.Visibility = Visibility.Hidden;
            CancelButton.Content = "סגור";
            this.IsEnabled = true;

            Settings.Default.BusyIndexing = false;
            Settings.Default.Save();
        }

        public void ReportProgress()
        {
            IndexerProgressBarDelgate.progressReporter.Report(1);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            hostWindow.Close();
        }
    }

    class IndexerWindow : Window
    {
        public IndexerWindow()
        {
            FlowDirection = FlowDirection.RightToLeft;
            ResizeMode = ResizeMode.NoResize;
            Title = "יצירת אינדקס";
            Height = 172; Width = 300;
            ProgressBarX progressBarX = new ProgressBarX(this);
            Content = progressBarX;
        }
    }

    public static class IndexerProgressBarDelgate
    {
        static ProgressBar _progressBar = new ProgressBar();
        public static void AttachProgressBar(ProgressBar progressBar)
        {
            _progressBar = progressBar;
        }
        public static IProgress<double> progressReporter = new Progress<double>(OnProgressChanged);
        private static void OnProgressChanged(double progressValue)
        {
            if (progressValue == -1) { _progressBar.Value = progressValue; }
            else { _progressBar.Value += progressValue; }
        }
    }
}
