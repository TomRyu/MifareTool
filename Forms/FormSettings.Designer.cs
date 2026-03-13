namespace MifareTool
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbLicense = new System.Windows.Forms.TextBox();
            this.btnSelectFolderL = new System.Windows.Forms.Button();
            this.btnFolderOpenL = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPrivate_key = new System.Windows.Forms.TextBox();
            this.btnSelectFolderP = new System.Windows.Forms.Button();
            this.btnFolderOpenP = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnGetCpuProcessorId = new System.Windows.Forms.Button();
            this.tbCpuProcessorId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboUsbDrives = new System.Windows.Forms.ComboBox();
            this.tbPNPHash = new System.Windows.Forms.TextBox();
            this.btnRefreshUSB = new System.Windows.Forms.Button();
            this.tbPNP = new System.Windows.Forms.TextBox();
            this.tbUSBVolume = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPNP = new System.Windows.Forms.Button();
            this.btnUSBVolume = new System.Windows.Forms.Button();
            this.btnCheckLicense = new System.Windows.Forms.Button();
            this.btnCheckUSB = new System.Windows.Forms.Button();
            this.btnMakeLicenseDat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(627, 355);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(627, 394);
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
            this.tabControl1.Size = new System.Drawing.Size(627, 355);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCheckLicense);
            this.tabPage1.Controls.Add(this.btnCheckUSB);
            this.tabPage1.Controls.Add(this.btnMakeLicenseDat);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(619, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "라이센스 파일 생성";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbLicense);
            this.groupBox3.Controls.Add(this.btnSelectFolderL);
            this.groupBox3.Controls.Add(this.btnFolderOpenL);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(8, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 67);
            this.groupBox3.TabIndex = 87;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "license.dat";
            // 
            // tbLicense
            // 
            this.tbLicense.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLicense.Location = new System.Drawing.Point(9, 19);
            this.tbLicense.Margin = new System.Windows.Forms.Padding(1);
            this.tbLicense.Name = "tbLicense";
            this.tbLicense.Size = new System.Drawing.Size(479, 29);
            this.tbLicense.TabIndex = 86;
            // 
            // btnSelectFolderL
            // 
            this.btnSelectFolderL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectFolderL.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFolderL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFolderL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectFolderL.Location = new System.Drawing.Point(498, 14);
            this.btnSelectFolderL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFolderL.Name = "btnSelectFolderL";
            this.btnSelectFolderL.Size = new System.Drawing.Size(39, 44);
            this.btnSelectFolderL.TabIndex = 85;
            this.btnSelectFolderL.Text = "...";
            this.btnSelectFolderL.UseVisualStyleBackColor = true;
            this.btnSelectFolderL.Click += new System.EventHandler(this.btnSelectFolderL_Click);
            // 
            // btnFolderOpenL
            // 
            this.btnFolderOpenL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFolderOpenL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFolderOpenL.ForeColor = System.Drawing.Color.Black;
            this.btnFolderOpenL.Image = global::MifareTool.Properties.Resources.folder;
            this.btnFolderOpenL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolderOpenL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFolderOpenL.Location = new System.Drawing.Point(543, 14);
            this.btnFolderOpenL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFolderOpenL.Name = "btnFolderOpenL";
            this.btnFolderOpenL.Size = new System.Drawing.Size(41, 44);
            this.btnFolderOpenL.TabIndex = 84;
            this.btnFolderOpenL.UseVisualStyleBackColor = true;
            this.btnFolderOpenL.Click += new System.EventHandler(this.btnFolderOpenL_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPrivate_key);
            this.groupBox2.Controls.Add(this.btnSelectFolderP);
            this.groupBox2.Controls.Add(this.btnFolderOpenP);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(8, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 67);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "private_key.pem";
            // 
            // tbPrivate_key
            // 
            this.tbPrivate_key.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPrivate_key.Location = new System.Drawing.Point(9, 19);
            this.tbPrivate_key.Margin = new System.Windows.Forms.Padding(1);
            this.tbPrivate_key.Name = "tbPrivate_key";
            this.tbPrivate_key.Size = new System.Drawing.Size(479, 29);
            this.tbPrivate_key.TabIndex = 86;
            // 
            // btnSelectFolderP
            // 
            this.btnSelectFolderP.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectFolderP.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFolderP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFolderP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectFolderP.Location = new System.Drawing.Point(498, 14);
            this.btnSelectFolderP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFolderP.Name = "btnSelectFolderP";
            this.btnSelectFolderP.Size = new System.Drawing.Size(39, 44);
            this.btnSelectFolderP.TabIndex = 85;
            this.btnSelectFolderP.Text = "...";
            this.btnSelectFolderP.UseVisualStyleBackColor = true;
            this.btnSelectFolderP.Click += new System.EventHandler(this.btnSelectFolderP_Click);
            // 
            // btnFolderOpenP
            // 
            this.btnFolderOpenP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFolderOpenP.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFolderOpenP.ForeColor = System.Drawing.Color.Black;
            this.btnFolderOpenP.Image = global::MifareTool.Properties.Resources.folder;
            this.btnFolderOpenP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolderOpenP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFolderOpenP.Location = new System.Drawing.Point(543, 14);
            this.btnFolderOpenP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFolderOpenP.Name = "btnFolderOpenP";
            this.btnFolderOpenP.Size = new System.Drawing.Size(41, 44);
            this.btnFolderOpenP.TabIndex = 84;
            this.btnFolderOpenP.UseVisualStyleBackColor = true;
            this.btnFolderOpenP.Click += new System.EventHandler(this.btnFolderOpenP_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(8, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 150);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PC 정보";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnGetCpuProcessorId);
            this.groupBox6.Controls.Add(this.tbCpuProcessorId);
            this.groupBox6.Location = new System.Drawing.Point(9, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 110);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CPU Processor ID";
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
            this.tbCpuProcessorId.TextChanged += new System.EventHandler(this.tbCpuProcessorId_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboUsbDrives);
            this.groupBox1.Controls.Add(this.tbPNPHash);
            this.groupBox1.Controls.Add(this.btnRefreshUSB);
            this.groupBox1.Controls.Add(this.tbPNP);
            this.groupBox1.Controls.Add(this.tbUSBVolume);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnPNP);
            this.groupBox1.Controls.Add(this.btnUSBVolume);
            this.groupBox1.Location = new System.Drawing.Point(434, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 301);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB 메모리 정보";
            this.groupBox1.Visible = false;
            // 
            // cboUsbDrives
            // 
            this.cboUsbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsbDrives.FormattingEnabled = true;
            this.cboUsbDrives.Location = new System.Drawing.Point(9, 45);
            this.cboUsbDrives.Name = "cboUsbDrives";
            this.cboUsbDrives.Size = new System.Drawing.Size(340, 29);
            this.cboUsbDrives.TabIndex = 85;
            // 
            // tbPNPHash
            // 
            this.tbPNPHash.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbPNPHash.Location = new System.Drawing.Point(9, 258);
            this.tbPNPHash.Name = "tbPNPHash";
            this.tbPNPHash.Size = new System.Drawing.Size(387, 29);
            this.tbPNPHash.TabIndex = 84;
            this.tbPNPHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRefreshUSB
            // 
            this.btnRefreshUSB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshUSB.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefreshUSB.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshUSB.Image = global::MifareTool.Properties.Resources.refresh2;
            this.btnRefreshUSB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshUSB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshUSB.Location = new System.Drawing.Point(355, 24);
            this.btnRefreshUSB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefreshUSB.Name = "btnRefreshUSB";
            this.btnRefreshUSB.Size = new System.Drawing.Size(41, 44);
            this.btnRefreshUSB.TabIndex = 84;
            this.btnRefreshUSB.UseVisualStyleBackColor = true;
            this.btnRefreshUSB.Click += new System.EventHandler(this.btnRefreshUSB_Click);
            // 
            // tbPNP
            // 
            this.tbPNP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbPNP.Location = new System.Drawing.Point(9, 188);
            this.tbPNP.Multiline = true;
            this.tbPNP.Name = "tbPNP";
            this.tbPNP.Size = new System.Drawing.Size(387, 49);
            this.tbPNP.TabIndex = 84;
            this.tbPNP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUSBVolume
            // 
            this.tbUSBVolume.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbUSBVolume.Location = new System.Drawing.Point(134, 89);
            this.tbUSBVolume.Name = "tbUSBVolume";
            this.tbUSBVolume.Size = new System.Drawing.Size(262, 29);
            this.tbUSBVolume.TabIndex = 84;
            this.tbUSBVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 21);
            this.label11.TabIndex = 83;
            this.label11.Text = "PNP Hash";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 21);
            this.label10.TabIndex = 83;
            this.label10.Text = "PNP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 21);
            this.label9.TabIndex = 83;
            this.label9.Text = "USB 메모리 드라이브";
            // 
            // btnPNP
            // 
            this.btnPNP.ForeColor = System.Drawing.Color.Black;
            this.btnPNP.Location = new System.Drawing.Point(6, 123);
            this.btnPNP.Name = "btnPNP";
            this.btnPNP.Size = new System.Drawing.Size(122, 35);
            this.btnPNP.TabIndex = 82;
            this.btnPNP.Text = "PNP읽기";
            this.btnPNP.UseVisualStyleBackColor = true;
            this.btnPNP.Click += new System.EventHandler(this.btnPNP_Click);
            // 
            // btnUSBVolume
            // 
            this.btnUSBVolume.ForeColor = System.Drawing.Color.Black;
            this.btnUSBVolume.Location = new System.Drawing.Point(6, 82);
            this.btnUSBVolume.Name = "btnUSBVolume";
            this.btnUSBVolume.Size = new System.Drawing.Size(122, 35);
            this.btnUSBVolume.TabIndex = 82;
            this.btnUSBVolume.Text = "볼륨 Serial 읽기";
            this.btnUSBVolume.UseVisualStyleBackColor = true;
            this.btnUSBVolume.Click += new System.EventHandler(this.btnUSBVolume_Click);
            // 
            // btnCheckLicense
            // 
            this.btnCheckLicense.ForeColor = System.Drawing.Color.Blue;
            this.btnCheckLicense.Location = new System.Drawing.Point(434, 249);
            this.btnCheckLicense.Name = "btnCheckLicense";
            this.btnCheckLicense.Size = new System.Drawing.Size(167, 35);
            this.btnCheckLicense.TabIndex = 82;
            this.btnCheckLicense.Text = "license.dat 검증";
            this.btnCheckLicense.UseVisualStyleBackColor = true;
            this.btnCheckLicense.Click += new System.EventHandler(this.btnCheckLicense_Click);
            // 
            // btnCheckUSB
            // 
            this.btnCheckUSB.ForeColor = System.Drawing.Color.Blue;
            this.btnCheckUSB.Location = new System.Drawing.Point(551, 290);
            this.btnCheckUSB.Name = "btnCheckUSB";
            this.btnCheckUSB.Size = new System.Drawing.Size(167, 35);
            this.btnCheckUSB.TabIndex = 82;
            this.btnCheckUSB.Text = "라이센스USB 테스트";
            this.btnCheckUSB.UseVisualStyleBackColor = true;
            this.btnCheckUSB.Visible = false;
            this.btnCheckUSB.Click += new System.EventHandler(this.btnCheckUSB_Click);
            // 
            // btnMakeLicenseDat
            // 
            this.btnMakeLicenseDat.ForeColor = System.Drawing.Color.Red;
            this.btnMakeLicenseDat.Location = new System.Drawing.Point(434, 208);
            this.btnMakeLicenseDat.Name = "btnMakeLicenseDat";
            this.btnMakeLicenseDat.Size = new System.Drawing.Size(167, 35);
            this.btnMakeLicenseDat.TabIndex = 82;
            this.btnMakeLicenseDat.Text = "license.dat 생성";
            this.btnMakeLicenseDat.UseVisualStyleBackColor = true;
            this.btnMakeLicenseDat.Click += new System.EventHandler(this.btnMakeLicenseDat_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(434, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 35);
            this.button1.TabIndex = 81;
            this.button1.Text = "private, public pem 생성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.toolStrip2.Size = new System.Drawing.Size(227, 39);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(80, 36);
            this.toolStripLabel2.Text = "설정 화면";
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 394);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbLicense;
        public System.Windows.Forms.Button btnSelectFolderL;
        public System.Windows.Forms.Button btnFolderOpenL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPrivate_key;
        public System.Windows.Forms.Button btnSelectFolderP;
        public System.Windows.Forms.Button btnFolderOpenP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboUsbDrives;
        private System.Windows.Forms.TextBox tbPNPHash;
        public System.Windows.Forms.Button btnRefreshUSB;
        private System.Windows.Forms.TextBox tbPNP;
        private System.Windows.Forms.TextBox tbUSBVolume;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPNP;
        private System.Windows.Forms.Button btnUSBVolume;
        private System.Windows.Forms.Button btnCheckUSB;
        private System.Windows.Forms.Button btnMakeLicenseDat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCheckLicense;
    }
}