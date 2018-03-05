using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SmartPos.DomainModel.Communication;

namespace Smartpos.Api.Communication
{
    [HubName(SignalRHub.NAME)]
    public class PosTransferHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}