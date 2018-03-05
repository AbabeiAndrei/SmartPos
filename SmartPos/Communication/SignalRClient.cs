using System;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using SmartPos.Desktop.Properties;
using SmartPos.DomainModel.Communication;

namespace SmartPos.Desktop.Communication
{
    public class SignalRClient : IDisposable
    {
        #region Properties

        public IHubProxy Hub { get; }

        public HubConnection Connection { get; }

        public bool IsConnected => Connection.State == ConnectionState.Connected;

        public bool IsReconnecting => Connection.State == ConnectionState.Connecting || 
                                      Connection.State == ConnectionState.Reconnecting;

        public bool IsDisconnected => Connection.State == ConnectionState.Disconnected;

        #endregion
        
        #region Constructors

        public SignalRClient()
        {
            Connection = new HubConnection(Settings.Default.HubUrl);
            Hub = Connection.CreateHubProxy(SignalRHub.NAME);
        }

        #endregion

        #region Public methods

        public async Task Start()
        {
            await Connection.Start();
        }

        public void Stop()
        {
            Connection.Stop();
        }
        
        public void Dispose()
        {
            Connection?.Dispose();
        }

        #endregion
    }
}
