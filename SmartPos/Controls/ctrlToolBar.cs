using SmartPos.Desktop.Security;
using SmartPos.Ui;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop.Controls
{
    [PosAuthorisation]
    public partial class ctrlToolBar : BaseControl
    {
        public ctrlToolBar()
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
