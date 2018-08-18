using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface ICustomerController : IController
    {
        Task<Customer> FindCustomer(string name);
        Task<Customer> Save(string name, string address);
    }
}
