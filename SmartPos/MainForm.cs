using System;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;

using SmartPos.Ui;
using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Controls;
using SmartPos.Desktop.Communication;

using AuthenticationManager = SmartPos.Ui.Security.AuthenticationManager;

namespace SmartPos.Desktop
{
    public sealed partial class MainForm : BaseForm
    {
        #region Fields

        private readonly ApiClient _apiClient;
        private ITheme _theme;

        #endregion

        #region Properties

#if DEBUG
        protected override bool ShowWindowBorder => false;
#endif

        protected override int MessageLineTop => ctrlStatusBar?.Bottom ?? base.MessageLineTop;
        
        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            FormBorderStyle = FormBorderStyle.FixedSingle;
#endif
            _apiClient = new ApiClient(LoadingState);
        }

        #endregion

        #region Implementation of IThemeable

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);

            _theme = theme;

            if (theme == null)
                return;

            BackColor = theme.WindowBackColor;
            ForeColor = theme.WindowForeColor;
        }

        #endregion

        #region Overrides

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!AuthenticationManager.IsLoggedIn)
                UiHelper.ShowForm<CtrlNumericKeyboard>(UiHelper.Title("Login"), this)
                        .Configure(control => control.KeyboardLayout = NumericKeyboardLayout.Pin)
                        .OnConfirm(PerformLogin)
                        .AddDrawer()
                        .ApplyTheme(_theme)
                        .Show();
        }

        #endregion

        #region Public methods

        private async Task PerformLogin(IFormSender sender, IContinuityDelegate after)
        {
            var pin = sender.Result?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(pin))
            {
                after.PresentMessage("Pin is empty", MessageType.Error);
                return;
            }

            try
            {
                var loaderToken = sender.Form.LoadingState;
                var apiClient = Application.Api(loaderToken);
                var user = await apiClient.Account.Login(pin);
                AuthenticationManager.User = user;
            }
            catch (RequestException ex)
                when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                after.PresentMessage("Incorect PIN!", MessageType.Error);
                return;
            }
            catch (Exception ex)
            {
                after.PresentMessage(ex.Message, MessageType.Error);
                return;
            }
            finally
            {
                sender.Control.Text = string.Empty;
            }
            
            ShowMessage("Login successful", MessageType.Info, 1000);
            after.Close = true;
            await InitializePos();
        }

        private async Task InitializePos()
        {
            await ctrlWorkspace.Initialize(_apiClient);
        }

        #endregion
    }
}
