using System;
using System.Windows.Forms;

namespace MifareTool
{
    public partial class FrmPasswd : Form
    {
        public FrmPasswd() =>  InitializeComponent();

        private void FrmPasswd_Load(object sender, EventArgs e)
        {
            btn_0.Click += btnNum_Click;
            btn_1.Click += btnNum_Click;
            btn_2.Click += btnNum_Click;
            btn_3.Click += btnNum_Click;
            btn_4.Click += btnNum_Click;
            btn_5.Click += btnNum_Click;
            btn_6.Click += btnNum_Click;
            btn_7.Click += btnNum_Click;
            btn_8.Click += btnNum_Click;
            btn_9.Click += btnNum_Click;
        }

        private void btnDel_Click(object sender, EventArgs e) => txtPwd.Text = "";
        private void btnClose_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnEnt_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("MMdd") == txtPwd.Text)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("다시 입력해 주세요.", "대흥정보 중계서버");
                btnDel.PerformClick();
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if(sender == btn_0) txtPwd.Text += "0";
            else if (sender == btn_1) txtPwd.Text += "1";
            else if (sender == btn_2) txtPwd.Text += "2";
            else if (sender == btn_3) txtPwd.Text += "3";
            else if (sender == btn_4) txtPwd.Text += "4";
            else if (sender == btn_5) txtPwd.Text += "5";
            else if (sender == btn_6) txtPwd.Text += "6";
            else if (sender == btn_7) txtPwd.Text += "7";
            else if (sender == btn_8) txtPwd.Text += "8";
            else if (sender == btn_9) txtPwd.Text += "9";
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
                btnEnt.PerformClick();
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }

    }
}
