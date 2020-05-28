using AqualityTracking.Integrations.Core.Models;
using System.Collections.Generic;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestEndpoints : AqualityTrackingEndpoints, ITestEndpoints
    {
        private const string CreateOrUpdateTestEndpoint = "/api/public/test/create-or-update";

        public TestEndpoints(Configuration configuration, IHttpClient httpClient) : base(configuration, httpClient)
        {
        }

        public Test CreateOrUpdateTest(string name, IList<Suite> suites)
        {
            var test = new Test
            {
                ProjectId = Configuration.ProjectId,
                Name = name,
                Suites = suites
            };
            var uri = GetUriBuilder(CreateOrUpdateTestEndpoint).Uri;

            return HttpClient.SendPOST(uri, test);
        }
    }
}
