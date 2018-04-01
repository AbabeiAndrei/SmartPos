using System;
using System.Drawing;
using System.Windows.Forms;

using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Utils;
using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Controls.Workspace
{
    public partial class CtrlTable : BaseControl
    {
        #region Fields

        private ITheme _theme;
        private Brush _textBrush;
        private Brush _freeTableBrush;
        private Brush _openTableBrush;
        private Brush _ocupiedTableBrush;
        private static readonly StringFormat _stringFormat;

        #endregion

        #region Properties

        public Table Table { get; }

        #endregion

        #region Constructors

        public CtrlTable(Table table)
        {
            Table = table;
            InitializeComponent();
        }

        static CtrlTable()
        {
            _stringFormat = GfxHelper.CreateStringFormat(StringAlignment.Center, StringAlignment.Center);
        }
        
        #endregion

        #region Overrides

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

        protected override async void OnClick(EventArgs e)
        {
            try
            {
                var order = await Application.Api(ParentForm.LoadingState).Order.OpenTable(Table.Id.ToString());

                UiHelper.ShowOrder(order);
            }
            catch (Exception ex)
            {
                GlobalHandler.Catch(ex, ParentForm);
            }
            base.OnClick(e);
        }

        #endregion
    }
}
