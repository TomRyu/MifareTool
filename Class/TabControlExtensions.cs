using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MifareTool.Class
{
    public static class TabControlExtensions
    {
        // 숨긴 탭을 복원하기 위해 원본 인덱스를 저장
        private static readonly Dictionary<TabPage, int> _originalIndex = new Dictionary<TabPage, int>();

        public static void HideTab(this TabControl tab, TabPage page)
        {
            if (page == null) return;
            if (!tab.TabPages.Contains(page)) return; // 이미 숨겨진 상태

            if (!_originalIndex.ContainsKey(page))
                _originalIndex[page] = tab.TabPages.IndexOf(page);

            tab.TabPages.Remove(page);
        }

        public static void ShowTab(this TabControl tab, TabPage page)
        {
            if (page == null) return;
            if (tab.TabPages.Contains(page)) return; // 이미 보이는 상태

            int idx;
            if (!_originalIndex.TryGetValue(page, out idx)) idx = tab.TabPages.Count;

            // 인덱스가 범위를 벗어나면 뒤에 붙임
            idx = Math.Max(0, Math.Min(idx, tab.TabPages.Count));
            tab.TabPages.Insert(idx, page);
        }

        public static void SetTabVisible(this TabControl tab, TabPage page, bool visible)
        {
            if (visible) tab.ShowTab(page);
            else tab.HideTab(page);
        }
    }
}
