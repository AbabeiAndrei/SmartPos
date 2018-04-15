using System;
using System.Runtime.Serialization;

namespace SmartPos.DomainModel.Business.Exceptions
{
    public class EntityIsNewException : Exception
    {
        public EntityIsNewException()
        {
        }

        public EntityIsNewException(string message) : base(message)
        {
        }

        public EntityIsNewException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityIsNewException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
