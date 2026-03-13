using MifareTool;
using MifareTool.Class;
using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using static MifareTool.Class.LicenseModel;

public static class LicenseVerifier
{
    // public_key.pem 경로(프로그램 폴더에 포함했다고 가정)
    internal static bool VerifyLicense(
        string licenseDatPath,
        string publicKeyPemPath,
        bool bTest,
        out LicensePayload payload,
        out string reason)
    {
        payload = null;
        reason = null;

        var jss = new JavaScriptSerializer();

        // 1) license.dat 읽기
        if (!File.Exists(licenseDatPath))
        {
            reason = "license.dat 파일이 없습니다.";
            return false;
        }

        string envelopeJson = File.ReadAllText(licenseDatPath, Encoding.UTF8);

        LicenseEnvelope env;
        try
        {
            env = jss.Deserialize<LicenseEnvelope>(envelopeJson);
        }
        catch (Exception ex)
        {
            reason = "license.dat 파싱 실패: " + ex.Message;
            return false;
        }

        if (env == null || string.IsNullOrWhiteSpace(env.payload_b64) || string.IsNullOrWhiteSpace(env.sig_b64))
        {
            reason = "license.dat 형식이 올바르지 않습니다.";
            return false;
        }

        // 2) payload_b64 Base64 디코딩
        byte[] payloadBytes;
        try
        {
            payloadBytes = Convert.FromBase64String(env.payload_b64);
        }
        catch (Exception ex)
        {
            reason = "payload_b64 Base64 디코딩 실패: " + ex.Message;
            return false;
        }

        // 3) sig_b64 Base64 디코딩
        byte[] sigBytes;
        try
        {
            sigBytes = Convert.FromBase64String(env.sig_b64);
        }
        catch (Exception ex)
        {
            reason = "sig_b64 Base64 디코딩 실패: " + ex.Message;
            return false;
        }

        // 4) public_key.pem 로드
        using (RSA rsa = PemKeyLoader.LoadRsaPublicKeyFromPem(publicKeyPemPath))
        {
            // 5) rsa.VerifyData(payloadBytes, sigBytes, SHA256, PKCS1)
            bool ok = rsa.VerifyData(
                payloadBytes,
                sigBytes,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            if (!ok)
            {
                reason = "서명 검증 실패(위조 또는 파일 손상).";
                return false;
            }
        }

        // 6) OK면 payloadJson 파싱해서 만료/기능/USB바인딩 체크
        string payloadJson = Encoding.UTF8.GetString(payloadBytes);

        try
        {
            payload = jss.Deserialize<LicensePayload>(payloadJson);
        }
        catch (Exception ex)
        {
            reason = "payload JSON 파싱 실패: " + ex.Message;
            return false;
        }

        if (payload == null)
        {
            reason = "payload가 비어 있습니다.";
            return false;
        }
        
        // (6-3) PC정보 바인딩 체크
        if (payload.pcInfoBind != null)
        {
            //// MotherBoard UUID 체크
            //string actualUuid = bTest ? G.sMotherboardUuid : HwId.GetMotherboardUuid();
            //if (string.IsNullOrWhiteSpace(actualUuid))
            //{
            //    reason = "MotherBoard UUID를 읽을 수 없습니다.";
            //    return false;
            //}

            //if (!string.Equals(payload.pcInfoBind.motherboardUuid, actualUuid, StringComparison.OrdinalIgnoreCase))
            //{
            //    reason = "MotherBoard UUID 바인딩 불일치";
            //    return false;
            //}

            // CPU Processor ID 체크
            string actualCpu = bTest ? G.sCpuProcessorId : HwId.GetCpuProcessorId();
            if (string.IsNullOrWhiteSpace(actualCpu))
            {
                reason = "CPU Processor ID를 읽을 수 없습니다.";
                return false;
            }
            
            if (!string.Equals(payload.pcInfoBind.cpuProcessorId, actualCpu, StringComparison.OrdinalIgnoreCase))
            {
                reason = "CPU Processor ID 바인딩 불일치";
                return false;
            }
        }

        return true;
    }

    internal static bool VerifyLicense_USB(
        string licenseDatPath,
        string publicKeyPemPath,
        string usbDriveRoot, // 예: "E:\\"
        out LicensePayload payload,
        out string reason)
    {
        payload = null;
        reason = null;

        var jss = new JavaScriptSerializer();

        // 1) license.dat 읽기
        if (!File.Exists(licenseDatPath))
        {
            reason = "license.dat 파일이 없습니다.";
            return false;
        }

        string envelopeJson = File.ReadAllText(licenseDatPath, Encoding.UTF8);

        LicenseEnvelope env;
        try
        {
            env = jss.Deserialize<LicenseEnvelope>(envelopeJson);
        }
        catch (Exception ex)
        {
            reason = "license.dat 파싱 실패: " + ex.Message;
            return false;
        }

        if (env == null || string.IsNullOrWhiteSpace(env.payload_b64) || string.IsNullOrWhiteSpace(env.sig_b64))
        {
            reason = "license.dat 형식이 올바르지 않습니다.";
            return false;
        }

        // 2) payload_b64 Base64 디코딩
        byte[] payloadBytes;
        try
        {
            payloadBytes = Convert.FromBase64String(env.payload_b64);
        }
        catch (Exception ex)
        {
            reason = "payload_b64 Base64 디코딩 실패: " + ex.Message;
            return false;
        }

        // 3) sig_b64 Base64 디코딩
        byte[] sigBytes;
        try
        {
            sigBytes = Convert.FromBase64String(env.sig_b64);
        }
        catch (Exception ex)
        {
            reason = "sig_b64 Base64 디코딩 실패: " + ex.Message;
            return false;
        }

        // 4) public_key.pem 로드
        using (RSA rsa = PemKeyLoader.LoadRsaPublicKeyFromPem(publicKeyPemPath))
        {
            // 5) rsa.VerifyData(payloadBytes, sigBytes, SHA256, PKCS1)
            bool ok = rsa.VerifyData(
                payloadBytes,
                sigBytes,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            if (!ok)
            {
                reason = "서명 검증 실패(위조 또는 파일 손상).";
                return false;
            }
        }

        // 6) OK면 payloadJson 파싱해서 만료/기능/USB바인딩 체크
        string payloadJson = Encoding.UTF8.GetString(payloadBytes);

        try
        {
            payload = jss.Deserialize<LicensePayload>(payloadJson);
        }
        catch (Exception ex)
        {
            reason = "payload JSON 파싱 실패: " + ex.Message;
            return false;
        }

        if (payload == null)
        {
            reason = "payload가 비어 있습니다.";
            return false;
        }

        // (6-1) 만료 체크
        //if (!TryParseUtc(payload.expiresAtUtc, out DateTime expiresUtc))
        //{
        //    reason = "expiresAtUtc 형식이 올바르지 않습니다.";
        //    return false;
        //}

        //if (DateTime.UtcNow > expiresUtc)
        //{
        //    reason = "라이선스 만료: " + expiresUtc.ToString("u");
        //    return false;
        //}

        // (6-2) 기능 체크(예: 특정 기능이 반드시 있어야 한다면)
        // 필요 없으면 제거하세요.
        if (payload.features == null) payload.features = new System.Collections.Generic.List<string>();
        // 예: LPR 기능이 있어야 실행
        // if (!payload.features.Contains("LPR")) { reason = "필수 기능(LPR)이 없는 라이선스입니다."; return false; }

        // (6-3) USB 바인딩 체크
        if (payload.usbBind != null)
        {
            // volumeSerial 체크(권장)
            string actualVol = VolumeSerialUtil.GetVolumeSerialHex(usbDriveRoot);
            if (string.IsNullOrWhiteSpace(actualVol))
            {
                reason = "USB 볼륨 시리얼을 읽을 수 없습니다.";
                return false;
            }

            if (!string.Equals(payload.usbBind.volumeSerial, actualVol, StringComparison.OrdinalIgnoreCase))
            {
                reason = "USB 바인딩 불일치(VolumeSerial).";
                return false;
            }

            // pnpIdHash 체크(선택)
            if (!string.IsNullOrWhiteSpace(payload.usbBind.pnpIdHash))
            {
                string actualPnpHash = UsbPnPHash.GetPnPIdHashForDrive(usbDriveRoot);
                if (string.IsNullOrWhiteSpace(actualPnpHash))
                {
                    reason = "USB PNP 해시를 읽을 수 없습니다.";
                    return false;
                }

                if (!string.Equals(payload.usbBind.pnpIdHash, actualPnpHash, StringComparison.Ordinal))
                {
                    reason = "USB 바인딩 불일치(PnPIdHash).";
                    return false;
                }
            }
        }

        return true;
    }

    private static bool TryParseUtc(string iso8601, out DateTime utc)
    {
        utc = default;
        if (string.IsNullOrWhiteSpace(iso8601)) return false;

        // 발급툴에서 DateTime.UtcNow.ToString("o") 형태로 넣었다고 가정
        if (!DateTime.TryParse(iso8601, null, System.Globalization.DateTimeStyles.AdjustToUniversal, out utc))
            return false;

        // Kind가 Local/Unspecified로 들어오는 케이스 방어
        if (utc.Kind != DateTimeKind.Utc)
            utc = DateTime.SpecifyKind(utc.ToUniversalTime(), DateTimeKind.Utc);

        return true;
    }

    /// <summary>
    /// UsbDriveService.GetRemovableUsbDrives() 결과에서
    /// 루트에 license.dat이 존재하는 첫 번째 드라이브의 문자 1글자(예:"E")를 반환.
    /// 없으면 null.
    /// </summary>
    public static string FindFirstLicenseDriveLetter()
    {
        var drives = UsbDriveService.GetRemovableUsbDrives();
        if (drives == null) return null;

        // IEnumerable로 돌리기 (string[], List<>, DriveInfo[] 등 모두 대응)
        foreach (var item in (IEnumerable)drives)
        {
            string root = TryGetDriveRoot(item); // "E:\"
            if (string.IsNullOrEmpty(root)) continue;

            try
            {
                // 드라이브 루트가 실제로 접근 가능한지부터 확인
                if (!Directory.Exists(root)) continue;

                // 루트에 license.dat 검사
                string licensePath = Path.Combine(root, "license.dat");
                if (File.Exists(licensePath))
                {
                    return char.ToUpperInvariant(root[0]).ToString();
                }
            }
            catch
            {
                // 접근 거부 / 장치 오류 등은 무시하고 다음 드라이브로
            }
        }

        return null;
    }

    /// <summary>
    /// item이 DriveInfo이든 string이든 커스텀 객체이든
    /// 최대한 "E:\" 형태의 루트 경로를 뽑아내는 함수
    /// </summary>
    private static string TryGetDriveRoot(object item)
    {
        if (item == null) return null;

        // 1) DriveInfo인 경우
        if (item is DriveInfo di)
            return di.RootDirectory.FullName;

        // 2) string인 경우 ("E:\", "E:" 등)
        if (item is string s)
        {
            var root = Path.GetPathRoot(s.Trim());
            return string.IsNullOrEmpty(root) ? null : root;
        }

        // 3) 커스텀 타입인 경우: 흔히 Root/RootPath/Drive/DriveLetter 같은 프로퍼티가 있음
        // 리플렉션으로 유추 (안전하게 실패하면 null)
        try
        {
            var t = item.GetType();

            // 우선순위: RootDirectory, RootPath, Root, Path, DriveRoot
            string[] propNames = { "RootDirectory", "RootPath", "Root", "Path", "DriveRoot" };
            foreach (var name in propNames)
            {
                var p = t.GetProperty(name);
                if (p == null) continue;

                var v = p.GetValue(item, null);
                if (v == null) continue;

                // DriveInfo-like
                if (v is DriveInfo di2) return di2.RootDirectory.FullName;

                // string-like
                if (v is string s2)
                {
                    var root = Path.GetPathRoot(s2.Trim());
                    if (!string.IsNullOrEmpty(root)) return root;
                }

                // DirectoryInfo-like
                if (v is DirectoryInfo dir) return dir.FullName;
            }

            // DriveLetter 프로퍼티가 있다면 ("E" / "E:" 등)
            var pLetter = t.GetProperty("DriveLetter");
            if (pLetter != null)
            {
                var v = pLetter.GetValue(item, null)?.ToString();
                if (!string.IsNullOrWhiteSpace(v))
                {
                    v = v.Trim();
                    if (v.Length == 1) return v.ToUpperInvariant() + @":\";
                    if (v.Length >= 2 && v[1] == ':') return char.ToUpperInvariant(v[0]) + @":\";
                }
            }
        }
        catch
        {
            // 무시
        }

        return null;
    }
}
