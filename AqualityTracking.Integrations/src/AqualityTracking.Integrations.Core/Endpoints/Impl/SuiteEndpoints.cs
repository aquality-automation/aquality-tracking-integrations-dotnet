using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Models;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class SuiteEndpoints : AqualityTrackingEndpoints, ISuiteEndpoints
    {
        private const string CreateOrUpdateEndpoint = "/api/public/suite/create-or-update";

        public SuiteEndpoints(IConfiguration configuration, IHttpClient httpClient) : base(configuration, httpClient)
        {
        }

        public Suite CreateSuite(string name)
        {           
            var suite = new Suite
            {
                Name = name,
                ProjectId = Configuration.ProjectId
            };
            var uri = GetUriBuilder(CreateOrUpdateEndpoint).Uri;

            return HttpClient.SendPOST(uri, suite);
        }
    }
}
