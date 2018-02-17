using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Ui.Security
{
    public class NotAuthorizedException : Exception
    {
        public Type RequestedType { get; protected set; }

        public NotAuthorizedException(Type type)
        {
            RequestedType = type;
        }

        public NotAuthorizedException(Type type, string message) : base(message)
        {
            RequestedType = type;
        }

        public NotAuthorizedException(Type type, string message, Exception innerException) : base(message, innerException)
        {
            RequestedType = type;
        }

        protected NotAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
