using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmartPos.Ui.Utils;

namespace SmartPos.Ui.Controls
{
    public class SpListView : ListView
    {
        #region Overrides of ListView

        /// <inheritdoc />
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            WinApi.SetWindowTheme(Handle, "Explorer", 0);
        }

        #endregion
    }
}
