using AqualityTracking.Integrations.Core;
using AqualityTracking.Integrations.Core.Models;
using TechTalk.SpecFlow;

namespace AqualityTracking.SpecFlowPlugin
{
    [Binding]
    public class AqualityTrackingBindings
    {
        private static readonly AqualityTrackingLifecycle lifecycle = AqualityTrackingLifecycle.Instance;

        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        public AqualityTrackingBindings(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void StartTestRun()
        {
            lifecycle.StartTestRun();
        }

        [AfterTestRun]
        public static void FinishTestRun()
        {
            lifecycle.FinishTestRun();
        }

        [BeforeScenario(Order = int.MinValue)]
        public void SetCurrentTestData()
        {
            var currentTestCase = new Test
            {
                Name = $"{featureContext.FeatureInfo.Title}: {scenarioContext.ScenarioInfo.Title}"
            };
            lifecycle.SetCurrentTest(currentTestCase);
        }

        [BeforeScenario(Order = 0)]
        public void StartTestExecution()
        {
            lifecycle.StartTestExecution();
        }

        [AfterScenario(Order = int.MaxValue)]
        public void FinishTestExecution()
        {
            var testCaseResult = new TestCaseResultParser(scenarioContext.ScenarioExecutionStatus, scenarioContext.TestError).Parse();
            lifecycle.FinishTestExecution(testCaseResult.FinalResultId, testCaseResult.FailReason);
        }
    }
}
