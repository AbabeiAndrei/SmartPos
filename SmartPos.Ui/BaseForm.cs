using System;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Security;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Controls;
using SmartPos.Ui.Components;

namespace SmartPos.Ui
{
    public enum UnauthorizedFormResult : short
    {
        Nothing = 0,
        Hide = 1,
        Disable = 2,
        Exception = 3
    }

    public partial class BaseForm : Form, IThemeable, IMessagePresenter
    {
        #region Constants

        private const int PAUSE_SHOW_MESSAGE = 5000;
        private const int SHOW_MESSAGE_FPS = 10;
        private const int SHOW_MESSAGE_SPEED = 2;
        private const int LOADING_SPEED = 15;
        protected const int LOADIER_HEIGHT = 3;

        #endregion

        #region Fields

        private Pen _penBorder;
        private MessageAnimation _message;
        private bool _mouseOverErrorMessage;
        private int _loaderLocation;
        private int _curentBrush;
        private Brush[] _loaderBrushes;
        private Brush _lastLoadedBrush;
        private ILoadingToken _loadingState;
        private bool _showTitle;
        private bool _showClose;
        private bool _topPaneVisible;

        #endregion

        #region Properties

        public override string Text
        {
            get => lblTitle?.Text ?? string.Empty;
            set
            {
                if (lblTitle != null)
                    lblTitle.Text = value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        public virtual bool ShowTitle
        {
            get => _showTitle;
            set
            {
                if(lblTitle == null)
                    return;

                lblTitle.Visible = _showTitle = value;

                ShowTitlePane = ShowTitle || ShowClose;
            }
        }
        
        [DefaultValue(false)]
        [Category("Appearance")]
        public virtual bool ShowClose
        {
            get => _showClose;
            set
            {
                if(btnClose == null)
                    return;

                btnClose.Visible = _showClose = value;

                ShowTitlePane = ShowTitle || ShowClose;
            }
        }
        
        [DefaultValue(true)]
        [Category("Appearance")]
        public bool EnableClose
        {
            get => btnClose.Enabled;
            set => btnClose.Enabled = value;
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual bool ShowTitlePane
        {
            get => _topPaneVisible;
            set
            {
                if(pnlTitle == null)
                    return;

                if (ShowTitlePane && !value)
                    Height -= pnlTitle.Height;
                else if (!ShowTitlePane && value)
                    Height += pnlTitle.Height;

                if (!ShowTitlePane && value)
                    SetLoadingPaintHandler(pnlLoading_Paint, false);
                else if (ShowTitlePane && !value)
                    SetLoadingPaintHandler(pnlLoading_Paint, true);

                pnlTitle.Visible = _topPaneVisible = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ILoadingToken LoadingState
        {
            get => _loadingState;
            set => _loadingState = value;
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual object Entity => null;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected static Type AuthorisationType { get; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual UnauthorizedFormResult UnauthorizedResult => UnauthorizedFormResult.Exception;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual bool ShowWindowBorder => true;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual int MessageLineTop => ShowTitle
                                                    ? pnlTitle.Bottom
                                                    : 0;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual int LoaderLineTop => 0;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool IsAuthorized { get; private set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected ITheme Theme { get; private set; }

        #endregion

        #region Events

        public virtual event ConfirmFormHandler OnConfirm;

        public virtual event CloseFormHandler OnClose;

        public virtual event EventHandler OnStartLoading;

        public virtual event LoadingEndEventHandler OnEndLoading;

        #endregion

        #region Constructors

        public BaseForm()
        {
            InitializeComponent();
            lblTitle.Text = base.Text = Application.ProductName;
            tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;
            _loadingState = new LoadingAnimationHandler(this);

            pnlTitle.VisibleChanged += (sender, args) => SetLabelMessageLayout();
        }

        static BaseForm()
        {
            AuthorisationType = typeof(AuthorisationAttribute);
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

            Theme = theme;

            _loaderBrushes = Theme.LoadingColors.Select(c => new SolidBrush(c)).Cast<Brush>().ToArray();
            
            Refresh();
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AuthorizationHandler.AuthorisationChanged += CheckAuthorisation;

            CheckAuthorisation();

            pnlTitle.SendToBack();
            
            SetLoadingPaintHandler(pnlLoading_Paint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            UiConfigure.GraphicsSettingResolver?.Invoke(e.Graphics);

            if (ShowWindowBorder && _penBorder != null)
                e.Graphics.DrawRectangle(_penBorder, 0, 0, Width - 1, Height - 1);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetLabelMessageLayout();
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
            if (_message == null || _message.Hiding && lblMessage.Height <= 0)
            {
                lblMessage.Height = 0;
                tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;
                tmrAnimationTimer.Stop();
                _message = null;
                return;
            }

            if (tmrAnimationTimer.Interval == (_message.Duration ?? PAUSE_SHOW_MESSAGE))
                tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS;

            if (!_message.Hiding && lblMessage.Height < _message.Height)
            {
                lblMessage.Height += SHOW_MESSAGE_SPEED;
                return;
            }

            if(_mouseOverErrorMessage)
                return;

            if (_message.Hiding)
            {
                lblMessage.Height-= SHOW_MESSAGE_SPEED;
                return;
            }
            _message.Hiding = true;

            if(_message.Duration == Timeout.Infinite)
                tmrAnimationTimer.Stop();
            else
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
            if(_message.Locked)
                return;

            _message.Hiding = true;
            _mouseOverErrorMessage = false;
            tmrAnimationTimer.Interval = SHOW_MESSAGE_FPS / 2;
            tmrAnimationTimer.Start();
        }

        private void pnlLoading_Paint(object sender, PaintEventArgs e)
        {
            if(!tmrLoader.Enabled || _loaderBrushes == null)
                return;

            var width = ShowTitle
                            ? pnlTitle.Width
                            : (sender as Control)?.Width ?? Width;

            if (_loaderLocation >= width)
            {
                _lastLoadedBrush = _loaderBrushes[_curentBrush];
                if (_curentBrush + 1 >= _loaderBrushes.Length)
                    _curentBrush = 0;
                else
                    _curentBrush++;

                _loaderLocation = 0;
            }

            if(_lastLoadedBrush != null)
                e.Graphics.FillRectangle(_lastLoadedBrush, 0, LoaderLineTop, width, LOADIER_HEIGHT);

            if (_loaderBrushes[_curentBrush] != null)
                e.Graphics.FillRectangle(_loaderBrushes[_curentBrush], 0, LoaderLineTop, _loaderLocation, LOADIER_HEIGHT);

            _loaderLocation += width / LOADING_SPEED;
        }

        private void tmrLoader_Tick(object sender, EventArgs e)
        {
            InvalidateLoadingArea();

            if(LoadingState.TimeOut != 0 && tmrLoader.Tag is Stopwatch sw && sw.ElapsedMilliseconds >= LoadingState.TimeOut)
                StopLoading();
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            await PerformClose(new BaseControlWrapper((Control)sender));
        }

        private void CheckAuthorisation(object o, AuthorisationChangedArgs authorisationChangedArgs)
        {
            CheckAuthorisation();
        }

        #endregion

        #region Public methods

        public virtual async Task PerformConfirm(BaseControl sender)
        {
            await PerformConfirm(() => Entity, sender);
        }

        public virtual async Task PerformConfirm(Func<object> resultSelector, BaseControl sender)
        {
            var cont = new ContinuityDelegate();

            var confDelegate = OnConfirm;

            if (confDelegate != null)
            {
                var fsender = new FormSender(sender, resultSelector(), this);
                await confDelegate(fsender, cont);
            }

            if (!string.IsNullOrEmpty(cont.Message))
                PresentMessage(cont.Message, cont.MessageType, cont.Duration);

            if (cont.Close)
                Close();
        }

        public virtual async Task PerformClose(BaseControl sender)
        {
            var cancel = new CancelEventArgs();

            var closeDelegate = OnClose;

            if (closeDelegate != null)
            {
                var fsender = new FormSender(sender, Entity, this);
                await closeDelegate(fsender, cancel);
            }

            if (cancel.Cancel)
                return;

            Close();
        }

        public virtual void PresentMessage(string message, MessageType messageType, int? duration = null)
        {
            PresentMessage(new MessageInfo(message, messageType, duration));
        }

        public virtual void PresentMessage(string message, MessageType messageType, MessageDurationLength duration)
        {
            PresentMessage(new MessageInfo(message, messageType, duration == MessageDurationLength.Infinite ? (int?)duration : null));
        }

        public virtual void PresentMessage(MessageInfo message)
        {
            
            using (var gfx = CreateGraphics())
            {
                var height = gfx.MeasureString(message.Message, lblMessage.Font, new Size(lblMessage.Width, Height));
                _message = new MessageAnimation(message.Message, message.MessageType, (int) height.Height + 10)
                {
                    Duration = message.Duration,
                    Locked = message.Locked
                };
                switch (message.MessageType)
                {
                    case MessageType.Info:
                        lblMessage.BackColor = Theme.InfoBackColor;
                        break;
                    case MessageType.Warning:
                        lblMessage.BackColor = Theme.WarningBackColor;
                        break;
                    case MessageType.Error:
                        lblMessage.BackColor = Theme.ErrorBackColor;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(message.MessageType), message.MessageType, null);
                }
            }
            lblMessage.Text = _message.Message;
            lblMessage.BringToFront();
            tmrAnimationTimer.Start();
        }
        
        public virtual void StartLoading(int timeOut = 0)
        {
            try
            {
                SuspendLayout();
                if (tmrLoader.Enabled)
                    StopLoading();

                if (timeOut > 0)
                {
                    LoadingState.TimeOut = timeOut;
                    tmrLoader.Tag = Stopwatch.StartNew();
                }
                
                tmrLoader.Start();

                OnStartLoading?.Invoke(this, EventArgs.Empty);
            }
            finally
            {
                ResumeLayout();
            }
        }

        public virtual void StopLoading()
        {
            tmrLoader.Stop();
            _loaderLocation = 0;
            _curentBrush = 0;
            if (tmrLoader.Tag is Stopwatch sw)
            {
                sw.Stop();
                sw.Reset();
            }

            var isTimeOut = LoadingState.TimeOut <= 0;
            LoadingState.TimeOut = 0;
            InvalidateLoadingArea();
            OnEndLoading?.Invoke(this, new LoadingEndEventArgs(isTimeOut));
        }

        #endregion

        #region Protected methods

        protected virtual void OnAuthorisationFailed(NotAuthorizedException exception, HandledEventArgs args)
        {
            args.Handled = false;
        }

        protected virtual void DisposeComponents()
        {
            _lastLoadedBrush?.Dispose();

            _penBorder?.Dispose();
        }
        
        protected virtual void InvalidateLoadingArea()
        {
            if (ShowTitle)
            {
                pnlLoader.Invalidate(new Rectangle(0, LoaderLineTop, pnlLoader.Width, LOADIER_HEIGHT));
                pnlLoader.Update();
            }
            else
            {
                Invalidate(new Rectangle(0, LoaderLineTop, Width, LOADIER_HEIGHT));
                Update();
            }
        }

        protected virtual void SetLabelMessageLayout()
        {
            lblMessage.Width = ClientSize.Width;
            lblMessage.Top = MessageLineTop;
        }

        protected virtual void SetLoadingPaintHandler(PaintEventHandler handler, bool add)
        {
            if(add)
                Paint += handler;
            else
                Paint -= handler;
        }

        #endregion
        
        #region Private methods

        private void CheckAuthorisation()
        {
            if (DesignMode)
                return;

            var type = GetType();
            

            IsAuthorized = type.GetCustomAttributes(AuthorisationType, true)
                               .OfType<AuthorisationAttribute>()
                               .All(a => a.IsAuthorized());

            
            if (!IsAuthorized)
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

        private void DisposeComponentsImpl()
        {
            AuthorizationHandler.AuthorisationChanged -= CheckAuthorisation;
            DisposeComponents();
        }

        #endregion
    }
}
