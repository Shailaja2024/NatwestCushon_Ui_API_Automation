using NatwestCushon_Automation_Test.PageObjects;

namespace NatwestCushon_Automation_Test.StepDefinitions
{
    [Binding]
    public class ProductBrowsingSteps
    {
        private readonly IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly BrowseSweetsPage _browseSweetsPage;
        private readonly HomePage homePage;

        public ProductBrowsingSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("currentDriver");
            _browseSweetsPage = new BrowseSweetsPage(driver);

        }
        [Then("the user should see a list of available sweets with their names as below")]
        public void ThenTheUserShouldSeeAListOfAvailableSweetsWithTheirNamesAsBelow(DataTable dataTable)
        {
            _browseSweetsPage.VerifyListOfSweetsDisplayed(dataTable);
        }
        [When("the user clicks the '(.*)' button for a sweet '(.*)'")]
        public void WhenUserClicksTheButtonForASweet(string button, string name)
        {
            _browseSweetsPage.AddAnItemToTheBasket(button, name);
        }
        [Then("the user should be able to see the basket {int}")]
        public void ThenTheUserShouldBeAbleToSeeTheBasket(int count)
        {
            _browseSweetsPage.VerifyTheCountOnNavBarBasket(count);
        }
    }
}
