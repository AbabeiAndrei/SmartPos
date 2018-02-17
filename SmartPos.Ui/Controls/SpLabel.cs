using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
