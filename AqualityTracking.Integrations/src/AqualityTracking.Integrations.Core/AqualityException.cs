using System;

namespace AqualityTracking.Integrations.Core
{
    [Serializable]
    public class AqualityException : Exception
    {
        public AqualityException(string message) : base(message)
        {
        }
    }
}
