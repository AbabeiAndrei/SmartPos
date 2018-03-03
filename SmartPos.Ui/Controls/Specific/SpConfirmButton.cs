using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls.Specific
{
    public class SpConfirmButton : SpButton
    {
        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            BackColor = theme.ConfirmButtonColor;
            FlatAppearance.MouseDownBackColor = theme.ConfirmButtonDownBackColor;
            FlatAppearance.MouseOverBackColor = theme.ConfirmButtonOverBackColor;
        }
    }
}
