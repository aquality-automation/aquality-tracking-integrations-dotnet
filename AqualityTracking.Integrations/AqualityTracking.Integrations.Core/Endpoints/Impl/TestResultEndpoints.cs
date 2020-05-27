using AqualityTracking.Integrations.Core.Models;
using System;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestResultEndpoints : ITestResultEndpoints
    {
        private const string StartTestResultEndpoint = "/api/public/test/result/start";
        private const string FinishTestResultEndpoint = "/api/public/test/result/finish";
        private const string AddAttachmentEndpoint = "/api/public/test/result/attachment";

        public void AddAttachment(int testResultId, string file)
        {
            throw new NotImplementedException();
        }

        public TestResult FinishTestResult(int testResultId, FinalResultId finalResultId, string failReason)
        {
            throw new NotImplementedException();
        }

        public TestResult StartTestResult(int testRunId, int testId)
        {
            throw new NotImplementedException();
        }
    }
}
