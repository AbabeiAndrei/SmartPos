using System;
using System.Drawing;
using System.Windows.Forms;
using SmartPos.DomainModel.Entities;
using SmartPos.Ui;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop.Controls.Workspace
{
    public partial class CtrlWorkspaceZone : BaseControl
    {
        #region Fields

        private Brush _textColor;
        private Pen _borderPen;
        private Pen _selectedBorderPen;
        private Zone _zone;
        private bool _selected;
        private static readonly StringFormat _stringFormat;

        #endregion

        #region Properties

        public virtual Zone Zone
        {
            get => _zone;
            set
            {
                _zone = value;
                Refresh();
            }
        }

        public virtual bool Selected
        {
            get => _selected;
            set
            {
                var refresh = Selected != value;
                _selected = value;

                if(refresh)
                    Refresh();
            }
        }

        #endregion

        #region Constructors

        public CtrlWorkspaceZone(Zone zone)
        {
            InitializeComponent();
            _zone = zone;
        }

        static CtrlWorkspaceZone()
        {
            _stringFormat = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
        }

        #endregion

        #region Overrides

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);

            _textColor = new SolidBrush(ForeColor);
            _borderPen = new Pen(ForeColor);
            _selectedBorderPen = new Pen(ForeColor, 2.5f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(_textColor == null)
                return;

            if(Zone != null)
                e.Graphics.DrawString(Zone.Name, Font, _textColor, new Rectangle(0, 0, Width, Height), _stringFormat);

            var borderPen = Selected
                                ? _selectedBorderPen
                                : _borderPen;

            e.Graphics.DrawRectangle(borderPen, 0, 0, Width - borderPen.Width, Height - borderPen.Width);
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
            _textColor?.Dispose();
            _selectedBorderPen?.Dispose();
            _borderPen?.Dispose();
        }


        #endregion
    }
}
