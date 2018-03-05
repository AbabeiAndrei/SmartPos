using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.AspNet.SignalR.Client;

using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Security;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Properties;

namespace SmartPos.Desktop.Controls
{
    public partial class CtrlStatusBar : BaseControl
    {
        #region Constants

        protected const int TIME_WIDTH = 250;

        #endregion

        #region Fields

        private Brush _textBrush;
        private Brush _redBrush;
        private Brush _yellowBrush;
        private Brush _greenBrush;

        #endregion

        #region Constructors

        public CtrlStatusBar()
        {
            InitializeComponent();

            if(DesignMode)
                _textBrush = new SolidBrush(Color.White);

            AuthorizationHandler.AuthorisationChanged += (sender, args) => Refresh();
            Application.SignalRClient.Connection.StateChanged += _ =>
            {
                this.RunOnUiThread(() =>
                {
                    Invalidate(new Rectangle(0, 0, Height, Height));
                    Update();
                });
            };
        }

        #endregion

        #region Overrides
        
        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _textBrush = ForeColor.CreateBrush();
            _redBrush = MaterialColors.Red().CreateBrush();
            _yellowBrush = MaterialColors.Amber().CreateBrush();
            _greenBrush = MaterialColors.Green().CreateBrush();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(_textBrush == null)
                return;

            const int textStart = 3;
            const int nameStartX = 250;

            Brush circleBrush;

            switch (Application.SignalRClient.Connection.State)
            {
                case ConnectionState.Connected:
                    circleBrush = _greenBrush;
                    break;
                case ConnectionState.Connecting:
                case ConnectionState.Reconnecting:
                    circleBrush = _yellowBrush;
                    break;
                case ConnectionState.Disconnected:
                    circleBrush = _redBrush;
                    break;
                default:
                    circleBrush = null;
                    break;
            }

            if(circleBrush != null)
                e.Graphics.FillEllipse(circleBrush, 5f, 7f, Height - 15f, Height - 15f);

            e.Graphics.DrawString(UiHelper.Title(PosClient.LocationName), Font, _textBrush, 25, textStart);
            
            if(AuthenticationManager.IsLoggedIn)
                e.Graphics.DrawString(AuthenticationManager.User.FullName, Font, _textBrush, nameStartX, textStart);

            if(Settings.Default.ShowTimeInStatusbar)
                e.Graphics.DrawString(DateTime.Now.ToString("F", Application.UiFormat), 
                                      Font, _textBrush, 
                                      new Rectangle(0, textStart, Width, Height), 
                                      GfxHelper.CreateStringFormat(StringAlignment.Far));

            e.Graphics.DrawLine(Pens.White, 0, Height - 1, Width, Height - 1);
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
            _textBrush?.Dispose();
            _redBrush?.Dispose();
            _yellowBrush?.Dispose();
            _greenBrush?.Dispose();
        }

        #endregion

        #region Event handlers

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            Invalidate(new Rectangle(Width - TIME_WIDTH, 0, TIME_WIDTH, Height));
            Update();
        }

        #endregion
    }
}
