using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToratEmet.Models
{
    public static class ProgressBarDelgate
    {
        static ProgressBar _progressBar = new ProgressBar();
        public static void AttachProgressBar(ProgressBar progressBar)
        {
            _progressBar = progressBar;
        }
        public static IProgress<double> progressReporter = new Progress<double>(OnProgressChanged);
        private static void OnProgressChanged(double progressValue)
        {
            try
            {
                if (progressValue == -1) { _progressBar.Value = progressValue; }
                else { _progressBar.Value += progressValue; }
            }
            catch { }
        }
    }
}
