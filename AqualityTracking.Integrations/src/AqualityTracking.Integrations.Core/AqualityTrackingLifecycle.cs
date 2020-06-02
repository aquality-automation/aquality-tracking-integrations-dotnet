using AqualityTracking.Integrations.Core.Configuration;
using AqualityTracking.Integrations.Core.Endpoints;
using AqualityTracking.Integrations.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AqualityTracking.Integrations.Core
{
    public class AqualityTrackingLifecycle
    {
        private static readonly object lockobj = new object();
        private static AqualityTrackingLifecycle instance;

        private static Suite currentSuite;
        private static TestRun currentTestRun;

        private readonly ThreadLocal<Test> currentTest = new ThreadLocal<Test>();
        private readonly ThreadLocal<TestResult> currentTestResult = new ThreadLocal<TestResult>();

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
                currentSuite = suite;
                currentTestRun = testRun;
            }            
        }

        public void StartTestExecution(string testName = null)
        {
            if (Enabled)
            {
                var currentTestName = testName ?? currentTest.Value.Name;
                var test = testEndpoints.CreateOrUpdateTest(currentTestName, new List<Suite> { currentSuite });
                currentTest.Value = test;
                var testResult = testResultEndpoints.StartTestResult((int)currentTestRun.Id, (int)test.Id);
                currentTestResult.Value = testResult;
            }            
        }

        public void AddAttachment(string filePath)
        {
            if (Enabled)
            {
                testResultEndpoints.AddAttachment((int)currentTestResult.Value.Id, filePath);
            }            
        }

        public void FinishTestExecution(FinalResultId finalResultId, string failReson)
        {
            if (Enabled)
            {
                testResultEndpoints.FinishTestResult((int)currentTestResult.Value.Id, finalResultId, failReson);
            }            
        }

        public void FinishTestRun()
        {
            if (Enabled)
            {
                testRunEndpoints.FinishTestRun((int)currentTestRun.Id);
            }            
        }

        public void SetCurrentTest(Test test)
        {
            currentTest.Value = test;
        }

        public void UpdateCurrentTest(Action<Test> action)
        {
            if (!currentTest.IsValueCreated)
            {
                currentTest.Value = new Test();
            }
            action.Invoke(currentTest.Value);
        }
    }
}
