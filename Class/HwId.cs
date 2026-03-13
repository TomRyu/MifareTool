using System;
using System.Management;

namespace MifareTool.Class
{
    public static class HwId
    {
        public static string GetMotherboardUuid()
        {
            // Win32_ComputerSystemProduct.UUID
            return WmiGetFirst("Win32_ComputerSystemProduct", "UUID");
        }

        public static string GetCpuProcessorId()
        {
            // Win32_Processor.ProcessorId
            return WmiGetFirst("Win32_Processor", "ProcessorId");
        }

        private static string WmiGetFirst(string wmiClass, string prop)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher($"SELECT {prop} FROM {wmiClass}"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        var v = obj[prop]?.ToString();
                        if (!string.IsNullOrWhiteSpace(v))
                            return v.Trim();
                    }
                }
            }
            catch
            {
                // WMI 실패 시 null 리턴
            }
            return null;
        }
    }
}
