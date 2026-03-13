using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MifareTool.Controls
{
    public class RoundedLabel : Label
    {
        private int _cornerRadius = 10;
        private int _letterSpacing = 0;
        private Color _borderColor = Color.Transparent;
        private int _borderWidth = 0;
        private bool _useGradient = false;
        private Color _gradientColor = Color.Transparent;

        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        /// <summary>문자 사이 추가 간격 (픽셀)</summary>
        public int LetterSpacing
        {
            get => _letterSpacing;
            set { _letterSpacing = value; Invalidate(); }
        }

        /// <summary>테두리 색상 (Transparent 이면 테두리 없음)</summary>
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        /// <summary>테두리 두께 (픽셀)</summary>
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value; Invalidate(); }
        }

        /// <summary>그라디언트 사용 여부</summary>
        public bool UseGradient
        {
            get => _useGradient;
            set { _useGradient = value; Invalidate(); }
        }

        /// <summary>그라디언트 끝 색상 (UseGradient=true 일 때 사용)</summary>
        public Color GradientColor
        {
            get => _gradientColor;
            set { _gradientColor = value; Invalidate(); }
        }

        public RoundedLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 직사각형 기본 배경 대신 부모 배경을 그려서 모서리가 투명하게 보이도록 함
            if (Parent != null)
            {
                var pt = Parent.PointToClient(PointToScreen(Point.Empty));
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.DrawToBitmap(bmp, new Rectangle(0, 0, Parent.Width, Parent.Height));
                    e.Graphics.DrawImage(bmp,
                        new Rectangle(0, 0, Width, Height),
                        new Rectangle(pt.X, pt.Y, Width, Height),
                        GraphicsUnit.Pixel);
                }
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = CreateRoundedRect(rect, _cornerRadius))
            {
                // 배경 채우기
                if (_useGradient && _gradientColor != Color.Transparent)
                {
                    using (LinearGradientBrush bg = new LinearGradientBrush(
                        rect, BackColor, _gradientColor, LinearGradientMode.Vertical))
                        e.Graphics.FillPath(bg, path);
                }
                else
                {
                    using (SolidBrush bg = new SolidBrush(BackColor))
                        e.Graphics.FillPath(bg, path);
                }

                // 클리핑
                e.Graphics.SetClip(path);

                // 텍스트 그리기 (LetterSpacing 적용)
                DrawTextWithSpacing(e.Graphics, rect);

                e.Graphics.ResetClip();

                // 테두리 (클리핑 해제 후 위에 그려야 선명하게)
                if (_borderWidth > 0 && _borderColor != Color.Transparent)
                {
                    using (Pen borderPen = new Pen(_borderColor, _borderWidth))
                    {
                        borderPen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            }
        }

        private void DrawTextWithSpacing(Graphics g, Rectangle rect)
        {
            if (string.IsNullOrEmpty(Text)) return;

            string text = Text;

            if (_letterSpacing == 0)
            {
                // 기본 렌더링
                TextRenderer.DrawText(
                    g, text, Font, rect, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            // 각 문자 너비 측정 (GenericTypographic으로 여백 없이)
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

            float totalWidth = 0f;
            float[] charWidths = new float[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                SizeF sz = g.MeasureString(text[i].ToString(), Font, int.MaxValue, sf);
                charWidths[i] = sz.Width;
                totalWidth += sz.Width;
            }
            totalWidth += _letterSpacing * (text.Length - 1);

            // 문자 높이 (전체 텍스트 기준)
            SizeF fullSize = g.MeasureString(text, Font, int.MaxValue, sf);
            float charH = fullSize.Height;

            float startX = rect.X + (rect.Width - totalWidth) / 2f;
            float startY = rect.Y + (rect.Height - charH) / 2f;

            using (SolidBrush brush = new SolidBrush(ForeColor))
            {
                float x = startX;
                for (int i = 0; i < text.Length; i++)
                {
                    g.DrawString(text[i].ToString(), Font, brush, x, startY, sf);
                    x += charWidths[i] + _letterSpacing;
                }
            }
        }

        private static GraphicsPath CreateRoundedRect(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
