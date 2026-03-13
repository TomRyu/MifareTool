using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MifareTool.Controls
{
    public partial class ucINFO: UserControl
    {
        public event EventHandler tsBtnExit_Event;
        public ucINFO()
        {
            InitializeComponent();

            tsBtnExit.Click += TsBtnExit_Click;
        }

        private void TsBtnExit_Click(object sender, EventArgs e)
        {
            if (this.tsBtnExit_Event != null)
                tsBtnExit_Event(sender, e);
        }

        private void ucINFO_Load(object sender, EventArgs e)
        {
            string path = @"VersionHistory.txt";
            if (File.Exists(path))
                richTextBox1.Text = File.ReadAllText(path);
        }
    }
}
