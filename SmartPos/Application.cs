using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.Ui.Security;

namespace SmartPos.Desktop
{
    public static class Application
    {
        public static string ProductName => "SmartPos";

        public static User User => AuthenticationManager.User;

        public static bool UserIsLoggedIn => User != null;


    }
}
