using System;
using System.Linq;
using System.Windows.Forms;

namespace MifareTool.Class
{
    public static class TextBoxHexHelper
    {
        /// <summary>
        /// "FF FF ..." 형태로만 입력되도록 강제:
        /// - 0-9, A-F만 허용 (a-f는 자동 대문자)
        /// - 각 바이트는 반드시 2자리
        /// - 2자리 입력되면 자동으로 공백 추가(옵션)
        /// - 공백은 오직 2자리 완료 시에만 허용
        /// </summary>
        public static void AttachHexOnly_Force2Digits(TextBox tb, bool autoInsertSpace = true)
        {
            if (tb == null) throw new ArgumentNullException(nameof(tb));

            tb.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar))
                    return; // Backspace 등은 허용

                // 현재 커서/선택 상태
                int selStart = tb.SelectionStart;
                int selLen = tb.SelectionLength;

                // 현재 토큰(바이트) 길이 계산: 커서 기준으로 마지막 공백 이후부터 다음 공백 전까지
                int tokenLen = GetCurrentTokenLength(tb.Text, selStart, selLen);

                // 공백 입력은 "토큰이 정확히 2자리일 때만" 허용
                if (e.KeyChar == ' ')
                {
                    if (tokenLen == 2 && (selStart == 0 || tb.Text.ElementAtOrDefault(selStart - 1) != ' '))
                        return;

                    e.Handled = true;
                    return;
                }

                // 16진수 문자만 허용 + 소문자면 대문자로 변환
                char c = e.KeyChar;

                if (c >= 'a' && c <= 'f') c = char.ToUpperInvariant(c);

                bool isHex =
                    (c >= '0' && c <= '9') ||
                    (c >= 'A' && c <= 'F');

                if (!isHex)
                {
                    e.Handled = true;
                    return;
                }

                // 이미 토큰이 2자리인데 또 입력하려고 하면
                // (autoInsertSpace=true면) 공백을 자동 삽입하고 입력되게 처리
                if (tokenLen >= 2)
                {
                    if (!autoInsertSpace)
                    {
                        e.Handled = true;
                        return;
                    }

                    e.Handled = true;

                    // 선택 영역이 있으면 먼저 삭제 후 처리
                    if (selLen > 0)
                    {
                        tb.Text = tb.Text.Remove(selStart, selLen);
                    }

                    // 커서 위치에 공백이 없으면 공백을 먼저 삽입
                    if (selStart > 0 && tb.Text[selStart - 1] != ' ')
                    {
                        tb.Text = tb.Text.Insert(selStart, " ");
                        selStart += 1;
                    }

                    // 그 다음에 hex 문자 삽입
                    tb.Text = tb.Text.Insert(selStart, c.ToString());
                    tb.SelectionStart = selStart + 1;
                    tb.SelectionLength = 0;
                    return;
                }

                // tokenLen < 2 인 경우는 그대로 통과시키되,
                // 마지막 2번째 자리를 입력하는 순간 autoInsertSpace이면 공백 자동 추가
                e.KeyChar = c;

                if (autoInsertSpace && tokenLen == 1)
                {
                    // 기본 입력 이후에 공백을 붙여야 해서, 여기서는 수동 삽입 방식으로 처리
                    e.Handled = true;

                    if (selLen > 0)
                    {
                        tb.Text = tb.Text.Remove(selStart, selLen);
                    }

                    tb.Text = tb.Text.Insert(selStart, c.ToString());
                    selStart += 1;

                    // 입력 후 토큰이 2자리가 되면 공백 추가(단, 텍스트 끝이거나 다음이 공백이 아닐 때)
                    if (selStart == tb.Text.Length || tb.Text.ElementAtOrDefault(selStart) != ' ')
                    {
                        tb.Text = tb.Text.Insert(selStart, " ");
                        selStart += 1;
                    }

                    tb.SelectionStart = selStart;
                    tb.SelectionLength = 0;
                }
            };
        }

        private static int GetCurrentTokenLength(string text, int selStart, int selLen)
        {
            // 선택이 있으면, 선택 시작점을 기준으로 토큰 길이를 계산(일반적으로 자연스러움)
            int caret = selStart;

            // caret 앞쪽에서 마지막 공백 찾기
            int leftSpace = text.LastIndexOf(' ', Math.Max(0, caret - 1));
            int tokenStart = leftSpace + 1;

            // caret 이후에서 다음 공백 찾기
            int rightSpace = text.IndexOf(' ', caret);
            int tokenEnd = (rightSpace == -1) ? text.Length : rightSpace;

            // 현재 토큰 문자열 길이
            int tokenLen = tokenEnd - tokenStart;

            // 만약 선택 영역이 현재 토큰 안을 덮고 있으면, 입력 시 길이가 줄어들 수 있으니
            // 대략적으로 “선택된 부분은 지워진다”를 반영해 보정
            if (selLen > 0)
            {
                int selEnd = selStart + selLen;
                int overlapStart = Math.Max(tokenStart, selStart);
                int overlapEnd = Math.Min(tokenEnd, selEnd);
                int overlap = Math.Max(0, overlapEnd - overlapStart);
                tokenLen -= overlap;
                if (tokenLen < 0) tokenLen = 0;
            }

            return tokenLen;
        }
        public static void AttachHexOnly(TextBox tb, bool allowSpace = true)
        {
            if (tb == null) throw new ArgumentNullException(nameof(tb));

            tb.KeyPress += (s, e) =>
            {
                // 제어키(Backspace 등)는 허용
                if (char.IsControl(e.KeyChar))
                    return;

                // 공백 허용 옵션
                if (allowSpace && e.KeyChar == ' ')
                    return;

                // 0-9는 허용
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                    return;

                // a-f 입력 시 대문자로 바꿔서 통과
                if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
                {
                    e.KeyChar = char.ToUpperInvariant(e.KeyChar); // A-F로 변환
                    return;
                }

                // A-F 허용
                if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                    return;

                // 그 외는 차단
                e.Handled = true;
            };
        }
    }
}
