using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MifareTool.Class
{
    public static class Fingerprint
    {
        public static string Make(string uuid, string cpu, string salt)
        {
            // 정규화(대문자, 공백/하이픈 제거 등)
            string norm(string s) => (s ?? "").Trim().ToUpperInvariant();

            string data = $"{norm(uuid)}|{norm(cpu)}|{salt}";
            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
                return string.Concat(hash.Select(b => b.ToString("x2")));
            }
        }
    }
}
