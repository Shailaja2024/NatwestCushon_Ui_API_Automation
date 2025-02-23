using NatwestCushon_Automation_Test.RunSettings;
using NatwestCushon_Automation_Test.PageObjects;

namespace NatwestCushon_Automation_Test.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly ConfigManager configManager;
        private readonly HomePage homePage;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("currentDriver");
            configManager = new ConfigManager();
            homePage = new HomePage(driver);

        }

        [Given(@"the user is on the sweet shop home page")]
        public void GivenTheUserIsOnTheSweetShopHomePage()
        {
            driver.Navigate().GoToUrl(configManager.GetBaseUrl());
        }
        [Then("the user should be able to see the title '(.*)'")]
        public void ThenTheUserShouldBeAbleToSeeTheTitle(string title)
        {
            homePage.VerifyTheTitleOnHomePage(title);
        }
        [When("user clicks login button on navigation bar")]
        public void WhenUserClicksOnLoginButtonOnNavigationBar()
        {
            homePage.ClickOnLoginButton();
        }
        [Then("the user should be able to see the '(.*)' button")]
        public void ThenTheUserShouldBeAbleToSeeTheButton(string button)
        {
            homePage.VerifyTheBrowseSweetButton(button);
        }
        [Then("the user should be ale to see the below options in the menu bar")]
        public void ThenTheUserShouldBeAleToSeeTheBelowOptionsInTheMenuBar(DataTable dataTable)
        {
            homePage.VerifyTheMenuOptionsOnNavigationBar(dataTable);
        }
        [When("the user navigates to the '(.*)'")]
        public void WhenTheUserNavigatesToThe(string button)
        {
            homePage.ClickOnTheMenuOptionsOnNavigationBar(button);
        }
        [Then("the user should be able to see the valid '(.*)'")]
        public void ThenTheUserShouldBeAbleToSeeTheValid(string title)
        {
            homePage.VerifyTheTitleOnDifferentPages(title);
        }
    }
}
