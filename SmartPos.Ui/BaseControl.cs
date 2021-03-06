﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using SmartPos.Ui.Components;
using SmartPos.Ui.Handlers;
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
        #region Fields

        private BaseForm _curentParent;

        #endregion

        #region Properties
        
        protected static Type AuthorisationType { get; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual UnauthorizedControlResult UnauthorizedResult => UnauthorizedControlResult.Hide;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BaseForm ParentForm => base.ParentForm as BaseForm;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool IsAuthorized { get; private set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ILoadingToken LoadingState => ParentForm?.LoadingState;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected ITheme Theme { get; private set; }

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
            Theme = theme;

            if (theme != null)
            {
                BackColor = theme.ControlBackColor;
                ForeColor = theme.ControlForeColor;
            }

            foreach (var item in Controls.OfType<IThemeable>())
                item.ApplyTheme(theme);
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AuthorizationHandler.AuthorisationChanged += CheckAuthorisation;

            CheckAuthorisation();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (_curentParent != null)
            {
                _curentParent.OnStartLoading -= OnParentFormStartLoadingWrap;
                _curentParent.OnEndLoading -= OnParentOnOnEndLoadingWrap;
            }

            _curentParent = ParentForm;

            if (_curentParent != null)
            {
                _curentParent.OnStartLoading += OnParentFormStartLoadingWrap;
                _curentParent.OnEndLoading += OnParentOnOnEndLoadingWrap;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            UiConfigure.GraphicsSettingResolver?.Invoke(e.Graphics);
        }

        #endregion
        
        #region Event handlers

        private void CheckAuthorisation(object sender, AuthorisationChangedArgs authorisationChangedArgs)
        {
            CheckAuthorisation();
        }

        #endregion

        #region Protected methods

        protected virtual void OnAuthorisationFailed(NotAuthorizedException exception, HandledEventArgs args)
        {
            args.Handled = false;
        }

        protected virtual void OnParentFormStartLoading(EventArgs e)
        {
            if(ParentForm == null)
                return;

            ParentForm.EnableClose = false;
        }

        protected virtual void OnParentFormEndLoading(LoadingEndEventArgs e)
        {
            
            if(ParentForm == null)
                return;

            ParentForm.EnableClose = true;
        }

        protected virtual void DisposeComponents()
        {
        }

        #endregion

        #region Private methods

        private void CheckAuthorisation()
        {
            if(DesignMode || IsDisposed)
                return;

            var type = GetType();

            IsAuthorized = type.GetCustomAttributes(AuthorisationType, true)
                               .OfType<AuthorisationAttribute>()
                               .All(a => a.IsAuthorized());

            if (!IsAuthorized)
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

        private void OnParentFormStartLoadingWrap(object sender, EventArgs e)
        {
            OnParentFormStartLoading(e);
        }
        
        private void OnParentOnOnEndLoadingWrap(object sender, LoadingEndEventArgs e)
        {
            OnParentFormEndLoading(e);
        }

        private void DisposeComponentsImpl()
        {
            AuthorizationHandler.AuthorisationChanged -= CheckAuthorisation;
            DisposeComponents();
        }
        
        #endregion
    }
}
