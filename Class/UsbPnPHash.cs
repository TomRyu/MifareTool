using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace MifareTool.Class
{
    public static class UsbPnPHash
    {
        /// <summary>
        /// 드라이브 문자(예: "E:\\" 또는 "E:")로 USB의 PNPDeviceID를 찾아 SHA256+Base64 해시 반환
        /// 실패 시 null 반환
        /// </summary>
        public static string GetPnPIdHashForDrive(string driveRoot)
        {
            if (string.IsNullOrWhiteSpace(driveRoot)) return null;

            string root = NormalizeDriveRoot(driveRoot); // "E:"
                                                         // 1) 이 드라이브가 실제로 "Removable"인지 확인(선택)
            try
            {
                var di = new DriveInfo(root);
                if (!di.IsReady) return null;

                // Removable 아니어도(일부 환경) USB가 Fixed로 잡히는 경우가 있어 강제하지는 않음
                // if (di.DriveType != DriveType.Removable) return null;
            }
            catch { /* 무시 */ }

            // 2) Win32_LogicalDisk -> Win32_DiskPartition -> Win32_DiskDrive로 연결해서 PNPDeviceID 얻기
            //    참고: WMI 연관 쿼리는 Associators of {...}
            try
            {
                string logicalDiskPath = $"Win32_LogicalDisk.DeviceID=\"{root}\"";

                using (var partSearcher = new ManagementObjectSearcher(
                    $"ASSOCIATORS OF {{{logicalDiskPath}}} WHERE AssocClass = Win32_LogicalDiskToPartition"))
                {
                    foreach (ManagementObject partition in partSearcher.Get())
                    {
                        string partitionId = partition["DeviceID"]?.ToString();
                        if (string.IsNullOrEmpty(partitionId)) continue;

                        string partitionPath = $"Win32_DiskPartition.DeviceID=\"{EscapeWmiString(partitionId)}\"";

                        using (var driveSearcher = new ManagementObjectSearcher(
                            $"ASSOCIATORS OF {{{partitionPath}}} WHERE AssocClass = Win32_DiskDriveToDiskPartition"))
                        {
                            foreach (ManagementObject diskDrive in driveSearcher.Get())
                            {
                                // 여기서 물리 디스크(Win32_DiskDrive) 정보를 얻음
                                string pnp = diskDrive["PNPDeviceID"]?.ToString();
                                string interfaceType = diskDrive["InterfaceType"]?.ToString(); // "USB" 등이 들어오는 경우 많음
                                string mediaType = diskDrive["MediaType"]?.ToString();

                                if (string.IsNullOrEmpty(pnp)) continue;

                                // USB인지 판별(환경마다 달라서 보수적으로)
                                bool looksUsb =
                                    string.Equals(interfaceType, "USB", StringComparison.OrdinalIgnoreCase) ||
                                    pnp.StartsWith("USBSTOR\\", StringComparison.OrdinalIgnoreCase) ||
                                    pnp.StartsWith("USB\\", StringComparison.OrdinalIgnoreCase);

                                // USB만 원하면 아래 조건을 활성화
                                // if (!looksUsb) continue;

                                // 3) SHA256 + Base64
                                return Sha256Base64(pnp);
                            }
                        }
                    }
                }
            }
            catch
            {
                // WMI 권한/환경 문제 등
                return null;
            }

            return null;
        }

        /// <summary>
        /// 필요하면 원본 PNPDeviceID도 같이 얻고 싶을 때
        /// </summary>
        public static string GetPnPDeviceIdForDrive(string driveRoot)
        {
            if (string.IsNullOrWhiteSpace(driveRoot)) return null;
            string root = NormalizeDriveRoot(driveRoot);

            try
            {
                string logicalDiskPath = $"Win32_LogicalDisk.DeviceID=\"{root}\"";

                using (var partSearcher = new ManagementObjectSearcher(
                    $"ASSOCIATORS OF {{{logicalDiskPath}}} WHERE AssocClass = Win32_LogicalDiskToPartition"))
                {
                    foreach (ManagementObject partition in partSearcher.Get())
                    {
                        string partitionId = partition["DeviceID"]?.ToString();
                        if (string.IsNullOrEmpty(partitionId)) continue;

                        string partitionPath = $"Win32_DiskPartition.DeviceID=\"{EscapeWmiString(partitionId)}\"";

                        using (var driveSearcher = new ManagementObjectSearcher(
                            $"ASSOCIATORS OF {{{partitionPath}}} WHERE AssocClass = Win32_DiskDriveToDiskPartition"))
                        {
                            foreach (ManagementObject diskDrive in driveSearcher.Get())
                            {
                                return diskDrive["PNPDeviceID"]?.ToString();
                            }
                        }
                    }
                }
            }
            catch { return null; }

            return null;
        }

        private static string Sha256Base64(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private static string NormalizeDriveRoot(string driveRoot)
        {
            // "E", "E:", "E:\", "e:\" 다 받아서 "E:" 형태로 정규화
            string s = driveRoot.Trim();
            if (s.Length == 1) s += ":";
            if (s.Length >= 2 && s[1] == ':') return char.ToUpperInvariant(s[0]) + ":";
            // "E:\" 같은 형태면 Path.GetPathRoot
            string root = Path.GetPathRoot(s);
            if (string.IsNullOrEmpty(root)) return null;
            return char.ToUpperInvariant(root[0]) + ":";
        }

        private static string EscapeWmiString(string s)
        {
            // WMI path에서 \ 를 \\ 로, "를 \"로
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}
