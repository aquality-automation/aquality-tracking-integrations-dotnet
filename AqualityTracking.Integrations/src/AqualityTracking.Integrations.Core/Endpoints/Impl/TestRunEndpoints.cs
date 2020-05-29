using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Models;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestRunEndpoints : AqualityTrackingEndpoints, ITestRunEndpoints
    {
        private const string StartTestRunEndpoint = "/api/public/testrun/start";
        private const string FinishTestRunEndpoint = "/api/public/testrun/finish";

        public TestRunEndpoints(Configuration configuration, IHttpClient httpClient) : base(configuration, httpClient)
        {
        }

        public TestRun StartTestRun(int testSuiteId, string buildName, string environment, string executor, string ciBuild, bool debug)
        {
            var testRun = new TestRun
            {
                ProjectId = Configuration.ProjectId,
                TestSuiteId = testSuiteId,
                BuildName = buildName,
                ExecutionEnvironment = environment,
                Author = executor,
                CiBuild = ciBuild,
                Debug = debug ? 1 : 0
            };
            var uri = GetUriBuilder(StartTestRunEndpoint).Uri;

            return HttpClient.SendPOST(uri, testRun);
        }

        public TestRun FinishTestRun(int testRunId)
        {
            var uri = GetUriBuilder(FinishTestRunEndpoint)
                .AddParam("project_id", Configuration.ProjectId)
                .AddParam("id", testRunId)
                .Uri;
            
            return HttpClient.SendGET<TestRun>(uri);
        }
    }
}
