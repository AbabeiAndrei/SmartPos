using System.Drawing;
using System.Windows.Forms;
using SmartPos.DomainModel.Entities;
using SmartPos.Ui;
using SmartPos.Ui.Theming;

namespace SmartPos.Desktop.Controls.Workspace
{
    public partial class CtrlTable : BaseControl
    {
        private ITheme _theme;
        private Brush _textBrush;
        private Brush _freeTableBrush;
        private Brush _openTableBrush;
        private Brush _ocupiedTableBrush;
        private static readonly StringFormat _stringFormat;

        public Table Table { get; }

        public CtrlTable(Table table)
        {
            Table = table;
            InitializeComponent();
        }

        static CtrlTable()
        {
            _stringFormat = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
        }

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _theme = theme;
            _textBrush = new SolidBrush(ForeColor);
            _freeTableBrush = new SolidBrush(_theme.FreeTableColor);
            _openTableBrush = new SolidBrush(_theme.OpenedTableColor);
            _ocupiedTableBrush = new SolidBrush(_theme.OcupiedTableColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = new Rectangle(0, 0, Width, Height);
            
            e.Graphics.FillRectangle(_freeTableBrush, rect);

            if(Table != null)
                e.Graphics.DrawString(Table.Name, Font, _textBrush, rect, _stringFormat);
        }

        protected override void DisposeComponents()
        {
            base.DisposeComponents();
            _textBrush?.Dispose();
            _freeTableBrush?.Dispose();
            _openTableBrush?.Dispose();
            _ocupiedTableBrush?.Dispose();
        }
    }
}
