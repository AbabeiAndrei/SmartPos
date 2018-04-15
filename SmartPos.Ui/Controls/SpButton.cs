using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpButton : Button, IThemeable
    {
        #region Fields

        private bool _selectable;
        private bool _selected;
        private Color _selectedBackColor;
        private Color _selectedForeColor;
        private Color _originalBackColor;
        private Color _originalForeColor;

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

                #endregion

        #region Events

        [Category("Propertry Changed")]
        public event EventHandler SelectableChanged;

        [Category("Propertry Changed")]
        public event EventHandler SelectedBackColorChanged;

        [Category("Propertry Changed")]
        public event EventHandler SelectedForeColorChanged;

        [Category("Action")]
        public event EventHandler SelectedChanged;

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

        #endregion
    }
}
