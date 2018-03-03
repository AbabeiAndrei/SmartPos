using System;
using System.Runtime.Serialization;

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
