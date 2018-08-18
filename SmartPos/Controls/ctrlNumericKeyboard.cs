using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;
using SmartPos.Ui.Controls;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Desktop.Controls
{
    public enum NumericKeyboardLayout : short
    {
        Numeric = 0,
        Decimal = 1,
        Pin = 2,
        Phone = 3
    }

    [DefaultEvent("UserChangeText")]
    public partial class ctrlNumericKeyboard : BaseControl
    {
        #region Fields

        private NumericKeyboardLayout _keyboardLayout;
        private bool _echoInDisplay;
        private Font _buttonsFont;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets layout of the numeric keyboard
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(NumericKeyboardLayout.Numeric)]
        [Description("Gets or sets layout of the numeric keyboard")]
        public virtual NumericKeyboardLayout KeyboardLayout
        {
            get => _keyboardLayout;
            set
            {
                var invokeEvent = _keyboardLayout != value;
                _keyboardLayout = value;
                SetLayout(_keyboardLayout);

                if(invokeEvent)
                    KeyboardLayoutChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets whether the display is visible or not
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Gets or sets whether the display is visible or not")]
        public virtual bool ShowDisplay
        {
            get => txtDisplay.Visible;
            set
            {
                var invokeEvent = ShowDisplay != value;
                if (txtDisplay.Visible != value)
                    if (value)
                        Height += txtDisplay.Height;
                    else
                        Height -= txtDisplay.Height;

                txtDisplay.Visible = value;
                pnlMain.Top = txtDisplay.Visible ? txtDisplay.Bottom + 1 : txtDisplay.Top;

                if (!txtDisplay.Visible)
                    Clear();

                if (invokeEvent)
                    ShowDisplayChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets if the keys presed will be shown in display
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Gets or sets if the keys presed will be shown in display")]
        public virtual bool EchoInDisplay
        {
            get => ShowDisplay && _echoInDisplay;
            set
            {
                var invokeEvent = _echoInDisplay != value;
                _echoInDisplay = value;
                txtDisplay.ShowClear = _echoInDisplay;

                if (!_echoInDisplay)
                    Clear();

                if (invokeEvent)
                    EchoInDisplayChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the text from dispaly
        /// </summary>
        [DefaultValue("")]
        [Description("Gets or sets the text from dispaly")]
        public override string Text
        {
            get => txtDisplay.Text;
            set => txtDisplay.Text = value;
        }

        [Category("Appearance")]
        [Description("Gets or sets the font of the buttons")]
        public Font ButtonsFont
        {
            get => _buttonsFont;
            set
            {
                _buttonsFont = value;

                btnDecimal.Font = 
                    btn0.Font = 
                    btn1.Font = 
                    btn2.Font = 
                    btn3.Font = 
                    btn4.Font = 
                    btn5.Font = 
                    btn6.Font = 
                    btn7.Font = 
                    btn8.Font = 
                    btn9.Font = 
                    btnConfirm.Font = _buttonsFont;
            }
        }

        protected override UnauthorizedControlResult UnauthorizedResult => UnauthorizedControlResult.Hide;

        #endregion

        #region Events

        /// <summary>
        /// Triggers when KeyboardLayout have been changed
        /// </summary>
        [Category("Property Changed")]
        [Description("Triggers when KeyboardLayout have been changed")]
        public virtual event EventHandler KeyboardLayoutChanged;

        /// <summary>
        /// Triggers when ShowDisplay have been changed
        /// </summary>
        [Category("Property Changed")]
        [Description("Triggers when ShowDisplay have been changed")]
        public virtual event EventHandler ShowDisplayChanged;

        /// <summary>
        /// Triggers when EchoInDisplay have been changed
        /// </summary>
        [Category("Property Changed")]
        [Description("Triggers when EchoInDisplay have been changed")]
        public virtual event EventHandler EchoInDisplayChanged;

        /// <summary>
        /// Triggers when user changed the text
        /// </summary>
        [Category("Action")]
        [Description("Triggers when user changed the text")]
        public virtual event TextHandler UserChangeText;

        /// <summary>
        /// Triggers when user press OK button
        /// </summary>
        [Category("Action")]
        [Description("Triggers when user press OK button")]
        public virtual event EventHandler UserConfirm;

        #endregion

        #region Constructors

        /// <summary>
        /// Crete a new default instance of ctrlNumericKeyboard
        /// </summary>
        public ctrlNumericKeyboard()
        {
            InitializeComponent();

            _keyboardLayout = NumericKeyboardLayout.Numeric;
            _echoInDisplay = true;
        }

        /// <summary>
        /// Crete a new explicit instance of ctrlNumericKeyboard
        /// </summary>
        /// <param name="keyboardLayout">Keyboard layout of control</param>
        public ctrlNumericKeyboard(NumericKeyboardLayout keyboardLayout)
            : this()
        {
            _keyboardLayout = keyboardLayout;
        }

        #endregion

        #region Overriedes

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetLayout(_keyboardLayout);
        }

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            txtDisplay.ApplyTheme(theme);
            btn0.ApplyTheme(theme);
            btn1.ApplyTheme(theme);
            btn2.ApplyTheme(theme);
            btn3.ApplyTheme(theme);
            btn4.ApplyTheme(theme);
            btn5.ApplyTheme(theme);
            btn6.ApplyTheme(theme);
            btn7.ApplyTheme(theme);
            btn8.ApplyTheme(theme);
            btn9.ApplyTheme(theme);
            btnDecimal.ApplyTheme(theme);
            btnConfirm.ApplyTheme(theme);
        }

        #endregion

        #region Event handlers

        private void ButtonPressed(object sender, EventArgs e)
        {
            var btn = sender as SpButton;

            if(btn == null)
                return;

            var text = btn.Tag?.ToString();
            var isDecimal = text == ".";

            if (isDecimal && txtDisplay.IsEmpty)
                text = "0.";
            
            if(isDecimal && txtDisplay.Text.Contains("."))
                return;

            if (EchoInDisplay)
            {
                txtDisplay.Text += text;
                UserChangeText?.Invoke(this, txtDisplay.Text);
            }
            else
                UserChangeText?.Invoke(this, text);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (EchoInDisplay &&
                _keyboardLayout == NumericKeyboardLayout.Decimal &&
                !txtDisplay.IsEmpty &&
                txtDisplay.Text.Trim().LastOrDefault() == '.')
            {
                txtDisplay.Text += "0";
            }

            UserConfirm?.Invoke(this, EventArgs.Empty);
            ParentForm?.PerformConfirm(() => Text);
        }

        private void txtDisplay_ClearButtonPressed(object sender, HandledEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text.RemoveLast();
            e.Handled = true;
        }

        #endregion

        #region Private methods

        private void SetLayout(NumericKeyboardLayout keyboardLayout)
        {
            txtDisplay.Clear();
            txtDisplay.UseSystemPasswordChar = keyboardLayout == NumericKeyboardLayout.Pin;

            txtDisplay.TextAlign = keyboardLayout == NumericKeyboardLayout.Decimal ||
                                   keyboardLayout == NumericKeyboardLayout.Numeric
                                       ? HorizontalAlignment.Right
                                       : HorizontalAlignment.Left;

            btnDecimal.Visible = keyboardLayout == NumericKeyboardLayout.Decimal;

            btnConfirm.Left = btnDecimal.Visible
                                  ? btn9.Left
                                  : btnDecimal.Left;

            btnConfirm.Width = !btnDecimal.Visible ? 220 : 107;
            switch (keyboardLayout)
            {
                case NumericKeyboardLayout.Numeric:
                    break;
                case NumericKeyboardLayout.Decimal:
                    break;
                case NumericKeyboardLayout.Pin:
                    break;
                case NumericKeyboardLayout.Phone:

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(keyboardLayout), keyboardLayout, null);
            }
        }

        #endregion
        
        #region Public methods

        /// <summary>
        /// Clear the text from display
        /// </summary>
        public virtual void Clear()
        {
            if(!(EchoInDisplay && ShowDisplay))
                return;

            txtDisplay.Clear();
        }

        public virtual object GetValue()
        {
            switch (_keyboardLayout)
            {
                case NumericKeyboardLayout.Numeric:
                    if (!txtDisplay.IsEmpty && int.TryParse(txtDisplay.Text, out var valInt))
                        return valInt;
                    return 0;
                case NumericKeyboardLayout.Decimal:
                    if (!txtDisplay.IsEmpty && decimal.TryParse(txtDisplay.Text, out var valDec))
                        return valDec;
                    return decimal.Zero;
                case NumericKeyboardLayout.Pin:
                case NumericKeyboardLayout.Phone:
                    return txtDisplay.Text;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual T GetValue<T>()
        {
            return (T) GetValue();
        }

        #endregion
    }
}
