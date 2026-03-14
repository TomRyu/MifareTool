using MifareTool.Class;
using MifareTool.Controls;
using PCSC;
using PCSC.Monitoring;
using PCSC.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MifareTool
{
    public partial class FormMain : Form
    {
        private ISCardContext _context;
        private ISCardReader _reader;
        private SCardProtocol _activeProtocol;
        private string _readerName;
        private SCardMonitor _monitor;
        Card cardType = new Card();
        Card2 cardType2 = new Card2();
        public byte[] bWriteData = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                              0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};

        private TabPage _tabRF;
        private TabPage _tabWiFi;
        private int _issueCount = 0;

        #region Form 이벤트
        public FormMain()
        {
            InitializeComponent();

            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbRoomNum1, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbRoomNum2, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbRoomNum3, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbSysID1, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbSysID2, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbSysID3, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbSysID4, autoInsertSpace: false);
            TextBoxHexHelper.AttachHexOnly_Force2Digits(tbSysID5, autoInsertSpace: false);
            tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
            tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";

#if !MANAGER_MODE
            string _guestIconPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "cardguest.ico");
            if (System.IO.File.Exists(_guestIconPath))
                this.Icon = new System.Drawing.Icon(_guestIconPath);
#endif
            tsLabelPGMMode.Text = G.pGMMode == PGMMode.Manager ? "관리자용" : "고객용";
            if(G.pGMMode == PGMMode.Guest)
            {
                tsBtnSettings.Visible = tsBtnInfo.Visible = false;
                if (!G.VerifyLicense(@"C:\TheMR\MifareTool\Guest\license.dat"))
                {
                    throw new Exception("LICENSE_FAIL");
                }
            }

            btnReadCard.Enabled = false;
            tsBtnReadAll.Enabled = false;
            btnWriteCard.Enabled = false;
            btnReadCard2.Enabled = false;
            btnWriteCard2.Enabled = false;            
            btnRemoveCard.Enabled = false;
            btnDisconnect.Enabled = false;

            RefreshReaders();

            _tabRF = tabControl1.TabPages[0];
            _tabWiFi = tabControl1.TabPages[1];
            rdoRF.Checked = true;
            rdoGuest.Checked = true;
            rdoWiFiGuest.Checked = true;

            cboDataBlock.Items.AddRange(new object[] { 0, 1, 2, 3 });
            this.cboDataSector.SelectedIndexChanged -= new System.EventHandler(this.cboDataSector_SelectedIndexChanged);
            cboDataSector.Items.AddRange(new object[] { 2, 15 });            
            this.cboDataSector.SelectedIndexChanged += new System.EventHandler(this.cboDataSector_SelectedIndexChanged);
            cboDataSector.SelectedIndex = G.nCardSector;           

            this.cboDataSector2.SelectedIndexChanged -= new System.EventHandler(this.cboDataSector2_SelectedIndexChanged);
            cboDataSector2.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            this.cboDataSector2.SelectedIndexChanged += new System.EventHandler(this.cboDataSector2_SelectedIndexChanged);

            this.cboDataBlock2.SelectedIndexChanged -= new System.EventHandler(this.cboDataBlock2_SelectedIndexChanged);
            cboDataBlock2.Items.AddRange(new object[] { 0, 1, 2, 3 });
            this.cboDataBlock2.SelectedIndexChanged += new System.EventHandler(this.cboDataBlock2_SelectedIndexChanged);

            string sCardSector = "";
            if (G.ReadRegCardSector2(ref sCardSector))
            {
                G.nCardSector2 = cboDataSector2.Items.IndexOf(Convert.ToInt32(sCardSector));
                cboDataSector2.SelectedIndex = G.nCardSector2;                
            }
            else
            {
                cboDataSector2.SelectedItem = G.nCardSector2;
            }
            if (G.ReadRegCardBlock2(ref sCardSector))
            {
                G.nCardBlock2 = cboDataBlock2.Items.IndexOf(Convert.ToInt32(sCardSector));
                cboDataBlock2.SelectedIndex = G.nCardBlock2;
            }
            else
            {
                cboDataBlock2.SelectedItem = G.nCardBlock2;
            }

            // 버전 정보 표시
            var asm = Assembly.GetExecutingAssembly(); // 또는 GetEntryAssembly()
            var asmName = asm.GetName();
            string assemblyVersion = asmName.Version.ToString(); // [assembly: AssemblyVersion]
            this.Text += $" [{assemblyVersion}]";

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            chkBoxOnlyEmptyCard.Visible = false;
            chkBoxOnlyEmptyCard.Checked = true;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            mifareDumpView1.FontScale = 0.8f;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCardMonitor();
        }
        #endregion

        #region 버튼, 라디오버튼 이벤트
        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            RefreshReaders();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboReaders.SelectedItem == null)
                {
                    Log("리더를 선택하세요.");
                    return;
                }

                _readerName = cboReaders.SelectedItem.ToString();

                _reader?.Dispose();
                _reader = new SCardReader(_context);

                var rc = _reader.Connect(_readerName, SCardShareMode.Shared, SCardProtocol.Any);
                if (rc != SCardError.Success)
                {
                    Log("Connect 실패: " + SCardHelper.StringifyError(rc));
                    return;
                }

                _activeProtocol = _reader.ActiveProtocol;
                Log($"Connect 성공: {_readerName} / Protocol={_activeProtocol}");

                // 카드 존재 확인 (선택 사항이지만 로그에 도움)
                var status = _reader.Status(out var readerName, out var state, out var protocol, out var atr);
                if (status == SCardError.Success)
                {
                    if(rdoRF.Checked)
                        ReadCard();
                    else
                        ReadCard2();
                    Log($"Card State={state}, ATR={BitConverter.ToString(atr ?? new byte[0])}");
                }

                StartCardMonitor(_readerName);

                btnReadCard.Enabled = true;
                tsBtnReadAll.Enabled = true;
                btnWriteCard.Enabled = true;
                btnReadCard2.Enabled = true;
                btnWriteCard2.Enabled = true;
                btnRemoveCard.Enabled = true;   
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                Log("Connect 예외: " + ex.Message);
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_reader != null)
                {
                    _reader.Disconnect(SCardReaderDisposition.Leave);
                    _reader.Dispose();
                    _reader = null;
                }
                btnReadCard.Enabled = false;
                tsBtnReadAll.Enabled = false;
                btnWriteCard.Enabled = false;
                btnReadCard2.Enabled = false;
                btnWriteCard2.Enabled = false;
                btnRemoveCard.Enabled = false;
                btnDisconnect.Enabled = false;
                Log("Disconnect 완료");
            }
            catch (Exception ex)
            {
                Log("Disconnect 예외: " + ex.Message);
            }
        }
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            if (!Reconnect())
                return;

            ReadCard();
        }
        private void btnWriteCard_Click(object sender, EventArgs e)
        {   
            WriteTmrCard(cardType);
        }
        private void btnRemoveCard_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ReadSectorBlockHex(2, 0));
            var result = MessageBox.Show(
                "정말 삭제하시겠습니까?",
                "확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                // Yes 눌렀을 때 처리
                WriteZeroToSectorBlock(G.nCardSector, 0);
            }
        }
        private void chkBoxAuto_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxAuto.Text = chkBoxAuto.Checked ? "자동" : "수동";
            chkBoxOnlyEmptyCard.Visible = chkBoxAuto.Checked;
        }
        #endregion

        private void RefreshReaders()
        {
            try
            {
                _context?.Dispose();
                _context = ContextFactory.Instance.Establish(SCardScope.System);

                var readers = _context.GetReaders();
                cboReaders.Items.Clear();

                if (readers == null || readers.Length == 0)
                {
                    Log("리더가 없습니다. (PC/SC 서비스 또는 드라이버 확인)");
                    return;
                }

                cboReaders.Items.AddRange(readers);
                cboReaders.SelectedIndex = 0;
                Log($"리더 검색됨: {string.Join(", ", readers)}");
            }
            catch (Exception ex)
            {
                Log("RefreshReaders 예외: " + ex.Message);
            }
        }
        private bool Reconnect()
        {
            try
            {
                // 1) 리더 선택 확인
                if (cboReaders.SelectedItem == null)
                {
                    Log("리더를 선택하세요.");
                    return false;
                }

                var selectedReaderName = cboReaders.SelectedItem.ToString();

                // 2) 기존 연결 정리 (Disconnect 로직 재사용)
                try
                {
                    if (_reader != null)
                    {
                        _reader.Disconnect(SCardReaderDisposition.Leave);
                        _reader.Dispose();
                        _reader = null;
                    }
                }
                catch (Exception ex2)
                {
                    // 정리 중 예외가 나도 재연결은 시도할 수 있으니 로그만 남김
                    Log("기존 연결 정리 중 예외: " + ex2.Message);
                }

                // 3) 잠깐 대기(선택) - PCSC 드라이버/리더가 상태 갱신할 시간
                System.Threading.Thread.Sleep(150);

                // 4) 새로 Connect (Connect 로직 재사용)
                _readerName = selectedReaderName;

                _reader = new SCardReader(_context);

                var rc = _reader.Connect(_readerName, SCardShareMode.Shared, SCardProtocol.Any);
                if (rc != SCardError.Success)
                {
                    Log("Reconnect 실패: " + SCardHelper.StringifyError(rc));
                    btnReadCard.Enabled = false;
                    tsBtnReadAll.Enabled = false;
                    btnWriteCard.Enabled = false; 
                    btnReadCard2.Enabled = false;
                    btnWriteCard2.Enabled = false;
                    btnRemoveCard.Enabled = false;
                    btnDisconnect.Enabled = false;
                    return false;
                }

                _activeProtocol = _reader.ActiveProtocol;
                Log($"Reconnect 성공: {_readerName} / Protocol={_activeProtocol}");

                // 5) 카드 상태/ATR 확인(로그 도움)
                var status = _reader.Status(out var readerName, out var state, out var protocol, out var atr);
                if (status == SCardError.Success)
                {
                    Log($"Card State={state}, ATR={BitConverter.ToString(atr ?? new byte[0])}");
                }

                // 6) UI 상태 갱신
                btnReadCard.Enabled = true;
                tsBtnReadAll.Enabled = true;
                btnWriteCard.Enabled = true;
                btnReadCard2.Enabled = true;
                btnWriteCard2.Enabled = true;
                btnRemoveCard.Enabled = true;
                btnDisconnect.Enabled = true;                
            }
            catch (Exception ex)
            {
                Log("Reconnect 예외: " + ex.Message);
                btnReadCard.Enabled = false;
                tsBtnReadAll.Enabled = false;
                btnWriteCard.Enabled = false;
                btnReadCard2.Enabled = false;
                btnWriteCard2.Enabled = false;
                btnRemoveCard.Enabled = false;
                btnDisconnect.Enabled = false;
                return false;
            }

            return true;    
        }
        private void ReadCard()
        {
            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return;
                }

                // (1) 카드 UID 읽기 (ACR122U Control APDU: FF CA 00 00 00)
                var uid = TransmitApdu(new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 });
                if (!uid.success)
                {
                    Log("UID 읽기 실패: " + uid.error);
                    return;
                }
                Log("CARD UID: " + BitConverter.ToString(uid.data));

                // (2) Key 로드 (Key 슬롯 0에 FFFFFFFFFFFF 로드)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }
                    .Concat(key).ToArray());

                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    Log("※ 기본키가 변경되었거나 카드가 MIFARE Classic이 아닐 수 있습니다.");
                    return;
                }
                Log("Load Key OK (FFFFFFFFFFFF)");

                // -----------------------------
                // A) Sector 0: Block 0 앞 2바이트 읽기
                // -----------------------------
                // Sector0 Trailer는 Block3이지만, Block0은 보통 읽기 가능
                // 필요 시 인증 후 읽기(아래처럼 인증 포함)
                byte blockForAuthSector0 = 0x00; // Sector0의 첫 블록
                var auth0 = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                             0x01, 0x00, blockForAuthSector0, 0x60, 0x00 });
                if (!auth0.success)
                {
                    Log("Sector0 Authenticate 실패: " + auth0.error);
                    return;
                }

                var readBlock0 = TransmitApdu(new byte[] { 0xFF, 0xB0, 0x00, 0x00, 0x10 }); // Block 0
                if (!readBlock0.success)
                {
                    Log("Sector0 Block0 Read 실패: " + readBlock0.error);
                    return;
                }

                // Block0의 앞 2바이트
                byte[] sector0_first2 = readBlock0.data.Take(2).ToArray();
                Log("Sector0(Block0) First 2 bytes: " + BitConverter.ToString(sector0_first2));

                // -----------------------------
                // B) Sector 2: Block 8(=Sector2의 Block0) 앞 12바이트 읽기
                // -----------------------------
                // Sector2의 첫 블록 번호 = 2 * 4 = 8
                byte sector2_firstBlock = (byte)(G.nCardSector * 4 + G.nCardBlock);// 0x08;

                var auth2 = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                             0x01, 0x00, sector2_firstBlock, 0x60, 0x00 });
                if (!auth2.success)
                {
                    Log($"Sector{G.nCardSector} Authenticate 실패: " + auth2.error);
                    Log($"※ Sector{G.nCardSector} KeyA가 FFFFFFFFFFFF가 아닐 수 있습니다.");
                    return;
                }

                var readBlock8 = TransmitApdu(new byte[] { 0xFF, 0xB0, 0x00, sector2_firstBlock, 0x10 }); // Block 8
                if (!readBlock8.success)
                {
                    Log($"Sector{G.nCardSector}(Block{G.nCardBlock}) Read 실패: " + readBlock8.error);
                    return;
                }

                // Block8의 앞 6바이트
                byte[] sector2_first6 = readBlock8.data.Take(6).ToArray();
                Log($"Sector{G.nCardSector}(Block{G.nCardBlock}) First 6 bytes: " + BitConverter.ToString(sector2_first6));

                // (선택) 필요하면 Hex 문자열로도 만들기
                string sUID = BitConverter.ToString(uid.data).Replace("-", "");
                string sSector2_12 = BitConverter.ToString(sector2_first6).Replace("-", "");

                var helper = new CardHelper();
                Card cardType = helper.GetTMRCardType(sUID.Substring(0, 2), sSector2_12);
                //lblResult.ForeColor = System.Drawing.Color.Yellow;
                if (cardType == Card.GUEST)
                    lblResult.Text = "고객키";
                else if (cardType == Card.CLEAN)
                    lblResult.Text = "청소키";
                else if (cardType == Card.CHECK)
                    lblResult.Text = "점검키";
                else if (cardType == Card.INSTALL)
                    lblResult.Text = "공정키";
                else
                    lblResult.Text = "빈 카드";

                //lblResult.Text = "CardType = " + cardType;
            }
            catch (Exception ex)
            {
                Log("ReadSector0 예외: " + ex.Message);
            }
        }
        private void ReadCard2()
        {
            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return;
                }

                // (1) 카드 UID 읽기 (ACR122U Control APDU: FF CA 00 00 00)
                var uid = TransmitApdu(new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 });
                if (!uid.success)
                {
                    Log("UID 읽기 실패: " + uid.error);
                    return;
                }
                Log("CARD UID: " + BitConverter.ToString(uid.data));
                tbCardSN.Text = BitConverter.ToString(uid.data).Replace("-", " ");

                // (2) Key 로드 (Key 슬롯 0에 FFFFFFFFFFFF 로드)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }
                    .Concat(key).ToArray());

                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    Log("※ 기본키가 변경되었거나 카드가 MIFARE Classic이 아닐 수 있습니다.");
                    return;
                }
                Log("Load Key OK (FFFFFFFFFFFF)");

                // -----------------------------
                // Sector 15: Block 61(=Sector15의 Block1) 앞 16바이트 읽기
                // -----------------------------
                // Sector15의 두번째 블록 번호 = 15 * 4 + 1
                //byte block61 = (byte)(15 * 4 + 1);
                byte block61 = (byte)(G.nCardSector2 * 4 + G.nCardBlock2);
                var auth2 = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                             0x01, 0x00, block61, 0x60, 0x00 });
                if (!auth2.success)
                {
                    Log($"Sector{G.nCardSector2} Authenticate 실패: " + auth2.error);
                    Log($"※ Sector{G.nCardSector2} KeyA가 FFFFFFFFFFFF가 아닐 수 있습니다.");
                    return;
                }

                var readBlock61 = TransmitApdu(new byte[] { 0xFF, 0xB0, 0x00, block61, 0x10 }); // Block 8
                if (!readBlock61.success)
                {
                    Log($"Sector{G.nCardSector2}(Block{G.nCardBlock2}) Read 실패: " + readBlock61.error);
                    return;
                }

                // Block15(Block61)의 앞 16바이트
                byte[] sector15_first16 = readBlock61.data.Take(16).ToArray();
                Log($"Sector{G.nCardSector2}(Block{G.nCardBlock2}) First 16 bytes: " + BitConverter.ToString(sector15_first16));

                // (선택) 필요하면 Hex 문자열로도 만들기
                string sBlock61_16 = BitConverter.ToString(sector15_first16).Replace("-", " ");
                tbData.Text = sBlock61_16;

                var helper = new CardHelper();
                var result = helper.GetTMRCardType2(sBlock61_16);
                //lblResult.ForeColor = System.Drawing.Color.White;
                if (result.cardType == Card2.EMPTY)
                {
                    lblResult.Text = "EMPTY";
                    //rdoWiFiEmpty.Checked = true;    
                }
                else if (result.cardType == Card2.GUEST)
                {
                    lblResult.Text = "GUEST";
                    //rdoWiFiGuest.Checked = true;
                }
                else if (result.cardType == Card2.STAFF)
                {
                    lblResult.Text = "STAFF";
                    //rdoWiFiStaff.Checked = true;
                }
                else if (result.cardType == Card2.URGENT)
                {
                    lblResult.Text = "URGENT";
                    //rdoWiFiUrgent.Checked = true;
                }
                else if (result.cardType == Card2.PASSWORD)
                {
                    lblResult.Text = "PASSWORD";
                    //rdoWiFiPassword.Checked = true;
                }
                else if (result.cardType == Card2.ROOMNUM)
                {
                    lblResult.Text = "ROOMNUM";
                    //rdoWiFiRoomNum.Checked = true;
                }

            }
            catch (Exception ex)
            {
                Log("ReadSector0 예외: " + ex.Message);
            }
        }
        private void WriteTmrCard(Card cardType)
        {
            if (!Reconnect())
                return;

            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return;
                }

                // (1) 카드 UID 읽기
                var uid = TransmitApdu(new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 });
                if (!uid.success)
                {
                    Log("UID 읽기 실패: " + uid.error);
                    return;
                }
                Log("CARD UID: " + BitConverter.ToString(uid.data));

                // (2) Key 로드 (슬롯 0에 FFFFFFFFFFFF)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }.Concat(key).ToArray());
                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    Log("※ 기본키가 변경되었거나 카드가 MIFARE Classic이 아닐 수 있습니다.");
                    return;
                }
                Log("Load Key OK (FFFFFFFFFFFF)");

                // (3) Sector2 첫 블록 = 8 (Block8) 인증
                byte block8 = (byte)(G.nCardSector * 4 + G.nCardBlock);// 0x08;
                var auth2 = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                              0x01, 0x00, block8, 0x60, 0x00 }); // KeyA(0x60), KeySlot=0
                if (!auth2.success)
                {
                    Log($"Sector{G.nCardSector} Authenticate 실패: " + auth2.error);
                    Log($"※ Sector{G.nCardSector} KeyA가 FFFFFFFFFFFF가 아닐 수 있습니다.");
                    return;
                }

                // (4) 카드 타입 데이터 생성 (32 hex chars = 16 bytes)
                var helper = new CardHelper();
                string payloadHex = helper.SetTMRCardType(cardType, uid.data);
                if (string.IsNullOrWhiteSpace(payloadHex) || payloadHex.Length != 32)
                {
                    Log($"Payload 생성 실패 또는 길이 오류: len={payloadHex?.Length ?? 0}, payload={payloadHex}");
                    return;
                }

                byte[] payload = HexToBytes(payloadHex);

                // (5) Block8에 16바이트 Write
                // FF D6 00 <BlockNo> 10 <16 bytes>
                var write = TransmitApdu(new byte[] { 0xFF, 0xD6, 0x00, block8, 0x10 }
                                            .Concat(payload).ToArray());

                if (!write.success)
                {
                    Log($"Block{G.nCardSector * 4 + G.nCardBlock} Write 실패: " + write.error);
                    return;
                }

                //Log($"Block8 Write OK / CardType={cardType} / Data={payloadHex}");

                Beep();
                _issueCount++;
                lblCounter.Text = _issueCount.ToString();

                // (선택) 검증 Read-back
                var readBack = TransmitApdu(new byte[] { 0xFF, 0xB0, 0x00, block8, 0x10 });
                if (readBack.success)
                {
                    Log($"Read-back Block{G.nCardSector * 4 + G.nCardBlock}: " + BitConverter.ToString(readBack.data));
                }

                // (선택) 라벨 표시
                if (cardType == Card.GUEST)
                    lblResult.Text = "고객키";
                else if (cardType == Card.CLEAN)
                    lblResult.Text = "청소키";
                else if (cardType == Card.CHECK)
                    lblResult.Text = "점검키";
                else if (cardType == Card.INSTALL)
                    lblResult.Text = "공정키";
                //lblResult.Text = $"WRITE OK : {cardType}";
            }
            catch (Exception ex)
            {
                Log("WriteCard 예외: " + ex.Message);
            }
        }
        private void WriteTmrCard2(Card2 cardType)
        {
            if (!Reconnect())
                return;

            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return;
                }

                // (1) 카드 UID 읽기
                var uid = TransmitApdu(new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 });
                if (!uid.success)
                {
                    Log("UID 읽기 실패: " + uid.error);
                    return;
                }
                Log("CARD UID: " + BitConverter.ToString(uid.data));

                // (2) Key 로드 (슬롯 0에 FFFFFFFFFFFF)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }.Concat(key).ToArray());
                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    Log("※ 기본키가 변경되었거나 카드가 MIFARE Classic이 아닐 수 있습니다.");
                    return;
                }
                Log("Load Key OK (FFFFFFFFFFFF)");

                // (3) Sector15 두번째 블록 = 61 (Block61) 인증
                //byte block61 = (byte)(15 * 4 + 1);
                byte block61 = (byte)(G.nCardSector2 * 4 + G.nCardBlock2);
                var auth2 = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                              0x01, 0x00, block61, 0x60, 0x00 }); // KeyA(0x60), KeySlot=0
                if (!auth2.success)
                {
                    Log($"Sector{G.nCardSector2} Authenticate 실패: " + auth2.error);
                    Log($"※ Sector{G.nCardSector2} KeyA가 FFFFFFFFFFFF가 아닐 수 있습니다.");
                    return;
                }

                // (5) Block618에 16바이트 Write
                // FF D6 00 <BlockNo> 10 <16 bytes>
                var write = TransmitApdu(new byte[] { 0xFF, 0xD6, 0x00, block61, 0x10 }
                                            .Concat(bWriteData).ToArray());

                if (!write.success)
                {
                    Log($"Block{G.nCardSector2 * 4 + G.nCardBlock2} Write 실패: " + write.error);
                    return;
                }

                //Log($"Block8 Write OK / CardType={cardType} / Data={payloadHex}");

                Beep();
                _issueCount++;
                lblCounter.Text = _issueCount.ToString();

                // (선택) 검증 Read-back
                var readBack = TransmitApdu(new byte[] { 0xFF, 0xB0, 0x00, block61, 0x10 });
                if (readBack.success)
                {
                    Log($"Read-back Block{G.nCardSector2 * 4 + G.nCardBlock2}: " + BitConverter.ToString(readBack.data));
                }

                if (cardType == Card2.EMPTY)
                {
                    lblResult.Text = "EMPTY";
                    //rdoWiFiEmpty.Checked = true;
                }
                else if (cardType == Card2.GUEST)
                {
                    lblResult.Text = "GUEST";
                    //rdoWiFiGuest.Checked = true;
                }
                else if (cardType == Card2.STAFF)
                {
                    lblResult.Text = "STAFF";
                    //rdoWiFiStaff.Checked = true;
                }
                else if (cardType == Card2.URGENT)
                {
                    lblResult.Text = "URGENT";
                    //rdoWiFiUrgent.Checked = true;
                }
                else if (cardType == Card2.PASSWORD)
                {
                    lblResult.Text = "PASSWORD";
                    //rdoWiFiPassword.Checked = true;
                }
                else if (cardType == Card2.ROOMNUM)
                {
                    lblResult.Text = "ROOMNUM";
                    //rdoWiFiRoomNum.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Log("WriteCard 예외: " + ex.Message);
            }
        }
        private void StartCardMonitor(string readerName)
        {
            StopCardMonitor();

            _monitor = new SCardMonitor(ContextFactory.Instance, SCardScope.System);

            _monitor.CardInserted += (s, e) => BeginInvoke(new Action(() =>
            {
                Log($"[EVENT] Card가 리더기에 올려졌습니다.: {e.ReaderName}");
                if (rdoRF.Checked)
                {
                    if (chkBoxAuto.Checked &&
                        (!chkBoxOnlyEmptyCard.Checked || IsSectorBlockAllZero(G.nCardSector, G.nCardBlock)))
                    {
                        WriteTmrCard(cardType);
                    }
                    ReadCard();
                }
                else
                {
                    if (chkBoxAuto.Checked &&
                        (!chkBoxOnlyEmptyCard.Checked || IsSectorBlockAllZero(G.nCardSector2, G.nCardBlock2)))
                    {
                        WriteTmrCard2(cardType2);
                    }
                    ReadCard2();
                }
            }));

            _monitor.CardRemoved += (s, e) => BeginInvoke(new Action(() =>
            {
                Log($"[EVENT] Card가 리더기에서 제거됐습니다.: {e.ReaderName}");
            }));

            _monitor.MonitorException += (s, e) => BeginInvoke(new Action(() =>
            {
                Log("[MONITOR] Exception: " + e.Message);
            }));

            _monitor.Start(readerName);
        }
        private void StopCardMonitor()
        {
            try
            {
                if (_monitor != null)
                {
                    _monitor.Cancel();
                    _monitor.Dispose();
                    _monitor = null;
                    Log("[MONITOR] Stopped");
                }
            }
            catch (Exception ex)
            {
                Log("[MONITOR] Stop 예외: " + ex.Message);
            }
        }

        #region 카드의 섹터, 블럭을 읽고, 쓰는 함수
        private void Log(string msg)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
        }
        // Hex 문자열(예: "0A1B...") -> byte[]
        private static byte[] HexToBytes(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");
            if (hex.Length % 2 != 0) throw new ArgumentException("hex length must be even");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);

            return bytes;
        }
        private void Beep()
        {
            // FF 00 40 P2 04 T1 T2 Rep Link
            // P2=00, T1=03(300ms), T2=00, Rep=01, Link=01(부저)
            var beep = TransmitApdu(new byte[] { 0xFF, 0x00, 0x40, 0x00, 0x04, 0x03, 0x00, 0x01, 0x01 });

            //if (!beep.success)
            //    Log("Beep(Transmit) 실패: " + beep.error);
            //else
            //    Log("Beep(Transmit) OK");
        }
        /// <summary>
        /// ACR122U는 일반 APDU(FF xx ...)를 지원합니다. 여기서는 raw APDU transmit만 사용합니다.
        /// 응답의 마지막 2바이트(SW1 SW2)를 검사합니다. (예: 90 00 성공)
        /// </summary>
        private (bool success, byte[] data, string error) TransmitApdu(byte[] apdu)
        {
            try
            {
                // PCSC 5.x 방식: receiveBuffer는 ref byte[] 로 전달
                // 적당히 크게 잡아두면 라이브러리가 필요한 길이로 채워줍니다.
                byte[] recv = new byte[258];

                var rc = _reader.Transmit(apdu, ref recv);
                if (rc != SCardError.Success)
                    return (false, Array.Empty<byte>(), "Transmit 실패: " + SCardHelper.StringifyError(rc));

                if (recv == null || recv.Length < 2)
                    return (false, Array.Empty<byte>(), "응답 길이 부족");

                byte sw1 = recv[recv.Length - 2];
                byte sw2 = recv[recv.Length - 1];

                if (sw1 == 0x90 && sw2 == 0x00)
                {
                    var data = recv.Take(recv.Length - 2).ToArray();
                    return (true, data, "");
                }

                return (false, Array.Empty<byte>(), $"SW={sw1:X2} {sw2:X2}");
            }
            catch (Exception ex)
            {
                return (false, Array.Empty<byte>(), "예외: " + ex.Message);
            }
        }
        /// <summary>
        /// MIFARE Classic 1K: 특정 (섹터, 섹터내 블록인덱스)를 0x00(16바이트)로 덮어쓰기.
        /// sector: 0~15
        /// blockIndexInSector: 0~3 (3은 트레일러 블록)
        /// </summary>
        public bool WriteZeroToSectorBlock(int sector, int blockIndexInSector, bool allowTrailerBlock = false)
        {
            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return false;
                }

                // 범위 체크 (1K 기준)
                if (sector < 0 || sector > 15)
                {
                    Log("Sector 범위 오류 (0~15).");
                    return false;
                }
                if (blockIndexInSector < 0 || blockIndexInSector > 3)
                {
                    Log("BlockIndex 범위 오류 (0~3).");
                    return false;
                }

                // 실제 블록 번호 계산
                byte blockNo = (byte)(sector * 4 + blockIndexInSector);

                // 안전장치: Sector0 Block0은 절대 쓰기 금지
                if (sector == 0 && blockIndexInSector == 0)
                {
                    Log("Sector0 Block0(제조사 블록)은 쓰기 금지입니다.");
                    return false;
                }

                // 트레일러 블록(키/접근조건) 보호
                if (blockIndexInSector == 3 && !allowTrailerBlock)
                {
                    Log("트레일러 블록(Block 3)은 키/접근조건 영역입니다. allowTrailerBlock=true일 때만 허용됩니다.");
                    return false;
                }

                // 1) Key 로드 (슬롯 0에 FFFFFFFFFFFF)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }.Concat(key).ToArray());
                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    return false;
                }

                // 2) 인증 (KeyA=0x60, KeySlot=0)
                var auth = TransmitApdu(new byte[] { 0xFF, 0x86, 0x00, 0x00, 0x05,
                                             0x01, 0x00, blockNo, 0x60, 0x00 });
                if (!auth.success)
                {
                    Log($"Authenticate 실패 (Sector={sector}, BlockIdx={blockIndexInSector}, BlockNo={blockNo}): " + auth.error);
                    return false;
                }

                // 3) 16바이트 0x00 Write
                byte[] zeros = new byte[16];
                var write = TransmitApdu(new byte[] { 0xFF, 0xD6, 0x00, blockNo, 0x10 }
                                            .Concat(zeros).ToArray());
                if (!write.success)
                {
                    Log($"Write 실패 (BlockNo={blockNo}): " + write.error);
                    return false;
                }

                Log($"WriteZero OK (Sector={sector}, BlockIdx={blockIndexInSector}, BlockNo={blockNo})");

                Beep();

                return true;
            }
            catch (Exception ex)
            {
                Log("WriteZero 예외: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// MIFARE Classic 1K 기준
        /// sector: 0~15
        /// blockIndexInSector: 0~3
        /// return: 16바이트 HEX 문자열 (예: "11223344AABB...")
        /// </summary>
        public string ReadSectorBlockHex(int sector, int blockIndexInSector)
        {
            try
            {
                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return null;
                }

                // 범위 체크
                if (sector < 0 || sector > 15)
                {
                    Log("Sector 범위 오류 (0~15)");
                    return null;
                }

                if (blockIndexInSector < 0 || blockIndexInSector > 3)
                {
                    Log("BlockIndex 범위 오류 (0~3)");
                    return null;
                }

                // 실제 블록 번호 계산
                byte blockNo = (byte)(sector * 4 + blockIndexInSector);

                Reconnect();

                // 1️⃣ Key 로드 (슬롯0, 기본키)
                byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                var loadKey = TransmitApdu(
                    new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }
                    .Concat(key).ToArray());

                if (!loadKey.success)
                {
                    Log("Load Key 실패: " + loadKey.error);
                    return null;
                }

                // 2️⃣ 인증 (KeyA=0x60, KeySlot=0)
                var auth = TransmitApdu(new byte[] {
                    0xFF, 0x86, 0x00, 0x00, 0x05,
                    0x01, 0x00, blockNo, 0x60, 0x00
                });

                if (!auth.success)
                {
                    Log($"Authenticate 실패 (BlockNo={blockNo}): " + auth.error);
                    return null;
                }

                // 3️⃣ 16바이트 Read
                var read = TransmitApdu(new byte[] {
                    0xFF, 0xB0, 0x00, blockNo, 0x10
                });

                if (!read.success)
                {
                    Log($"Read 실패 (BlockNo={blockNo}): " + read.error);
                    return null;
                }

                // 4️⃣ HEX 문자열 변환
                string hex = BitConverter.ToString(read.data).Replace("-", "");
                Log($"Read OK (Sector={sector}, BlockIdx={blockIndexInSector}) : {hex}");

                return hex;
            }
            catch (Exception ex)
            {
                Log("ReadSectorBlockHex 예외: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 특정 섹터의 블록(기본: 0~2)이 모두 0x00인지 검사
        /// sector: 0~15 (MIFARE Classic 1K 기준)
        /// includeTrailerBlock: true면 블록3(트레일러)까지 포함
        /// </summary>
        public bool IsSectorAllZero(int sector, bool includeTrailerBlock = false)
        {
            // 검사할 블록 인덱스 범위
            int lastBlockIdx = includeTrailerBlock ? 3 : 2;

            for (int blockIdx = 0; blockIdx <= lastBlockIdx; blockIdx++)
            {
                // (선택) Sector0 Block0은 체크할지 말지 정책 결정 가능
                // 여기서는 "검사"는 허용(읽기 가능)
                // if (sector == 0 && blockIdx == 0) continue;

                string hex = ReadSectorBlockHex(sector, blockIdx); // 16바이트 HEX(32 chars) 기대
                if (hex == null)
                {
                    // 읽기 실패면 "0인지 확인 불가" -> false 처리
                    return false;
                }

                // 공백/하이픈 제거 후 비교
                hex = hex.Replace("-", "").Replace(" ", "").ToUpperInvariant();

                // 16바이트면 32 hex chars
                // 길이가 다르면 데이터 이상(또는 read 길이 문제) -> false
                if (hex.Length != 32)
                    return false;

                // 전부 0인지 체크
                // 빠른 체크: 32개 문자가 모두 '0'인지
                for (int i = 0; i < hex.Length; i++)
                {
                    if (hex[i] != '0')
                        return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 지정한 (sector, blockIndexInSector)의 16바이트가 모두 0x00인지 확인
        /// sector: 0~15 (MIFARE Classic 1K 기준)
        /// blockIndexInSector: 0~3
        /// </summary>
        public bool IsSectorBlockAllZero(int sector, int blockIndexInSector)
        {
            // 1) 범위 체크
            if (sector < 0 || sector > 15) return false;
            if (blockIndexInSector < 0 || blockIndexInSector > 3) return false;

            // 2) 블록 읽기 (HEX 문자열: 32 chars 기대)
            string hex = ReadSectorBlockHex(sector, blockIndexInSector);
            if (string.IsNullOrEmpty(hex))
                return false;

            hex = hex.Replace("-", "").Replace(" ", "").ToUpperInvariant();
            if (hex.Length != 32) // 16 bytes = 32 hex chars
                return false;

            // 3) 모두 '0'인지 검사
            for (int i = 0; i < hex.Length; i++)
            {
                if (hex[i] != '0')
                    return false;
            }

            return true;
        }

        #endregion

        private void rdoCardType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGuest.Checked)
                cardType = Card.GUEST;
            else if (rdoClean.Checked)
                cardType = Card.CLEAN;
            else if (rdoCheck.Checked)
                cardType = Card.CHECK;
            else if (rdoInstall.Checked)
                cardType = Card.INSTALL;
        }

        private void tsBtnInfo_Click(object sender, EventArgs e)
        {
            //var frmPwd = new FrmPasswd(); FormPCInfo
            //if (frmPwd.ShowDialog() != DialogResult.OK) return;

            FormInfo form = new FormInfo(this);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void tsBtnSettings_Click(object sender, EventArgs e)
        {
            ////var frmPwd = new FrmPasswd();
            ////if (frmPwd.ShowDialog() != DialogResult.OK) return;

            FormSettings form = new FormSettings();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void cboDataSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.nCardSector = Convert.ToInt16(cboDataSector.Text);
            cboDataBlock.SelectedIndex = cboDataSector.SelectedIndex == 0 ? 0 : 1;    
            G.nCardBlock = cboDataSector.SelectedIndex == 0 ? 0 : 1;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadCard2_Click(object sender, EventArgs e)
        {
            if (!Reconnect())
                return;

            ReadCard2();
        }

        private void btnWriteCard2_Click(object sender, EventArgs e)
        {
            WriteTmrCard2(cardType2);
        }

        private void rdoCardType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWiFiEmpty.Checked)
                ChangeCardType2(Card2.EMPTY);
            else if (rdoWiFiGuest.Checked)
                ChangeCardType2(Card2.GUEST);
            else if (rdoWiFiStaff.Checked)
                ChangeCardType2(Card2.STAFF);
            else if (rdoWiFiUrgent.Checked)
                ChangeCardType2(Card2.URGENT);
            else if (rdoWiFiPassword.Checked)
                ChangeCardType2(Card2.PASSWORD);
            else if (rdoWiFiRoomNum.Checked)
                ChangeCardType2(Card2.ROOMNUM);
        }
        private void ChangeCardType2(Card2 cardType)
        {
            cardType2 = cardType;
            if (cardType2 == Card2.EMPTY)
            {
                //tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = false;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = false;

                bWriteData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                          0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
                tbData.Text = HexText.ToHexSpaceString(bWriteData); 
            }
            else if (cardType2 == Card2.GUEST)
            {
                //tbRoomNum1.Text = tbRoomNum3.Text = "00";
                //tbRoomNum2.Text = "01";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = true;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = true;

                bWriteData = new byte[] { 
                    0xC1, 
                    HexText.HexStringToByteArray(tbRoomNum1.Text)[0],
                    HexText.HexStringToByteArray(tbRoomNum2.Text)[0],
                    HexText.HexStringToByteArray(tbRoomNum3.Text)[0],
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    HexText.HexStringToByteArray(tbSysID1.Text)[0],
                    HexText.HexStringToByteArray(tbSysID2.Text)[0],
                    HexText.HexStringToByteArray(tbSysID3.Text)[0],
                    HexText.HexStringToByteArray(tbSysID4.Text)[0],
                    HexText.HexStringToByteArray(tbSysID5.Text)[0]};
                tbData.Text = HexText.ToHexSpaceString(bWriteData);
            }
            else if (cardType2 == Card2.STAFF)
            {
                //tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = false;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = true;

                bWriteData = new byte[] {
                    0xC2,
                    0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    HexText.HexStringToByteArray(tbSysID1.Text)[0],
                    HexText.HexStringToByteArray(tbSysID2.Text)[0],
                    HexText.HexStringToByteArray(tbSysID3.Text)[0],
                    HexText.HexStringToByteArray(tbSysID4.Text)[0],
                    HexText.HexStringToByteArray(tbSysID5.Text)[0]};
                tbData.Text = HexText.ToHexSpaceString(bWriteData);
            }
            else if (cardType2 == Card2.URGENT)
            {
                //tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = false;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = true;

                bWriteData = new byte[] {
                    0xC3,
                    0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    HexText.HexStringToByteArray(tbSysID1.Text)[0],
                    HexText.HexStringToByteArray(tbSysID2.Text)[0],
                    HexText.HexStringToByteArray(tbSysID3.Text)[0],
                    HexText.HexStringToByteArray(tbSysID4.Text)[0],
                    HexText.HexStringToByteArray(tbSysID5.Text)[0]};
                tbData.Text = HexText.ToHexSpaceString(bWriteData);
            }
            else if (cardType2 == Card2.PASSWORD)
            {
                //tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = false;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = true;

                bWriteData = new byte[] {
                    0xC4,
                    0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    HexText.HexStringToByteArray(tbSysID1.Text)[0],
                    HexText.HexStringToByteArray(tbSysID2.Text)[0],
                    HexText.HexStringToByteArray(tbSysID3.Text)[0],
                    HexText.HexStringToByteArray(tbSysID4.Text)[0],
                    HexText.HexStringToByteArray(tbSysID5.Text)[0]};
                tbData.Text = HexText.ToHexSpaceString(bWriteData);
            }
            else if (cardType2 == Card2.ROOMNUM)
            {
                //tbRoomNum1.Text = tbRoomNum2.Text = tbRoomNum3.Text = "00";
                //tbSysID1.Text = tbSysID2.Text = tbSysID3.Text = tbSysID4.Text = tbSysID5.Text = "FF";
                tbRoomNum1.Enabled = tbRoomNum2.Enabled = tbRoomNum3.Enabled = true;
                tbSysID1.Enabled = tbSysID2.Enabled = tbSysID3.Enabled = tbSysID4.Enabled = tbSysID5.Enabled = false;

                bWriteData = new byte[] {
                    0xC5,
                    HexText.HexStringToByteArray(tbRoomNum1.Text)[0],
                    HexText.HexStringToByteArray(tbRoomNum2.Text)[0],
                    HexText.HexStringToByteArray(tbRoomNum3.Text)[0],
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00,};
                tbData.Text = HexText.ToHexSpaceString(bWriteData);
            }
        }

        private void tbCard2_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as System.Windows.Forms.TextBox;
            if (tb.Text == "")
            {
                tb.Text = "00";
                return;
            }
                
            rdoCardType2_CheckedChanged(null, null);
        }

        private void cboDataSector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.nCardSector2 = Convert.ToInt32(cboDataSector2.Text);
            G.WriteRegCardSector2(G.nCardSector2.ToString());
        }

        private void cboDataBlock2_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.nCardBlock2 = Convert.ToInt32(cboDataBlock2.Text);
            G.WriteRegCardBlock2(G.nCardBlock2.ToString());
        }

        private void rdoRF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRF.Checked)
            {
                // 현재 선택 탭이 숨길 탭이면 먼저 선택 이동
                if (tabControl1.SelectedTab == _tabWiFi)
                    tabControl1.SelectedTab = _tabRF;

                tabControl1.ShowTab(_tabRF);
                tabControl1.HideTab(_tabWiFi);
                tabControl1.SelectedTab = _tabRF;
            }
            else
            {
                if (tabControl1.SelectedTab == _tabRF)
                    tabControl1.SelectedTab = _tabWiFi;

                tabControl1.ShowTab(_tabWiFi);
                tabControl1.HideTab(_tabRF);
                tabControl1.SelectedTab = _tabWiFi;
            }
        }

        private void tsBtnReadAll_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!Reconnect())
                //    return;

                if (_reader == null)
                {
                    Log("먼저 Connect 하세요.");
                    return;
                }

                var helper = new MifareReaderHelper(TransmitApdu, Log);
                var dump = helper.ReadClassic1KDump();

                mifareDumpView1.DumpData = dump;
            }
            catch (Exception ex)
            {
                Log("전체 Dump 읽기 예외: " + ex.Message);
            }
        }

        private void chkBoxOnlyEmptyCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxOnlyEmptyCard.Checked)
            {
                chkBoxOnlyEmptyCard.Text = "빈 카드인 경우만 허용";
                chkBoxOnlyEmptyCard.ForeColor = Color.Blue;
            }
            else
            {
                chkBoxOnlyEmptyCard.Text = "빈 카드가 아니더라도 발급 허용";
                chkBoxOnlyEmptyCard.ForeColor = Color.Red;
            }
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            _issueCount = 0;
            lblCounter.Text = "0";
        }
    }
}
