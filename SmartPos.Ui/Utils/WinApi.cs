using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SmartPos.Ui.Utils
{
    public static class WinApi
    {
        public const int WmSetredraw = 11;

        public const int EmSetmargins = 0xD3;
        public const int EmSetcuebanner = 0x1501;
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, string lParam);

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
