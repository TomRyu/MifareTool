using System;
using System.Linq;
using System.Windows.Forms;

namespace MifareTool.Class
{
    public static class HexText
    {
        // byte[] -> "FF FF ... FF" 형태로 변환
        public static string ToHexSpaceString(byte[] data)
        {
            if (data == null || data.Length == 0) return string.Empty;

            // 2자리 대문자 16진수, 공백으로 조인
            return string.Join(" ", data.Select(b => b.ToString("X2")));
        }

        // 바로 TextBox에 세팅까지
        public static void SetHexToTextBox(TextBox tb, byte[] data)
        {
            if (tb == null) throw new ArgumentNullException(nameof(tb));
            tb.Text = ToHexSpaceString(data);
        }
        public static byte[] HexStringToByteArray(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return new byte[0];

            return hex
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ToByte(s, 16))
                .ToArray();
        }
    }
}
