using System.Threading.Tasks;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface IOrderController : IController
    {
        Task<Order> OpenTable(string tableId);
        Task<Order> SendOrder(Order order);
    }
}
