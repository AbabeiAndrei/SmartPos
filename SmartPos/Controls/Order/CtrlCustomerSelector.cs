using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using SmartPos.Desktop.Data;
using SmartPos.Ui;
using SmartPos.Ui.Components;
using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Controls.Order
{
    public partial class CtrlCustomerSelector : BaseControl
    {
        #region Fields

        private Customer _customer;

        #endregion

        #region Properties

        public Customer Customer
        {
            get => _customer;
            set => SetCustomer(value);
        }
        
        #endregion

        #region Constructors

        public CtrlCustomerSelector()
        {
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtClient.Text))
                    Customer = await Application.Api(LoadingState).Customer.Save(txtClient.Text, txtAddress.Text);
            }
            catch (Exception mex)
            {
                GlobalHandler.Catch(mex, ParentForm);
                return;
            }
            await ParentForm.PerformConfirm(() => Customer, this);
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            await ParentForm.PerformClose(this);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtClient.Text))
                return;

            try
            {
                Customer = await Application.Api(LoadingState).Customer.FindCustomer(txtClient.Text);
            }
            catch (Exception)
            {
                ParentForm.PresentMessage("Clientul nu a fost gasit", MessageType.Warning, MessageDurationLength.Medium);
            }
        }

        private void txtClient_ClearButtonPressed(object sender, HandledEventArgs e)
        {
            Customer = null;
        }

        #endregion

        #region Private methods

        private void SetCustomer(Customer customer)
        {
            _customer = customer;

            txtClient.Text = customer?.Name ?? string.Empty;
            txtAddress.Text = customer?.Address ?? string.Empty;
        }

        #endregion
    }
}
