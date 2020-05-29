using System;

namespace AqualityTracking.Integrations.Core
{
    public class AqualityException : Exception
    {
        public AqualityException(string message) : base(message)
        {
        }
    }
}
