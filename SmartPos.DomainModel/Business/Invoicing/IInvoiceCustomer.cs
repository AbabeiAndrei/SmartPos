namespace SmartPos.DomainModel.Business.Invoicing
{
    public interface IInvoiceCustomer
    {
        string Name { get; }
        string Address { get; }
    }
}