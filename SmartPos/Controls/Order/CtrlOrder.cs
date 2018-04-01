using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using SmartPos.Ui;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Security;
using SmartPos.Desktop.Interfaces;
using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary.Extensions;

using ToolBarButton = SmartPos.Desktop.Interfaces.ToolBarButton;

namespace SmartPos.Desktop.Controls.Order
{
    [PosAuthorisation]
    public partial class CtrlOrder : BaseControl, IStatusBarAccesor, IToolBarCustomizer
    {
        #region Fields

        private readonly DomainModel.Entities.Order _order;

        #endregion

        #region Constructors

        public CtrlOrder(DomainModel.Entities.Order order)
        {
            _order = order;
            InitializeComponent();
        }

        #endregion
        
        #region Implementation of IStatusBarAccesor

        public string Value
        {
            get
            {
                if (_order == null)
                    return string.Empty;

                var table = SimpleCache.Get<Table>(_order.TableId);

                return table != null
                               ? $"Masa : {table.Name}"
                               : string.Empty;
            }
        }

        #endregion

        #region Implementation of IToolBarCustomizer

        /// <inheritdoc />
        public bool ShowLogout => true;

        /// <inheritdoc />
        public bool ShowOptions => false;

        /// <inheritdoc />
        public IEnumerable<IToolBarButton> Buttons => new[]
                                                      {
                                                        new ToolBarButton("Send", SendOrder, ToolBarButtonLocation.Right),
                                                        new ToolBarButton("Tables", BackToTables), 
                                                      };

        #endregion

        #region Overrides of BaseControl

        /// <inheritdoc />
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (_order != null)
                LoadOrderItems(_order.Items);

            await ctrlMenu.LoadMenu();
        }

        #endregion

        #region Private methods

        private async Task SendOrder()
        {
            throw new NotImplementedException();
        }

        private static Task BackToTables()
        {
            UiHelper.ShowTablesInMainForm();
            return Task.CompletedTask;
        }

        private void LoadOrderItems(IEnumerable<OrderItem> orderItems)
        {
            try
            {
                lvItems.BeginUpdate();

                lvItems.Items.Clear();

                var lorderItems = orderItems as IList<OrderItem> ?? orderItems?.ToList() ?? new List<OrderItem>();

                if(lorderItems.Count > 0)
                    lvItems.Items.AddRange(lorderItems.Select(CreateListViewItem).ToArray());

                lblItems.Text = lorderItems.Count != 1
                                        ? $"{lorderItems.Count} produse"
                                        : "Un produs";

                var total = lorderItems.Select(item => item.UnitPrice.CalculateTotalPrice(item.Quantity))
                                       .DefaultIfEmpty(0m)
                                       .Sum();

                lblTotal.Text = $"TOTAL : {total:N2} LEI";


                //lvItems.Columns[0].Width = -2;
            }
            finally
            {
                lvItems.EndUpdate();
            }
        }

        private static ListViewItem CreateListViewItem(OrderItem arg)
        {
            return new ListViewItem(arg.Name)
                   {
                        SubItems =
                        {
                            arg.Quantity.ToString("N2"),
                            arg.UnitPrice.CalculateTotalPrice(arg.Quantity).ToString("N2")
                        },
                        Tag = arg
                   };
        }

        #endregion
    }
}
