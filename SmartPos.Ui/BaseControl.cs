using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Ui.Security;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Utils;

namespace SmartPos.Ui
{
    public enum UnauthorizedControlResult : short
    {
        Nothing = 0, 
        Hide = 1,
        Exception = 2
    }

    public partial class BaseControl : UserControl, IThemeable
    {
        #region Properties

        protected static Type AuthorisationType { get; }

        protected virtual UnauthorizedControlResult UnauthorizedResult => UnauthorizedControlResult.Hide;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BaseForm ParentForm => base.ParentForm as BaseForm;

        #endregion

        #region Constructors

        protected BaseControl()
        {
            InitializeComponent();
        }

        static BaseControl()
        {
            AuthorisationType = typeof(AuthorisationAttribute);
        }

        #endregion

        #region Implementation of IThemeable

        public virtual void ApplyTheme(ITheme theme)
        {
            BackColor = theme.ControlBackColor;
            ForeColor = theme.ControlForeColor;

            foreach (var item in Controls.OfType<IThemeable>())
                item.ApplyTheme(theme);
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AuthorizationHandler.AuthorisationChanged += (sender, args) => CheckAuthorisation();

            CheckAuthorisation();
        }

        #endregion

        #region Protected methods

        protected void OnAuthorisationFailed(NotAuthorizedException exception, HandledEventArgs args)
        {
            args.Handled = false;
        }

        #endregion

        #region Private methods

        private void CheckAuthorisation()
        {
            if(DesignMode)
                return;

            var type = GetType();
            var attributes = type.GetCustomAttributes(AuthorisationType, true)
                                 .OfType<AuthorisationAttribute>();

            foreach (var attribute in attributes)
                if (!attribute.IsAuthorized())
                    switch (UnauthorizedResult)
                    {
                        case UnauthorizedControlResult.Nothing:
                            break;
                        case UnauthorizedControlResult.Hide:
                            Visible = false;
                            WinApi.SuspendDrawing(this);
                            break;
                        case UnauthorizedControlResult.Exception:
                            var exception = new NotAuthorizedException(type);
                            var args = new HandledEventArgs();
                            OnAuthorisationFailed(exception, args);
                            if (!args.Handled)
                                throw exception;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                else if (UnauthorizedResult == UnauthorizedControlResult.Hide)
                {
                    Visible = true;
                    WinApi.ResumeDrawing(this);
                }


        }

        #endregion
    }
}
