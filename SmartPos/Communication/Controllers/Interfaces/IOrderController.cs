using System.Collections.Generic;
using System.Threading.Tasks;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface IOrderController : IController
    {
        Task<Order> OpenTable(string tableId);
        Task<Order> SendOrder(Order order);
        Task Pay(Order order);
        Task<IEnumerable<Order>> GetAllActiveOrders();
    }
}
