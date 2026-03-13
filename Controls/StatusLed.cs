using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHServerLPR.Controls
{
    using DHServerLPR.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class StatusLed : Control
    {
        private bool _isNormal = true;

        [Category("Behavior")]
        [Description("정상이면 true(녹색), 비정상이면 false(적색)")]
        public bool IsNormal
        {
            get => _isNormal;
            set
            {
                if (_isNormal == value) return;
                _isNormal = value;
                Invalidate();   // 다시 그리기
            }
        }

        [Category("Appearance")]
        public Color NormalColor { get; set; } = Color.LimeGreen;

        [Category("Appearance")]
        public Color AbnormalColor { get; set; } = Color.Crimson;

        public StatusLed()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.UserPaint, true);
            Size = new Size(20, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var size = Math.Min(Width, Height);
            var circle = new Rectangle(0, 0, size - 1, size - 1);

            using (var brush = new SolidBrush(IsNormal ? NormalColor : AbnormalColor))
            using (var pen = new Pen(Color.FromArgb(60, 0, 0, 0), 1.2f))
            {
                g.FillEllipse(brush, circle);
                g.DrawEllipse(pen, circle);
            }
        }

        // ===== 핵심: 비차단 깜빡임 =====
        private CancellationTokenSource _blinkCts;

        private int _blinkRefCount;

        public async Task BlinkGreenRefAsync(int durationMs = 200)
        {
            Interlocked.Increment(ref _blinkRefCount);
            await this.InvokeAsync(() => IsNormal = true);

            try { await Task.Delay(durationMs); }
            catch (TaskCanceledException) { /* 생략 가능 */ }

            if (Interlocked.Decrement(ref _blinkRefCount) == 0)
                await this.InvokeAsync(() => IsNormal = false); // 혹은 prev 저장/복원 로직
        }
        /// <summary>
        /// 지정한 시간(ms) 동안 녹색으로 유지한 뒤 원래 상태로 복원(비차단, 정확).
        /// 여러 번 호출 시 이전 깜빡임을 취소하고 최신 호출만 반영.
        /// </summary>
        public async Task BlinkGreenAsync(int durationMs = 200)
        {
            // 이전 깜빡임 취소
            _blinkCts?.Cancel();
            _blinkCts?.Dispose();
            _blinkCts = new CancellationTokenSource();
            var token = _blinkCts.Token;

            bool prev = IsNormal;

            // UI 스레드 보장
            if (InvokeRequired)
            {
                await Task.Factory.FromAsync(BeginInvoke((Action)(() => IsNormal = true)), EndInvoke);
            }
            else
            {
                IsNormal = true;
            }

            try
            {
                // 정확도: Task.Delay는 UI를 막지 않고 시스템 타이머 정밀도(보통 15.6ms) 내에서 동작
                await Task.Delay(durationMs, token);
            }
            catch (TaskCanceledException)
            {
                return; // 새 호출에 의해 취소됨
            }

            if (token.IsCancellationRequested) return;

            // 복원 (UI 스레드)
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => IsNormal = prev));
            }
            else
            {
                IsNormal = prev;
            }
        }

        /// <summary>
        /// N회 깜빡(켜짐/꺼짐) 패턴. on/off를 개별 ms로 제어.
        /// </summary>
        public async Task FlashGreenAsync(int flashes = 3, int onMs = 120, int offMs = 120)
        {
            _blinkCts?.Cancel();
            _blinkCts?.Dispose();
            _blinkCts = new CancellationTokenSource();
            var token = _blinkCts.Token;

            bool prev = IsNormal;

            try
            {
                for (int i = 0; i < flashes; i++)
                {
                    if (token.IsCancellationRequested) return;

                    if (InvokeRequired) BeginInvoke((Action)(() => IsNormal = true));
                    else IsNormal = true;
                    await Task.Delay(onMs, token);

                    if (token.IsCancellationRequested) return;

                    if (InvokeRequired) BeginInvoke((Action)(() => IsNormal = false));
                    else IsNormal = false;
                    await Task.Delay(offMs, token);
                }
            }
            catch (TaskCanceledException) { return; }
            finally
            {
                if (!token.IsCancellationRequested)
                {
                    if (InvokeRequired) BeginInvoke((Action)(() => IsNormal = prev));
                    else IsNormal = prev;
                }
            }
        }
    }
}
