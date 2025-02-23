using NatwestCushon_Automation_Test.RunSettings;
using NatwestCushon_Automation_Test.PageObjects;

namespace NatwestCushon_Automation_Test.StepDefinitions
{
    [Binding]
    class LoginSteps
    {
        private readonly IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly ConfigManager configManager;
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("currentDriver");
            configManager = new ConfigManager();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);

        }

        [When(@"the user enters the username '(.*)'")]
        public void WhenTheUserEntersTheUsernameAndPassword(string username)
         {
            if (username.Equals("Valid UserName"))
            {
                loginPage.EnterUsername(configManager.GetUsername());
            }
            else if (username.Equals("Invalid UserName"))
            {
                loginPage.EnterUsername(configManager.GetInvalidUsername());
            }
            else if (username.Equals("Empty"))
            {
                loginPage.EnterUsername("");
            }
            else
            {
                Assert.Fail();
            }
        }
        [When("the user enters the password '(.*)'")]
        public void WhenTheUserEntersThePasswordValidPassword(string password)
        {
           if (password.Equals("Valid Password"))
            {
                loginPage.EnterPassword(configManager.GetPassword());
            }            
            else if (password.Equals("Invalid Password"))
            {
                loginPage.EnterPassword(configManager.GetInvalidPassword());
            }        
            else if (password.Equals("Empty"))
            {
                loginPage.EnterPassword("");
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"clicks the login button")]
        public void WhenClicksTheLoginButton()
        {
            loginPage.ClickOnLoginBtn();
        }

        [Then(@"the user should see '(.*)'")]
        public void ThenTheUserShouldSee(string message)
        {
            loginPage.Message(message);
        }
    }
}
