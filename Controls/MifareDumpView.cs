using MifareTool.Class;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MifareTool.Controls
{
    public partial class MifareDumpView : UserControl
    {
        private float _fontScale = 1.0f;

        private void ApplyFonts()
        {
            if (SectorFont != null)
                SectorFont.Dispose();

            if (DumpFont != null)
                DumpFont.Dispose();

            SectorFont = new Font("맑은 고딕", 20f * _fontScale, FontStyle.Regular);
            DumpFont = new Font("Consolas", 19f * _fontScale, FontStyle.Regular);

            UpdateScrollSize();
            Invalidate();
        }
        private MifareDumpData _dumpData;

        public MifareDumpData DumpData
        {
            get { return _dumpData; }
            set
            {
                _dumpData = value;
                UpdateScrollSize();
                Invalidate();
            }
        }

        public Color BackColorDark { get; set; } = Color.FromArgb(34, 34, 34);
        public Color SectorTitleColor { get; set; } = Color.FromArgb(135, 220, 220);
        public Color NormalTextColor { get; set; } = Color.White;
        public Color UidColor { get; set; } = Color.FromArgb(180, 80, 255);        // 보라
        public Color ValueBlockColor { get; set; } = Color.FromArgb(230, 215, 40); // 노랑
        public Color KeyColor { get; set; } = Color.FromArgb(100, 255, 100);       // 연두
        public Color AccessColor { get; set; } = Color.FromArgb(255, 140, 40);     // 주황
        public Color SeparatorColor { get; set; } = Color.FromArgb(180, 180, 180);

        public Font SectorFont { get; set; }
        public Font DumpFont { get; set; }

        private readonly int _leftMargin = 20;
        private readonly int _topMargin = 6;
        private readonly int _sectorGap = 9;
        private readonly int _lineGap = 4;
        private readonly int _separatorGap = 7;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("전체 글자 확대/축소 배율")]
        public float FontScale
        {
            get { return _fontScale; }
            set
            {
                if (value <= 0.1f)
                    value = 0.1f;

                _fontScale = value;
                ApplyFonts();
            }
        }

        public MifareDumpView()
        {
            DoubleBuffered = true;
            AutoScroll = true;
            BackColor = BackColorDark;

            ApplyFonts();

            SectorFont = new Font("맑은 고딕", 20f, FontStyle.Regular);
            DumpFont = new Font("Consolas", 19f, FontStyle.Regular);

            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColorDark);
            e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (_dumpData == null || _dumpData.Sectors == null || _dumpData.Sectors.Count == 0)
            {
                using (var br = new SolidBrush(Color.Gray))
                {
                    e.Graphics.DrawString("No dump data", DumpFont, br, _leftMargin, _topMargin);
                }
                return;
            }

            int y = _topMargin;

            foreach (var sector in _dumpData.Sectors)
            {
                y = DrawSector(e.Graphics, sector, y);
            }
        }

        private int DrawSector(Graphics g, MifareDumpSector sector, int y)
        {
            using (var sectorBrush = new SolidBrush(SectorTitleColor))
            {
                g.DrawString("Sector: " + sector.SectorIndex, SectorFont, sectorBrush, _leftMargin, y);
            }

            y += (int)SectorFont.GetHeight(g) + 4;

            if (sector.ReadFailed)
            {
                using (var br = new SolidBrush(Color.FromArgb(220, 60, 60)))
                {
                    g.DrawString("No keys found (or dead sector)", DumpFont, br, _leftMargin + 8, y);
                }

                y += (int)DumpFont.GetHeight(g) + _lineGap;
            }
            else
            {
                foreach (var block in sector.Blocks.OrderBy(b => b.BlockIndexInSector))
                {
                    y = DrawBlock(g, block, y);
                }
            }

            int sepY = y + 2;
            using (var pen = new Pen(SeparatorColor, 2))
            {
                g.DrawLine(pen, _leftMargin + 8, sepY, Width - 60, sepY);
            }

            y = sepY + _separatorGap + _sectorGap;
            return y;
        }

        private int DrawBlock(Graphics g, MifareDumpBlock block, int y)
        {
            if (block.Data == null || block.Data.Length != 16)
            {
                using (var br = new SolidBrush(Color.Red))
                {
                    g.DrawString("????????????????????????????????", DumpFont, br, _leftMargin + 8, y);
                }

                return y + (int)DumpFont.GetHeight(g) + _lineGap;
            }

            if (block.IsSector0Block0)
            {
                DrawColoredHex(g, block, y, Sector0Block0ColorSelector);
            }
            else if (block.IsTrailerBlock)
            {
                DrawColoredHex(g, block, y, TrailerColorSelector);
            }
            else if (IsValueBlock(block.Data))
            {
                DrawColoredHex(g, block, y, ValueBlockColorSelector);
            }
            else
            {
                DrawColoredHex(g, block, y, NormalColorSelector);
            }

            return y + (int)DumpFont.GetHeight(g) + _lineGap;
        }

        private Color Sector0Block0ColorSelector(int byteIndex)
        {
            // Sector 0 / Block 0 전체를 UID/Manufacturer 컬러로
            return UidColor;
        }

        private Color TrailerColorSelector(int byteIndex)
        {
            // Trailer 구조
            // [0..5]   KeyA
            // [6..8]   Access Bits
            // [9]      General Purpose Byte
            // [10..15] KeyB
            if (byteIndex >= 0 && byteIndex <= 5)
                return KeyColor;

            if (byteIndex >= 6 && byteIndex <= 9)
                return AccessColor;

            if (byteIndex >= 10 && byteIndex <= 15)
                return KeyColor;

            return NormalTextColor;
        }

        private Color ValueBlockColorSelector(int byteIndex)
        {
            return ValueBlockColor;
        }

        private Color NormalColorSelector(int byteIndex)
        {
            return NormalTextColor;
        }

        private void DrawColoredHex(Graphics g, MifareDumpBlock block, int y, Func<int, Color> colorSelector)
        {
            float x = _leftMargin + 8;
            float charWidth = MeasureCharWidth(g);

            for (int i = 0; i < 16; i++)
            {
                bool unknown = block.UnknownMask != null && block.UnknownMask.Length > i && block.UnknownMask[i];
                string text = unknown ? "--" : block.Data[i].ToString("X2");
                Color color = unknown ? KeyColor : colorSelector(i);

                using (var br = new SolidBrush(color))
                {
                    g.DrawString(text, DumpFont, br, x, y);
                }

                x += charWidth * 2;
            }
        }

        private float MeasureCharWidth(Graphics g)
        {
            SizeF size = g.MeasureString("F", DumpFont, 1000, StringFormat.GenericTypographic);
            return size.Width;
        }

        private bool IsValueBlock(byte[] block)
        {
            if (block == null || block.Length != 16)
                return false;

            // MIFARE Value Block 형식
            // [0..3]   value
            // [4..7]   ~value
            // [8..11]  value
            // [12]     addr
            // [13]     ~addr
            // [14]     addr
            // [15]     ~addr

            bool valueMirror =
                block[0] == block[8] &&
                block[1] == block[9] &&
                block[2] == block[10] &&
                block[3] == block[11];

            bool valueInverse =
                block[4] == (byte)~block[0] &&
                block[5] == (byte)~block[1] &&
                block[6] == (byte)~block[2] &&
                block[7] == (byte)~block[3];

            bool addrRule =
                block[12] == block[14] &&
                block[13] == (byte)~block[12] &&
                block[15] == (byte)~block[14];

            return valueMirror && valueInverse && addrRule;
        }

        private void UpdateScrollSize()
        {
            if (_dumpData == null || _dumpData.Sectors == null)
            {
                AutoScrollMinSize = new Size(0, 0);
                return;
            }

            int lineH = TextRenderer.MeasureText("A", DumpFont).Height;
            int sectorH = TextRenderer.MeasureText("A", SectorFont).Height;

            int totalHeight = _topMargin;
            foreach (var sector in _dumpData.Sectors)
            {
                int blockLines = sector.ReadFailed ? 1 : 4;
                totalHeight += sectorH + 4 + (blockLines * (lineH + _lineGap)) + _separatorGap + _sectorGap;
            }
            totalHeight += 40;

            AutoScrollMinSize = new Size(0, totalHeight);
        }
    }
}