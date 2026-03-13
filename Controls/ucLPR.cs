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
    public partial class ucLPR : UserControl
    {
        private string sLPRName = "";
        private string sEntryExit = "";
        private string sFrontRear = "";
        public ucLPR()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        [Description("상태 텍스트를 설정하거나 가져옵니다.")]
        public string LRPName
        {
            get { return sLPRName; }
            set
            {
                sLPRName = value;
                labelLPRName.Text = value; // 내부 컨트롤에 반영
            }
        }
        [Category("Custom")]
        [Description("입구/출구")]
        public string EntryExit
        {
            get { return sEntryExit; }
            set
            {
                sEntryExit = value;
                labelEntryExit.Text = value; // 내부 컨트롤에 반영
            }
        }
        [Category("Custom")]
        [Description("전방/후방")]
        public string FrontRear
        {
            get { return sFrontRear; }
            set
            {
                sFrontRear = value;
                labelFrontRear.Text = value; // 내부 컨트롤에 반영
            }
        }
    }
}
