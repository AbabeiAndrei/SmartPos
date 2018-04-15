using System.Threading.Tasks;

using RestSharp;

using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication.Controllers.Interfaces;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IApiClient _client;

        public string Controller => "Order";

        public OrderController(IApiClient client)
        {
            _client = client;
        }

        public async Task<Order> OpenTable(string tableId)
        {
            return await _client.ExecuteAsync<Order>(Controller, Method.PUT, new {tableId});
        }

        /// <inheritdoc />
        public async Task<Order> SendOrder(Order order)
        {
            return await _client.ExecuteAsync<Order>(Controller, Method.POST, null, order);
        }
    }
}
