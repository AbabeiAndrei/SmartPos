using System;
using System.Runtime.Serialization;

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
