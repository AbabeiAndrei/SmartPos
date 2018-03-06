using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary;

namespace SmartPos.Ui.Security
{
    public static class AuthenticationManager
    {
        private static User _user;

        public static User User
        {
            get => _user;
            set
            {
                _user = value;
                AuthorizationHandler.OnAuthorizationChanged(value);
            }
        }

        public static IIdentity Identity => User;

        public static bool IsLoggedIn => User != null;

        public static void Logout()
        {
            User = null;
        }
    }
}
