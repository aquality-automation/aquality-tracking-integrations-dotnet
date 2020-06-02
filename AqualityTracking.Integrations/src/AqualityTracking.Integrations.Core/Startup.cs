using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Endpoints;
using AqualityTracking.Integrations.Core.Endpoints.Impl;
using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace AqualityTracking.Integrations.Core
{
    internal class Startup
    {
        internal void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(getConfiguration());
            serviceCollection.AddScoped<IHttpClient, AqualityHttpClient>();
            serviceCollection.AddTransient<ISuiteEndpoints, SuiteEndpoints>();
            serviceCollection.AddTransient<ITestRunEndpoints, TestRunEndpoints>();
            serviceCollection.AddTransient<ITestEndpoints, TestEndpoints>();
            serviceCollection.AddTransient<ITestResultEndpoints, TestResultEndpoints>();
        }

        private IConfiguration getConfiguration()
        {
            var jsonSettings = FileReader.ReadFromResources(AqualityConstants.SettingsFileName);
            return JObject.Parse(jsonSettings)?.ToObject<AqualityConfiguration>();
        }
    }
}
