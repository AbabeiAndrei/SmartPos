using SmartPos.Ui.Security;
using SmartPos.Ui.Components;
using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication;

namespace SmartPos.Desktop
{
    public static partial class Application
    {
        public static string ProductName => "SmartPos";

        public static User User => AuthenticationManager.User;

        public static bool UserIsLoggedIn => User != null;

        public static ApiClient Api() => _apiClient ?? (_apiClient = new ApiClient());

        public static ApiClient Api(ILoadingToken token) => new ApiClient(token);
    }
}
