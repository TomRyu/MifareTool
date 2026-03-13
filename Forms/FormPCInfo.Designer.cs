namespace MifareTool
{
    partial class FormPCInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPCInfo));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCopyClipboard2 = new System.Windows.Forms.Button();
            this.btnGetCpuProcessorId = new System.Windows.Forms.Button();
            this.tbCpuProcessorId = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new MifareTool.Class.ClickThroughToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(430, 237);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(430, 276);
            this.toolStripContainer1.TabIndex = 48;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(430, 237);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(422, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "라이센스 파일 생성";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(21, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 42);
            this.label1.TabIndex = 84;
            this.label1.Text = "위 정보를 개발사에 전달하세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(6, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 149);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PC 정보";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCopyClipboard2);
            this.groupBox6.Controls.Add(this.btnGetCpuProcessorId);
            this.groupBox6.Controls.Add(this.tbCpuProcessorId);
            this.groupBox6.Location = new System.Drawing.Point(9, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 110);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CPU Processor ID";
            // 
            // btnCopyClipboard2
            // 
            this.btnCopyClipboard2.ForeColor = System.Drawing.Color.Black;
            this.btnCopyClipboard2.Location = new System.Drawing.Point(174, 28);
            this.btnCopyClipboard2.Name = "btnCopyClipboard2";
            this.btnCopyClipboard2.Size = new System.Drawing.Size(204, 35);
            this.btnCopyClipboard2.TabIndex = 82;
            this.btnCopyClipboard2.Text = "클립보드에 복사";
            this.btnCopyClipboard2.UseVisualStyleBackColor = true;
            this.btnCopyClipboard2.Click += new System.EventHandler(this.btnCopyClipboard2_Click);
            // 
            // btnGetCpuProcessorId
            // 
            this.btnGetCpuProcessorId.ForeColor = System.Drawing.Color.Black;
            this.btnGetCpuProcessorId.Location = new System.Drawing.Point(6, 28);
            this.btnGetCpuProcessorId.Name = "btnGetCpuProcessorId";
            this.btnGetCpuProcessorId.Size = new System.Drawing.Size(162, 35);
            this.btnGetCpuProcessorId.TabIndex = 82;
            this.btnGetCpuProcessorId.Text = "Get";
            this.btnGetCpuProcessorId.UseVisualStyleBackColor = true;
            this.btnGetCpuProcessorId.Click += new System.EventHandler(this.btnGetCpuProcessorId_Click);
            // 
            // tbCpuProcessorId
            // 
            this.tbCpuProcessorId.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbCpuProcessorId.Location = new System.Drawing.Point(6, 69);
            this.tbCpuProcessorId.Name = "tbCpuProcessorId";
            this.tbCpuProcessorId.Size = new System.Drawing.Size(372, 29);
            this.tbCpuProcessorId.TabIndex = 84;
            this.tbCpuProcessorId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel2,
            this.toolStripSeparator4,
            this.tsBtnExit});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(246, 39);
            this.toolStrip2.TabIndex = 66;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::MifareTool.Properties.Resources.setting;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(99, 36);
            this.toolStripLabel2.Text = "PC정보 화면";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Image = global::MifareTool.Properties.Resources.Logout;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(94, 36);
            this.tsBtnExit.Text = "나가기";
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // FormPCInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 276);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPCInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Class.ClickThroughToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnGetCpuProcessorId;
        private System.Windows.Forms.TextBox tbCpuProcessorId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyClipboard2;
    }
}