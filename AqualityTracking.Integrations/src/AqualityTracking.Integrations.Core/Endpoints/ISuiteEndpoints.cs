using AqualityTracking.Integrations.Core.Models;

namespace AqualityTracking.Integrations.Core.Endpoints
{
    public interface ISuiteEndpoints
    {
        /// <summary>
        /// Creates new suite or gets the existing one.
        /// </summary>
        /// <param name="name">Name of suite.</param>
        /// <returns>Instance of created or found Suite.</returns>
        Suite CreateSuite(string name);
    }
}
