using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToratEmet.Controls
{
    public partial class HostControl : UserControl
    {
        public MainControl mainControl;
        public HostControl()
        {
            InitializeComponent();
            mainControl = mainControl1;
        }
    }
}
