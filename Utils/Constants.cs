using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitDefenderChallenge.Utils
{
    public static class Constants
    {
        public static string TestReportPath()
        {
            var filePath = Environment.CurrentDirectory + @"\Test Reports\";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return filePath;
        }

        public static string TestReportFileName()
        {
            return  DateTime.Now.ToString("yyyy-MM-dd")+".txt";
        }

        public static void TestReportHeader(string testName)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine("Test - " + testName);
            }
        }

        public static void TestReportFooter(Stopwatch sw)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine("Test Run at " + DateTime.Now.ToString());
                file.WriteLine("Test PASSED");
                file.WriteLine("Test took: " + sw.Elapsed);
            }
        }

        public static void TestReportFooterFailed(Stopwatch sw, string message)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine("\n");
                file.WriteLine("Test Run at " + DateTime.Now.ToString());
                file.WriteLine("Test FAILED !!!");
                file.WriteLine(message);
                file.WriteLine("************************************************");
            }
        }

        public static void TestReportFooterTimeout(Stopwatch sw)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine("Test Run at " + DateTime.Now.ToString());
                file.WriteLine("Test TIMED OUT !!!");
            }
        }

        public static void TestReportFooterError(Stopwatch sw)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine("Test Run at " + DateTime.Now.ToString());
                file.WriteLine("Test ERROR !!!");
            }
        }

        public static void WriteTestStepToReport(string text)
        {
            using (var file = new StreamWriter(TestReportPath() + TestReportFileName(), true))
            {
                file.WriteLine(text);
            }
        }
    }
}
