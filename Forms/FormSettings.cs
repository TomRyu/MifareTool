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

namespace MifareTool
{
    public partial class FormSettings : Form
    {
        #region Form 생성자
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            //tbExcelFolder.Text = G.sExcelFolder; 
            //tbImageFolder.Text = G.sImageFolder;
            //tbDBConn.Text = G.sDBConn;
            //tbServerLPRConn.Text = G.sServerLPRConn;
            //tbServerLPRHealthCheck.Text = G.sServerLPRHealthCheck;
            //tbTestImageFolder.Text = G.sampleImg;
            //chkBoxTestMode.Checked = G.bUseImgTest;
            //nudLimitOfRows.Value = G.nLimitOfRows;
            //nudHCTimeOut.Value = G.nHealthCheckTimeOut;
            //
            G.sPrivateKey = "";
            if (G.ReadRegPrivateKeyPath(ref G.sPrivateKey))
                tbPrivate_key.Text = G.sPrivateKey;
            G.sLicense = "";
            if (G.ReadRegLicensePath(ref G.sLicense))
                tbLicense.Text = G.sLicense;

            //USB인증 시, 복원
            //RefreshUsbCombo();
        }
        #endregion

        private void RefreshUsbCombo()
        {
            var drives = UsbDriveService.GetRemovableUsbDrives();

            cboUsbDrives.DisplayMember = "DisplayText"; // 보여줄 값
            cboUsbDrives.ValueMember = "DriveRoot";     // 내부 값(드라이브 루트)
            cboUsbDrives.DataSource = drives;

            if (drives.Count == 0)
            {
                cboUsbDrives.Text = "";
                MessageBox.Show("연결된 USB(이동식) 드라이브가 없습니다.",
                                "에러",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #region ToolStripButton
        private void tsBtnSave_Click(object sender, EventArgs e)
        {   
            //G.sExcelFolder = tbExcelFolder.Text;
            //G.iniData["SYSTEM"]["EXCEL_FOLDER"] = tbExcelFolder.Text;

            //G.sImageFolder = tbImageFolder.Text;
            //G.iniData["SYSTEM"]["IMAGE_FOLDER"] = tbImageFolder.Text;

            //G.sDBConn = tbDBConn.Text;
            //G.iniData["SYSTEM"]["DB_CONN"] = tbDBConn.Text;

            //G.sServerLPRConn = tbServerLPRConn.Text;
            //G.iniData["SYSTEM"]["LPR_CONN"] = tbServerLPRConn.Text;

            //G.sServerLPRHealthCheck = tbServerLPRHealthCheck.Text;
            //G.iniData["SYSTEM"]["LPR_HEALTH_CHECK"] = tbServerLPRHealthCheck.Text;

            //G.sampleImg = tbTestImageFolder.Text;
            //G.iniData["SYSTEM"]["TEST_IMAGE_FOLDER"] = tbTestImageFolder.Text;
            //G.seq = new FilePathSequencer(G.sampleImg, "*.jpg",
            //            recursive: false, sortBy: SortBy.CreationTime);

            //G.bUseImgTest = chkBoxTestMode.Checked;
            //G.iniData["SYSTEM"]["USE_IMAGE_TEST"] = G.bUseImgTest ? "YES" : "NO";

            //G.nLimitOfRows = (int)nudLimitOfRows.Value;
            //G.iniData["SYSTEM"]["LIMIT_OF_ROWS"] = G.nLimitOfRows.ToString();

            //G.nHealthCheckTimeOut = (int)nudHCTimeOut.Value;
            //G.iniData["SYSTEM"]["HEALTH_CHECK_TIME_OUT"] = G.nHealthCheckTimeOut.ToString();

            //G.parser.WriteFile(G.iniPath, G.iniData, Encoding.UTF8);
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 텍스트박스: 엔터키로 포커스 이동, 숫자만 입력
        public bool NextFocus(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                return true;
            }
            return false;
        }
        private void nextFocus_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = NextFocus(sender, e);
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링             
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리             
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 함수
        private bool Check_MakeLicenseDat()
        {
            if (string.IsNullOrWhiteSpace(tbPrivate_key.Text))
            {
                MessageBox.Show("tbPrivate_key.pem가 있는 Path를 지정하세요",
                                "license.dat 생성",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbLicense.Text))
            {
                MessageBox.Show("license.dat가 생성될 Path를 지정하세요!",
                                "license.dat 생성",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (tbCpuProcessorId.Text.Length == 0)
            {
                MessageBox.Show("CPU Processor ID 정보가 없습니다!",
                                "license.dat 생성",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            //if (tbMotherboardUuid.Text.Length == 0)
            //{
            //    MessageBox.Show("MotherBoard UUID 정보가 없습니다!",
            //                    "license.dat 생성",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return false;
            //}

            //USB인증 시, 복원===========================================
            //var item = cboUsbDrives.SelectedItem as UsbDriveItem;
            //if (item == null)
            //{
            //    MessageBox.Show("USB메모리를 연결하세요!",
            //                    "license.dat 생성",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return false;
            //}

            //btnUSBVolume.PerformClick();
            //btnPNP.PerformClick();
            //if (tbUSBVolume.Text.Length == 0)
            //{
            //    MessageBox.Show("USB메모리 볼륨정보가 없습니다!",
            //                    "license.dat 생성",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return false;
            //}
            //if (tbPNPHash.Text.Length == 0)
            //{
            //    MessageBox.Show("USB메모리 PNP정보가 없습니다!",
            //                    "license.dat 생성",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return false;
            //}
            //============================================================

            return true;
        }

        private bool Check_USB()
        {
            var item = cboUsbDrives.SelectedItem as UsbDriveItem;
            if (item == null)
            {
                MessageBox.Show("USB메모리를 연결하세요!",
                                "라이센스USB 테스트",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// private_key.pem (PKCS#8 또는 PKCS#1)에서 RSA 개인키 로드
        /// </summary>
        static RSA LoadRsaPrivateKeyFromPem(string pemPath)
        {
            if (!File.Exists(pemPath))
                throw new FileNotFoundException("private_key.pem not found", pemPath);

            using (var reader = File.OpenText(pemPath))
            {
                var pemReader = new PemReader(reader);
                object keyObj = pemReader.ReadObject();

                AsymmetricKeyParameter privKeyParam;

                if (keyObj is AsymmetricCipherKeyPair pair)
                    privKeyParam = pair.Private;
                else if (keyObj is AsymmetricKeyParameter akp && akp.IsPrivate)
                    privKeyParam = akp;
                else
                    throw new InvalidOperationException("PEM에서 개인키를 읽지 못했습니다.");

                var rsaPriv = (RsaPrivateCrtKeyParameters)privKeyParam;
                RSAParameters rp = DotNetUtilities.ToRSAParameters(rsaPriv);

                var rsa = RSA.Create();
                rsa.ImportParameters(rp);
                return rsa;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                var privatePem = PemExport.ExportPrivateKeyPem(rsa);
                var publicPem = PemExport.ExportPublicKeyPem(rsa);
            }
        }
        private void btnMakeLicenseDat_Click(object sender, EventArgs e)
        {
            if (!Check_MakeLicenseDat())
                return;

            // 1) 입력 경로
            string privatePemPath = $"{tbPrivate_key.Text}\\private_key.pem";
            string outputLicensePath = $"{tbLicense.Text}\\license.dat"; 

            // 2) payload 구성 (예시)
            var payloadObj = new
            {
                product = "PMS-Pro",
                customer = "OO시청",
                licenseId = "LIC-2026-000123",
                issuedAtUtc = DateTime.UtcNow.ToString("o"),
                expiresAtUtc = new DateTime(2027, 2, 14, 0, 0, 0, DateTimeKind.Utc).ToString("o"),
                features = new[] { "LPR", "KIOSK", "REPORT" },

                // USB 바인딩(예시) - 대표님이 실제 USB의 값으로 채우면 됨
                //usbBind = new
                //{
                //    volumeSerial = tbUSBVolume.Text,
                //    pnpIdHash = tbPNPHash.Text
                //},
                pcInfoBind = new
                {
                    motherboardUuid = "",
                    cpuProcessorId = tbCpuProcessorId.Text
                }
            };

            // 3) payload JSON -> bytes
            var jss = new JavaScriptSerializer();
            string payloadJson = jss.Serialize(payloadObj);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

            // 4) RSA private key 로드
            using (RSA rsa = G.LoadRsaPrivateKeyFromPem(privatePemPath))
            {
                // 5) payload 서명(RSA-SHA256)
                byte[] sig = rsa.SignData(payloadBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                // 6) envelope 생성
                var envelope = new
                {
                    ver = 1,
                    alg = "RSA-SHA256",
                    payload_b64 = Convert.ToBase64String(payloadBytes),
                    sig_b64 = Convert.ToBase64String(sig)
                };

                string licenseDatJson = jss.Serialize(envelope);

                // 7) 저장
                Directory.CreateDirectory(Path.GetDirectoryName(outputLicensePath));
                File.WriteAllText(outputLicensePath, licenseDatJson, Encoding.UTF8);
            }
            MessageBox.Show("license.dat 파일 생성 성공!",
                            "license.dat 생성",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            //Console.WriteLine("OK: license.dat 생성 완료");
            //Console.WriteLine(outputLicensePath);
        }
        
        private void btnUSBVolume_Click(object sender, EventArgs e)
        {
            var item = cboUsbDrives.SelectedItem as UsbDriveItem;
            if (item == null) return;

            //MessageBox.Show(
            //    $"Drive: {item.DriveRoot}\nLabel: {item.VolumeLabel}\nSerial: {item.SerialHex}",
            //    "선택된 USB"
            //);
            

            string serialHex = VolumeSerialUtil.GetVolumeSerialHex(item.DriveRoot);
            if (serialHex != null)
                tbUSBVolume.Text = serialHex;
        }

        private void btnPNP_Click(object sender, EventArgs e)
        {
            var item = cboUsbDrives.SelectedItem as UsbDriveItem;
            if (item == null) return;

            //MessageBox.Show(
            //    $"Drive: {item.DriveRoot}\nLabel: {item.VolumeLabel}\nSerial: {item.SerialHex}",
            //    "선택된 USB"
            //);
            string driveLetter = item.DriveRoot.Substring(0, 1);
            string pnp = UsbPnPHash.GetPnPDeviceIdForDrive(driveLetter);
            string pnpHash = UsbPnPHash.GetPnPIdHashForDrive(driveLetter);
            tbPNP.Text = pnp;
            tbPNPHash.Text = pnpHash;
        }

        private void btnSelectFolderP_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.InitialDirectory = tbPrivate_key.Text;
            dlg.IsFolderPicker = true; // true면 폴더 선택 false면 파일 선택

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // dlg.FileName
                //Get the path of specified file
                //webBrowser1.Url = new Uri(dlg.FileName);

                tbPrivate_key.Text = dlg.FileName;
                G.sPrivateKey = tbPrivate_key.Text;
                G.WriteRegPrivateKeyPath(G.sPrivateKey);
            }
        }

        private void btnFolderOpenP_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", tbPrivate_key.Text);
        }

        private void btnSelectFolderL_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.InitialDirectory = tbLicense.Text;
            dlg.IsFolderPicker = true; // true면 폴더 선택 false면 파일 선택

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // dlg.FileName
                //Get the path of specified file
                //webBrowser1.Url = new Uri(dlg.FileName);

                tbLicense.Text = dlg.FileName;
                G.sLicense = tbLicense.Text;
                G.WriteRegLicensePath(G.sLicense);
            }
        }

        private void btnFolderOpenL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", tbLicense.Text);
        }

        private void btnRefreshUSB_Click(object sender, EventArgs e)
        {
            RefreshUsbCombo();
        }

        private void btnCheckUSB_Click(object sender, EventArgs e)
        {
            if (!Check_USB())
                return;

            if(G.VerifyLicense())
            {
                MessageBox.Show("라인센스USB메모리는 정상적으로 인증됐습니다!",
                                "라이센스USB 테스트",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }    
        }

        private void btnGetCpuProcessorId_Click(object sender, EventArgs e)
        {
            tbCpuProcessorId.Text = HwId.GetCpuProcessorId();
        }

        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            //license.dat 확인
            string sLicenseDat = $"{tbLicense.Text}\\license.dat";
            if (!File.Exists(sLicenseDat))
            {
                MessageBox.Show("license.dat파일이 존재하지 않습니다!",
                                "license.dat 검증",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                tbLicense.Focus();
                return;
            }
            //MotherBoard UUID 확인
            //if (tbMotherboardUuid.Text.Length == 0)
            //{
            //    MessageBox.Show("MotherBoard UUID정보가 존재하지 않습니다!",
            //                    "license.dat 검증",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    tbMotherboardUuid.Focus();
            //    return;
            //}
            //CPU Processor ID 확인
            if (tbCpuProcessorId.Text.Length == 0) 
            {
                MessageBox.Show("CPU Processor ID정보가 존재하지 않습니다!",
                                "license.dat 검증",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                tbCpuProcessorId.Focus();
                return;
            }

            //id두개 확인
            if (G.VerifyLicense($"{tbLicense.Text}\\license.dat", true))
            {
                MessageBox.Show("license.dat는 정상적으로 인증됐습니다!",
                                "license.dat 검증",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void tbCpuProcessorId_TextChanged(object sender, EventArgs e)
        {
            G.sCpuProcessorId = tbCpuProcessorId.Text;
        }
    }
}
