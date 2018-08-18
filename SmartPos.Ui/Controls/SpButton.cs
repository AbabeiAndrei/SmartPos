using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpButton : Button, IThemeable
    {
        protected const int DEFAULT_TIMEOUT_LONG_PRESS = 3000;

        #region Fields

        private bool _selectable;
        private bool _selected;
        private Color _selectedBackColor;
        private Color _selectedForeColor;
        private Color _originalBackColor;
        private Color _originalForeColor;
        private readonly Timer _timerLongPress;

        #endregion

        #region Properties

        [Category("Behavior")]
        [DefaultValue(false)]
        public virtual bool Selectable
        {
            get => _selectable;
            set
            {
                var invokeEvent = _selectable != value;

                _selectable = value;

                if(invokeEvent)
                    OnSelectableChanged();
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool Selected
        {
            get => _selected;
            set
            {
                var invokeEvent = _selected != value;

                _selected = value;
                
                if(invokeEvent)
                    OnSelectedChanged();
            }
        }

        [Category("Appearance")]
        public virtual Color SelectedBackColor
        {
            get => _selectedBackColor;
            set
            {
                var invokeEvent = _selectedBackColor != value;

                _selectedBackColor = value;
                
                if(invokeEvent)
                    OnSelectedBackColorChanged();
            }
        }

        [Category("Appearance")]
        public virtual Color SelectedForeColor
        {
            get => _selectedForeColor;
            set
            {
                var invokeEvent = _selectedForeColor != value;

                _selectedForeColor = value;
                
                if(invokeEvent)
                    OnSelectedForeColorChanged();
            }
        }

        [Category("Behavior")]
        [DefaultValue(DEFAULT_TIMEOUT_LONG_PRESS)]
        public virtual int TimeoutLongPress
        {
            get => _timerLongPress.Interval;
            set => _timerLongPress.Interval = value;
        }

        #endregion

        #region Events

        [Category("Propertry Changed")]
        public virtual event EventHandler SelectableChanged;

        [Category("Propertry Changed")]
        public virtual event EventHandler SelectedBackColorChanged;

        [Category("Propertry Changed")]
        public virtual event EventHandler SelectedForeColorChanged;

        [Category("Action")]
        public virtual event EventHandler SelectedChanged;
        
        [Category("Action")]
        public virtual event EventHandler LongPress;

        #endregion

        #region Constructors

        /// <inheritdoc />
        public SpButton()
        {
            _timerLongPress = new Timer
            {
                Interval = DEFAULT_TIMEOUT_LONG_PRESS
            };
            _timerLongPress.Tick += TimerLongPressOnTick;
        }

        #endregion

        #region Implementation of IThemeable

        public virtual void ApplyTheme(ITheme theme)
        {
            BackColor = theme.ButtonBackColor;
            ForeColor = theme.ButtonForeColor;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = theme.ButtonBorderSize;
            FlatAppearance.BorderColor = theme.ButtonBorderColor;
            FlatAppearance.MouseDownBackColor = theme.ButtonDownBackColor;
            FlatAppearance.MouseOverBackColor = theme.ButtonOverBackColor;

            SelectedBackColor = theme.SelectedButtonBackColor;
            SelectedForeColor = theme.SelectedButtonForeColor;

            _originalBackColor = BackColor;
            _originalForeColor = ForeColor;
        }

        #endregion

        #region Overrides of Button

        /// <inheritdoc />
        protected override void OnClick(EventArgs e)
        {
            try
            {
                if (Selectable)
                    Selected = !Selected;
            }
            finally
            {
                base.OnClick(e);
            }
        }

        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if(_timerLongPress.Enabled)
                _timerLongPress.Stop();
        }

        #endregion

        #region Overrides of ButtonBase

        /// <inheritdoc />
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if(LongPress != null)
                _timerLongPress.Start();
        }

        #endregion

        #region Event handlers

        private void TimerLongPressOnTick(object sender, EventArgs e)
        {
            _timerLongPress.Stop();
            OnLongPress();
        }

        #endregion

        #region Protected methods

        protected virtual void OnSelectableChanged()
        {
            SelectableChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSelectedChanged()
        {
            if(!Selectable)
                return;

            if (Selected)
            {
                _originalBackColor = BackColor;
                _originalForeColor = ForeColor;

                BackColor = SelectedBackColor;
                ForeColor = SelectedForeColor;
            }
            else
            {
                BackColor = _originalBackColor;
                ForeColor = _originalForeColor;
            }

            SelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSelectedBackColorChanged()
        {
            SelectedBackColorChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSelectedForeColorChanged()
        {
            SelectedForeColorChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLongPress()
        {
            LongPress?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Overrides of ButtonBase

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            try
            {
                _timerLongPress.Tick -= TimerLongPressOnTick;
                _timerLongPress.Stop();
                _timerLongPress.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion
    }
}
