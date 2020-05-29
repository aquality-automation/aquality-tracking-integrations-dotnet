using AqualityTracking.Integrations.Core.Models;
using System.Collections.Generic;

namespace AqualityTracking.Integrations.Core.Endpoints
{
    public interface ITestEndpoints
    {
        /// <summary>
        /// Creates new Test or updates and gets the existing one.
        /// Does not override the existing suites, adds a missing ones.
        /// </summary>
        /// <param name="name">Name of Test.</param>
        /// <param name="suites">List of Suites that Test belongs to.</param>
        /// <returns>Instance of new or updated Test.</returns>
        Test CreateOrUpdateTest(string name, IList<Suite> suites);
    }
}
