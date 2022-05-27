using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumHW.PageObjectModel;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using System.Reflection;


namespace SeleniumHW.Hooks
{
    [Binding]
    public class Hook
    {
        private static IWebDriver _driver;
        private static WebDriverWait _wait;
        private static ExtentReports _extent;
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static  ScenarioContext _scenarioContext;
        

        static ChromeOptions options = new ChromeOptions();

        public IWebDriver GetDriver()
        { 
            return _driver; 
        }
        public WebDriverWait GetWait() 
        { 
            return _wait; 
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Daniel\Desktop\QA Internship\ExtentReport.html");
           
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }


        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _featureName = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

       /* public static MediaEntityModelProvider CaptureScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }*/

        [AfterStep]
        public static void InsertReportSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
               //var mediaEntity = CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
            else if (ScenarioStepContext.Current.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }

        [BeforeScenario]
        public static void DriverSetUp()
        {
            options.AddArguments("--start-maximized");
            options.AddArguments("--incognito");
            options.AddArguments("--safebrowsing-enable-enhanced-protection");
            options.AddArguments("--ignore-certificate-errors");
            _driver = new ChromeDriver(options);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _scenario = _featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public static void TestStop()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();
            }
            else
            {
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();
            }
        }

    }
}
