using System;
using System.Drawing;
using System.Windows.Forms;

using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Utils;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Model;

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
        private DomainModel.Entities.Order _order;
        private static readonly StringFormat StringFormat;
        private static readonly Font FontOcupiedUser;

        #endregion

        #region Properties

        public Table Table { get; }

        public DomainModel.Entities.Order Order
        {
            get => _order;
            set
            {
                _order = value;

                Refresh();
            }
        }

        #endregion

        #region Constructors

        public CtrlTable(Table table)
        {
            Table = table;
            InitializeComponent();
        }

        static CtrlTable()
        {
            StringFormat = GfxHelper.CreateStringFormat(StringAlignment.Center, StringAlignment.Center);
            FontOcupiedUser = new Font(DefaultFont.FontFamily, 8f);
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

            Brush brush;
            
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (Table?.State?.State)
            {
                case TableOcupation.Opened:
                    brush = _openTableBrush;
                    break;
                case TableOcupation.Ocupied:
                    brush = _ocupiedTableBrush;
                    break;
                default:
                    brush = _freeTableBrush;
                    break;
            }

            e.Graphics.FillRectangle(brush, rect);

            if (Table != null)
            {
                e.Graphics.DrawString(Table.Name, Font, _textBrush, rect, StringFormat);
                if(Table.State != null)
                    e.Graphics.DrawString(Table.State.OcupiedByUser, FontOcupiedUser, _textBrush, 
                                          new Rectangle(0, Height - 30, Width, 30), StringFormat);
            }
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
