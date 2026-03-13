using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DHServerLPR.Controls
{
    public partial class ucLPRSetting : UserControl
    {
        private string sLPRName = "";
        public int n = 0;
        public ucLPRSetting()
        {
            InitializeComponent();

            cbCamType.Items.AddRange(new object[] { "Novitec" });
            cbCamType.SelectedIndex = 0;
            cbEntryExit.Items.AddRange(new object[] { "입구", "출구" });
            cbEntryExit.SelectedIndex = 0;
            cbFrontRear.Items.AddRange(new object[] { "전방", "후방" });
            cbFrontRear.SelectedIndex = 0;
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

        private void btnCamSet_Click(object sender, EventArgs e)
        {
            if (G.pMain.m_advForm[n] == null || !G.pMain.m_advForm[n].Visible)
            {
                G.pMain.m_advForm[n] = new AdvFeatureForm(G.pMain.m_camera[n]);
            }

            var child = G.pMain.m_advForm[n];
            child.WindowState = FormWindowState.Normal;               // 위치 계산 전에 Normal
            child.StartPosition = FormStartPosition.CenterParent;       // 부모 기준 중앙
            child.ShowDialog(G.pMain); // 
        }

        private void cbEntryExit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucEntryExit1.bEntry = cbEntryExit.SelectedIndex == 0;
        }

        private void cbFrontRear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucFrontRear1.bFront = cbFrontRear.SelectedIndex == 0;
        }
    }
}
