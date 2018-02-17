using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Security;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Utils;
using SmartPos.Utils;

namespace SmartPos.Ui
{
    public enum UnauthorizedFormResult : short
    {
        Nothing = 0,
        Hide = 1,
        Disable = 2,
        Exception = 3
    }

    public partial class BaseForm : Form, IThemeable
    {
        #region Constants

        private const int PAUSE_SHOW_MESSAGE = 5000;
        private const int SHOW_MESSAGE_FPS = 10;
        private const int SHOW_MESSAGE_SPEED = 2;

        #endregion

        #region Fields

        private Pen _penBorder;
        private MessageAnimation _message;
        private ITheme _theme;
        private bool _mouseOverErrorMessage;

        #endregion

        #region Properties

        public override string Text
        {
            get
            {
                return lblTitle?.Text ?? string.Empty;
            }
            set
            {
                if (lblTitle != null)
                    lblTitle.Text = value;
            }
        }

        protected static Type AuthorisationType { get; }

        protected virtual object Entity => null;

        public bool Drawer
        {
            get
            {
                return lblTitle?.Visible ?? false;
            }
            set
            {
                if(lblTitle == null || lblTitle.Visible == value)
                    return;

                if (lblTitle.Visible && !value)
                    Height -= lblTitle.Height;
                else
                    Height += lblTitle.Height;

                lblTitle.Visible = value;
            }
        }

        protected virtual UnauthorizedFormResult UnauthorizedResult => UnauthorizedFormResult.Exception;

        protected virtual bool ShowWindowBorder => true;

        #endregion

        #region Events

        public virtual event ConfirmFormHandler OnConfirm;

        public virtual event CloseFormHandler OnClose;

        #endregion

        #region Constructors

        public BaseForm()
        {
            InitializeComponent();
            lblTitle.Text = Application.ProductName;
            tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;
        }

        static BaseForm()
        {
            AuthorisationType = typeof(AuthorisationAttribute);
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AuthorizationHandler.AuthorisationChanged += (sender, args) => CheckAuthorisation();

            CheckAuthorisation();

            lblTitle.SendToBack();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if(ShowWindowBorder && _penBorder != null)
                    e.Graphics.DrawRectangle(_penBorder, 0, 0, Width - 1, Height - 1);
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        #endregion

        #region Implementation of IThemeable 

        public virtual void ApplyTheme(ITheme theme)
        {
            BackColor = theme.WindowBackColor;
            ForeColor = theme.WindowForeColor;

            lblTitle.BackColor = theme.WindowBackColor;
            lblTitle.ForeColor = theme.WindowForeColor;

            foreach (var item in Controls.OfType<IThemeable>())
                item.ApplyTheme(theme);

            _penBorder = new Pen(theme.WindowBorderColor);
            if(ShowWindowBorder)
                Padding = new Padding(1);

            _theme = theme;

            Refresh();
        }

        #endregion

        #region Event handlers

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_NCLBUTTONDOWN, WinApi.HT_CAPTION, 0);
        }

        private void tmrAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_message == null || _message.Hiding && lblErrors.Height <= 0)
            {
                lblErrors.Height = 0;
                tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;
                tmrAnimationTimer.Stop();
                _message = null;
                return;
            }

            if (tmrAnimationTimer.Interval == (_message.Duration ?? PAUSE_SHOW_MESSAGE))
                tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;

            if (!_message.Hiding && lblErrors.Height < _message.Height)
            {
                lblErrors.Height += SHOW_MESSAGE_SPEED;
                return;
            }

            if(_mouseOverErrorMessage)
                return;

            if (_message.Hiding)
            {
                lblErrors.Height-= SHOW_MESSAGE_SPEED;
                return;
            }
            _message.Hiding = true;
            tmrAnimationTimer.Interval = _message.Duration ?? PAUSE_SHOW_MESSAGE;
        }

        private void lblErrors_MouseEnter(object sender, EventArgs e)
        {
            _message.Hiding = false;
            _mouseOverErrorMessage = true;
        }

        private void lblErrors_MouseLeave(object sender, EventArgs e)
        {
            _mouseOverErrorMessage = false;
        }

        private void lblErrors_Click(object sender, EventArgs e)
        {
            _message.Hiding = true;
            _mouseOverErrorMessage = false;
            tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS / 2;
            tmrAnimationTimer.Start();
        }

        #endregion

        #region Public methods

        public virtual void PerformConfirm(Func<object> resultSelector)
        {
            var cont = new ContinuityDelegate();

            OnConfirm?.Invoke(new FormResult(resultSelector(), this), cont);

            if (!string.IsNullOrEmpty(cont.Message))
                ShowMessage(cont.Message, cont.MessageType, cont.Duration);

            if (cont.Close)
                Close();
        }

        public virtual void PerformConfirm()
        {
            PerformConfirm(() => Entity);
        }

        public virtual void PerformClose()
        {
            var cancel = new CancelEventArgs();

            OnClose?.Invoke(new FormResult(Entity, this), cancel);

            if (cancel.Cancel)
                return;

            Close();
        }

        public void ShowMessage(string message, MessageType messageType, int? duration = null)
        {
            using (var gfx = CreateGraphics())
            {
                var height = gfx.MeasureString(message, lblErrors.Font, new Size(lblErrors.Width, Height));
                _message = new MessageAnimation(message, messageType, (int) height.Height + 10)
                           {
                               Duration = duration
                           };
                switch (messageType)
                {
                    case MessageType.Info:
                        lblErrors.BackColor = _theme.InfoBackColor;
                        break;
                    case MessageType.Warning:
                        lblErrors.BackColor = _theme.WarningBackColor;
                        break;
                    case MessageType.Error:
                        lblErrors.BackColor = _theme.ErrorBackColor;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
                }
            }
            lblErrors.Text = _message.Message;
            lblErrors.BringToFront();
            tmrAnimationTimer.Start();
        }

        #endregion

        #region Protected methods

        protected virtual void OnAuthorisationFailed(NotAuthorizedException exception, HandledEventArgs args)
        {
            args.Handled = false;
        }

        protected virtual void DisposeComponents()
        {
            _penBorder?.Dispose();
        }

        #endregion
        
        #region Private methods

        private void CheckAuthorisation()
        {
            if (DesignMode)
                return;

            var type = GetType();
            var attributes = type.GetCustomAttributes(AuthorisationType, true)
                                 .OfType<AuthorisationAttribute>();

            foreach (var attribute in attributes)
                if (!attribute.IsAuthorized())
                    switch (UnauthorizedResult)
                    {
                        case UnauthorizedFormResult.Nothing:
                            break;
                        case UnauthorizedFormResult.Disable:
                            Enabled = false;
                            break;
                        case UnauthorizedFormResult.Hide:
                            Visible = false;
                            WinApi.SuspendDrawing(this);
                            break;
                        case UnauthorizedFormResult.Exception:
                            var exception = new NotAuthorizedException(type);
                            var args = new HandledEventArgs();
                            OnAuthorisationFailed(exception, args);
                            if (!args.Handled)
                                throw exception;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                else if (UnauthorizedResult == UnauthorizedFormResult.Hide)
                {
                    Visible = true;
                    WinApi.ResumeDrawing(this);
                }
                else if (UnauthorizedResult == UnauthorizedFormResult.Disable)
                {
                    Enabled = true;
                }
        }

        #endregion
    }

    internal class MessageAnimation
    {
        public string Message { get; }
        public MessageType MessageType { get; }
        public int Height { get; }

        public bool Hiding { get; set; }
        public int? Duration { get; set; }

        public MessageAnimation(string message, MessageType messageType, int height)
        {
            Message = message;
            MessageType = messageType;
            Height = height;
            Hiding = false;
        }
    }
}
