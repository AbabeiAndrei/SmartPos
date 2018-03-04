using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.GeneralLibrary.Exceptions
{
    [Serializable]
    public class PosException : Exception
    {
        public Guid Code { get; }

        public PosException()
        {
            Code = Guid.NewGuid();
        }

        public PosException(string message) : base(message)
        {
            Code = Guid.NewGuid();
        }

        public PosException(string message, Exception innerException) : base(message, innerException)
        {
            Code = Guid.NewGuid();
        }

        protected PosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = Guid.NewGuid();
        }
    }
}
