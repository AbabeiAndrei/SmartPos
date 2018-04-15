using System.Drawing;

namespace SmartPos.Ui.Theming
{
    public interface ITheme
    {
        Color WindowBackColor { get; }
        Color WindowForeColor { get; }
        Color WindowBorderColor { get; }

        Color ControlBackColor { get; }
        Color ControlForeColor { get; }

        Color ButtonBackColor { get; }
        Color ButtonForeColor { get; }
        Color SelectedButtonBackColor { get; }
        Color SelectedButtonForeColor { get; }

        int ButtonBorderSize { get; }
        Color ButtonBorderColor { get; }
        Color ButtonDownBackColor { get; }
        Color ButtonOverBackColor { get; }

        Color ConfirmButtonColor { get; }
        Color ConfirmButtonDownBackColor { get; }
        Color ConfirmButtonOverBackColor { get; }

        Color CancelButtonColor { get; }
        Color CancelButtonDownBackColor { get; }
        Color CancelButtonOverBackColor { get; }
        Color ToolBarBackground { get; }

        Color InfoBackColor { get; }
        Color WarningBackColor { get; }
        Color ErrorBackColor { get; }
        Color[] LoadingColors { get; }

        Color FreeTableColor { get; }
        Color OpenedTableColor { get; }
        Color OcupiedTableColor { get; }

        Color StornoOrderItemBackColor { get; }
        Color FormTransparentBackColor { get; }
    }
}