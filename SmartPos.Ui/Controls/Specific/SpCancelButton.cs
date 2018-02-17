using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls.Specific
{
    public class SpCancelButton : SpButton
    {
        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            BackColor = theme.CancelButtonColor;
            FlatAppearance.MouseDownBackColor = theme.CancelButtonDownBackColor;
            FlatAppearance.MouseOverBackColor = theme.CancelButtonOverBackColor;
        }
    }
}
