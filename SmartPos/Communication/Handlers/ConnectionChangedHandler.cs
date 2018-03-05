using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SmartPos.Desktop.Communication.Handlers
{
    public delegate void ConnectionChangedHandler(ConnectionChangedArgs args);

    public class ConnectionChangedArgs : IConnectionChangedArgs
    {
        public ConnectionState OldState { get; }

        public ConnectionState NewState { get; }

        public ISignalRClient Client { get; }

        public ConnectionChangedArgs(ConnectionState oldState, ConnectionState newState, ISignalRClient client)
        {
            OldState = oldState;
            NewState = newState;
            Client = client;
        }
    }

    public interface IConnectionChangedArgs
    {
        ISignalRClient Client { get; }
        ConnectionState NewState { get; }
        ConnectionState OldState { get; }
    }
}
