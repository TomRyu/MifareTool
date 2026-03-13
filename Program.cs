using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MifareTool
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //checkAndRegFonts();
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                //if (ex.Message == "LICENSE_FAIL")
                //{
                //    MessageBox.Show("라이센스 인증에 실패했습니다!",
                //                    "License Error",
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Error);
                //}
            }
        }


        #region 폰트 등록 관련
        private static void checkAndRegFonts()
        {
            DirectoryInfo di = new DirectoryInfo("Fonts");

            if (di.Exists)
            {
                List<string> regFonts = new List<string>();

                foreach (var fontFile in di.GetFiles())
                {
                    if (isExistFont(fontFile.Name) == false)
                    {
                        regFonts.Add(fontFile.FullName);
                    }
                }

                if (regFonts.Count > 0)
                {
                    StartRegFontProcess(regFonts);
                }
            }
        }
        private static bool StartRegFontProcess(List<string> regList)
        {
            try
            {
                // RegFont.exe가 현재 앱과 같은 폴더에 있다고 가정
                var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RegFont.exe");
                if (!File.Exists(exePath))
                {
                    MessageBox.Show("RegFont.exe not found");
                    throw new FileNotFoundException("RegFont.exe not found", exePath);
                }

                // 공백 대비해서 인자 개별 인용
                var args = string.Join(" ", regList.Select(f => $"\"{f}\""));

                var psi = new ProcessStartInfo
                {
                    FileName = exePath,                               // 절대 경로!
                    Arguments = args,
                    WorkingDirectory = Path.GetDirectoryName(exePath),// 현재 작업폴더 고정
                    UseShellExecute = true,                           // runas 쓰려면 true
                    Verb = "runas",                                   // 관리자 권한
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process.Start(psi)) { }
                return true;
            }
            catch (System.ComponentModel.Win32Exception w32) when (w32.NativeErrorCode == 1223)
            {
                // UAC 취소
                System.Diagnostics.Debug.WriteLine("User canceled elevation.");
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        private static bool isExistFont(string fontFileName)
        {
            return File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontFileName));
        }
        #endregion
    }
}
