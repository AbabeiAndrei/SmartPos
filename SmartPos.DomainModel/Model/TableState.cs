namespace SmartPos.DomainModel.Model
{
    public enum TableOcupation : short
    {
        Free = 0,
        Opened = 1,
        Ocupied = 2,
        Locked = 3
    }

    public class TableState
    {
        #region Properties

        public int OcupiedByUserId { get; set; }

        public string OcupiedByUser { get; set; }

        public TableOcupation State { get; set; }

        public static TableState Free => new TableState(TableOcupation.Free);

        #endregion

        #region Constructors

        public TableState()
        {
        }

        public TableState(TableOcupation state)
        {
            State = state;
        }

        #endregion
    }
}
