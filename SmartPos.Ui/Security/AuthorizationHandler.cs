using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.DomainModel;
using SmartPos.GeneralLibrary;

namespace SmartPos.Ui.Security
{
    public static class AuthorizationHandler
    {
        public static event AuthorisationChangedHandler AuthorisationChanged;

        public static void OnAuthorizationChanged(IIdentity identity)
        {
            AuthorisationChanged?.Invoke(null, new AuthorisationChangedArgs(identity));
        }
    }

    public delegate void AuthorisationChangedHandler(object sender, AuthorisationChangedArgs args);

    public class AuthorisationChangedArgs
    {
        public IIdentity Identity { get; }

        public AuthorisationChangedArgs(IIdentity identity)
        {
            Identity = identity;
        }
    }
}
