using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework;

namespace BitDefenderChallenge.Utils
{
    [TestClass]
    public class BaseTestClass
    {
        private static int _executedTests;
        private static int _passedTests;
        private Stopwatch sw;
        private static TimeSpan totalTestsTime;
        protected static string assertMessage;

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            Constants.WriteTestStepToReport("************************************************");
            Constants.WriteTestStepToReport("* Test results *");
            Constants.WriteTestStepToReport("Time when run: " + DateTime.Now.ToString());
            Constants.WriteTestStepToReport("Total tests executed: " + _executedTests);
            Constants.WriteTestStepToReport("Total tests passed: " + _passedTests);
            Constants.WriteTestStepToReport("Total time taken for tests: " + totalTestsTime);
            if (_executedTests == _passedTests)
            {
                Constants.WriteTestStepToReport("All tests PASSED");
            }
            Constants.WriteTestStepToReport("************************************************");
        }
        public static Stopwatch StartTimer()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            return stopwatch;
        }
        protected void IncrementTests()
        {
           sw = StartTimer();
            _executedTests++;
        }

        protected void Cleanup(TestContext testContext, SeleniumFramework.SeleniumDriver driver)
        {
            if (testContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                IncrementPassedTests();
            }
            else if (testContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                FailedTests();
            }
            else if (testContext.CurrentTestOutcome == UnitTestOutcome.Timeout)
            {
                TimeoutTests();
            }
            else if (testContext.CurrentTestOutcome == UnitTestOutcome.Error)
            {
                ErrorTests();
            }
            IncreaseTotalElapsedTime();
            driver.Instance.Dispose();
        }

        protected void IncrementPassedTests()
        {
            _passedTests++;
        }

        protected void IncreaseTotalElapsedTime()
        {
            sw.Stop();
            totalTestsTime += sw.Elapsed;
        }

        protected void FailedTests()
        {
            Constants.TestReportFooterFailed(sw, assertMessage);
        }

        protected void TimeoutTests()
        {
            Constants.TestReportFooterTimeout(sw);
        }

        protected void ErrorTests()
        {
            Constants.TestReportFooterError(sw);
        }
    }
}