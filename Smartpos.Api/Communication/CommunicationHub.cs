using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

using SmartPos.DomainModel.Model;
using SmartPos.DomainModel.Communication;

namespace Smartpos.Api.Communication
{
    public class CommunicationHub : ICommunicationHub
    {
        public void SendAll(MessageModel message)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<PosTransferHub>();
            IClientProxy proxy = hub.Clients.AllExcept(message.From);
            proxy.Invoke(SignalRHub.Events.Order.RegisterTable, message);
        }
    }
}