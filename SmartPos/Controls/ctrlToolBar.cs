using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmartPos.Desktop.Interfaces;
using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Security;
using SmartPos.Ui.Controls;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Security;

namespace SmartPos.Desktop.Controls
{
    [PosAuthorisation]
    public partial class CtrlToolBar : BaseControl
    {
        #region Fields

        private ITheme _theme;

        #endregion

        #region Events

        public event EventHandler OptionPressed;

        #endregion

        #region Constructors

        public CtrlToolBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of BaseControl

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _theme = theme;

            if (theme != null)
                BackColor = theme.ToolBarBackground;
        }

        #endregion

        #region Public methods

        public void ResetCustomize()
        {
            Customize(null);
        }

        public void Customize(IToolBarCustomizer customizer)
        {
            try
            {
                SuspendLayout();
                customizer = customizer ?? new DefaultToolBarCustomizer();

                pnlLogout.Visible = customizer.ShowLogout;
                pnlOptions.Visible = customizer.ShowOptions;

                ClearButtons();

                if (customizer.Buttons == null)
                    return;

                foreach (var toolBarButton in customizer.Buttons)
                {
                    var button = CreateButton(toolBarButton);

                    if (toolBarButton.Location == ToolBarButtonLocation.Left)
                        flowLeft.Controls.Add(button);
                    else
                        flowRight.Controls.Add(button);
                }
            }
            finally
            {
                ResumeLayout();
            }
        }

        #endregion

        #region Private methods

        private SpButton CreateButton(IToolBarButton toolBarButton)
        {
            var button = new SpButton
                         {
                            Text = toolBarButton.Text,
                            Size = btnLogout.Size
                         };

            button.ApplyTheme(_theme);
            button.Click += async (s, e) => await ToolBarCustomButtonClick(toolBarButton.Action);

            return button;
        }

        private static Task ToolBarCustomButtonClick(Func<Task> action)
        {
            return action == null
                           ? Task.CompletedTask
                           : action();
        }

        private void ClearButtons()
        {
            foreach (var button in flowLeft.Controls.OfType<SpButton>())
                button.Dispose();

            foreach (var button in flowRight.Controls.OfType<SpButton>())
                button.Dispose();

            flowLeft.Controls.Clear();
            flowRight.Controls.Clear();
        }

        #endregion

        #region Event handlers

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticationManager.Logout();
            ParentForm.ShowMessage("Logout successful", MessageType.Info, 1000);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionPressed?.Invoke(sender, e);
        }

        #endregion
    }
}
