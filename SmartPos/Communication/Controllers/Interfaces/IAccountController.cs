using System.Threading.Tasks;
using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface IAccountController : IController
    {
        Task<User> Login(string pin);
    }
}