using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string OcupiedByUser { get; set; }

        public TableOcupation State { get; set; }
    }
}
