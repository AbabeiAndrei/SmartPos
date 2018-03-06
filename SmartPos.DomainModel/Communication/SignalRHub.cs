// ReSharper disable InconsistentNaming
namespace SmartPos.DomainModel.Communication
{
    public class SignalRHub
    {
        public const string Name = "PosTransferHub";

        public static class Events
        {
            public static class Account
            {
                public const string RegisterClient = nameof(RegisterClient);

                public const string RemoveClient = nameof(RemoveClient);
            }

            public static class Order
            {
                public const string RegisterTable = nameof(RegisterTable);
            }
        }
    }
}
