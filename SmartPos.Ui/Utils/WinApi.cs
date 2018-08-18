using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SmartPos.Ui.Utils
{
    public static class WinApi
    {
        #region Constants

        public const int WM_SETREDRAW = 11;

        public const int EM_SETMARGINS = 0xD3;
        public const int EM_SETCUEBANNER = 0x1501;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        
        private const string USER32_DLL = "user32.dll";
        private const string KERNEL32_DLL = "kernel32.dll";
        private const string UXTHEME_DLL = "uxtheme.dll";

        #endregion

        [DllImport(USER32_DLL)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32_DLL)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        [DllImport(USER32_DLL)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport(USER32_DLL)]
        public static extern bool ReleaseCapture();

        [DllImport(USER32_DLL, CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, string lParam);
        
        [DllImport(KERNEL32_DLL, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
        
        [DllImport(UXTHEME_DLL, ExactSpelling=true, CharSet=CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, int pszSubIdList);

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WmSetredraw, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WmSetredraw, true, 0);
            parent.Refresh();
        }
    }
}
