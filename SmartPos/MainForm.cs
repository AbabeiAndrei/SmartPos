using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SmartPos.Desktop.Controls;
using SmartPos.Desktop.Utils;
using SmartPos.DomainModel;
using SmartPos.Ui;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Security;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Utils;
using SmartPos.Utils;

namespace SmartPos.Desktop
{
    public partial class MainForm : BaseForm
    {
        private ITheme _theme;

#if DEBUG
        protected override bool ShowWindowBorder => false;
#endif

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            FormBorderStyle = FormBorderStyle.FixedSingle;
#endif
    }

        public void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var authException = e.ExceptionObject as NotAuthorizedException;
            if (authException != null)
                MessageBox.Show(this, "Cannot access requested resource.\n" + authException.RequestedType.FullName, 
                                Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);

            _theme = theme;

            if (theme != null)
            {
                BackColor = theme.WindowBackColor;
                ForeColor = theme.WindowForeColor;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!AuthenticationManager.IsLoggedIn)
                UiHelper.ShowForm<ctrlNumericKeyboard>(UiHelper.Title("Login"), this)
                        .Configure(control => control.KeyboardLayout = NumericKeyboardLayout.Pin)
                        .OnConfirm(PerformLogin)
                        .AddDrawer()
                        .ApplyTheme(_theme)
                        .Show();
        }

        private void PerformLogin(IFormResult result, IContinuityDelegate after)
        {
            var pin = result.Result?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(pin))
            {
                after.PresentMessage("Pin is empty", MessageType.Error);
                return;
            }

            ShowMessage("Login successful", MessageType.Info, 1000);
            after.Close = true;
        }
    }
}
