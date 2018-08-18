using System.ComponentModel;
using System.Windows.Forms;

namespace SmartPos.Ui.Handlers
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
