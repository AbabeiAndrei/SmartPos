using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Desktop.Communication.Controllers.Interfaces
{
    public interface IOrderController : IController
    {
        Task<string> OpenTable(string tableId);
    }
}
