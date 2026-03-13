using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MifareTool.Class
{
    public static class VolumeSerialUtil
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetVolumeInformation(
            string lpRootPathName,
            System.Text.StringBuilder lpVolumeNameBuffer,
            int nVolumeNameSize,
            out uint lpVolumeSerialNumber,
            out uint lpMaximumComponentLength,
            out uint lpFileSystemFlags,
            System.Text.StringBuilder lpFileSystemNameBuffer,
            int nFileSystemNameSize);

        /// <summary>
        /// 예: driveLetter = "E" 또는 "E:"
        /// 반환: "A1B2C3D4" (8자리 HEX) / 실패 시 null
        /// </summary>
        public static string GetVolumeSerialHex(string driveLetter)
        {
            if (string.IsNullOrWhiteSpace(driveLetter)) return null;

            driveLetter = driveLetter.Substring(0, 1);

            // "E" -> "E:\"
            string root = driveLetter.Trim().TrimEnd(':') + @":\";
            if (!Directory.Exists(root)) return null;

            var volName = new System.Text.StringBuilder(261);
            var fsName = new System.Text.StringBuilder(261);

            bool ok = GetVolumeInformation(
                root,
                volName, volName.Capacity,
                out uint serial,
                out uint maxCompLen,
                out uint fsFlags,
                fsName, fsName.Capacity);

            if (!ok) return null;

            // Windows에서 흔히 보이는 형태: 8자리 HEX
            return serial.ToString("X8");
        }
    }
}
