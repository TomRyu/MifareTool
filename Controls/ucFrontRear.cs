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
    public partial class ucFrontRear : UserControl
    {
        private bool _bFront = true;
        public ucFrontRear()
        {
            InitializeComponent();
            bFront = true;
        }
        [Category("Custom")]
        [Description("상태 텍스트를 설정하거나 가져옵니다.")]
        public bool bFront
        {
            get { return _bFront; }
            set
            {
                _bFront = value;
                if (_bFront)
                {
                    pictureBox1.Image = Resources.front;
                }
                else
                {
                    pictureBox1.Image = Resources.rear;
                }
                pictureBox1.Invalidate();   
            }
        }
    }
}
