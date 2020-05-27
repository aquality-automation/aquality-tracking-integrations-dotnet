using AqualityTracking.Integrations.Core.Models;
using System;
using System.Collections.Generic;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestEndpoints : ITestEndpoints
    {
        private const string CreateOrUpdateTestEndpoint = "/api/public/test/create-or-update";

        public Test CreateOrUpdateTest(string name, IList<Suite> suites)
        {
            throw new NotImplementedException();
        }
    }
}
