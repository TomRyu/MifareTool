using Microsoft.WindowsAPICodePack.Dialogs;
using MifareTool.Class;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MifareTool
{
    public partial class FormPCInfo : Form
    {
        #region Form 생성자
        public FormPCInfo()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            btnGetCpuProcessorId.PerformClick();    
        }
        #endregion

        private void btnGetCpuProcessorId_Click(object sender, EventArgs e)
        {
            tbCpuProcessorId.Text = HwId.GetCpuProcessorId();
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        private void btnCopyClipboard2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbCpuProcessorId.Text))
            {
                Clipboard.SetText(tbCpuProcessorId.Text);
                MessageBox.Show("클립보드에 복사되었습니다!",
                               "PC정보",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            else
            {
                btnGetCpuProcessorId.PerformClick();
                MessageBox.Show("복사할 내용이 없습니다!",
                                "PC정보",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
