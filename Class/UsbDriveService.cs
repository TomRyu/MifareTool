using System;
using System.Collections.Generic;
using System.IO;

namespace MifareTool.Class
{
    public class UsbDriveItem
    {
        public string DriveRoot { get; set; }   // "E:\"
        public string VolumeLabel { get; set; } // "TMRUSB"
        public string SerialHex { get; set; }   // "A1B2C3D4"

        // ComboBox에 보여줄 문자열
        public string DisplayText
        {
            get
            {
                string label = string.IsNullOrWhiteSpace(VolumeLabel) ? "(NoLabel)" : VolumeLabel;
                string serial = string.IsNullOrWhiteSpace(SerialHex) ? "--------" : SerialHex;
                return $"{DriveRoot}  {label}  [{serial}]";
            }
        }
    }

    public static class UsbDriveService
    {
        /// <summary>
        /// 현재 꽂힌 이동식(USB) 드라이브 목록을 반환
        /// </summary>
        public static List<UsbDriveItem> GetRemovableUsbDrives()
        {
            var list = new List<UsbDriveItem>();

            foreach (var d in DriveInfo.GetDrives())
            {
                if (d.DriveType != DriveType.Removable) continue;
                if (!d.IsReady) continue;

                string root = d.Name; // "E:\"
                string serial = VolumeSerialUtil.GetVolumeSerialHex(root); // 앞서 만든 함수 재사용

                list.Add(new UsbDriveItem
                {
                    DriveRoot = root,
                    VolumeLabel = d.VolumeLabel,
                    SerialHex = serial
                });
            }

            return list;
        }
    }
}
