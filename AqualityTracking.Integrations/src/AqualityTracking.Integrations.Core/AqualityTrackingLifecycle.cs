using AqualityTracking.Integrations.Core;
using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Endpoints;
using AqualityTracking.Integrations.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AqualityTracking.SpecFlowPlugin
{
    public class AqualityTrackingLifecycle
    {
        private static readonly object lockobj = new object();
        private static AqualityTrackingLifecycle instance;

        private static Suite currentSuite;
        private static TestRun currentTestRun;

        private readonly ThreadLocal<Test> currentTest = new ThreadLocal<Test>();
        private readonly ThreadLocal<TestResult> currentTestResult = new ThreadLocal<TestResult>();
        private readonly ThreadLocal<Action<Test>> updateCurrentTestAction = new ThreadLocal<Action<Test>>();

        private readonly IConfiguration configuration;
        private readonly ISuiteEndpoints suiteEndpoints;
        private readonly ITestRunEndpoints testRunEndpoints;
        private readonly ITestEndpoints testEndpoints;
        private readonly ITestResultEndpoints testResultEndpoints;

        private AqualityTrackingLifecycle()
        {
            var serviceCollection = new ServiceCollection();
            new Startup().ConfigureServices(serviceCollection);
            var provider = serviceCollection.BuildServiceProvider();

            configuration = provider.GetRequiredService<IConfiguration>();
            suiteEndpoints = provider.GetRequiredService<ISuiteEndpoints>();
            testRunEndpoints = provider.GetRequiredService<ITestRunEndpoints>();
            testEndpoints = provider.GetRequiredService<ITestEndpoints>();
            testResultEndpoints = provider.GetRequiredService<ITestResultEndpoints>();
        }

        public static AqualityTrackingLifecycle Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        instance = instance ?? new AqualityTrackingLifecycle();
                    }
                }
                return instance;
            }
        }

        private bool Enabled => configuration.Enabled;

        public void StartTestRun()
        {
            if (Enabled)
            {
                var suite = suiteEndpoints.CreateSuite(configuration.SuiteName);
                var testRun = testRunEndpoints.StartTestRun((int)suite.Id, configuration.BuildName, configuration.Environment,
                    configuration.Executor, configuration.CiBuild, configuration.Debug);
                SetCurrentSuite(suite);
                SetCurrentTestRun(testRun);
            }
        }

        private static void SetCurrentSuite(Suite suite)
        {
            currentSuite = suite;
        }

        private static void SetCurrentTestRun(TestRun testRun)
        {
            currentTestRun = testRun;
        }

        public void StartTestExecution(string testName)
        {
            if (Enabled)
            {
                var desiredTest = new Test { Name = testName };
                updateCurrentTestAction.Value?.Invoke(desiredTest);

                currentTest.Value = testEndpoints.CreateOrUpdateTest(desiredTest.Name, new List<Suite> { currentSuite });
                currentTestResult.Value = testResultEndpoints.StartTestResult((int)currentTestRun.Id, (int)currentTest.Value.Id);
            }
        }

        public void AddAttachment(string filePath)
        {
            if (Enabled)
            {
                testResultEndpoints.AddAttachment((int)currentTestResult.Value.Id, filePath);
            }
        }

        public void FinishTestExecution(FinalResultId finalResultId, string failReason)
        {
            if (Enabled)
            {
                testResultEndpoints.FinishTestResult((int)currentTestResult.Value.Id, finalResultId, failReason);
            }
        }

        public void FinishTestRun()
        {
            if (Enabled)
            {
                testRunEndpoints.FinishTestRun((int)currentTestRun.Id);
            }
        }

        public void UpdateCurrentTest(Action<Test> action)
        {
            updateCurrentTestAction.Value = action;
        }
    }
}
