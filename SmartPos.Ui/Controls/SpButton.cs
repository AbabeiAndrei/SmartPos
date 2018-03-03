using System.Windows.Forms;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpButton : Button, IThemeable
    {
        public virtual void ApplyTheme(ITheme theme)
        {
            BackColor = theme.ButtonBackColor;
            ForeColor = theme.ButtonForeColor;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = theme.ButtonBorderSize;
            FlatAppearance.BorderColor = theme.ButtonBorderColor;
            FlatAppearance.MouseDownBackColor = theme.ButtonDownBackColor;
            FlatAppearance.MouseOverBackColor = theme.ButtonOverBackColor;
        }
    }
}
