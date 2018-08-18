using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication.Controllers.Interfaces;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class OrderController : IOrderController
    {
        #region Fields

        private readonly IApiClient _client;

        #endregion

        #region Implementation of IController

        public string Controller => "Order";

        #endregion

        #region Constructors

        public OrderController(IApiClient client)
        {
            _client = client;
        }

        #endregion

        #region Implementation of IOrderController

        public async Task<Order> OpenTable(string tableId)
        {
            return await _client.ExecuteAsync<Order>(Controller, Method.PUT, new {tableId});
        }

        /// <inheritdoc />
        public async Task<Order> SendOrder(Order order)
        {
            return await _client.ExecuteAsync<Order>(Controller, Method.POST, null, order);
        }

        /// <inheritdoc />
        public Task Pay(Order order)
        {
            return _client.ExecuteAsync<Order>(Controller, Method.PATCH, null, order);
        }

        /// <inheritdoc />
        public Task<IEnumerable<Order>> GetAllActiveOrders()
        {
            return _client.ExecuteAsync<IEnumerable<Order>>(Controller, Method.GET, null);
        }

        #endregion
    }
}
