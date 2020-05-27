using AqualityTracking.Integrations.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AqualityTracking.Integrations.Core.Endpoints
{
    public interface ITestResultEndpoints
    {
        /// <summary>
        /// Starts new Test execution.
        /// </summary>
        /// <param name="testRunId">Id of current Test Run.</param>
        /// <param name="testId">Id of Test to execute.</param>
        /// <returns>Instance of started Test execution (Test Result).</returns>
        TestResult StartTestResult(int testRunId, int testId);

        /// <summary>
        /// Sets Test Result.
        /// </summary>
        /// <param name="testResultId">Id of Test Result to finish.</param>
        /// <param name="finalResultId">Id of the result.</param>
        /// <param name="failReason">Reason of test failure. If not needed - pass null.</param>
        /// <returns>Instance of finished Test Result.</returns>
        TestResult FinishTestResult(int testResultId, FinalResultId finalResultId, string failReason);

        /// <summary>
        /// Add attachment to Test Result.
        /// </summary>
        /// <param name="testResultId">Id of Test Result.</param>
        /// <param name="file">Attachment file.</param>
        void AddAttachment(int testResultId, string file); // TODO: change second parameter
    }
}
