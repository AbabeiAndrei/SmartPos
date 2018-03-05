using System;
using Microsoft.AspNet.SignalR.Client;

namespace SmartPos.Desktop.Communication
{
    public interface ISignalRClient : IDisposable
    {
        Guid Id { get; }
        HubConnection Connection { get; }
    }
}