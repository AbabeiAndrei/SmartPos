using System;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var form = new MainForm();
            form.ApplyTheme(ThemeManager.GetTheme(Properties.Settings.Default.ThemeName));

            System.Windows.Forms.Application.Run(form);
        }
    }
}
