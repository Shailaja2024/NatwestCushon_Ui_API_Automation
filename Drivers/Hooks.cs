using NatwestCushon_Automation_Test.RunSettings;

namespace NatwestCushon_Automation_Test.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private readonly ConfigManager _configManager;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private static ExtentHtmlReporter _htmlReporter;
        private DateTime _stepStartTime;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _configManager = new ConfigManager();
        }

        // Initialize the Extent Report once for the entire test run
        [BeforeTestRun]
        public static void InitializeReport()
        {
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\TestResults\\ExtentReport.html");
            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _htmlReporter.Config.DocumentTitle = "Automation Test Report";
            _htmlReporter.Config.ReportName = "Test Report";          
            _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
            _extent.AddSystemInfo("Application", "Natwest Cushon");
            _extent.AddSystemInfo("Browser", "Chrome");
            _extent.AddSystemInfo("OS", "Windows");
        }

        // Start a new test for each scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("api"))
            {
                _driver = WebDriverFactory.CreateDriver();
                _driver.Manage().Window.Maximize();
                _scenarioContext["currentDriver"] = _driver;
            }           

            // Start a new test with a unique name
            var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
            _test = _extent.CreateTest(scenarioTitle);
            _test.Log(Status.Info, $"Starting test: {scenarioTitle}");
        }
        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = _scenarioContext.StepContext.StepInfo.Text;
            var stepDuration = DateTime.Now - _stepStartTime; // Calculate step duration

            // Log Pass or Fail for each step with execution time
            if (_scenarioContext.TestError == null)
            {
                _test.Log(Status.Pass, $"{stepType} {stepText} - <i>Duration: {stepDuration.TotalSeconds} seconds</i>");
            }
            else
            {
                string screenshotPath = CaptureScreenshot(stepText);
                _test.Log(Status.Fail, $"{stepType} {stepText} - <i>Duration: {stepDuration.TotalSeconds} seconds</i>");
                _test.Fail(_scenarioContext.TestError.Message).AddScreenCaptureFromPath(screenshotPath);
            }
        }
        // Log the result after each scenario
        [AfterScenario]
        public void AfterScenario()
        {
            var scenarioTitle = _scenarioContext.ScenarioInfo.Title;
            var scenarioStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (scenarioStatus == TestStatus.Passed)
            {
                _test.Pass("Test Passed");
            }
            else if (scenarioStatus == TestStatus.Failed)
            {
                if (_scenarioContext.ScenarioInfo.Tags.Contains("api") == false && _driver != null)
                {
                    string screenshotPath = CaptureScreenshot(scenarioTitle);
                    _test.Fail("Test Failed").AddScreenCaptureFromPath(screenshotPath);
                }                
                _test.Log(Status.Fail, TestContext.CurrentContext.Result.Message);
            }
            else
            {
                _test.Skip("Test Skipped");
            }

            if (_scenarioContext.ScenarioInfo.Tags.Contains("api") == false && _driver != null)
            {
                _driver.Quit();
            }
        }

        // Capture screenshot with scenario name
        private string CaptureScreenshot(string scenarioTitle)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\TestResults\\Screenshots");
                Directory.CreateDirectory(screenshotDirectory);

                string screenshotPath = Path.Combine(screenshotDirectory, $"{scenarioTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);

                return screenshotPath;
            }
            catch (Exception ex)
            {
                _test.Warning("Error capturing screenshot: " + ex.Message);
                return string.Empty;
            }
        }

        // Flush the report once after all tests are executed
        [AfterTestRun]
        public static void TearDownReport()
        {
            if (_extent != null)
            {
                _extent.Flush();
            }
        }

        public IWebDriver Driver => _driver;
    }
}
