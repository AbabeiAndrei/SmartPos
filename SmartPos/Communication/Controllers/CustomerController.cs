using System.Threading.Tasks;

using RestSharp;

using SmartPos.Desktop.Communication.Controllers.Interfaces;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Model;

namespace SmartPos.Desktop.Communication.Controllers
{
    public class CustomerController : ICustomerController
    {
        #region Fields

        private readonly IApiClient _client;

        #endregion

        #region Constructors

        public CustomerController(IApiClient client)
        {
            _client = client;
        }

        #endregion
        
        #region Implementation of IController

        /// <inheritdoc />
        public string Controller => "Customer";
        
        #endregion
        
        #region Implementation of CustomerController

        /// <inheritdoc />
        public Task<Customer> FindCustomer(string name)
        {
            return _client.ExecuteAsync<Customer>(Controller, Method.GET, new {name});
        }

        /// <inheritdoc />
        public Task<Customer> Save(string name, string address)
        {
            var model = new CustomerSaveModel(name, address)
            {
                CreatedBy = Application.User.Id
            };

            return _client.ExecuteAsync<Customer>(Controller, Method.POST, null, model);
        }

        #endregion
    }
}
