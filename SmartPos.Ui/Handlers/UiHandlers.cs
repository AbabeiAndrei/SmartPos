using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Ui.Handlers;
using SmartPos.Utils;

namespace SmartPos.Ui
{
    public enum MessageType
    {
        Info, 
        Warning,
        Error
    }

    public delegate void ConfirmFormHandler(IFormResult result, IContinuityDelegate after);

    public delegate void CloseFormHandler(IFormResult result, CancelEventArgs args);

    public delegate void CloseFormResult(DialogResult result);

    public delegate void TextHandler(object sender, string text);
}
