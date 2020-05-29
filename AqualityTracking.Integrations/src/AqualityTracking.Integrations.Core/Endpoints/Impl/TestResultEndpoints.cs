using AqualityTracking.Integrations.Core.Http;
using AqualityTracking.Integrations.Core.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AqualityTracking.Integrations.Core.Endpoints.Impl
{
    public class TestResultEndpoints : AqualityTrackingEndpoints, ITestResultEndpoints
    {
        private const string StartTestResultEndpoint = "/api/public/test/result/start";
        private const string FinishTestResultEndpoint = "/api/public/test/result/finish";
        private const string AddAttachmentEndpoint = "/api/public/test/result/attachment";

        public TestResultEndpoints(Configuration configuration, IHttpClient httpClient) : base(configuration, httpClient)
        {
        }

        public TestResult StartTestResult(int testRunId, int testId)
        {
            var uri = GetUriBuilder(StartTestResultEndpoint)
                .AddParam("project_id", Configuration.ProjectId)
                .AddParam("test_run_id", testRunId)
                .AddParam("test_id", testId)
                .Uri;

            return HttpClient.SendGET<TestResult>(uri);
        }

        public TestResult FinishTestResult(int testResultId, FinalResultId finalResultId, string failReason)
        {
            var testResult = new TestResult
            {
                ProjectId = Configuration.ProjectId,
                Id = testResultId,
                FinalResultId = finalResultId,
                FailReason = failReason
            };
            var uri = GetUriBuilder(FinishTestResultEndpoint).Uri;

            return HttpClient.SendPOST(uri, testResult);
        }

        public void AddAttachment(int testResultId, string filePath)
        {
            var uri = GetUriBuilder(AddAttachmentEndpoint)
                .AddParam("project_id", Configuration.ProjectId)
                .AddParam("test_result_id", testResultId)
                .Uri;

            using (var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath)))
            {
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeConstants.MultipartFormData);
                var content = new MultipartFormDataContent
                {
                    { fileContent, "files", Path.GetFileName(filePath) }
                };
                HttpClient.SendPOST<string>(uri, content);
            }            
        }
    }
}
