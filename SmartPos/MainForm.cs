using System;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using SmartPos.Ui;
using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Components;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Controls;
using SmartPos.Desktop.Interfaces;
using SmartPos.Desktop.Communication;
using SmartPos.DomainModel.Communication;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Model;
using SmartPos.GeneralLibrary.Extensions;

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

        protected override int LoaderLineTop => ctrlStatusBar.Bottom - LOADIER_HEIGHT;

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

            ctrlToolBar.OptionPressed += (s, e) => LoadingState.Loading = !LoadingState.Loading;
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
                        ShowMessage(MessageInfo.Create("Disconected from server!", MessageType.Error, Timeout.Infinite, true));
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

        protected override void InvalidateLoadingArea()
        {
            ctrlStatusBar.Invalidate(new Rectangle(0, LoaderLineTop, ctrlStatusBar.Width, LOADIER_HEIGHT));
        }

        #endregion

        #region Event handlers

        private void PnlMain_ControlsChanged(object sender, ControlEventArgs e)
        {
            var controls = pnlMain.Controls.OfType<BaseControl>()
                                  .Where(bc => bc.Visible)
                                  .ToList();

            var accesor = controls.OfType<IStatusBarAccesor>()
                                  .FirstOrDefault();

            var toolbarControl = controls.OfType<IToolBarCustomizer>()
                                         .FirstOrDefault();

            ctrlStatusBar.InfoText = accesor?.Value;

            if (toolbarControl != null)
                ctrlToolBar.Customize(toolbarControl);
            else
                ctrlToolBar.ResetCustomize();
        }

        private void OnOrderCreated(OrderCreatedMessage model)
        {
            this.RunOnUiThread(() => SetOrderToTable(model.Order));
        }

        private void OnRegisterTable(OrderOpenMessage model)
        {

        }
        
        #endregion

        #region Private methods

        private void CheckLogin(bool ignoreServerState = false)
        {
            if(!ignoreServerState && Application.SignalRClient.IsDisconnected)
                return;

            if (!AuthenticationManager.IsLoggedIn)
                UiHelper.ShowForm<CtrlNumericKeyboard>(UiHelper.CreateTitle("Login"), this)
                        .Configure(control => control.KeyboardLayout = NumericKeyboardLayout.Pin)
                        .OnConfirm(PerformLogin)
                        .SetTitleBar(true, true)
                        .ApplyTheme(_theme)
                        .Show();
        }


        private async Task PerformLogin(IFormSender sender, IContinuityDelegate after)
        {
            var pin = sender.Result?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(pin))
            {
#if DEBUG
                pin = "1234";
#else
                after.PresentMessage("Pin is empty", MessageType.Error);
                return;
#endif
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
            Application.SignalRClient.Subscribe<OrderOpenMessage>(SignalRHub.Events.Order.RegisterTable, OnRegisterTable);
            Application.SignalRClient.Subscribe<OrderCreatedMessage>(SignalRHub.Events.Order.Created, OnOrderCreated);
            await ctrlWorkspace.Initialize(_apiClient);
        }

        #endregion

        #region Public methods

        public void SetControlInContainer<TControl>(TControl control)
            where TControl : BaseControl
        {
            control.ApplyTheme(_theme);

            try
            {
                pnlMain.SuspendLayout();

                ctrlWorkspace.Visible = false;

                pnlMain.Controls.Add(control);

                control.Dock = DockStyle.Fill;

                control.Visible = true;
            }
            finally
            {
                pnlMain.ResumeLayout();
            }
        }

        public void ShowTablesInContainer()
        {
            try
            {
                pnlMain.SuspendLayout();

                ctrlWorkspace.Visible = true;
                
                pnlMain.Controls.RemoveAll<BaseControl>(control => control.Name != ctrlWorkspace.Name);
            }
            finally
            {
                pnlMain.ResumeLayout();
            }
        }

        public void SetOrderToTable(Order order)
        {
            var ctrlTable = ctrlWorkspace.GetTable(order.TableId);

            if (ctrlTable == null)
                return;

            ctrlTable.Order = order;
        }

        #endregion
    }
}
