using AqualityTracking.Integrations.Core;
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

        [BeforeScenario(Order = 0)]
        public void StartTestExecution()
        {
            var testName = $"{featureContext.FeatureInfo.Title}: {scenarioContext.ScenarioInfo.Title}";
            lifecycle.StartTestExecution(testName);
        }

        [AfterScenario(Order = int.MaxValue)]
        public void FinishTestExecution()
        {
            var testCaseResult = new TestCaseResultParser(scenarioContext.ScenarioExecutionStatus, scenarioContext.TestError).Parse();
            lifecycle.FinishTestExecution(testCaseResult.FinalResultId, testCaseResult.FailReason);
        }
    }
}
