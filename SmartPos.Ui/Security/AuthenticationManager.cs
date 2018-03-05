using SmartPos.DomainModel.Entities;

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

        public static bool IsLoggedIn => User != null;

        public static void Logout()
        {
            User = null;
        }
    }
}
