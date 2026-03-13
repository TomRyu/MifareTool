namespace DHServerLPR.Controls
{
    partial class ucLPRSetting
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLPRSetting));
            this.labelLPRName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCamType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEntryExit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFrontRear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEasyFeePort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCamSet = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ipEasyFee = new DHServerLPR.Controls.IpAddressControl();
            this.ucEntryExit1 = new DHServerLPR.Controls.ucEntryExit();
            this.ucFrontRear1 = new DHServerLPR.Controls.ucFrontRear();
            this.ipCam = new DHServerLPR.Controls.IpAddressControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLPRName
            // 
            this.labelLPRName.Font = new System.Drawing.Font("현대하모니 M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelLPRName.Location = new System.Drawing.Point(12, 6);
            this.labelLPRName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLPRName.Name = "labelLPRName";
            this.labelLPRName.Size = new System.Drawing.Size(155, 15);
            this.labelLPRName.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 101;
            this.label5.Text = "Cam IP:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Camera Type:";
            // 
            // cbCamType
            // 
            this.cbCamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamType.FormattingEnabled = true;
            this.cbCamType.Location = new System.Drawing.Point(10, 81);
            this.cbCamType.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbCamType.Name = "cbCamType";
            this.cbCamType.Size = new System.Drawing.Size(156, 21);
            this.cbCamType.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "입구/출구:";
            // 
            // cbEntryExit
            // 
            this.cbEntryExit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntryExit.FormattingEnabled = true;
            this.cbEntryExit.Location = new System.Drawing.Point(10, 37);
            this.cbEntryExit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbEntryExit.Name = "cbEntryExit";
            this.cbEntryExit.Size = new System.Drawing.Size(86, 21);
            this.cbEntryExit.TabIndex = 106;
            this.cbEntryExit.SelectedIndexChanged += new System.EventHandler(this.cbEntryExit_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 101;
            this.label7.Text = "전방/후방:";
            // 
            // cbFrontRear
            // 
            this.cbFrontRear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrontRear.FormattingEnabled = true;
            this.cbFrontRear.Location = new System.Drawing.Point(10, 87);
            this.cbFrontRear.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbFrontRear.Name = "cbFrontRear";
            this.cbFrontRear.Size = new System.Drawing.Size(75, 21);
            this.cbFrontRear.TabIndex = 106;
            this.cbFrontRear.SelectedIndexChanged += new System.EventHandler(this.cbFrontRear_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 15);
            this.label8.TabIndex = 101;
            this.label8.Text = "EasyFee IP:";
            // 
            // tbEasyFeePort
            // 
            this.tbEasyFeePort.Location = new System.Drawing.Point(10, 98);
            this.tbEasyFeePort.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbEasyFeePort.Name = "tbEasyFeePort";
            this.tbEasyFeePort.Size = new System.Drawing.Size(156, 20);
            this.tbEasyFeePort.TabIndex = 107;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(6, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.TabIndex = 101;
            this.label9.Text = "EasyFee Port:";
            // 
            // btnCamSet
            // 
            this.btnCamSet.Location = new System.Drawing.Point(10, 130);
            this.btnCamSet.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCamSet.Name = "btnCamSet";
            this.btnCamSet.Size = new System.Drawing.Size(155, 29);
            this.btnCamSet.TabIndex = 108;
            this.btnCamSet.Text = "Cam Setting";
            this.btnCamSet.UseVisualStyleBackColor = true;
            this.btnCamSet.Click += new System.EventHandler(this.btnCamSet_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("현대하모니 M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(6, 109);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 15);
            this.label10.TabIndex = 101;
            this.label10.Text = "Cam 설정:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnCamSet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ipCam);
            this.groupBox1.Controls.Add(this.cbCamType);
            this.groupBox1.Location = new System.Drawing.Point(2, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(174, 161);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ucEntryExit1);
            this.groupBox2.Controls.Add(this.cbEntryExit);
            this.groupBox2.Controls.Add(this.ucFrontRear1);
            this.groupBox2.Controls.Add(this.cbFrontRear);
            this.groupBox2.Location = new System.Drawing.Point(2, 186);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Size = new System.Drawing.Size(174, 132);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbEasyFeePort);
            this.groupBox3.Controls.Add(this.ipEasyFee);
            this.groupBox3.Location = new System.Drawing.Point(2, 320);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(174, 136);
            this.groupBox3.TabIndex = 113;
            this.groupBox3.TabStop = false;
            // 
            // ipEasyFee
            // 
            this.ipEasyFee.Address = ((System.Net.IPAddress)(resources.GetObject("ipEasyFee.Address")));
            this.ipEasyFee.Font = new System.Drawing.Font("현대하모니 L", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipEasyFee.Location = new System.Drawing.Point(10, 39);
            this.ipEasyFee.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ipEasyFee.Name = "ipEasyFee";
            this.ipEasyFee.Size = new System.Drawing.Size(160, 22);
            this.ipEasyFee.TabIndex = 103;
            this.ipEasyFee.Text = "0.0.0.0";
            // 
            // ucEntryExit1
            // 
            this.ucEntryExit1.bEntry = true;
            this.ucEntryExit1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucEntryExit1.Location = new System.Drawing.Point(113, 16);
            this.ucEntryExit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucEntryExit1.Name = "ucEntryExit1";
            this.ucEntryExit1.Size = new System.Drawing.Size(40, 30);
            this.ucEntryExit1.TabIndex = 110;
            // 
            // ucFrontRear1
            // 
            this.ucFrontRear1.bFront = true;
            this.ucFrontRear1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucFrontRear1.Location = new System.Drawing.Point(113, 66);
            this.ucFrontRear1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFrontRear1.Name = "ucFrontRear1";
            this.ucFrontRear1.Size = new System.Drawing.Size(40, 30);
            this.ucFrontRear1.TabIndex = 109;
            // 
            // ipCam
            // 
            this.ipCam.Address = ((System.Net.IPAddress)(resources.GetObject("ipCam.Address")));
            this.ipCam.Location = new System.Drawing.Point(10, 29);
            this.ipCam.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ipCam.Name = "ipCam";
            this.ipCam.Size = new System.Drawing.Size(160, 22);
            this.ipCam.TabIndex = 103;
            this.ipCam.Text = "0.0.0.0";
            // 
            // ucLPRSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelLPRName);
            this.Font = new System.Drawing.Font("현대하모니 L", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "ucLPRSetting";
            this.Size = new System.Drawing.Size(179, 461);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLPRName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public IpAddressControl ipCam;
        public System.Windows.Forms.ComboBox cbCamType;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbEntryExit;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbFrontRear;
        private System.Windows.Forms.Label label8;
        public IpAddressControl ipEasyFee;
        public System.Windows.Forms.TextBox tbEasyFeePort;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnCamSet;
        private System.Windows.Forms.Label label10;
        private ucFrontRear ucFrontRear1;
        private ucEntryExit ucEntryExit1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
