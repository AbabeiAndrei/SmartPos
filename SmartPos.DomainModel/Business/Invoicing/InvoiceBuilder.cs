using System.Collections.Generic;

namespace SmartPos.DomainModel.Business.Invoicing
{
    public static class InvoiceBuilder
    {
        public static Invoice Create(int number, IDictionary<string, IEnumerable<object>> fields, IInvoiceCustomer customer)
        {
            return new Invoice
            {
                Number = number,
                Customer = customer,
                Header = fields.Keys,
                Items = fields
            };
        }
    }
}
