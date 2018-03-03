using System;
using System.Drawing;
using System.Windows.Forms;

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

        #endregion

        #region Constructors

        public CtrlStatusBar()
        {
            InitializeComponent();

            if(DesignMode)
                _textBrush = new SolidBrush(Color.White);

            AuthorizationHandler.AuthorisationChanged += (sender, args) => Refresh();
        }

        #endregion

        #region Overrides

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _textBrush = new SolidBrush(ForeColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(_textBrush == null)
                return;

            const int textStart = 3;
            const int nameStartX = 250;

            e.Graphics.DrawString(UiHelper.Title(PosClient.LocationName), Font, _textBrush, 0, textStart);
            
            if(AuthenticationManager.IsLoggedIn)
                e.Graphics.DrawString(AuthenticationManager.User.FullName, Font, _textBrush, nameStartX, textStart);

            if(Settings.Default.ShowTimeInStatusbar)
                e.Graphics.DrawString(DateTime.Now.ToString("F", Application.UiFormat), Font, _textBrush, Width - TIME_WIDTH, textStart);

            e.Graphics.DrawLine(Pens.White, 0, Height - 1, Width, Height - 1);
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
            _textBrush?.Dispose();
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
