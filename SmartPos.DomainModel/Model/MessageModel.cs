using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.DomainModel.Model
{
    public class MessageModel
    {
        public string From { get; }

        protected MessageModel(string from)
        {
            From = from;
        }
    }
}
