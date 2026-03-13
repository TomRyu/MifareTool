using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MifareTool.Class
{
    internal static class ClickThroughHelper
    {
        internal const int WM_MOUSEACTIVATE = 0x21;
        internal static readonly IntPtr MA_ACTIVATE = (IntPtr)1;
        // 기본값 MA_ACTIVATEANDEAT(2)를 MA_ACTIVATE(1)로 바꿔 ‘첫 클릭도 전달’하게 함.
        internal static bool HandleMouseActivate(ref Message m, bool designMode)
        {
            if (m.Msg == WM_MOUSEACTIVATE && !designMode)
            {
                m.Result = MA_ACTIVATE; // 클릭 먹지 말고 활성화+클릭 전달
                return true;
            }
            return false;
        }
    }

    public class ClickThroughToolStrip : ToolStrip
    {
        protected override void WndProc(ref Message m)
        {
            if (ClickThroughHelper.HandleMouseActivate(ref m, DesignMode)) return;
            base.WndProc(ref m);
        }
    }

    public class ClickThroughMenuStrip : MenuStrip
    {
        protected override void WndProc(ref Message m)
        {
            if (ClickThroughHelper.HandleMouseActivate(ref m, DesignMode)) return;
            base.WndProc(ref m);
        }
    }

    public class ClickThroughStatusStrip : StatusStrip
    {
        protected override void WndProc(ref Message m)
        {
            if (ClickThroughHelper.HandleMouseActivate(ref m, DesignMode)) return;
            base.WndProc(ref m);
        }
    }

    public class ClickThroughContextMenuStrip : ContextMenuStrip
    {
        public ClickThroughContextMenuStrip() : base() { }
        public ClickThroughContextMenuStrip(System.ComponentModel.IContainer c) : base(c) { }

        protected override void WndProc(ref Message m)
        {
            if (ClickThroughHelper.HandleMouseActivate(ref m, DesignMode)) return;
            base.WndProc(ref m);
        }
    }
}
