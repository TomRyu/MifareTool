namespace DHServerLPR.Controls
{
    partial class ucLPR
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
            this.labelLPRName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEntryExit = new System.Windows.Forms.Label();
            this.labelFrontRear = new System.Windows.Forms.Label();
            this.ucFrontRear1 = new DHServerLPR.Controls.ucFrontRear();
            this.ucEntryExit1 = new DHServerLPR.Controls.ucEntryExit();
            this.ledLPRRun = new DHServerLPR.Controls.StatusLed();
            this.ledConnection = new DHServerLPR.Controls.StatusLed();
            this.SuspendLayout();
            // 
            // labelLPRName
            // 
            this.labelLPRName.Font = new System.Drawing.Font("현대하모니 L", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelLPRName.Location = new System.Drawing.Point(9, 11);
            this.labelLPRName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLPRName.Name = "labelLPRName";
            this.labelLPRName.Size = new System.Drawing.Size(117, 15);
            this.labelLPRName.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 101;
            this.label1.Text = "Cam 연결";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(5, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Cam Connection";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 101;
            this.label3.Text = "LPR 실행";
            // 
            // labelEntryExit
            // 
            this.labelEntryExit.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.labelEntryExit.Location = new System.Drawing.Point(10, 94);
            this.labelEntryExit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEntryExit.Name = "labelEntryExit";
            this.labelEntryExit.Size = new System.Drawing.Size(54, 15);
            this.labelEntryExit.TabIndex = 101;
            // 
            // labelFrontRear
            // 
            this.labelFrontRear.Font = new System.Drawing.Font("현대하모니 L", 12F);
            this.labelFrontRear.Location = new System.Drawing.Point(10, 136);
            this.labelFrontRear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFrontRear.Name = "labelFrontRear";
            this.labelFrontRear.Size = new System.Drawing.Size(54, 15);
            this.labelFrontRear.TabIndex = 101;
            // 
            // ucFrontRear1
            // 
            this.ucFrontRear1.bFront = true;
            this.ucFrontRear1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucFrontRear1.Location = new System.Drawing.Point(83, 136);
            this.ucFrontRear1.Name = "ucFrontRear1";
            this.ucFrontRear1.Size = new System.Drawing.Size(40, 30);
            this.ucFrontRear1.TabIndex = 103;
            // 
            // ucEntryExit1
            // 
            this.ucEntryExit1.bEntry = true;
            this.ucEntryExit1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucEntryExit1.Location = new System.Drawing.Point(83, 94);
            this.ucEntryExit1.Name = "ucEntryExit1";
            this.ucEntryExit1.Size = new System.Drawing.Size(40, 30);
            this.ucEntryExit1.TabIndex = 102;
            // 
            // ledLPRRun
            // 
            this.ledLPRRun.AbnormalColor = System.Drawing.Color.Crimson;
            this.ledLPRRun.IsNormal = false;
            this.ledLPRRun.Location = new System.Drawing.Point(95, 66);
            this.ledLPRRun.Name = "ledLPRRun";
            this.ledLPRRun.NormalColor = System.Drawing.Color.LimeGreen;
            this.ledLPRRun.Size = new System.Drawing.Size(20, 16);
            this.ledLPRRun.TabIndex = 100;
            this.ledLPRRun.Text = "statusLed2";
            // 
            // ledConnection
            // 
            this.ledConnection.AbnormalColor = System.Drawing.Color.Crimson;
            this.ledConnection.IsNormal = false;
            this.ledConnection.Location = new System.Drawing.Point(95, 35);
            this.ledConnection.Name = "ledConnection";
            this.ledConnection.NormalColor = System.Drawing.Color.LimeGreen;
            this.ledConnection.Size = new System.Drawing.Size(20, 16);
            this.ledConnection.TabIndex = 99;
            this.ledConnection.Text = "statusLed1";
            // 
            // ucLPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ucFrontRear1);
            this.Controls.Add(this.ucEntryExit1);
            this.Controls.Add(this.labelFrontRear);
            this.Controls.Add(this.labelEntryExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLPRName);
            this.Controls.Add(this.ledLPRRun);
            this.Controls.Add(this.ledConnection);
            this.Font = new System.Drawing.Font("현대하모니 L", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "ucLPR";
            this.Size = new System.Drawing.Size(140, 173);
            this.ResumeLayout(false);

        }

        #endregion

        public StatusLed ledConnection;
        public StatusLed ledLPRRun;
        private System.Windows.Forms.Label labelLPRName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelEntryExit;
        public System.Windows.Forms.Label labelFrontRear;
        public ucEntryExit ucEntryExit1;
        public ucFrontRear ucFrontRear1;
    }
}
