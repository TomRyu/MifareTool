
using Microsoft.Win32;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static MifareTool.Class.LicenseModel;

namespace MifareTool
{
    #region enum, class
    public enum PGMMode
    {
        Manager,
        Guest
    }
    #endregion

    public static class G
    {
        public static FormMain pMain;
        public static object lockObject = new object();

        // 로거 ILog 필드
        //public static ILog log = LogManager.GetLogger("Program");
        // 로거 사용 : 5가지 레벨의 메서드들
        //log.Debug("Main() started");
        //log.Info("My Info");
        //log.Warn("My Warning");
        //log.Error("My Error");
        ////log.Fatal("My Fatal Er

        public static string sPrivateKey = "", sLicense = "";
        public static string sMotherboardUuid = "", sCpuProcessorId = "";
        // RF : 2번섹터 1번블록, 15번섹터 2번블록
        // RF : 2번섹터 0번블록, 15번섹터 1번블록 ... 이게 맞음
        public static int nCardSector = 0, nCardBlock = 0, nCardSector2 = 15, nCardBlock2 = 1;
        public static PGMMode pGMMode = PGMMode.Manager;

        #region 라이센스 생성 관련
        public static bool VerifyLicense(string licenseDatPath = @".\license.dat", bool bTest = false)
        {
            LicensePayload payload;
            string reason;

            //USB인증 시, 복원
            //string ret = LicenseVerifier.FindFirstLicenseDriveLetter();
            //if (ret == null)
            //{
            //    MessageBox.Show("license.dat파일이 포함된 USB메모리를 연결하세요!",
            //                    "라이센스 인증 실패",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    return false;
            //}
            //bool ok = LicenseVerifier.VerifyLicense(
            //    licenseDatPath: $"{ret}:\\license.dat",
            //    publicKeyPemPath: @".\public_key.pem",
            //    usbDriveRoot: $"{ret}:\\",
            //    out payload,
            //    out reason);

            // 1) license.dat 읽기
            //string licenseDatPath = @".\license.dat";
            if (!File.Exists(licenseDatPath) && !bTest)
            {
                var frm = new FormPCInfo(); 
                frm.ShowDialog();
                return false;
            }

            bool ok = LicenseVerifier.VerifyLicense(
                licenseDatPath: licenseDatPath,
                publicKeyPemPath: @".\public_key.pem",
                bTest,
                out payload,
                out reason);

            if (!ok)
            {
                MessageBox.Show(reason.ToString(),
                                "라이센스 인증 실패",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return ok;

            //if (!ok)
            //{
            //    // 실행 차단
            //    Console.WriteLine("라이선스 실패: " + reason);
            //}
            //else
            //{
            //    Console.WriteLine("라이선스 OK: " + payload.customer);
            //    // 프로그램 실행
            //}
        }
        /// <summary>
        /// private_key.pem (PKCS#8 또는 PKCS#1)에서 RSA 개인키 로드
        /// </summary>
        public static RSA LoadRsaPrivateKeyFromPem(string pemPath)
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

        #region 레지스트리에 임시 저장, 로드
        public static bool ReadRegCardSector(ref string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_sector");

            id = reg.GetValue("ID", "").ToString();

            if (string.IsNullOrEmpty(id))
                return false;
            else
                return true;
        }
        public static bool ReadRegCardSector2(ref string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_sector2");

            id = reg.GetValue("ID", "").ToString();

            if (string.IsNullOrEmpty(id))
                return false;
            else
                return true;
        }
        public static bool ReadRegCardBlock2(ref string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_block2");

            id = reg.GetValue("ID", "").ToString();

            if (string.IsNullOrEmpty(id))
                return false;
            else
                return true;
        }
        public static void WriteRegCardSector(string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_sector");

            reg.SetValue("ID", id);
        }
        public static void WriteRegCardSector2(string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_sector2");

            reg.SetValue("ID", id);
        }
        public static void WriteRegCardBlock2(string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("card_block2");

            reg.SetValue("ID", id);
        }
        public static bool ReadRegPrivateKeyPath(ref string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("private_key_path");

            id = reg.GetValue("ID", "").ToString();

            if (string.IsNullOrEmpty(id))
                return false;
            else
                return true;
        }
        public static void WriteRegPrivateKeyPath(string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("private_key_path");

            reg.SetValue("ID", id);
        }
        public static bool ReadRegLicensePath(ref string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("license_path");

            id = reg.GetValue("ID", "").ToString();

            if (string.IsNullOrEmpty(id))
                return false;
            else
                return true;
        }
        public static void WriteRegLicensePath(string id)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("TheMR").CreateSubKey("license_path");

            reg.SetValue("ID", id);
        }
        #endregion

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        public static string[] sIp = { "10.8.254.11", "169.254.116.1" };          // 기존 배열
        public static Dictionary<string, bool> dictCampIp = new Dictionary<string, bool>();
        //    // 딕셔너리의 "현재 열거 순서"에서 key가 몇 번째인지 반환 (없으면 -1)

        //    public static int nCntOfCams = 4;
        //    public static LprInfo[] lprInfo = new LprInfo[nCntOfCams];  
        //    public static int IndexOfKey<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, IEqualityComparer<TKey> cmp = null)
        //    {
        //        if (dict == null) throw new ArgumentNullException("dict");

        //        var comparer = cmp ?? EqualityComparer<TKey>.Default;

        //        int i = 0;
        //        foreach (var k in dict.Keys)
        //        {
        //            if (comparer.Equals(k, key))
        //                return i;
        //            i++;
        //        }
        //        return -1;
        //    }

        //    public static string dbPgConnStringServer = "Host=172.31.251.200;Port=5432;Username=postgres;Password=DH@inerv1!;Database=dhlpr;";
        //    public static string dbPgConnStringLocal = "Host=127.0.0.1;Port=5432;Username=postgres;Password=dhicc!@#0512;Database=dhlpr;";

        //    // Config 로드 변수 =========================================================================
        //    //public static Config config = Config.Ini;//빌드시 설정한다.

        //    // ini-parser 데이터 로드 
        //    public static FileIniDataParser parser = new FileIniDataParser();
        //    public static string iniPath;
        //    public static IniData iniData;

        //    // 런타임에서 메모리로 INI 딕셔너리 불러오기
        //    public static LprEventRepository dbPg = new LprEventRepository();
        //    public static Dictionary<string, Dictionary<string, string>> cfg;

        //    public static string sExcelFolder, sImageFolder, sDBConn, sServerLPRConn, sServerLPRHealthCheck, sampleImg;
        //    public static bool bUseImgTest;
        //    public static int nLimitOfRows, nHealthCheckTimeOut;
        //    public static FilePathSequencer seq;              
        //    //===========================================================================================

        //    public static string ResolvePath(string input)
        //    {
        //        if (string.IsNullOrWhiteSpace(input)) return null;
        //        var p = input.Trim().Trim('"');                      // 혹시 앞뒤 따옴표 제거
        //        p = Environment.ExpandEnvironmentVariables(p);       // %USERPROFILE% 같은 env 확장

        //        if (!Path.IsPathRooted(p))                           // 상대경로면 앱 기준으로
        //            p = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p));
        //        return p;
        //    }

        //    // 디렉터리 존재 여부 (경로 유효성까지 확인)
        //    public static bool DirExists(string path)
        //    {
        //        if (string.IsNullOrWhiteSpace(path)) return false;
        //        try
        //        {
        //            string full = Path.GetFullPath(path); // 잘못된 문자/형식이면 예외
        //            return Directory.Exists(full);
        //        }
        //        catch
        //        {
        //            return false; // 잘못된 경로 등
        //        }
        //    }

        //    /// INI 파일 선택 대화상자를 띄우고, 선택된 파일 경로를 반환합니다. 취소 시 null.
        //    /// </summary>
        //    public static string PickIniFile(IWin32Window owner = null, string initialDir = null)
        //    {
        //        using (var dlg = new OpenFileDialog())
        //        {
        //            dlg.Title = "INI 파일 선택";
        //            dlg.Filter = "INI 파일 (*.ini)|*.ini|모든 파일 (*.*)|*.*";
        //            dlg.FilterIndex = 1;
        //            dlg.CheckFileExists = true;
        //            dlg.CheckPathExists = true;
        //            dlg.Multiselect = false;
        //            dlg.RestoreDirectory = true;
        //            dlg.InitialDirectory = string.IsNullOrEmpty(initialDir)
        //                ? AppDomain.CurrentDomain.BaseDirectory
        //                : initialDir;

        //            return dlg.ShowDialog(owner) == DialogResult.OK ? dlg.FileName : null;
        //        }
        //    }
        //    /// 문자열을 임시 .txt 파일로 저장하고 메모장으로 연다.
        //    /// </summary>
        //    /// <param name="text">메모장에 표시할 내용</param>
        //    /// <param name="title">임시 파일명 접두(옵션)</param>
        //    /// <param name="autoDelete">메모장 종료 후 임시파일 자동 삭제 여부</param>
        //    public static void ShowInNotepad(string text, string title = "output", bool autoDelete = false)
        //    {
        //        if (text == null) text = string.Empty;

        //        // 파일명 안전화
        //        string Safe(string s) =>
        //            new string((s ?? "output").Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)).ToArray());

        //        string fileName = $"{Safe(title)}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        //        string tempPath = Path.Combine(Path.GetTempPath(), fileName);

        //        // 개행 정규화(선택): \n만 있을 경우 Windows 개행으로
        //        string normalized = text.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

        //        // UTF-8 with BOM으로 저장(한글 깨짐 방지)
        //        File.WriteAllText(tempPath, normalized, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

        //        var psi = new ProcessStartInfo
        //        {
        //            FileName = "notepad.exe",
        //            Arguments = $"\"{tempPath}\"",
        //            UseShellExecute = false
        //        };

        //        var p = Process.Start(psi);

        //        if (autoDelete && p != null)
        //        {
        //            p.EnableRaisingEvents = true;
        //            p.Exited += (_, __) =>
        //            {
        //                try { if (File.Exists(tempPath)) File.Delete(tempPath); }
        //                catch { /* 무시: 파일 잠김/권한 문제 등 */ }
        //            };
        //        }
        //    }

        //    #region 파이프라인 구조
        //    public static readonly BlockingCollection<(int cam, Bitmap bmp, MetaInfo meta)> _q
        //               = new BlockingCollection<(int, Bitmap, MetaInfo)>(boundedCapacity: 8);
        //    #endregion

        //    #region 레지스트리에 임시 저장, 로드
        //    public static bool ReadRegistry_SourceFolder(ref string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        id = reg.GetValue("SourceFolder", "").ToString();

        //        if (string.IsNullOrEmpty(id))
        //            return false;
        //        else
        //            return true;
        //    }
        //    public static void WriteRegistry_SourceFolder(string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        reg.SetValue("SourceFolder", id);
        //    }
        //    public static bool ReadRegistry_OkFolder(ref string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        id = reg.GetValue("OkFolder", "").ToString();

        //        if (string.IsNullOrEmpty(id))
        //            return false;
        //        else
        //            return true;
        //    }
        //    public static void WriteRegistry_OkFolder(string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        reg.SetValue("OkFolder", id);
        //    }
        //    public static bool ReadRegistry_NgFolder(ref string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        id = reg.GetValue("NgFolder", "").ToString();

        //        if (string.IsNullOrEmpty(id))
        //            return false;
        //        else
        //            return true;
        //    }
        //    public static void WriteRegistry_NgFolder(string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey(Application.ProductName);

        //        reg.SetValue("NgFolder", id);
        //    }
        //    #endregion

        //    #region 이미지 변환
        //    public static Image LoadImageNoLock(string path)
        //    {
        //        // 파일 공유 허용 + EXIF/ColorProfile 검증 비활성화(성능)
        //        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        using (var img = Image.FromStream(fs, useEmbeddedColorManagement: false, validateImageData: false))
        //        {
        //            return new Bitmap(img); // 메모리에 복사 → 파일 핸들 해제 후에도 사용 가능
        //        }
        //    }
        //    public static byte[] LoadJpegBytesNoLock(string path)
        //    {
        //        // 확장자 검사 (jpg/jpeg만 허용)
        //        string ext = Path.GetExtension(path)?.ToLowerInvariant();
        //        if (ext != ".jpg" && ext != ".jpeg")
        //            throw new ArgumentException($"JPG 파일만 로드할 수 있습니다. 입력: {path}");

        //        // 파일 읽기 (공유 허용)
        //        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        using (var img = Image.FromStream(fs, useEmbeddedColorManagement: false, validateImageData: false))
        //        using (var ms = new MemoryStream())
        //        {
        //            // JPEG 형식으로 메모리에 저장
        //            img.Save(ms, ImageFormat.Jpeg);
        //            return ms.ToArray();
        //        }
        //    }
        //    public static byte[] ToJpegBytes(BitmapSource src, int quality = 90, System.Windows.Media.Color? background = null)
        //    {
        //        if (src == null) throw new ArgumentNullException(nameof(src));
        //        if (src.CanFreeze && !src.IsFrozen) src.Freeze();

        //        // 필요 시 배경색으로 합성(알파 제거용)
        //        BitmapSource work = src;
        //        bool hasAlpha =
        //            work.Format == PixelFormats.Bgra32 || work.Format == PixelFormats.Pbgra32 ||
        //            work.Format == PixelFormats.Prgba64 || work.Format == PixelFormats.Rgba64 ||
        //            work.Format == PixelFormats.Rgba128Float;

        //        if (hasAlpha && background.HasValue)
        //        {
        //            int w = Math.Max(1, work.PixelWidth);
        //            int h = Math.Max(1, work.PixelHeight);
        //            double dpiX = work.DpiX > 0 ? work.DpiX : 96;
        //            double dpiY = work.DpiY > 0 ? work.DpiY : 96;

        //            var dv = new DrawingVisual();
        //            using (var dc = dv.RenderOpen())
        //            {
        //                dc.DrawRectangle(new SolidColorBrush(background.Value), null, new System.Windows.Rect(0, 0, w, h));
        //                dc.DrawImage(work, new System.Windows.Rect(0, 0, w, h));
        //            }
        //            var rtb = new RenderTargetBitmap(w, h, dpiX, dpiY, PixelFormats.Pbgra32);
        //            rtb.Render(dv);
        //            if (rtb.CanFreeze && !rtb.IsFrozen) rtb.Freeze();
        //            work = rtb;
        //        }

        //        // JPEG은 알파 미지원 → Bgr24로 변환
        //        if (work.Format != PixelFormats.Bgr24)
        //        {
        //            var converted = new FormatConvertedBitmap(work, PixelFormats.Bgr24, null, 0);
        //            if (converted.CanFreeze && !converted.IsFrozen) converted.Freeze();
        //            work = converted;
        //        }

        //        // 품질 클램프 (1~100)
        //        if (quality < 1) quality = 1;
        //        else if (quality > 100) quality = 100;

        //        var encoder = new JpegBitmapEncoder { QualityLevel = quality };
        //        encoder.Frames.Add(BitmapFrame.Create(work));

        //        var ms = new MemoryStream();
        //        encoder.Save(ms);
        //        return ms.ToArray();
        //    }
        //    public static Bitmap FromFile(string jpegPath)
        //    {
        //        if (string.IsNullOrWhiteSpace(jpegPath) || !File.Exists(jpegPath))
        //            throw new FileNotFoundException("JPEG 파일을 찾을 수 없습니다.", jpegPath);

        //        // WPF 디코더로 읽어 파일 잠김 방지 + CMYK JPEG 등 호환성 확보
        //        var fs = new FileStream(jpegPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        var decoder = new JpegBitmapDecoder(
        //            fs,
        //            BitmapCreateOptions.PreservePixelFormat,
        //            BitmapCacheOption.OnLoad); // 파일 핸들 해제 가능
        //        var frame = decoder.Frames[0];
        //        if (frame.CanFreeze && !frame.IsFrozen) frame.Freeze();

        //        // 무손실 BMP로 메모리에 저장 후 System.Drawing.Bitmap으로 변환
        //        var ms = new MemoryStream();
        //        var enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(frame));
        //        enc.Save(ms);
        //        ms.Position = 0;

        //        // 스트림 종속성 제거를 위해 한 번 더 복제
        //        var tmp = new Bitmap(ms);
        //        return new Bitmap(tmp);
        //    }
        //    public static byte[] ToJpegBytes(Bitmap src, int quality = 90)
        //    {
        //        if (src == null) throw new ArgumentNullException(nameof(src));

        //        // 품질 범위 보정
        //        if (quality < 1) quality = 1;
        //        else if (quality > 100) quality = 100;

        //        // 24bpp RGB로 보장
        //        using (Bitmap work = Ensure24bpp(src))
        //        using (var ms = new MemoryStream())
        //        {
        //            var jpeg = GetJpegCodec();
        //            using (var encParams = new EncoderParameters(1))
        //            {
        //                encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
        //                work.Save(ms, jpeg, encParams);
        //            }
        //            return ms.ToArray();
        //        }
        //    }
        //    // Bitmap → JPEG 파일 저장

        //    public static void SaveAsJpeg(Bitmap src, string filePath, int quality = 90)
        //    {
        //        if (src == null) throw new ArgumentNullException(nameof(src));
        //        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("filePath is empty.", nameof(filePath));

        //        // 품질 보정
        //        if (quality < 1) quality = 1;
        //        else if (quality > 100) quality = 100;

        //        // 확장자 보정
        //        if (!filePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) &&
        //            !filePath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
        //        {
        //            filePath += ".jpg";
        //        }

        //        // 디렉터리 생성
        //        var dir = Path.GetDirectoryName(filePath);
        //        if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

        //        using (Bitmap work = Ensure24bpp(src))
        //        {
        //            var jpeg = GetJpegCodec() ?? throw new InvalidOperationException("JPEG codec not found.");

        //            using (var encParams = new EncoderParameters(1))
        //            {
        //                encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

        //                // 부분 파일 방지를 위한 원자적 저장
        //                string temp = filePath + ".tmp";
        //                using (var fs = new FileStream(temp, FileMode.Create, FileAccess.Write, FileShare.None))
        //                {
        //                    work.Save(fs, jpeg, encParams);
        //                }

        //                if (File.Exists(filePath)) File.Delete(filePath);
        //                File.Move(temp, filePath);
        //            }
        //        }
        //    }
        //    public static string GetSavePath(string sBaseDir, DateTime dtNow, string plateNo, int nIdx)
        //    {
        //        string sFileName = $"{dtNow.ToString("yyyy-MM-dd HH-mm-ss")}_{plateNo}_LPR{nIdx + 1}";

        //        string targetDir = Path.Combine(sBaseDir, $"{dtNow:yyyy}", $"{dtNow:MM}", $"{dtNow:dd}");
        //        switch (nIdx)
        //        {
        //            case 0:
        //                targetDir = Path.Combine(targetDir, plateNo == ""? "LPR1_NG": "LPR1");
        //                break;
        //            case 1:
        //                targetDir = Path.Combine(targetDir, plateNo == "" ? "LPR2_NG" : "LPR2");
        //                break;
        //            case 2:
        //                targetDir = Path.Combine(targetDir, plateNo == "" ? "LPR3_NG" : "LPR3");
        //                break;
        //            case 3:
        //                targetDir = Path.Combine(targetDir, plateNo == "" ? "LPR4_NG" : "LPR4");
        //                break;
        //        }
        //        string target = Path.Combine(targetDir, sFileName);

        //        return target + ".jpg";
        //    }
        //    public static byte[] JpgToBytes2(string jpgPath)
        //    {
        //        if (string.IsNullOrWhiteSpace(jpgPath) || !File.Exists(jpgPath))
        //            throw new FileNotFoundException("JPEG 파일을 찾을 수 없습니다.", jpgPath);

        //        return File.ReadAllBytes(jpgPath);
        //    }
        //    public static byte[] JpgToBytes(string jpgPath)
        //    {
        //        if (string.IsNullOrWhiteSpace(jpgPath) || !File.Exists(jpgPath))
        //            throw new FileNotFoundException("JPEG 파일을 찾을 수 없습니다.", jpgPath);

        //        using (FileStream fs = new FileStream(jpgPath, FileMode.Open, FileAccess.Read))
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            fs.CopyTo(ms);
        //            return ms.ToArray();
        //        }
        //    }
        //    private static Bitmap Ensure24bpp(Bitmap src)
        //    {
        //        if (src.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        //        {
        //            return src.Clone(new Rectangle(0, 0, src.Width, src.Height),
        //                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //        }
        //        return (Bitmap)src.Clone();
        //    }
        //    private static Bitmap Ensure24bppSafe(Image src)
        //    {
        //        if (src == null) throw new ArgumentNullException(nameof(src));
        //        if (src.Width <= 0 || src.Height <= 0)
        //            throw new ArgumentException($"Invalid image size: {src.Width}x{src.Height}");

        //        var dst = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //        // 원본 DPI 보존(0 DPI 방지)
        //        float dx = src.HorizontalResolution > 0 ? src.HorizontalResolution : 96f;
        //        float dy = src.VerticalResolution > 0 ? src.VerticalResolution : 96f;
        //        dst.SetResolution(dx, dy);

        //        using (var g = Graphics.FromImage(dst))
        //        {
        //            g.CompositingMode = CompositingMode.SourceCopy;
        //            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //            g.SmoothingMode = SmoothingMode.None;

        //            // src 전체를 dst에 그대로 복사
        //            g.DrawImage(src,
        //                new Rectangle(0, 0, dst.Width, dst.Height),
        //                0, 0, src.Width, src.Height,
        //                GraphicsUnit.Pixel);
        //        }
        //        return dst;
        //    }

        //    private static ImageCodecInfo GetJpegCodec()
        //    {
        //        return ImageCodecInfo.GetImageEncoders()
        //            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        //    }
        //    #endregion

        //    #region 파일 처리
        //    public static async Task DeleteFolderRecursiveAsync(string folderPath)
        //    {
        //        if (!Directory.Exists(folderPath))
        //            return;

        //        // Task.Run으로 백그라운드 스레드에서 실행
        //        await Task.Run(() =>
        //        {
        //            Directory.Delete(folderPath, recursive: true);
        //        }).ConfigureAwait(false);
        //    }
        //    #endregion

        //    public static IniData createIni(string strIniFilePath)
        //    {
        //        IniData iniData = null;

        //        try
        //        {
        //            FileInfo fi = new FileInfo(strIniFilePath);
        //            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
        //            if (di.Exists == false)
        //                di.Create();

        //            if (fi.Exists == false)
        //                File.WriteAllText(strIniFilePath, Properties.Resources.CONFIG_INI);

        //            iniData = parser.ReadFile(strIniFilePath);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            string message = string.Format("Failed to create new Config.ini file : {0}", ex.Message);

        //            MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //        }

        //        return iniData;
        //    }
        //    public static void ClearImage(PictureBox pb)
        //    {
        //        if (pb.Image != null)
        //        {
        //            pb.Image.Dispose();   // 메모리/파일 잠금 해제
        //            pb.Image = null;
        //        }
        //        if (pb.BackgroundImage != null)
        //        {
        //            pb.BackgroundImage.Dispose();
        //            pb.BackgroundImage = null;
        //        }
        //        pb.Invalidate(); // 다시 그리기
        //    }
        //    public static void MyDelay(int nMiliSeconds)
        //    {
        //        DateTime start = DateTime.Now;
        //        TimeSpan span = DateTime.Now.Subtract(start);
        //        while (span.TotalMilliseconds <= nMiliSeconds)
        //        {
        //            Application.DoEvents();
        //            span = DateTime.Now.Subtract(start);
        //        }
        //    }
        //    public static void Update_listBox(ListBox listBox, string data)
        //    {
        //        try
        //        {
        //            string str = string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), data);
        //            //log.Debug(str);
        //            listBox.Invoke(new MethodInvoker(
        //                 delegate ()
        //                 {
        //                     listBox.BeginInvoke(new Action(() => listBox.Items.Insert(0, str)));

        //                     // 방금 추가한 아이템에 스크롤을 위치시킨다.
        //                     listBox.BeginInvoke(new Action(() => listBox.SelectedIndex = 0));
        //                 }
        //                 )
        //            );
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    public static void Add_Dgv(int n, string sPlateNo, double dConf, double dElapsedMs, 
        //        string sImgPath, bool isOffline, DateTime dtNow = default)
        //    {
        //        if (dtNow == default)
        //            dtNow = DateTime.Now;

        //        const int MAX_ROWS = 5000;

        //        //string sEntryExit = G.lprInfo[n].InOut == InOutType.Entry ? "입차" : "출차";
        //        //string sFrontRear = G.lprInfo[n].Facing == FacingType.Front ? "전방" : "후방";
        //        //string sRelatedLPR = G.lprInfo[n].relatedLPR.ToString();

        //        if (pMain?.dgv == null || pMain.dgv.IsDisposed) return;

        //        var dgv = pMain.dgv;

        //        dgv.Invoke(new Action(() =>
        //        {
        //            dgv.SuspendLayout();
        //            try
        //            {
        //                dgv.SelectionChanged -= new System.EventHandler(G.pMain.dgv_SelectionChanged);
        //                //DateTime dtNow = DateTime.Now;  
        //                // 1) 새 행을 맨 위에 추가
        //                dgv.Rows.Insert(0, dtNow.ToString("MM-dd HH:mm:ss"),
        //                    $"LPR{n + 1}",
        //                    //$"{sRelatedLPR}",
        //                    $"{sPlateNo}",
        //                    isOffline ? "" : $"{dConf:F2}%",
        //                    isOffline ? "" : $"{dElapsedMs:N0}ms",
        //                    $"{sImgPath}",
        //                    $"{isOffline}");

        //                G.log.Info(string.Format("LPR{0} ... 차량번호:{1}, 신뢰도:{2:F2}, 처리시간:{3:N0}ms", n+1, sPlateNo, dConf*100, dElapsedMs));

        //                //dgv.ClearSelection();

        //                dgv.SelectionChanged += new System.EventHandler(G.pMain.dgv_SelectionChanged);                    
        //                dgv.ClearSelection();
        //                dgv.CurrentCell = dgv.Rows[0].Cells[0];
        //                dgv.Rows[0].Selected = true;
        //                G.pMain.dgv_SelectionChanged(null, null);

        //                // 3) 초과분 제거 (AllowUserToAddRows 고려)
        //                int actualCount = dgv.Rows.Count - (dgv.AllowUserToAddRows ? 1 : 0);
        //                while (actualCount > MAX_ROWS)
        //                {
        //                    int lastDataIndex = dgv.Rows.Count - 1 - (dgv.AllowUserToAddRows ? 1 : 0);
        //                    if (lastDataIndex >= 0)
        //                        dgv.Rows.RemoveAt(lastDataIndex); // 가장 오래된 행(맨 아래) 삭제

        //                    actualCount--;
        //                }
        //            }
        //            finally
        //            {
        //                dgv.ResumeLayout();
        //            }
        //        }));
        //    }

        //    public static void Insert_LprData(System.Windows.Forms.ListView listview, string data)
        //    {
        //        try
        //        {
        //            //log.Debug(str);
        //            listview.Invoke(new MethodInvoker(
        //                 delegate ()
        //                 {
        //                     ListViewItem item = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //                     item.SubItems.Add(data);

        //                     // ListView에 추가 (Insert: 지정 위치에 넣기)
        //                     //listview.Items.Insert(0, item); // 첫 번째 위치                         
        //                     listview.BeginInvoke(new Action(() => listview.Items.Insert(0, item)));
        //                     //listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        //                     // 방금 추가한 아이템에 스크롤을 위치시킨다.
        //                     listview.BeginInvoke(new Action(() => listview.Items[0].Selected = true));
        //                     //listview.Items[0].EnsureVisible();
        //                 }
        //                 )
        //            );
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }


        //    public static void CaptureScreen(string savePath)
        //    {
        //        // 전체 화면 사이즈 가져오기
        //        Rectangle bounds = Screen.PrimaryScreen.Bounds;

        //        // 비트맵 생성
        //        using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
        //        {
        //            // 그래픽 객체 생성
        //            using (Graphics g = Graphics.FromImage(bitmap))
        //            {
        //                // 화면 캡처
        //                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
        //            }

        //            // 이미지 저장 (PNG 또는 JPEG 등으로 가능)
        //            bitmap.Save(savePath, ImageFormat.Png);
        //        }

        //        MessageBox.Show(string.Format("\'{0}\' 파일이 내문서에 저장됐습니다.", savePath));
        //        //Console.WriteLine($"스크린샷이 저장되었습니다: {savePath}");
        //    }

        //    #region 레지스트리에 임시 저장, 로드
        //    public static bool ReadRegistry(ref string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("SKTVision");

        //        id = reg.GetValue("ID", "").ToString();

        //        if (string.IsNullOrEmpty(id))
        //            return false;
        //        else
        //            return true;
        //    }
        //    public static void WriteRegistry(string id)
        //    {
        //        RegistryKey reg = Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("SKTVision");

        //        reg.SetValue("ID", id);
        //    }
        //    #endregion

        //    // 이미지 파일을 선택하는 다이얼로그를 표시하는 메소드
        //    public static string ShowImageFileDialog()
        //    {
        //        // OpenFileDialog 객체 생성
        //        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

        //        // 이미지 파일 필터 설정 (예: JPG, PNG, BMP, GIF)
        //        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
        //        //

        //        // 다이얼로그를 표시하고 사용자가 선택한 파일 경로 반환
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            return openFileDialog.FileName;  // 선택된 파일의 경로 반환
        //        }

        //        return null;  // 파일이 선택되지 않으면 null 반환
        //    }

        //}
    }
}
