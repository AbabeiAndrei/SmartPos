using System;
using System.Runtime.Serialization;

namespace SmartPos.DomainModel.Business.Exceptions
{
    public class EntityNotNewException : Exception
    {
        public EntityNotNewException()
        {
        }

        public EntityNotNewException(string message) : base(message)
        {
        }

        public EntityNotNewException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotNewException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
