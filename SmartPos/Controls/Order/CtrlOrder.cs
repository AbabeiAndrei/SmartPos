using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using SmartPos.Ui;
using SmartPos.Ui.Handlers;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Handlers;
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

        #region Events

        public event OrderSentEventHandler OrderSent;

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
            new ToolBarButton("Trimite", SendOrder, ToolBarButtonLocation.Right),
            new ToolBarButton("Mese", BackToTables)
        };

        #endregion

        #region Overrides of BaseControl

        /// <inheritdoc />
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (_order != null)
                LoadOrderItems(_order.Items);

            try
            {
                LoadingState.Loading = true;

                await ctrlMenu.LoadMenu();
            }
            finally
            {
                LoadingState.Loading = false;
            }
        }

        #endregion
        
        #region Event handlers

        private async Task SendOrder()
        {
            try
            {
                if ((_order.Items?.Count() ?? 0) <= 0)
                {
                    ParentForm.ShowMessage("Nu se poate trimite o comanda goala. Adaugati produse dupa incercati din nou.", MessageType.Warning);
                    return;
                }

                var order = await Application.Api(LoadingState).Order.SendOrder(_order);
                await OnOrderSent(new OrderSentEventArgs(order));
                await BackToTables();
            }
            catch (Exception ex)
            {
                GlobalHandler.Catch(ex, ParentForm);
            }
        }

        private Task CtrlMenu_ProductClick(object sender, IProductItemArgs args)
        {
            var last = _order.Items?.LastOrDefault();

            if (last != null && last.ProductId == args.Product.Id)
            {
                IncreaseQuantity(last, args.Quantity);
                return Task.CompletedTask;
            }

            var item = new OrderItem
            {
                Name = args.Product.Name,
                ProductId = args.Product.Id,
                Quantity = args.Quantity,
                State = OrderItemState.Active,
                UnitPrice = args.Product.UnitPrice
            };
            var newList = new List<OrderItem>(_order.Items ?? Enumerable.Empty<OrderItem>())
            {
                item
            };

            _order.Items = newList;

            var lvi = CreateListViewItem(item);
            
            lvItems.Items.Add(lvi);

            CalculateTotal(newList);

            lvi.EnsureVisible();

            return Task.CompletedTask;
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item != null)
                IncreaseQuantity(item);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item != null)
                DecreaseQuantity(item);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item == null)
                return;

            RemoveItem(item);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnProfoma_Click(object sender, EventArgs e)
        {

        }

        #endregion
        
        #region Protected methods

        protected virtual async Task OnOrderSent(IOrderSentEventArgs args)
        {
            if (OrderSent != null)
                await OrderSent.Invoke(this, args);
        }

        #endregion

        #region Private methods

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

                if (lorderItems.Count > 0)
                {
                    var items = lorderItems.Where(oi => oi.State.IsValidForOrder())
                                           .Select(CreateListViewItem)
                                           .ToArray();
                    lvItems.Items.AddRange(items);
                }

                CalculateTotal(lorderItems);

                //lvItems.Columns[0].Width = -2;
            }
            finally
            {
                lvItems.EndUpdate();
            }
        }

        private void CalculateTotal(ICollection<OrderItem> lorderItems)
        {
            lblItems.Text = lorderItems.Count != 1
                                    ? $"{lorderItems.Count} produse"
                                    : "Un produs";

            var total = lorderItems.Select(item => item.UnitPrice.CalculateTotalPrice(item.Quantity))
                                   .DefaultIfEmpty(0m)
                                   .Sum();

            lblTotal.Text = $"TOTAL : {total:N2} LEI";
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

        private OrderItem GetSelectedItem()
        {
            return lvItems.SelectedItems.Count > 0
                           ? lvItems.SelectedItems[0].Tag as OrderItem
                           : null;
        }
        
        private void IncreaseQuantity(OrderItem item, float quantity = 1f)
        {
            SetQuantity(item, item.Quantity + quantity);
        }
        
        private void DecreaseQuantity(OrderItem item, float quantity = 1f)
        {
            SetQuantity(item, item.Quantity - quantity);
        }

        private void SetQuantity(OrderItem item, float quantity)
        {
            if(item == null)
                return;

            if (quantity <= 0)
            {
                RemoveItem(item);
                return;
            }

            item.Quantity = quantity;
            SetRowValueForOrderItem(item);
        }

        private void SetRowValueForOrderItem(OrderItem orderItem)
        {
            if(orderItem == null)
                return;

            var item = lvItems.Items.OfType<ListViewItem>()
                              .FirstOrDefault(lvi => lvi.Tag is OrderItem oi && oi.ObiectId == orderItem.ObiectId);

            if(item == null)
                return;

            item.SubItems[0].Text = orderItem.Name;
            item.SubItems[1].Text = orderItem.Quantity.ToString("N2");
            item.SubItems[2].Text = orderItem.UnitPrice.CalculateTotalPrice(orderItem.Quantity).ToString("N2");

            if (orderItem.Deleted)
                if (orderItem.State == OrderItemState.Storno)
                {
                    item.Font = new Font(item.Font, FontStyle.Strikeout);
                    item.BackColor = Theme.StornoOrderItemBackColor;
                }
                else
                    item.Remove();

            CalculateTotal(lvItems.Items.OfType<ListViewItem>().Select(lvi => lvi.Tag as OrderItem).ToList());
        }

        private void RemoveItem(OrderItem item)
        {
            var quantity = "produsul ";

            if (item.Quantity > 1)
                quantity = $"produsele {item.Quantity}x";

            var answer = UiHelper.ShowConfirmation($"Esti sigur ca vrei sa stergi {quantity + '"' + item.Name}\"?", MessageType.Warning);

            if (answer != DialogResult.Yes)
                return;

            if (item.Id == 0)
                _order.Items = _order.Items.Where(oi => oi.ObiectId != item.ObiectId);
            else
                item.State = OrderItemState.Storno;

            item.Deleted = true;

            SetRowValueForOrderItem(item);
        }

        #endregion
    }
}
