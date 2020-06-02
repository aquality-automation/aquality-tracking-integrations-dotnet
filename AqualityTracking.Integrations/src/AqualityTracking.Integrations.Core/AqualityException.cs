using System;
using System.Runtime.Serialization;

namespace AqualityTracking.Integrations.Core
{
    [Serializable]
    public class AqualityException : Exception
    {
        public AqualityException()
        {
        }

        public AqualityException(string message) : base(message)
        {
        }

        public AqualityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AqualityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
