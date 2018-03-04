using System;
using System.Runtime.Serialization;

using SmartPos.GeneralLibrary.Exceptions;

namespace SmartPos.Ui.Security
{
    public class NotAuthorizedException : PosException
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
