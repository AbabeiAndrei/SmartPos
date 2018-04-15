using System;

using SmartPos.Ui.Forms;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;

namespace SmartPos.Desktop.Controls.Form
{
    public partial class ConfirmationForm : TransparentForm
    {
        #region Fields

        private MessageType _messageType;

        #endregion
       
        #region Properties
        
        public virtual string Title
        {
            get => lblMessageTitle.Text;
            set => lblMessageTitle.Text = value;
        }

        public virtual string Question
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        public virtual MessageType MessageType
        {
            get => _messageType;
            set
            {
                var invokeChangeTheme = _messageType != value;

                _messageType = value;

                if(invokeChangeTheme)
                    ApplyPnlContentTheme(Theme);
            }
        }

        #endregion

        #region Constructors

        public ConfirmationForm()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public ConfirmationForm(string question)
            : this()
        {
            lblText.Text = question;
        }

        #endregion

        #region Overrides of BaseForm

        /// <inheritdoc />
        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);

            ApplyPnlContentTheme(theme);
            lblMessageTitle.ForeColor = MaterialColors.Black;
            lblText.ForeColor = MaterialColors.Black;
        }

        #endregion

        #region Private methods

        private void ApplyPnlContentTheme(ITheme theme)
        {
            switch (MessageType)
            {
                case MessageType.Info:
                    pnlContent.BackColor = theme.InfoBackColor;
                    break;
                case MessageType.Warning:
                    pnlContent.BackColor = theme.WarningBackColor;
                    break;
                case MessageType.Error:
                    pnlContent.BackColor = theme.ErrorBackColor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
