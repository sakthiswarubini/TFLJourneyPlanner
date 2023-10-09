using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLJourneyPlanner.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        //public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        //public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
       
        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\sakth\OneDrive\Desktop\ExtentReportResults\Report.html");
            htmlReporter.Config.ReportName = "TFL Journey Planner";
            htmlReporter.Config.DocumentTitle = "TFL Journey planner Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

    }
}
