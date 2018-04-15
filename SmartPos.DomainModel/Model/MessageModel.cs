using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.DomainModel.Model
{
    public abstract class MessageModel
    {
        public abstract string Method { get; }

        public string From { get; }

        protected MessageModel(string from)
        {
            From = from;
        }
    }
}
