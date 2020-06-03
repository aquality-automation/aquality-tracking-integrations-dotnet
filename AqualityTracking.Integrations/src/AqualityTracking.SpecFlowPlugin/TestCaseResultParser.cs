using AqualityTracking.Integrations.Core;
using System;
using TechTalk.SpecFlow;

namespace AqualityTracking.SpecFlowPlugin
{
    internal class TestCaseResultParser
    {
        private readonly ScenarioExecutionStatus executionStatus;
        private readonly Exception testError;

        internal TestCaseResultParser(ScenarioExecutionStatus executionStatus, Exception testError)
        {
            this.executionStatus = executionStatus;
            this.testError = testError;
        }

        internal TestCaseResult Parse()
        {
            var testCaseResult = new TestCaseResult();

            switch (executionStatus)
            {
                case ScenarioExecutionStatus.OK:
                    testCaseResult.FinalResultId = FinalResultId.Passed;
                    break;
                case ScenarioExecutionStatus.TestError:
                    testCaseResult.FinalResultId = FinalResultId.Failed;
                    testCaseResult.FailReason = $"Message:{Environment.NewLine}{testError.Message}{Environment.NewLine}{Environment.NewLine}" +
                        $"Stack Trace:{Environment.NewLine}{testError.StackTrace}";
                    break;
                case ScenarioExecutionStatus.BindingError:
                case ScenarioExecutionStatus.StepDefinitionPending:
                    testCaseResult.FinalResultId = FinalResultId.Failed;
                    testCaseResult.FailReason = testError?.Message;
                    break;
                case ScenarioExecutionStatus.UndefinedStep:
                    testCaseResult.FinalResultId = FinalResultId.Failed;
                    testCaseResult.FailReason = "No matching step definition found for one or more steps.";
                    break;
                case ScenarioExecutionStatus.Skipped:
                    testCaseResult.FinalResultId = FinalResultId.Pending;
                    testCaseResult.FailReason = "Test skipped.";
                    break;
                default:
                    testCaseResult.FinalResultId = FinalResultId.NotExecuted;
                    break;
            }

            return testCaseResult;
        }
    }

    internal class TestCaseResult
    {
        internal FinalResultId FinalResultId { get; set; }
        internal string FailReason { get; set; }
    }
}
