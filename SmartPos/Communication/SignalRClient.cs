using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using SmartPos.Desktop.Properties;
using SmartPos.DomainModel.Communication;
using SmartPos.Desktop.Communication.Handlers;
using SmartPos.Desktop.Data;
using SmartPos.GeneralLibrary;
using SmartPos.Ui.Security;

namespace SmartPos.Desktop.Communication
{
    public class SignalRClient : ISignalRClient
    {
        #region Properties

        public IHubProxy Hub { get; }

        public Guid Id { get; }

        public HubConnection Connection { get; }

        public virtual bool IsConnected => Connection.State == ConnectionState.Connected;

        public virtual bool IsReconnecting => Connection.State == ConnectionState.Connecting || 
                                              Connection.State == ConnectionState.Reconnecting;

        public virtual bool IsDisconnected => Connection.State == ConnectionState.Disconnected;

        public virtual event ConnectionChangedHandler StateChanged;

        #endregion
        
        #region Constructors

        public SignalRClient()
        {
            Id = Guid.NewGuid();
            Connection = new HubConnection(Settings.Default.HubUrl);
            Hub = Connection.CreateHubProxy(SignalRHub.Name);

            Connection.StateChanged += OnConnectionStateChanged;
            AuthorizationHandler.AuthorisationChanged += OnUserAuthorisationChanged;
        }

        #endregion
        
        #region Event handlers

        private async void OnUserAuthorisationChanged(object sender, AuthorisationChangedArgs args)
        {
            if(Connection == null)
                return;

            if (Connection.Headers.ContainsKey(UserIdentity.AUTHORISATION_HEADER))
                Connection.Headers.Remove(UserIdentity.AUTHORISATION_HEADER);

            try
            {
                if (args.Identity != null)
                {
                    Connection.Headers.Add(UserIdentity.AUTHORISATION_HEADER, args.Identity.Id.GetHashCode().ToString());
                    var connectionId = await Hub.Invoke<string>(SignalRHub.Events.Account.RegisterClient, args.Identity);
                    args.Identity.ConnectionId = connectionId;
                }
                else
                    await Hub.Invoke(SignalRHub.Events.Account.RemoveClient);
            }
            catch (Exception ex)
            {
                GlobalHandler.Catch(ex);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void OnConnectionStateChanged(StateChange state)
        {
            if (StateChanged == null)
                return;

            var args = new ConnectionChangedArgs(state.OldState, state.NewState, this);
            StateChanged?.Invoke(args);
        }

        #endregion

        #region Public methods

        public virtual async Task Start()
        {
            try
            {
                await Connection.Start();
            }
            catch(Exception)
            {
                OnConnectionStateChanged(new StateChange(ConnectionState.Connecting, ConnectionState.Disconnected));
            }
        }

        public virtual void Stop()
        {
            Connection.Stop();
        }

        public virtual IDisposable Subscribe<TModel>(string method, SignalRSubscriptionHandler<TModel> handler)
        {
            if(string.IsNullOrEmpty(method))
                throw new ArgumentNullException(nameof(method));

            if(handler == null)
                throw new ArgumentNullException(nameof(handler));

            return Hub.On<TModel>(method, res => handler(res));
        }

        //public virtual Task<IDisposable> SubscribeAsync<TModel>(string method, SignalRSubscriptionAsyncHandler<TModel> handler)
        //{
        //    return Task.CompletedTask;
        //}
        
        public virtual void Dispose()
        {
            AuthorizationHandler.AuthorisationChanged -= OnUserAuthorisationChanged;
            Connection?.Dispose();
        }

        #endregion
    }
}
