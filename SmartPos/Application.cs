using System;
using System.Globalization;
using System.Threading.Tasks;

using SmartPos.Ui;
using SmartPos.Ui.Security;
using SmartPos.Ui.Components;
using SmartPos.Desktop.Utils;
using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication;

namespace SmartPos.Desktop
{
    public static partial class Application
    {
        #region Properties

        public static string ProductName => "SmartPos";

        public static User User => AuthenticationManager.User;

        public static bool UserIsLoggedIn => User != null;

        public static ApiClient Api() => _apiClient ?? (_apiClient = new ApiClient());

        public static ApiClient Api(ILoadingToken token) => new ApiClient(token);

        public static IFormatProvider UiFormat => _uiFormatProvider ?? (_uiFormatProvider = new CultureInfo("ro-RO"));

        public static SignalRClient SignalRClient { get; set; }

        #endregion

        #region Constructors

        static Application()
        {
            SignalRClient = new SignalRClient();
        }

        #endregion

        #region Public methods

        public static void InitializeUi()
        {
            UiConfigure.GraphicsSettingResolver = GfxHelper.ApplyDisplaySettings;
        }

        public static async Task InitializeCommunication()
        {
            await SignalRClient.Start();
        }

        #endregion
    }
}
