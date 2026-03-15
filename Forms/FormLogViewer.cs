using System;
using System.Windows.Forms;

namespace MifareTool
{
    public partial class FormLogViewer : Form
    {
        public FormLogViewer(string logText)
        {
            InitializeComponent();
            txtLogFull.Text = logText;
            txtLogFull.SelectionStart = txtLogFull.Text.Length;
            txtLogFull.ScrollToCaret();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그를 모두 지우시겠습니까?", "확인",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtLogFull.Clear();
                LogCleared = true;
            }
        }

        /// <summary>로그 지우기 버튼을 눌렀는지 여부</summary>
        public bool LogCleared { get; private set; } = false;
    }
}
