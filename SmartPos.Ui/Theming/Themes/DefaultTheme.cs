using System.Drawing;

namespace SmartPos.Ui.Theming.Themes
{
    [ThemeName("Default")]
    public class DefaultTheme : ITheme
    {
        public Color WindowBackColor { get; }
        public Color WindowForeColor { get; }
        public Color WindowBorderColor { get; }
        public Color ControlBackColor { get; }
        public Color ControlForeColor { get; }
        public Color ButtonBackColor { get; }
        public Color ButtonForeColor { get; }
        public Color SelectedButtonBackColor { get; }
        public Color SelectedButtonForeColor { get; }
        public int ButtonBorderSize { get; }
        public Color ButtonBorderColor { get; }
        public Color ButtonDownBackColor { get; }
        public Color ButtonOverBackColor { get; }
        public Color ConfirmButtonColor { get; }
        public Color ConfirmButtonDownBackColor { get; }
        public Color ConfirmButtonOverBackColor { get; }
        public Color CancelButtonColor { get; }
        public Color CancelButtonDownBackColor { get; }
        public Color CancelButtonOverBackColor { get; }
        public Color ToolBarBackground { get; }
        public Color InfoBackColor { get; }
        public Color WarningBackColor { get; }
        public Color ErrorBackColor { get; }
        public Color[] LoadingColors { get; }

        public Color FreeTableColor { get; }
        public Color OpenedTableColor { get; }
        public Color OcupiedTableColor { get; }
        
        public Color StornoOrderItemBackColor { get; }
        
        public Color FormTransparentBackColor { get; }

        public DefaultTheme()
        {
            WindowBackColor = MaterialColors.Black;
            WindowForeColor = MaterialColors.White;
            WindowBorderColor = MaterialColors.White;

            ControlBackColor = MaterialColors.Black;
            ControlForeColor = MaterialColors.White;

            ButtonBackColor = MaterialColors.Grey(ColorDepth.C900);
            ButtonForeColor = MaterialColors.White;
            SelectedButtonBackColor = MaterialColors.Grey();
            SelectedButtonForeColor = ButtonForeColor;

            ButtonBorderSize = 1;
            ButtonBorderColor = MaterialColors.Grey(ColorDepth.C400);
            ButtonDownBackColor = MaterialColors.Grey();
            ButtonOverBackColor = MaterialColors.Grey(ColorDepth.C600);

            ConfirmButtonColor = MaterialColors.Green(ColorDepth.C600);
            ConfirmButtonDownBackColor = MaterialColors.Green(ColorDepth.C300);
            ConfirmButtonOverBackColor = MaterialColors.Green(ColorDepth.C400);

            CancelButtonColor = MaterialColors.Red();
            CancelButtonDownBackColor = MaterialColors.Red(ColorDepth.A700);
            CancelButtonOverBackColor = MaterialColors.Red(ColorDepth.C400);

            ToolBarBackground = MaterialColors.Grey(ColorDepth.C800);

            InfoBackColor = MaterialColors.Green();
            WarningBackColor = MaterialColors.Amber();
            ErrorBackColor = MaterialColors.Red();

            FreeTableColor = MaterialColors.Green();
            OpenedTableColor = MaterialColors.Amber();
            OcupiedTableColor = MaterialColors.Red();

            StornoOrderItemBackColor = MaterialColors.Red(ColorDepth.C200);

            FormTransparentBackColor = MaterialColors.Grey(ColorDepth.C200);

            LoadingColors = new[]
                            {
                                MaterialColors.Red(),
                                MaterialColors.Amber(),
                                MaterialColors.Green(),
                                MaterialColors.Pink(),
                                MaterialColors.Purple(),
                                MaterialColors.DeepOrange(),
                                MaterialColors.Blue(),
                                MaterialColors.Amber()
                            };
        }
    }
}
