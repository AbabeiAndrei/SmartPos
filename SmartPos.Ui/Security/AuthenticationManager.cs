using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.DomainModel;

namespace SmartPos.Ui.Security
{
    public static class AuthenticationManager
    {
        private static User _user;

        public static User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                AuthorizationHandler.OnAuthorizationChanged(value);
            }
        }

        public static bool IsLoggedIn => User != null;
    }
}
