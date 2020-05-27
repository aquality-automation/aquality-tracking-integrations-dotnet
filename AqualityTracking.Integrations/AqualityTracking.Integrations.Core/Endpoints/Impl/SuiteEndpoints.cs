using AqualityTracking.Integrations.Core.Models;
using System;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class SuiteEndpoints : ISuiteEndpoints
    {
        private const string CreateOrUpdateEndpoint = "/api/public/suite/create-or-update";

        public Suite CreateSuite(string name)
        {
            throw new NotImplementedException();
        }
    }
}
