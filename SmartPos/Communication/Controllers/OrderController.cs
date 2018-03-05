using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<string> OpenTable(string tableId)
        {
            return await _client.ExecuteAsync<string>(Controller, Method.POST, new {tableId});
        }
    }
}
