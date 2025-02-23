using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace NatwestCushon_Automation_Test.Support
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browser = "chrome", bool headless = false)
        {
            IWebDriver driver;
            Console.WriteLine($"Starting tests with {browser} browser. Headless: {headless}");

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    // Only run headless if specified
                    if (headless) chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--start-maximized");
                    // Helps avoid issues in some environments
                    chromeOptions.AddArgument("--disable-gpu");
                    // Avoid pop-ups
                    chromeOptions.AddArgument("--disable-notifications"); 

                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless) firefoxOptions.AddArgument("--headless");

                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (headless) edgeOptions.AddArgument("--headless");

                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}