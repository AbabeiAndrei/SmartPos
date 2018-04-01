using System.Threading.Tasks;
using System.Collections.Generic;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers
{
    public interface IMenuController : IController
    {
        Task<IEnumerable<MenuCategory>> GetMenu();
    }
}