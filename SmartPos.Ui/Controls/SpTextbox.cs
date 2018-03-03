using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;

namespace SmartPos.Ui.Controls
{
    public class SpTextbox : TextBox, IThemeable
    {
        #region Fields

        private readonly SpButton _clearButton;
        private string _placeholder;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether the clear button is visible or not
        /// </summary>
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the clear button is visible or not")]
        public virtual bool ShowClear
        {
            get => _clearButton.Visible;
            set
            {
                var invokeEvent = _clearButton.Visible != value;
                _clearButton.Visible = value;
                if(invokeEvent)
                    ShowClearChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        [Category("Behavior")]
        [Description("Gets or sets if ClearButton is enabled")]
        public bool EnableBackspace
        {
            get => _clearButton?.Enabled ?? false;
            set
            {
                if (_clearButton != null)
                    _clearButton.Enabled = value;
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _clearButton.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the palceholder of the text
        /// </summary>
        [Localizable(true)]
        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Gets or sets whether the palceholder of the text")]
        public virtual string Placeholder
        {
            get => _placeholder;
            set
            {
                var invokeEvent = _placeholder != value;
                _placeholder = value;
                UpdatePlaceHolder();
                if(invokeEvent)
                    PlaceholderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets if the Textbox is empty or have any text in it 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsEmpty => string.IsNullOrEmpty(Text);

        /// <summary>
        /// Gets or sets text of ClearButton
        /// </summary>
        [Localizable(true)]
        [DefaultValue("x")]
        [Category("Appearance")]
        [Description("Gets or sets text of ClearButton")]
        public virtual string ClearButtonText
        {
            get => _clearButton.Text;
            set
            {
                var invokeEvemt = _clearButton.Text != value;
                _clearButton.Text = value;
                if(invokeEvemt)
                    ClearButtonTextChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        [Category("Appearance")]
        [Description("Gets or sets font of ClearButton")]
        public Font ClearButtonFont
        {
            get => _clearButton.Font;
            set => _clearButton.Font = value;
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        [Description("Triggers when ShowClear have been changed")]
        public virtual event EventHandler ShowClearChanged;

        [Category("Property Changed")]
        [Description("Triggers when Placeholder have been changed")]
        public virtual event EventHandler PlaceholderChanged;

        [Category("Property Changed")]
        [Description("Triggers when ClearButtonText have been changed")]
        public virtual event EventHandler ClearButtonTextChanged;

        [Category("Action")]
        [Description("Triggers when ClearButton have been pressed")]
        public virtual event HandledEventHandler ClearButtonPressed;

        #endregion

        #region Constructors

        public SpTextbox()
        {
            _clearButton = new SpButton
                           {
                               Size = new Size(ClientSize.Height, ClientSize.Height + 2),
                               Visible = false,
                               Cursor = Cursors.Default,
                               Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                               Location = new Point(ClientSize.Width - ClientSize.Height, -1),
                               Text = "x",
                               Font = base.Font,
                               TextAlign = ContentAlignment.MiddleCenter
                           };

            _clearButton.Click += clearButton_Click;

            Controls.Add(_clearButton);
        }

        #endregion

        #region Overrides

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdatePlaceHolder();
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            try
            {
                WinApi.SendMessage(Handle, WinApi.EM_SETMARGINS, (IntPtr)2, (IntPtr)(_clearButton.Height << 16));
            }
            finally
            {
                base.OnBindingContextChanged(e);
            }

        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if(disposing)
                    _clearButton?.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _clearButton.Left = ClientSize.Width - _clearButton.Height;
            _clearButton.Width = _clearButton.Height;
        }

        #endregion

        #region Event handlers
        
        private void clearButton_Click(object sender, EventArgs e)
        {
            if (ClearButtonPressed != null)
            {
                var args = new HandledEventArgs();
                ClearButtonPressed?.Invoke(this, args);

                if (args.Handled)
                    return;
            }

            Clear();
        }

        #endregion

        #region Private methods

        private void UpdatePlaceHolder()
        {
            if (IsHandleCreated && Placeholder != null)
                WinApi.SendMessage(Handle, WinApi.EM_SETCUEBANNER, (IntPtr) 1, Placeholder);
        }

        #endregion

        #region Public methods

        public void ApplyTheme(ITheme theme)
        {
            if(DesignMode)
                return;

            _clearButton.ApplyTheme(theme);
        }

        #endregion
    }
}
