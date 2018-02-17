using System;
using System.Threading;
using System.Windows.Forms;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop
{
    using Application = System.Windows.Forms.Application;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            form.ApplyTheme(ThemeManager.GetTheme(Properties.Settings.Default.ThemeName));

            //Application.ThreadException += (a, b) => MessageBox.Show(a.ToString() + "\n" + b.ToString());

            // Set the unhandled exception mode to force all Windows Forms errors
            // to go through our handler.
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            //AppDomain.CurrentDomain.UnhandledException += form.ExceptionHandler;

            System.Windows.Forms.Application.Run(form);
        }
    }
}
