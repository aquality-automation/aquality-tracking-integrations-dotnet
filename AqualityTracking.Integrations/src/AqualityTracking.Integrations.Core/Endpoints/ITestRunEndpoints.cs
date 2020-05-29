using AqualityTracking.Integrations.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqualityTracking.Integrations.Core.Endpoints
{
    public interface ITestRunEndpoints
    {
        /// <summary>
        /// Starts new Test Run.
        /// </summary>
        /// <param name="testSuiteId">Id of Test Suite which included in Test Run.</param>
        /// <param name="buildName">Name of current build.</param>
        /// <param name="environment">Name of execution environment.</param>
        /// <param name="executor">Name of author.</param>
        /// <param name="ciBuild">Link to the CI build of current Test Run.</param>
        /// <param name="debug">Debug (true) or regular (false) execution. If debug Test Run won't be present in Aquality Tracking.</param>
        /// <returns>Instance of started Test Run.</returns>
        TestRun StartTestRun(int testSuiteId, string buildName, string environment,
            string executor, string ciBuild, bool debug);

        /// <summary>
        /// Finished Test Run.
        /// </summary>
        /// <param name="testRunId">Id of Test Run which should be finished.</param>
        /// <returns>Instance of finished Test Run.</returns>
        TestRun FinishTestRun(int testRunId);
    }
}
