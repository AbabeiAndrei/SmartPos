using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication.Controllers.Interfaces;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class LayoutController : ILayoutController
    {
        private readonly IApiClient _client;

        public string Controller => "Layout";

        public LayoutController(IApiClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Zone>> GetAllZones()
        {
            return await _client.ExecuteAsync<IEnumerable<Zone>>(Controller, Method.GET, null);
        }

    }
}
