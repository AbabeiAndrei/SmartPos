﻿using System;
using System.Net;
using System.Runtime.Serialization;

using SmartPos.GeneralLibrary.Exceptions;

namespace SmartPos.Desktop.Communication
{
    public class RequestException : PosException
    {
        public HttpStatusCode StatusCode { get; }

        public RequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public RequestException(HttpStatusCode statusCode, string errorMessage) 
            : base(errorMessage)
        {
            StatusCode = statusCode;
        }

        public RequestException(HttpStatusCode statusCode, string errorMessage, Exception innerException) 
            : base(errorMessage, innerException)
        {
            StatusCode = statusCode;
        }

        protected RequestException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}