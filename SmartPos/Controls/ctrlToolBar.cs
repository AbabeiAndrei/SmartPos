using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Security;

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

            btnLogout.ApplyTheme(theme);
            btnOptions.ApplyTheme(theme);

            if (theme != null)
                BackColor = theme.ToolBarBackground;
        }
    }
}
