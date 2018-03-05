using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpFlowPanel : FlowLayoutPanel, IThemeable
    {
        public void ApplyTheme(ITheme theme)
        {
            foreach (var control in Controls.OfType<IThemeable>())
                control.ApplyTheme(theme);
        }
    }
}
