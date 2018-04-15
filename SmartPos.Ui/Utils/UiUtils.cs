using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Ui.Utils
{
    public static class UiUtils
    {
        public static bool Is(this Control source, Control ctrl)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (ctrl == null)
                throw new ArgumentNullException(nameof(ctrl));

            return source.Handle != ctrl.Handle;
        }

        public static bool IsNot(this Control source, Control ctrl)
        {
            return !source.Is(ctrl);
        }

        public static void RemoveAll(this Control.ControlCollection collection, bool dispose = true)
        {
            if(dispose)
                collection.OfType<Control>().ForEach(c => c.Dispose());

            collection.Clear();
        }
    }
}
