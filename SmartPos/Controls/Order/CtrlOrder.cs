using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using SmartPos.Ui;
using SmartPos.Ui.Utils;
using SmartPos.Ui.Theming;
using SmartPos.Ui.Handlers;
using SmartPos.Desktop.Data;
using SmartPos.Ui.Components;
using SmartPos.Desktop.Utils;
using SmartPos.Desktop.Handlers;
using SmartPos.Desktop.Security;
using SmartPos.Desktop.Interfaces;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.GeneralLibrary.Writers;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.DomainModel.Business.Invoicing;

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

                var sb = new StringBuilder();

                if(table != null)
                    sb.Append($"Masa : {table.Name},");

                if (_order.Id != 0)
                    sb.Append($"Comanda : {_order.Number},");

                if(_order.Customer != null)
                    sb.Append($"Client : {_order.Customer.Name}");

                return sb.ToString().Trim(',');
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
                    ParentForm.PresentMessage("Nu se poate trimite o comanda goala. Adaugati produse dupa incercati din nou.", MessageType.Warning);
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

            CreateOrderItem(args);

            return Task.CompletedTask;
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item != null)
                IncreaseQuantity(item);
        }

        private void btnPlus_LongPress(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if (item == null)
                return;

            SetQuantityInput(item);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item != null)
                DecreaseQuantity(item);
        }

        private void btnMinus_LongPress(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if (item == null)
                return;

            SetQuantityInput(item);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if(item == null)
                return;

            var index = lvItems.SelectedIndices[0];
            RemoveItem(item);
            SelecteNextItem(index);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();

            if (item == null)
                return;

            UiHelper.ShowForm<CtrlNumericKeyboard>($"Split {item.Name}", ParentForm)
                    .ApplyTheme(Theme)
                    .Configure(ctrl => ctrl.KeyboardLayout = NumericKeyboardLayout.Decimal)
                    .OnConfirm((formSender, after) => SplitItem(formSender, item, after))
                    .SetTitleBar(true, true)
                    .Show();
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                var result = UiHelper.ShowConfirmation($"Esti sigur ca vrei sa inchizi masa {_order.Table?.Name}?", 
                                                       MessageType.Info, $"Comanda {_order.Number}", ParentForm); 

                if(result != DialogResult.Yes)
                    return;

                await Application.Api(ParentForm.LoadingState).Order.Pay(_order);
                await BackToTables();
            }
            catch (Exception exception)
            {
                GlobalHandler.Catch(exception, ParentForm);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if(lvItems.Items.Count <= 0)
                return;

            if (_order.Customer == null)
                SelectCustomer();

            if (_order.Customer == null)
                return;

            var items = lvItems.Items.OfType<ListViewItem>()
                               .Select(lvi => lvi.Tag as OrderItem)
                               .ToList();

            var invoice = InvoiceBuilder.Create(FinancialHandler.GenerateInvoiceNumber(),
                                                CreateInvoice(items),
                                                _order.Customer);
            invoice.Total = items.Select(oi => oi.CalculateTotal())
                                 .DefaultIfEmpty(0)
                                 .Sum();

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(desktopPath, $"Factura-{invoice.Number}.pdf");
            var pdfWriter = new PdfWriter(path);

            pdfWriter.Write(invoice.ToString());
            pdfWriter.Save();

            Process.Start(path);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        private void SelectCustomer()
        {
            UiHelper.ShowForm<CtrlCustomerSelector>("Set customer", ParentForm)
                    .SetTitleBar(true, true)
                    .OnConfirm(OnSetCustomer)
                    .Configure(ctrl => ctrl.Customer = _order.Customer)
                    .ApplyTheme(Theme)
                    .Show(r => Application.MainForm.As<MainForm>().SetStatusBarInfoText(this));
        }

        private Task SplitItem(IFormSender formSender, OrderItem item, IContinuityDelegate after)
        {
            if (!float.TryParse(formSender.Result?.ToString() ?? string.Empty, out var result))
            {
                after.PresentMessage("Cantitate invalida", MessageType.Error, MessageDurationLength.Short);
                after.Close = false;
                return Task.CompletedTask;
            }

            var newQuantity = item.Quantity - result;

            SetQuantity(item, newQuantity);
            CreateOrderItem(item.Name, item.ProductId, result, item.UnitPrice);

            ParentForm.PresentMessage("Succes!", MessageType.Info, MessageDurationLength.Short);

            after.Close = true;

            return Task.CompletedTask;
        }

        private Task OnSetCustomer(IFormSender sender, IContinuityDelegate after)
        {
            if (sender.Result is Customer customer)
            {
                _order.Customer = customer;
                _order.CustomerId = customer.Id;
                after.PresentMessage($"Clientul {customer.Name} a fost adaugat in comanda", MessageType.Info, MessageDurationLength.Medium);
            }
            else
            {
                _order.Customer = null;
                _order.CustomerId = null;
                after.PresentMessage("Clientul a fost scos din comanda", MessageType.Info, MessageDurationLength.Short);
            }

            after.Close = true;
            return Task.CompletedTask;
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

        private static async Task BackToTables()
        {
            await UiHelper.ShowTablesInMainForm();
        }

        private void CreateOrderItem(IProductItemArgs args)
        {
            CreateOrderItem(args.Product.Name, args.Product.Id, args.Quantity, args.Product.UnitPrice);
        }

        private void CreateOrderItem(string productName, int productId, float quantity, decimal unitPrice)
        {
            var item = new OrderItem
            {
                Name = productName,
                ProductId = productId,
                Quantity = quantity,
                State = OrderItemState.Active,
                UnitPrice = unitPrice
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

        private void SelecteNextItem(int index)
        {
            if(lvItems.Items.Count == 0)
                return;
            
            if (index < 0)
                index = 0;
            else if (index >= lvItems.Items.Count)
                index = lvItems.Items.Count - 1;

            var item = lvItems.Items[index];
            item.Selected = true;
            item.Focused = true;
            item.EnsureVisible();
        }

        private void SetQuantityInput(OrderItem item)
        {
            UiHelper.ShowForm<CtrlNumericKeyboard>($"Set quantity {item.Name}", ParentForm)
                    .ApplyTheme(Theme)
                    .Configure(ctrl => ctrl.KeyboardLayout = NumericKeyboardLayout.Decimal)
                    .OnConfirm((formSender, after) => SetQuantity(item, formSender, after))
                    .SetTitleBar(true, true)
                    .Show();
        }

        private Task SetQuantity(OrderItem item, IFormSender formSender, IContinuityDelegate after)
        {
            if (!float.TryParse(formSender.Result?.ToString() ?? string.Empty, out var result))
            {
                after.PresentMessage("Cantitate invalida", MessageType.Error, MessageDurationLength.Short);
                after.Close = false;
                return Task.CompletedTask;
            }
            SetQuantity(item, result);

            after.Close = true;

            return Task.CompletedTask;
        }

        private static IDictionary<string, IEnumerable<object>> CreateInvoice(IEnumerable<OrderItem> items)
        {
            var dict = new Dictionary<string, IEnumerable<object>>();

            items = items as IList<OrderItem> ?? items.ToList();

            dict.Add("Produs", items.Select(oi => oi.Name));
            dict.Add("Cantitate", items.Select(oi => oi.Quantity.ToString("N2")));
            dict.Add("Pret unitar", items.Select(oi => oi.UnitPrice.ToString("N2")));
            dict.Add("Pret", items.Select(oi => oi.CalculateTotal().ToString("N2")));

            return dict;
        }

        #endregion
    }
}
