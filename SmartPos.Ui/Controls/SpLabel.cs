using System.Drawing;
using System.Windows.Forms;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpLabel : Label, IThemeable
    {
        public virtual void ApplyTheme(ITheme theme)
        {
            BackColor = Color.Transparent;
            ForeColor = theme.WindowForeColor;
        }
    }
}
