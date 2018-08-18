using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SmartPos.Ui.Handlers
{
    public delegate Task ConfirmFormHandler(IFormSender sender, IContinuityDelegate after);

    public delegate Task CloseFormHandler(IFormSender sender, CancelEventArgs args);

    public delegate void CloseFormResult(DialogResult result);

    public delegate void TextHandler(object sender, string text);

    public delegate void UiInvokeRequiredHandler();

    public delegate Task UiInvokeRequiredAsyncHandler();
}
