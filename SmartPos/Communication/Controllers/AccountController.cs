using System.Threading.Tasks;

using RestSharp;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Security;
using SmartPos.Desktop.Communication.Controllers.Interfaces;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class AccountController : IAccountController
    {
        #region Fields

        private readonly IApiClient _client;
        private readonly IPasswordHasher<User> _hasher;
        
        #endregion

        #region Properties

        public string Controller => "Account";

        #endregion

        #region Constructors

        public AccountController(IApiClient client)
        {
            _client = client;
            _hasher = new UserPasswordHasher();
        }

        #endregion

        #region Public methods

        public async Task<User> Login(string pin)
        {
            return await _client.ExecuteAsync<User>(Controller, Method.GET, new { pin = _hasher.Hash(pin, null) });
        }

        #endregion
    }
}
