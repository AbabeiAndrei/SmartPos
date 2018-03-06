using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.DomainModel.Model
{
    public class OrderOpenMessage : MessageModel
    {
        public string TableId { get; set; }

        public TableState State { get; set; }

        public OrderOpenMessage(string from) 
            : base(from)
        {
        }
    }
}
