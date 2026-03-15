namespace MifareTool
{
    partial class FormMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.cboReaders = new System.Windows.Forms.ComboBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContLeft = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoWiFi = new System.Windows.Forms.RadioButton();
            this.rdoRF = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboDataBlock = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDataSector = new System.Windows.Forms.ComboBox();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoInstall = new System.Windows.Forms.RadioButton();
            this.rdoCheck = new System.Windows.Forms.RadioButton();
            this.rdoClean = new System.Windows.Forms.RadioButton();
            this.rdoGuest = new System.Windows.Forms.RadioButton();
            this.btnWriteCard = new System.Windows.Forms.Button();
            this.btnRemoveCard = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboDataBlock2 = new System.Windows.Forms.ComboBox();
            this.cboDataSector2 = new System.Windows.Forms.ComboBox();
            this.tbSysID5 = new System.Windows.Forms.TextBox();
            this.tbSysID3 = new System.Windows.Forms.TextBox();
            this.tbRoomNum3 = new System.Windows.Forms.TextBox();
            this.tbSysID4 = new System.Windows.Forms.TextBox();
            this.tbSysID2 = new System.Windows.Forms.TextBox();
            this.tbRoomNum2 = new System.Windows.Forms.TextBox();
            this.tbSysID1 = new System.Windows.Forms.TextBox();
            this.tbCardSN = new System.Windows.Forms.TextBox();
            this.tbData = new System.Windows.Forms.TextBox();
            this.tbRoomNum1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoWiFiRoomNum = new System.Windows.Forms.RadioButton();
            this.rdoWiFiPassword = new System.Windows.Forms.RadioButton();
            this.rdoWiFiUrgent = new System.Windows.Forms.RadioButton();
            this.rdoWiFiStaff = new System.Windows.Forms.RadioButton();
            this.rdoWiFiGuest = new System.Windows.Forms.RadioButton();
            this.rdoWiFiEmpty = new System.Windows.Forms.RadioButton();
            this.btnReadCard2 = new System.Windows.Forms.Button();
            this.btnWriteCard2 = new System.Windows.Forms.Button();
            this.chkBoxAuto = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnResetCounter = new System.Windows.Forms.Button();
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBoxOnlyEmptyCard = new System.Windows.Forms.CheckBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lblCounter = new MifareTool.Controls.RoundedLabel();
            this.lblResult = new MifareTool.Controls.RoundedLabel();
            this.mifareDumpView1 = new MifareTool.Controls.MifareDumpView();
            this.toolStrip1 = new MifareTool.Class.ClickThroughToolStrip();
            this.tsLabelPGMMode = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnReadAll = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.tsBtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContLeft)).BeginInit();
            this.splitContLeft.Panel1.SuspendLayout();
            this.splitContLeft.Panel2.SuspendLayout();
            this.splitContLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboReaders
            // 
            this.cboReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReaders.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboReaders.FormattingEnabled = true;
            this.cboReaders.Location = new System.Drawing.Point(24, 28);
            this.cboReaders.Name = "cboReaders";
            this.cboReaders.Size = new System.Drawing.Size(254, 29);
            this.cboReaders.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 363);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(427, 73);
            this.txtLog.TabIndex = 2;
            this.txtLog.DoubleClick += new System.EventHandler(this.txtLog_DoubleClick);
            //
            // splitContLeft
            // 
            this.splitContLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContLeft.Name = "splitContLeft";
            // 
            // splitContLeft.Panel1
            // 
            this.splitContLeft.Panel1.Controls.Add(this.txtLog);
            this.splitContLeft.Panel1.Controls.Add(this.groupBox3);
            this.splitContLeft.Panel1.Controls.Add(this.groupBox4);
            this.splitContLeft.Panel1.Controls.Add(this.lblResult);
            // 
            // splitContLeft.Panel2
            // 
            this.splitContLeft.Panel2.Controls.Add(this.mifareDumpView1);
            this.splitContLeft.Size = new System.Drawing.Size(784, 440);
            this.splitContLeft.SplitterDistance = 446;
            this.splitContLeft.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.cboReaders);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "카드 리더기";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.Image = global::MifareTool.Properties.Resources.connected;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(236, 69);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(83, 43);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "연결";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDisconnect.Image = global::MifareTool.Properties.Resources.disconnected;
            this.btnDisconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisconnect.Location = new System.Drawing.Point(325, 69);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(83, 43);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "해제";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::MifareTool.Properties.Resources.refresh21;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(298, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 43);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoWiFi);
            this.panel3.Controls.Add(this.rdoRF);
            this.panel3.Location = new System.Drawing.Point(24, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 40);
            this.panel3.TabIndex = 7;
            // 
            // rdoWiFi
            // 
            this.rdoWiFi.Checked = true;
            this.rdoWiFi.Image = global::MifareTool.Properties.Resources.wifi;
            this.rdoWiFi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoWiFi.Location = new System.Drawing.Point(91, 4);
            this.rdoWiFi.Name = "rdoWiFi";
            this.rdoWiFi.Size = new System.Drawing.Size(88, 32);
            this.rdoWiFi.TabIndex = 0;
            this.rdoWiFi.TabStop = true;
            this.rdoWiFi.Text = "WiFi";
            this.rdoWiFi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoWiFi.UseVisualStyleBackColor = true;
            this.rdoWiFi.CheckedChanged += new System.EventHandler(this.rdoRF_CheckedChanged);
            // 
            // rdoRF
            // 
            this.rdoRF.Image = global::MifareTool.Properties.Resources.rfid;
            this.rdoRF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdoRF.Location = new System.Drawing.Point(4, 4);
            this.rdoRF.Name = "rdoRF";
            this.rdoRF.Size = new System.Drawing.Size(81, 32);
            this.rdoRF.TabIndex = 0;
            this.rdoRF.Text = "RF";
            this.rdoRF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoRF.UseVisualStyleBackColor = true;
            this.rdoRF.CheckedChanged += new System.EventHandler(this.rdoRF_CheckedChanged);
            // 
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 228);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboDataBlock);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cboDataSector);
            this.tabPage1.Controls.Add(this.btnReadCard);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnWriteCard);
            this.tabPage1.Controls.Add(this.btnRemoveCard);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RF";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboDataBlock
            // 
            this.cboDataBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBlock.Enabled = false;
            this.cboDataBlock.FormattingEnabled = true;
            this.cboDataBlock.Location = new System.Drawing.Point(440, 46);
            this.cboDataBlock.Name = "cboDataBlock";
            this.cboDataBlock.Size = new System.Drawing.Size(58, 29);
            this.cboDataBlock.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "섹터";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "블록";
            // 
            // cboDataSector
            // 
            this.cboDataSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSector.FormattingEnabled = true;
            this.cboDataSector.Location = new System.Drawing.Point(285, 46);
            this.cboDataSector.Name = "cboDataSector";
            this.cboDataSector.Size = new System.Drawing.Size(58, 29);
            this.cboDataSector.TabIndex = 0;
            this.cboDataSector.SelectedIndexChanged += new System.EventHandler(this.cboDataSector_SelectedIndexChanged);
            // 
            // btnReadCard
            // 
            this.btnReadCard.Image = global::MifareTool.Properties.Resources.rfidtag;
            this.btnReadCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadCard.Location = new System.Drawing.Point(51, 29);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(109, 43);
            this.btnReadCard.TabIndex = 1;
            this.btnReadCard.Text = "Read";
            this.btnReadCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoInstall);
            this.panel1.Controls.Add(this.rdoCheck);
            this.panel1.Controls.Add(this.rdoClean);
            this.panel1.Controls.Add(this.rdoGuest);
            this.panel1.Location = new System.Drawing.Point(217, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 42);
            this.panel1.TabIndex = 3;
            // 
            // rdoInstall
            // 
            this.rdoInstall.AutoSize = true;
            this.rdoInstall.Location = new System.Drawing.Point(242, 6);
            this.rdoInstall.Name = "rdoInstall";
            this.rdoInstall.Size = new System.Drawing.Size(76, 25);
            this.rdoInstall.TabIndex = 0;
            this.rdoInstall.Text = "공정키";
            this.rdoInstall.UseVisualStyleBackColor = true;
            this.rdoInstall.CheckedChanged += new System.EventHandler(this.rdoCardType_CheckedChanged);
            // 
            // rdoCheck
            // 
            this.rdoCheck.AutoSize = true;
            this.rdoCheck.Location = new System.Drawing.Point(164, 6);
            this.rdoCheck.Name = "rdoCheck";
            this.rdoCheck.Size = new System.Drawing.Size(76, 25);
            this.rdoCheck.TabIndex = 0;
            this.rdoCheck.Text = "점검키";
            this.rdoCheck.UseVisualStyleBackColor = true;
            this.rdoCheck.CheckedChanged += new System.EventHandler(this.rdoCardType_CheckedChanged);
            // 
            // rdoClean
            // 
            this.rdoClean.AutoSize = true;
            this.rdoClean.Location = new System.Drawing.Point(86, 6);
            this.rdoClean.Name = "rdoClean";
            this.rdoClean.Size = new System.Drawing.Size(76, 25);
            this.rdoClean.TabIndex = 0;
            this.rdoClean.Text = "청소키";
            this.rdoClean.UseVisualStyleBackColor = true;
            this.rdoClean.CheckedChanged += new System.EventHandler(this.rdoCardType_CheckedChanged);
            // 
            // rdoGuest
            // 
            this.rdoGuest.AutoSize = true;
            this.rdoGuest.Location = new System.Drawing.Point(8, 6);
            this.rdoGuest.Name = "rdoGuest";
            this.rdoGuest.Size = new System.Drawing.Size(76, 25);
            this.rdoGuest.TabIndex = 0;
            this.rdoGuest.Text = "고객키";
            this.rdoGuest.UseVisualStyleBackColor = true;
            this.rdoGuest.CheckedChanged += new System.EventHandler(this.rdoCardType_CheckedChanged);
            // 
            // btnWriteCard
            // 
            this.btnWriteCard.Image = global::MifareTool.Properties.Resources.writing;
            this.btnWriteCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWriteCard.Location = new System.Drawing.Point(51, 78);
            this.btnWriteCard.Name = "btnWriteCard";
            this.btnWriteCard.Size = new System.Drawing.Size(109, 43);
            this.btnWriteCard.TabIndex = 1;
            this.btnWriteCard.Text = "Write";
            this.btnWriteCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWriteCard.UseVisualStyleBackColor = true;
            this.btnWriteCard.Click += new System.EventHandler(this.btnWriteCard_Click);
            // 
            // btnRemoveCard
            // 
            this.btnRemoveCard.Image = global::MifareTool.Properties.Resources.eraser_icon;
            this.btnRemoveCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveCard.Location = new System.Drawing.Point(51, 127);
            this.btnRemoveCard.Name = "btnRemoveCard";
            this.btnRemoveCard.Size = new System.Drawing.Size(109, 43);
            this.btnRemoveCard.TabIndex = 1;
            this.btnRemoveCard.Text = "Empty";
            this.btnRemoveCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveCard.UseVisualStyleBackColor = true;
            this.btnRemoveCard.Click += new System.EventHandler(this.btnRemoveCard_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboDataBlock2);
            this.tabPage2.Controls.Add(this.cboDataSector2);
            this.tabPage2.Controls.Add(this.tbSysID5);
            this.tabPage2.Controls.Add(this.tbSysID3);
            this.tabPage2.Controls.Add(this.tbRoomNum3);
            this.tabPage2.Controls.Add(this.tbSysID4);
            this.tabPage2.Controls.Add(this.tbSysID2);
            this.tabPage2.Controls.Add(this.tbRoomNum2);
            this.tabPage2.Controls.Add(this.tbSysID1);
            this.tabPage2.Controls.Add(this.tbCardSN);
            this.tabPage2.Controls.Add(this.tbData);
            this.tabPage2.Controls.Add(this.tbRoomNum1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.btnReadCard2);
            this.tabPage2.Controls.Add(this.btnWriteCard2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 194);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WiFi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboDataBlock2
            // 
            this.cboDataBlock2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBlock2.FormattingEnabled = true;
            this.cboDataBlock2.Location = new System.Drawing.Point(494, 14);
            this.cboDataBlock2.Name = "cboDataBlock2";
            this.cboDataBlock2.Size = new System.Drawing.Size(58, 29);
            this.cboDataBlock2.TabIndex = 0;
            this.cboDataBlock2.SelectedIndexChanged += new System.EventHandler(this.cboDataBlock2_SelectedIndexChanged);
            // 
            // cboDataSector2
            // 
            this.cboDataSector2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSector2.FormattingEnabled = true;
            this.cboDataSector2.Location = new System.Drawing.Point(371, 14);
            this.cboDataSector2.Name = "cboDataSector2";
            this.cboDataSector2.Size = new System.Drawing.Size(58, 29);
            this.cboDataSector2.TabIndex = 0;
            this.cboDataSector2.SelectedIndexChanged += new System.EventHandler(this.cboDataSector2_SelectedIndexChanged);
            // 
            // tbSysID5
            // 
            this.tbSysID5.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSysID5.Location = new System.Drawing.Point(621, 105);
            this.tbSysID5.Name = "tbSysID5";
            this.tbSysID5.Size = new System.Drawing.Size(37, 35);
            this.tbSysID5.TabIndex = 11;
            this.tbSysID5.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbSysID3
            // 
            this.tbSysID3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSysID3.Location = new System.Drawing.Point(535, 106);
            this.tbSysID3.Name = "tbSysID3";
            this.tbSysID3.Size = new System.Drawing.Size(37, 35);
            this.tbSysID3.TabIndex = 11;
            this.tbSysID3.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbRoomNum3
            // 
            this.tbRoomNum3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRoomNum3.Location = new System.Drawing.Point(310, 104);
            this.tbRoomNum3.Name = "tbRoomNum3";
            this.tbRoomNum3.Size = new System.Drawing.Size(37, 35);
            this.tbRoomNum3.TabIndex = 11;
            this.tbRoomNum3.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbSysID4
            // 
            this.tbSysID4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSysID4.Location = new System.Drawing.Point(578, 105);
            this.tbSysID4.Name = "tbSysID4";
            this.tbSysID4.Size = new System.Drawing.Size(37, 35);
            this.tbSysID4.TabIndex = 11;
            this.tbSysID4.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbSysID2
            // 
            this.tbSysID2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSysID2.Location = new System.Drawing.Point(492, 105);
            this.tbSysID2.Name = "tbSysID2";
            this.tbSysID2.Size = new System.Drawing.Size(37, 35);
            this.tbSysID2.TabIndex = 11;
            this.tbSysID2.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbRoomNum2
            // 
            this.tbRoomNum2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRoomNum2.Location = new System.Drawing.Point(267, 104);
            this.tbRoomNum2.Name = "tbRoomNum2";
            this.tbRoomNum2.Size = new System.Drawing.Size(37, 35);
            this.tbRoomNum2.TabIndex = 11;
            this.tbRoomNum2.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbSysID1
            // 
            this.tbSysID1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSysID1.Location = new System.Drawing.Point(449, 105);
            this.tbSysID1.Name = "tbSysID1";
            this.tbSysID1.Size = new System.Drawing.Size(37, 35);
            this.tbSysID1.TabIndex = 11;
            this.tbSysID1.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // tbCardSN
            // 
            this.tbCardSN.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCardSN.Location = new System.Drawing.Point(93, 13);
            this.tbCardSN.Name = "tbCardSN";
            this.tbCardSN.ReadOnly = true;
            this.tbCardSN.Size = new System.Drawing.Size(218, 35);
            this.tbCardSN.TabIndex = 11;
            // 
            // tbData
            // 
            this.tbData.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbData.Location = new System.Drawing.Point(14, 152);
            this.tbData.Name = "tbData";
            this.tbData.ReadOnly = true;
            this.tbData.Size = new System.Drawing.Size(655, 35);
            this.tbData.TabIndex = 11;
            // 
            // tbRoomNum1
            // 
            this.tbRoomNum1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRoomNum1.Location = new System.Drawing.Point(224, 104);
            this.tbRoomNum1.Name = "tbRoomNum1";
            this.tbRoomNum1.Size = new System.Drawing.Size(37, 35);
            this.tbRoomNum1.TabIndex = 11;
            this.tbRoomNum1.TextChanged += new System.EventHandler(this.tbCard2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "블록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "System ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "섹터";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Card SN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Room Num";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoWiFiRoomNum);
            this.panel2.Controls.Add(this.rdoWiFiPassword);
            this.panel2.Controls.Add(this.rdoWiFiUrgent);
            this.panel2.Controls.Add(this.rdoWiFiStaff);
            this.panel2.Controls.Add(this.rdoWiFiGuest);
            this.panel2.Controls.Add(this.rdoWiFiEmpty);
            this.panel2.Location = new System.Drawing.Point(130, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 41);
            this.panel2.TabIndex = 9;
            // 
            // rdoWiFiRoomNum
            // 
            this.rdoWiFiRoomNum.AutoSize = true;
            this.rdoWiFiRoomNum.Location = new System.Drawing.Point(395, 6);
            this.rdoWiFiRoomNum.Name = "rdoWiFiRoomNum";
            this.rdoWiFiRoomNum.Size = new System.Drawing.Size(138, 25);
            this.rdoWiFiRoomNum.TabIndex = 0;
            this.rdoWiFiRoomNum.Text = "Room Number";
            this.rdoWiFiRoomNum.UseVisualStyleBackColor = true;
            this.rdoWiFiRoomNum.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // rdoWiFiPassword
            // 
            this.rdoWiFiPassword.AutoSize = true;
            this.rdoWiFiPassword.Location = new System.Drawing.Point(299, 6);
            this.rdoWiFiPassword.Name = "rdoWiFiPassword";
            this.rdoWiFiPassword.Size = new System.Drawing.Size(97, 25);
            this.rdoWiFiPassword.TabIndex = 0;
            this.rdoWiFiPassword.Text = "Password";
            this.rdoWiFiPassword.UseVisualStyleBackColor = true;
            this.rdoWiFiPassword.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // rdoWiFiUrgent
            // 
            this.rdoWiFiUrgent.AutoSize = true;
            this.rdoWiFiUrgent.Location = new System.Drawing.Point(219, 6);
            this.rdoWiFiUrgent.Name = "rdoWiFiUrgent";
            this.rdoWiFiUrgent.Size = new System.Drawing.Size(79, 25);
            this.rdoWiFiUrgent.TabIndex = 0;
            this.rdoWiFiUrgent.Text = "Urgent";
            this.rdoWiFiUrgent.UseVisualStyleBackColor = true;
            this.rdoWiFiUrgent.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // rdoWiFiStaff
            // 
            this.rdoWiFiStaff.AutoSize = true;
            this.rdoWiFiStaff.Location = new System.Drawing.Point(155, 6);
            this.rdoWiFiStaff.Name = "rdoWiFiStaff";
            this.rdoWiFiStaff.Size = new System.Drawing.Size(61, 25);
            this.rdoWiFiStaff.TabIndex = 0;
            this.rdoWiFiStaff.Text = "Staff";
            this.rdoWiFiStaff.UseVisualStyleBackColor = true;
            this.rdoWiFiStaff.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // rdoWiFiGuest
            // 
            this.rdoWiFiGuest.AutoSize = true;
            this.rdoWiFiGuest.Location = new System.Drawing.Point(83, 6);
            this.rdoWiFiGuest.Name = "rdoWiFiGuest";
            this.rdoWiFiGuest.Size = new System.Drawing.Size(70, 25);
            this.rdoWiFiGuest.TabIndex = 0;
            this.rdoWiFiGuest.Text = "Guest";
            this.rdoWiFiGuest.UseVisualStyleBackColor = true;
            this.rdoWiFiGuest.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // rdoWiFiEmpty
            // 
            this.rdoWiFiEmpty.AutoSize = true;
            this.rdoWiFiEmpty.Location = new System.Drawing.Point(8, 6);
            this.rdoWiFiEmpty.Name = "rdoWiFiEmpty";
            this.rdoWiFiEmpty.Size = new System.Drawing.Size(74, 25);
            this.rdoWiFiEmpty.TabIndex = 0;
            this.rdoWiFiEmpty.Text = "Empty";
            this.rdoWiFiEmpty.UseVisualStyleBackColor = true;
            this.rdoWiFiEmpty.CheckedChanged += new System.EventHandler(this.rdoCardType2_CheckedChanged);
            // 
            // btnReadCard2
            // 
            this.btnReadCard2.Image = global::MifareTool.Properties.Resources.rfidtag;
            this.btnReadCard2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadCard2.Location = new System.Drawing.Point(14, 54);
            this.btnReadCard2.Name = "btnReadCard2";
            this.btnReadCard2.Size = new System.Drawing.Size(109, 43);
            this.btnReadCard2.TabIndex = 6;
            this.btnReadCard2.Text = "Read";
            this.btnReadCard2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadCard2.UseVisualStyleBackColor = true;
            this.btnReadCard2.Click += new System.EventHandler(this.btnReadCard2_Click);
            // 
            // btnWriteCard2
            // 
            this.btnWriteCard2.Image = global::MifareTool.Properties.Resources.writing;
            this.btnWriteCard2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWriteCard2.Location = new System.Drawing.Point(14, 103);
            this.btnWriteCard2.Name = "btnWriteCard2";
            this.btnWriteCard2.Size = new System.Drawing.Size(109, 43);
            this.btnWriteCard2.TabIndex = 8;
            this.btnWriteCard2.Text = "Write";
            this.btnWriteCard2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWriteCard2.UseVisualStyleBackColor = true;
            this.btnWriteCard2.Click += new System.EventHandler(this.btnWriteCard2_Click);
            // 
            // chkBoxAuto
            // 
            this.chkBoxAuto.AutoSize = true;
            this.chkBoxAuto.Location = new System.Drawing.Point(18, 28);
            this.chkBoxAuto.Name = "chkBoxAuto";
            this.chkBoxAuto.Size = new System.Drawing.Size(61, 25);
            this.chkBoxAuto.TabIndex = 4;
            this.chkBoxAuto.Text = "수동";
            this.chkBoxAuto.UseVisualStyleBackColor = true;
            this.chkBoxAuto.CheckedChanged += new System.EventHandler(this.chkBoxAuto_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblCounter);
            this.groupBox4.Controls.Add(this.btnResetCounter);
            this.groupBox4.Location = new System.Drawing.Point(12, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(427, 80);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "카드 발급 카운터";
            // 
            // btnResetCounter
            // 
            this.btnResetCounter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResetCounter.Image = global::MifareTool.Properties.Resources.reset;
            this.btnResetCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetCounter.Location = new System.Drawing.Point(285, 28);
            this.btnResetCounter.Name = "btnResetCounter";
            this.btnResetCounter.Size = new System.Drawing.Size(85, 44);
            this.btnResetCounter.TabIndex = 1;
            this.btnResetCounter.Text = "리셋";
            this.btnResetCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetCounter.UseVisualStyleBackColor = true;
            this.btnResetCounter.Click += new System.EventHandler(this.btnResetCounter_Click);
            // 
            // splitContMain
            // 
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContMain.Location = new System.Drawing.Point(0, 0);
            this.splitContMain.Name = "splitContMain";
            this.splitContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContMain.Panel1
            // 
            this.splitContMain.Panel1.Controls.Add(this.groupBox1);
            this.splitContMain.Panel1.Controls.Add(this.splitContLeft);
            // 
            // splitContMain.Panel2
            // 
            this.splitContMain.Panel2.Controls.Add(this.tabControl1);
            this.splitContMain.Size = new System.Drawing.Size(784, 672);
            this.splitContMain.SplitterDistance = 440;
            this.splitContMain.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkBoxOnlyEmptyCard);
            this.groupBox3.Controls.Add(this.chkBoxAuto);
            this.groupBox3.Location = new System.Drawing.Point(12, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 62);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "자동 발급 설정";
            // 
            // chkBoxOnlyEmptyCard
            // 
            this.chkBoxOnlyEmptyCard.AutoSize = true;
            this.chkBoxOnlyEmptyCard.Location = new System.Drawing.Point(111, 28);
            this.chkBoxOnlyEmptyCard.Name = "chkBoxOnlyEmptyCard";
            this.chkBoxOnlyEmptyCard.Size = new System.Drawing.Size(261, 25);
            this.chkBoxOnlyEmptyCard.TabIndex = 4;
            this.chkBoxOnlyEmptyCard.Text = "빈 카드가 아니더라도 발급 허용";
            this.chkBoxOnlyEmptyCard.UseVisualStyleBackColor = true;
            this.chkBoxOnlyEmptyCard.CheckedChanged += new System.EventHandler(this.chkBoxOnlyEmptyCard_CheckedChanged);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 672);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 711);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // lblCounter
            // 
            this.lblCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(8)))));
            this.lblCounter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.lblCounter.BorderWidth = 2;
            this.lblCounter.CornerRadius = 12;
            this.lblCounter.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(30)))));
            this.lblCounter.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(5)))));
            this.lblCounter.LetterSpacing = 4;
            this.lblCounter.Location = new System.Drawing.Point(16, 25);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(180, 48);
            this.lblCounter.TabIndex = 0;
            this.lblCounter.Text = "0";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCounter.UseGradient = true;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(14)))));
            this.lblResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))));
            this.lblResult.BorderWidth = 2;
            this.lblResult.CornerRadius = 14;
            this.lblResult.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(120)))));
            this.lblResult.GradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(35)))), ((int)(((byte)(16)))));
            this.lblResult.LetterSpacing = 7;
            this.lblResult.Location = new System.Drawing.Point(14, 137);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(418, 69);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.UseGradient = true;
            // 
            // mifareDumpView1
            // 
            this.mifareDumpView1.AccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(40)))));
            this.mifareDumpView1.AutoScroll = true;
            this.mifareDumpView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.mifareDumpView1.BackColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.mifareDumpView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mifareDumpView1.DumpData = null;
            this.mifareDumpView1.DumpFont = new System.Drawing.Font("Consolas", 19F);
            this.mifareDumpView1.FontScale = 1F;
            this.mifareDumpView1.KeyColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.mifareDumpView1.Location = new System.Drawing.Point(0, 0);
            this.mifareDumpView1.Name = "mifareDumpView1";
            this.mifareDumpView1.NormalTextColor = System.Drawing.Color.White;
            this.mifareDumpView1.SectorFont = new System.Drawing.Font("맑은 고딕", 20F);
            this.mifareDumpView1.SectorTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mifareDumpView1.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.mifareDumpView1.Size = new System.Drawing.Size(334, 440);
            this.mifareDumpView1.TabIndex = 0;
            this.mifareDumpView1.UidColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.mifareDumpView1.ValueBlockColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(215)))), ((int)(((byte)(40)))));
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabelPGMMode,
            this.tsBtnReadAll,
            this.tsBtnSettings,
            this.tsBtnInfo,
            this.toolStripSeparator1,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsLabelPGMMode
            // 
            this.tsLabelPGMMode.ForeColor = System.Drawing.Color.Blue;
            this.tsLabelPGMMode.Name = "tsLabelPGMMode";
            this.tsLabelPGMMode.Size = new System.Drawing.Size(74, 36);
            this.tsLabelPGMMode.Text = "설정 화면";
            // 
            // tsBtnReadAll
            // 
            this.tsBtnReadAll.Image = global::MifareTool.Properties.Resources.rfidtag;
            this.tsBtnReadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReadAll.Name = "tsBtnReadAll";
            this.tsBtnReadAll.Size = new System.Drawing.Size(105, 36);
            this.tsBtnReadAll.Text = "전체읽기";
            this.tsBtnReadAll.Click += new System.EventHandler(this.tsBtnReadAll_Click);
            // 
            // tsBtnSettings
            // 
            this.tsBtnSettings.Image = global::MifareTool.Properties.Resources.setting;
            this.tsBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSettings.Name = "tsBtnSettings";
            this.tsBtnSettings.Size = new System.Drawing.Size(75, 36);
            this.tsBtnSettings.Text = "설정";
            this.tsBtnSettings.Click += new System.EventHandler(this.tsBtnSettings_Click);
            // 
            // tsBtnInfo
            // 
            this.tsBtnInfo.Image = global::MifareTool.Properties.Resources.Info;
            this.tsBtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInfo.Name = "tsBtnInfo";
            this.tsBtnInfo.Size = new System.Drawing.Size(140, 36);
            this.tsBtnInfo.Text = "프로그램 정보";
            this.tsBtnInfo.Click += new System.EventHandler(this.tsBtnInfo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.Image = global::MifareTool.Properties.Resources.Logout;
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(90, 36);
            this.tsBtnExit.Text = "나가기";
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "(주)더엠알 카드 생성기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContLeft.Panel1.ResumeLayout(false);
            this.splitContLeft.Panel1.PerformLayout();
            this.splitContLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContLeft)).EndInit();
            this.splitContLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboReaders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContLeft;
        private MifareTool.Controls.RoundedLabel lblResult;
        private System.Windows.Forms.Button btnWriteCard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoInstall;
        private System.Windows.Forms.RadioButton rdoCheck;
        private System.Windows.Forms.RadioButton rdoClean;
        private System.Windows.Forms.RadioButton rdoGuest;
        private System.Windows.Forms.CheckBox chkBoxAuto;
        private System.Windows.Forms.Button btnRemoveCard;
        private System.Windows.Forms.ComboBox cboDataSector;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public System.Windows.Forms.ToolStripButton tsBtnSettings;
        private Class.ClickThroughToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsBtnInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.ToolStripLabel tsLabelPGMMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoWiFiUrgent;
        private System.Windows.Forms.RadioButton rdoWiFiStaff;
        private System.Windows.Forms.RadioButton rdoWiFiGuest;
        private System.Windows.Forms.RadioButton rdoWiFiEmpty;
        private System.Windows.Forms.Button btnReadCard2;
        private System.Windows.Forms.Button btnWriteCard2;
        private System.Windows.Forms.RadioButton rdoWiFiRoomNum;
        private System.Windows.Forms.RadioButton rdoWiFiPassword;
        private System.Windows.Forms.TextBox tbRoomNum3;
        private System.Windows.Forms.TextBox tbRoomNum2;
        private System.Windows.Forms.TextBox tbRoomNum1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSysID5;
        private System.Windows.Forms.TextBox tbSysID3;
        private System.Windows.Forms.TextBox tbSysID4;
        private System.Windows.Forms.TextBox tbSysID2;
        private System.Windows.Forms.TextBox tbSysID1;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.TextBox tbCardSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDataSector2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDataBlock2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoWiFi;
        private System.Windows.Forms.RadioButton rdoRF;
        private System.Windows.Forms.ComboBox cboDataBlock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContMain;
        private Controls.MifareDumpView mifareDumpView1;
        public System.Windows.Forms.ToolStripButton tsBtnReadAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxOnlyEmptyCard;
        private System.Windows.Forms.GroupBox groupBox4;
        private MifareTool.Controls.RoundedLabel lblCounter;
        private System.Windows.Forms.Button btnResetCounter;
    }
}

