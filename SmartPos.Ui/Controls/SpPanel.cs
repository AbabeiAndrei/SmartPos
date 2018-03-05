using System.Linq;
using System.Windows.Forms;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpPanel : Panel, IThemeable
    {
        public void ApplyTheme(ITheme theme)
        {
            foreach (var control in Controls.OfType<IThemeable>())
                control.ApplyTheme(theme);
        }
    }
}
