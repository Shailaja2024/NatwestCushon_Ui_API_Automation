using NatwestCushon_Automation_Test.PageObjects;

namespace NatwestCushon_Automation_Test.StepDefinitions
{
    [Binding]
    public class BasketSteps
    {
        private readonly IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly BasketPage _basketPage;
        private readonly HomePage homePage;

        public BasketSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("currentDriver");
            _basketPage = new BasketPage(driver);
        }
        [Then("the user should be albe to see the your basket is {int}")]
        public void ThenTheUserShouldBeAlbeToSeeTheYourBasketIs(int count)
        {
            _basketPage.VerifyTheYourBasketCount(count);
        }
        [When("the user clicks on empty basket button")]
        public void WhenTheUserClicksOnEmptyBasketButton()
        {
            _basketPage.ClickOnEmptyBasketButton();
        }
        [When("the user enters details to billing adress")]
        public void WhenTheUserEntersDetailsToBillingAdress(DataTable dataTable)
        {
            _basketPage.EnterDetailsToBillingAdress(dataTable);
        }
        [When("the user selects an option from the below dripdowns")]
        public void WhenTheUserSelectsAnOptionFromTheBelowDripdowns(DataTable dataTable)
        {
            _basketPage.SelectDropdownOptions(dataTable);
        }
        [When("the user enters details to Payment")]
        public void WhenTheUserEntersDetailsToPayment(DataTable dataTable)
        {
            _basketPage.EnterPaymentDetails(dataTable);
        }
        [When("the user click on the '(.*)' button")]
        public void WhenTheUserClickOnTheButton(string button)
        {
            _basketPage.ClickOnCheckoutBtn(button);
        }
    }
}
