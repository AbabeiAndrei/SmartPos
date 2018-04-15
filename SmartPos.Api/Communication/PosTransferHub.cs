using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Smartpos.Api.Security;
using SmartPos.DomainModel.Communication;
using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary;

namespace Smartpos.Api.Communication
{
    [HubName(SignalRHub.Name)]
    public class PosTransferHub : Hub
    {
        [HubMethodName(SignalRHub.Events.Account.RegisterClient)]
        public string RegisterClient(User user)
        {
            if (AuthenticationCache.Map.ContainsKey(Context.ConnectionId))
                AuthenticationCache.Map[Context.ConnectionId] = user;
            else
                AuthenticationCache.Map.Add(Context.ConnectionId, user);

            return Context.ConnectionId;
        }

        [HubMethodName(SignalRHub.Events.Account.RemoveClient)]
        public void RemoveClient()
        {
            if (AuthenticationCache.Map.ContainsKey(Context.ConnectionId))
                AuthenticationCache.Map.Remove(Context.ConnectionId);
        }
    }
}