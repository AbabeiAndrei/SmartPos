using SmartPos.DomainModel.Communication;
using SmartPos.DomainModel.Entities;

namespace SmartPos.DomainModel.Model
{
    public class OrderCreatedMessage : MessageModel
    {
        #region Properties

        public Order Order { get; set; }

        #endregion

        #region Overrides of MessageModel

        /// <inheritdoc />
        public override string Method => SignalRHub.Events.Order.Created;

        #endregion

        #region Constructors

        public OrderCreatedMessage(string from)
                : base(from)
        {
        }

        #endregion

    }
}
