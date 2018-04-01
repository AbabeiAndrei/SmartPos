using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using SmartPos.Ui;
using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Controls;
using SmartPos.Desktop.Communication;
using SmartPos.Ui.Components;

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
            Click += (s, a) => CheckLogin();
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            await Application.InitializeCommunication();
            Application.SignalRClient.StateChanged += state =>
            {
                if(state.NewState == ConnectionState.Disconnected)
                    this.RunOnUiThread(() =>
                    {
                        ShowMessage(new MessageInfo("Disconected from server!", MessageType.Error, Timeout.Infinite, true));
                        AuthenticationManager.Logout();
                    });
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            CheckLogin(true);
        }

        protected override void SetLoadingPaintHandler(PaintEventHandler handler, bool add)
        {
            if(add)
                ctrlStatusBar.Paint += handler;
            else 
                ctrlStatusBar.Paint -= handler;
        }

        #endregion

        #region Private methods

        private void CheckLogin(bool ignoreServerState = false)
        {
            if(!ignoreServerState && Application.SignalRClient.IsDisconnected)
                return;

            if (!AuthenticationManager.IsLoggedIn)
                UiHelper.ShowForm<CtrlNumericKeyboard>(UiHelper.Title("Login"), this)
                        .Configure(control => control.KeyboardLayout = NumericKeyboardLayout.Pin)
                        .OnConfirm(PerformLogin)
                        .SetTitleBar(true, true)
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
            InitializePos();
        }

        private async void InitializePos()
        {
            Application.SignalRClient.Subscribe<string>("test", s => this.RunOnUiThread(() => ShowMessage(s, MessageType.Info)));
            await ctrlWorkspace.Initialize(_apiClient);
        }

        #endregion
    }
}
