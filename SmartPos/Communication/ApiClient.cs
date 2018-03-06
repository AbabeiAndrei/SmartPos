using System.Threading.Tasks;

using RestSharp;

using SmartPos.Ui.Components;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.Desktop.Communication.Controllers;
using SmartPos.Desktop.Communication.Controllers.Interfaces;
using SmartPos.Ui.Security;

namespace SmartPos.Desktop.Communication
{
    public class ApiClient : IApiClient
    {
        private readonly RestClient _client;
        private ILoadingToken _loadingToken;
        private IAccountController _account;
        private ILayoutController _layout;
        private IOrderController _order;

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

        public ApiClient()
        {
            _client = new RestClient(Properties.Settings.Default.ApiUrl);

            _account = new AccountController(this);
            _layout = new LayoutController(this);
            _order = new OrderController(this);
        }
        
        public ApiClient(ILoadingToken loadingToken = null)
            : this()
        {
            _loadingToken = loadingToken;
        }

        public async Task<T> ExecuteAsync<T>(string resource, Method method, object queryStringParameters, object body = null) 
        {
            try
            {
                if (LoadingToken != null)
                    LoadingToken.Loading = true;

                var request = new RestRequest(resource, method);

                if (queryStringParameters != null)
                    foreach (var (name, value) in queryStringParameters.GetProperties())
                        request.AddQueryParameter(name, value.ToString());

                if (body != null)
                    request.AddBody(body);

                if (AuthenticationManager.Identity != null)
                    request.AddHeader("Authorization", AuthenticationManager.Identity.ConnectionId);

                var response = await _client.ExecuteTaskAsync<T>(request);

                if (response.IsSuccessful)
                    return response.Data;

                throw new RequestException(response.StatusCode, response.ErrorMessage, response.ErrorException);
            }
            finally
            {
                if (LoadingToken != null)
                    LoadingToken.Loading = false;
            }
        }
    }
}
