using DHServerLPR.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHServerLPR.Controls
{
    public partial class ucEntryExit : UserControl
    {
        private bool _bEntry = true;
        public ucEntryExit()
        {
            InitializeComponent();
            bEntry = true;
        }
        [Category("Custom")]
        [Description("상태 텍스트를 설정하거나 가져옵니다.")]
        public bool bEntry
        {
            get { return _bEntry; }
            set
            {
                _bEntry = value;
                if (_bEntry)
                {
                    pictureBox1.Image = Resources.entrances;
                }
                else
                {
                    pictureBox1.Image = Resources.exit;
                }
                pictureBox1.Invalidate();   
            }
        }
    }
}
