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

            var theme = ThemeManager.GetTheme(Properties.Settings.Default.ThemeName);
            form.ApplyTheme(theme);

            Application.InitializeUi(form);
            Application.UiTheme = theme;

            System.Windows.Forms.Application.Run(form);
        }
        
    }
}
