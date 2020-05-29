using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Endpoints;
using AqualityTracking.Integrations.Core.Endpoints.Impl;
using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace AqualityTracking.Integrations.Core
{
    public class Startup
    {
        public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(getConfiguration());
            serviceCollection.AddScoped<IHttpClient, AqualityHttpClient>();
            serviceCollection.AddTransient<ISuiteEndpoints, SuiteEndpoints>();
            serviceCollection.AddTransient<ITestRunEndpoints, TestRunEndpoints>();
            serviceCollection.AddTransient<ITestEndpoints, TestEndpoints>();
            serviceCollection.AddTransient<ITestResultEndpoints, TestResultEndpoints>();
            return serviceCollection;
        }

        private IConfiguration getConfiguration()
        {
            var jsonSettings = FileReader.ReadFromResources(AqualityConstants.SettingsFileName);
            return AqualityConfiguration.ParseFromJson(jsonSettings);
        }
    }
}
