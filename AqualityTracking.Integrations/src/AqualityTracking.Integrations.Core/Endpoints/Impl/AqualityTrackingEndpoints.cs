using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Utilities;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public abstract class AqualityTrackingEndpoints
    {
        public AqualityTrackingEndpoints(IConfiguration configuration, IHttpClient httpClient)
        {
            Configuration = configuration;
            HttpClient = httpClient;
        }

        protected IConfiguration Configuration { get; }

        protected IHttpClient HttpClient { get; }        

        protected UriBuilder GetUriBuilder(string path)
        {
            return new UriBuilder(Configuration.Host).SetPath(path);
        }
    }
}
