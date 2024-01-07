using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium.DevTools.V117.Page;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
using WinjitAssessment.com.winjitAssessment.Utilities;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace winjitAssessment.Utilities

{
    public class BaseClass
    {
        public IWebDriver driver;
        public static WebDriverWait wait;
        ExtentReports extent;
        ExtentTest test;
            

        [OneTimeSetUp]
        public void setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath=projectDirectory+ "//index.html";               
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent=new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("UserName","Ajay Dudhmal");        

        }

        [SetUp]
        public void startBrowser()
        {

            test=extent.CreateTest(TestContext.CurrentContext.Test.Name);
            String browserName =
                ConfigurationManager.AppSettings["browser"];          
           

            StartBrowse();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        
        public void StartBrowse()
        {
            driver = new ChromeDriver();           
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/");
            }        

               

        public static TestData_Config JsonObj()
        {
            return new TestData_Config();
        }


        [TearDown]
        public void AfterTest() {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            if (status == TestStatus.Failed)
            {
                CaptureScreenshot();
                test.Log(Status.Fail,"Testcase failed"+ stackTrace);
            }
            else if (status == TestStatus.Passed)
            { 
            
            }
            driver.Close();
            extent.Flush();
        }

        public static String getJsonData(String getdata)
        {
            return BaseClass.JsonObj().extractJsonData(getdata);                   

        }


        public void CaptureScreenshot()
        {            
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"../../../ScreenShots\Image.png", format: ScreenshotImageFormat.Png);           

        }
    }
}
