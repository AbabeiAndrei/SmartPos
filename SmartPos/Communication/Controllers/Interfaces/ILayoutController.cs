using System.Threading.Tasks;
using System.Collections.Generic;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface ILayoutController : IController
    {
        Task<IEnumerable<Zone>> GetAllZones();
    }
}