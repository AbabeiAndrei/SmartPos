using SmartPos.DomainModel.Communication;

namespace SmartPos.DomainModel.Model
{
    public class OrderOpenMessage : MessageModel
    {
        #region Properties

        public int TableId { get; set; }

        public TableState State { get; set; }

        #endregion

        #region Overrides of MessageModel

        /// <inheritdoc />
        public override string Method => SignalRHub.Events.Order.RegisterTable;

        #endregion

        #region Constructors

        public OrderOpenMessage(string from) 
                : base(from)
        {
        }

        #endregion
    }
}
