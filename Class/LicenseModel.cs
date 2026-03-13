using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MifareTool.Class
{
    internal class LicenseModel
    {
        public class LicensePayload
        {
            public string product { get; set; }
            public string customer { get; set; }
            public string licenseId { get; set; }
            public string issuedAtUtc { get; set; }
            public string expiresAtUtc { get; set; }
            public List<string> features { get; set; }
            public UsbBind usbBind { get; set; }
            public PCInfoBind pcInfoBind { get; set; }
        }

        public class UsbBind
        {
            public string volumeSerial { get; set; }
            public string pnpIdHash { get; set; }
        }
        public class PCInfoBind
        {
            public string motherboardUuid { get; set; }
            public string cpuProcessorId { get; set; }
        }

        public class LicenseEnvelope
        {
            public int ver { get; set; }
            public string alg { get; set; }
            public string payload_b64 { get; set; }
            public string sig_b64 { get; set; }
        }
    }
}
