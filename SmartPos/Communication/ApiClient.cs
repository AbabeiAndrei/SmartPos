using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using RestSharp;

using SmartPos.Ui.Security;
using SmartPos.Desktop.Data;
using SmartPos.Ui.Components;
using SmartPos.DomainModel.Base;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.Desktop.Communication.Controllers;
using SmartPos.Desktop.Communication.Controllers.Interfaces;

namespace SmartPos.Desktop.Communication
{
    public class ApiClient : IApiClient
    {
        private readonly RestClient _client;
        private ILoadingToken _loadingToken;
        private IAccountController _account;
        private ILayoutController _layout;
        private IOrderController _order;
        private IMenuController _menu;
        private ICustomerController _customer;
        private bool _enableCache;

        public virtual ILoadingToken LoadingToken
        {
            get => _loadingToken;
            set => _loadingToken = value;
        }

        public virtual IAccountController Account
        {
            get => _account;
            protected set => _account = value;
        }

        public virtual ILayoutController Layout
        {
            get => _layout;
            protected set => _layout = value;
        }

        public virtual IOrderController Order
        {
            get => _order;
            protected set => _order = value;
        }

        public virtual IMenuController Menu
        {
            get => _menu;
            protected set => _menu = value;
        }

        public virtual ICustomerController Customer
        {
            get => _customer;
            protected set => _customer = value;
        }

        public ApiClient()
        {
            _client = new RestClient(Properties.Settings.Default.ApiUrl);

            _account = new AccountController(this);
            _layout = new LayoutController(this);
            _order = new OrderController(this);
            _menu = new MenuController(this);
            _customer = new CustomerController(this);

            _enableCache = true;
        }
        
        public ApiClient(ILoadingToken loadingToken)
            : this()
        {
            _loadingToken = loadingToken;
        }

        /// <inheritdoc />
        public virtual bool EnableCache
        {
            get => _enableCache;
            set => _enableCache = value;
        }

        public virtual async Task<T> ExecuteAsync<T>(string resource, Method method, object queryStringParameters, object body = null)
        {
            try
            {
                if (LoadingToken != null)
                    LoadingToken.Loading = true;

                var request = new RestRequest(resource, method)
                {
                    RequestFormat = DataFormat.Json
                };

                if (queryStringParameters != null)
                    foreach (var (name, value) in queryStringParameters.GetProperties())
                        request.AddQueryParameter(name, value.ToString());

                if (body != null)
                    request.AddBody(body);

                if (AuthenticationManager.Identity != null)
                    request.AddHeader("Authorization", AuthenticationManager.Identity.ConnectionId);
                
                var response = await _client.ExecuteTaskAsync<T>(request);

                if (!response.IsSuccessful)
                    throw new RequestException(response.StatusCode, response.ErrorMessage, response.ErrorException);

                if (!EnableCache)
                    return response.Data;

                switch (response.Data)
                {
                    case IEnumerable<Entity> collectionEntities:
                        SimpleCache.CheckForUpdates(collectionEntities);
                        break;
                    case Entity entity:
                        SimpleCache.CheckForUpdates(entity);
                        break;
                }

                return response.Data;
            }
            finally
            {
                if (LoadingToken != null)
                    LoadingToken.Loading = false;
            }
        }
    }
}
