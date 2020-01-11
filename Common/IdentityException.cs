using System;
using System.Runtime.Serialization;

namespace Hermes.Identity.Common
{
    public class IdentityException : Exception
    {
        public IdentityException()
        {
        }

        public IdentityException(string message) : base(message)
        {
        }

        public IdentityException(string message, string description) : base(message)
        {
        }

        public IdentityException(string message, string description, Exception innerException) : base(message, innerException)
        {
        }

        protected IdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}