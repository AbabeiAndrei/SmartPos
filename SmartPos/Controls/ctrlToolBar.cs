using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Security;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Security;

namespace SmartPos.Desktop.Controls
{
    [PosAuthorisation]
    public partial class CtrlToolBar : BaseControl
    {
        public CtrlToolBar()
        {
            InitializeComponent();
        }

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);

            if (theme != null)
                BackColor = theme.ToolBarBackground;
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            AuthenticationManager.Logout();
            ParentForm.ShowMessage("Logout successful", MessageType.Info, 1000);
        }
    }
}
