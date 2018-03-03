using System.Threading.Tasks;
using RestSharp;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Security;
using SmartPos.GeneralLibrary.Extensions;
using SmartPos.Ui.Components;

namespace SmartPos.Desktop.Communication
{
    public class ApiClient
    {
        private readonly RestClient _client;
        private ILoadingToken _loadingToken;

        public virtual ILoadingToken LoadingToken
        {
            get => _loadingToken;
            set => _loadingToken = value;
        }

        public ApiClient()
        {
            _client = new RestClient(Properties.Settings.Default.ApiUrl);
        }
        
        public ApiClient(ILoadingToken loadingToken = null)
            : this()
        {
            _loadingToken = loadingToken;
        }

        public async Task<User> Login(string pin)
        {
            const string controller = "Account";

            var hasher = new UserPasswordHasher();

            return await ExecuteAsync<User>(controller, Method.GET, new { pin = hasher.Hash(pin, null) });
        }

        protected async Task<T> ExecuteAsync<T>(string resource, Method method, object queryStringParameters, object body = null) 
            where T : new()
        {
            try
            {
                if (LoadingToken != null)
                    LoadingToken.Loading = true;

                var request = new RestRequest(resource, method);

                foreach (var (name, value) in queryStringParameters.GetProperties())
                    request.AddParameter(name, value);

                if (body != null)
                    request.AddBody(body);

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
