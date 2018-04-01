using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class MenuController : IMenuController
    {
        private readonly IApiClient _client;

        public MenuController(IApiClient client)
        {
            _client = client;
        }

        #region Implementation of IController

        /// <inheritdoc />
        public string Controller => "Menu";

        #endregion

        #region Implementation of IMenuController

        /// <inheritdoc />
        public Task<IEnumerable<MenuCategory>> GetMenu()
        {
            return _client.ExecuteAsync<IEnumerable<MenuCategory>>(Controller, Method.GET, null);
        }

        #endregion
    }
}
