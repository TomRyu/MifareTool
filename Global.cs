
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
#if MANAGER_MODE
        public static PGMMode pGMMode = PGMMode.Manager;
#else
        public static PGMMode pGMMode = PGMMode.Guest;
#endif

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
    }
}
