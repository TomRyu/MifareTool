using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DHServerLPR.Controls
{
    [DefaultEvent(nameof(AddressChanged))]
    public class IpAddressControl : UserControl
    {
        private readonly TextBox[] _box = new TextBox[4];
        private bool _handlingPaste;

        public event EventHandler AddressChanged;

        public IpAddressControl()
        {
            Height = 24;
            CreateUi();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void CreateUi()
        {
            int segWidth = 32, dotWidth = 8, pad = 2;
            int x = 0;

            for (int i = 0; i < 4; i++)
            {
                var tb = new TextBox
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    MaxLength = 3,
                    TextAlign = HorizontalAlignment.Center,
                    Location = new Point(x, 0),
                    Width = segWidth,
                    Tag = i,
                };
                tb.KeyPress += Segment_KeyPress;
                tb.TextChanged += Segment_TextChanged;
                tb.Enter += (s, e) => ((TextBox)s).SelectAll();
                tb.Validating += Segment_Validating;
                tb.KeyDown += Segment_KeyDown;
                Controls.Add(tb);
                _box[i] = tb;

                x += segWidth;
                if (i < 3)
                {
                    var dot = new Label
                    {
                        AutoSize = false,
                        Text = ".",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(x, 0),
                        Width = dotWidth,
                        Height = tb.Height
                    };
                    Controls.Add(dot);
                    x += dotWidth + pad;
                }
            }
            Width = x;
        }

        // 숫자/백스페이스/점만 허용
        private void Segment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.')
            {
                MoveNext((TextBox)sender);
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // 3자리 되면 자동 이동
        private void Segment_TextChanged(object sender, EventArgs e)
        {
            if (_handlingPaste) return;
            var tb = (TextBox)sender;
            if (tb.Text.Length == 3) MoveNext(tb);
            OnAddressChanged();
        }

        // 0~255 강제
        private void Segment_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text)) { tb.Text = "0"; return; }
            if (!int.TryParse(tb.Text, out int v) || v < 0) { tb.Text = "0"; return; }
            if (v > 255) tb.Text = "255";
        }

        // ←/→, Backspace 이동 & 붙여넣기 처리
        private void Segment_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;
            int idx = (int)tb.Tag;

            if (e.Control && e.KeyCode == Keys.V)
            {
                var clip = Clipboard.GetText()?.Trim();
                if (IPAddress.TryParse(clip, out var ip))
                {
                    _handlingPaste = true;
                    SetFromBytes(ip.GetAddressBytes());
                    _handlingPaste = false;
                    e.Handled = true;
                    OnAddressChanged();
                }
                return;
            }

            if (e.KeyCode == Keys.Left && tb.SelectionStart == 0 && idx > 0)
            {
                _box[idx - 1].Focus();
                _box[idx - 1].SelectionStart = _box[idx - 1].Text.Length;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right && tb.SelectionStart == tb.Text.Length && idx < 3)
            {
                _box[idx + 1].Focus();
                _box[idx + 1].SelectionStart = 0;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back && tb.SelectionStart == 0 && tb.SelectionLength == 0 && idx > 0)
            {
                _box[idx - 1].Focus();
                _box[idx - 1].SelectionStart = Math.Max(0, _box[idx - 1].Text.Length - 1);
                e.Handled = false;
            }
        }

        private void MoveNext(TextBox tb)
        {
            int idx = (int)tb.Tag;
            if (idx < 3) _box[idx + 1].Focus();
        }

        private void SetFromBytes(byte[] bytes)
        {
            if (bytes?.Length != 4) return;
            for (int i = 0; i < 4; i++) _box[i].Text = bytes[i].ToString();
            _box[3].SelectionStart = _box[3].Text.Length;
            _box[3].SelectionLength = 0;
        }

        private void OnAddressChanged() => AddressChanged?.Invoke(this, EventArgs.Empty);

        // ---- 공개 속성 ----
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => string.Join(".", _box.Select(b => string.IsNullOrWhiteSpace(b.Text) ? "0" : b.Text));
            set
            {
                if (IPAddress.TryParse(value, out var ip)) SetFromBytes(ip.GetAddressBytes());
            }
        }

        [Browsable(false)]
        public IPAddress Address
        {
            get
            {
                var parts = _box.Select(b => int.TryParse(b.Text, out int v) ? Math.Max(0, Math.Min(255, v)) : 0)
                                .Select(v => (byte)v)
                                .ToArray();
                return new IPAddress(parts);
            }
            set
            {
                if (value == null) return;
                SetFromBytes(value.GetAddressBytes());
            }
        }

        public bool TryGetAddress(out IPAddress ip)
        {
            ip = null;
            var s = Text;
            return IPAddress.TryParse(s, out ip);
        }

        public void ClearAddress()
        {
            foreach (var b in _box) b.Text = "0";
        }
    }
}
