using AqualityTracking.Integrations.Core.Models;
using System;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestRunEndpoints : ITestRunEndpoints
    {
        private const string StartTestRunEndpoint = "/api/public/testrun/start";
        private const string FinishTestRunEndpoint = "/api/public/testrun/finish";

        public TestRun FinishTestRun(int testRunId)
        {
            throw new NotImplementedException();
        }

        public TestRun StartTestRun(int testSuiteId, string buildName, string environment, string executor, string ciBuild, bool debug)
        {
            throw new NotImplementedException();
        }
    }
}
