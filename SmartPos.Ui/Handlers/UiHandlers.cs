using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SmartPos.Ui.Handlers
{
    public enum MessageType
    {
        Info, 
        Warning,
        Error
    }

    public delegate Task ConfirmFormHandler(IFormSender sender, IContinuityDelegate after);

    public delegate Task CloseFormHandler(IFormSender sender, CancelEventArgs args);

    public delegate void CloseFormResult(DialogResult result);

    public delegate void TextHandler(object sender, string text);
}
