using NatwestCushon_Automation_Test.Support;

namespace NatwestCushon_Automation_Test.PageObjects
{
    public class BasketPage
    {
        private readonly IWebDriver _driver;
        private string _button;

        public IWebElement YourBasketCount => _driver.FindElement(By.XPath("//*[@id='basketCount']"));
        public IWebElement EmptyBasketBtn => _driver.FindElement(By.XPath("//a[@onclick='emptyBasket();']"));
        public IWebElement checkoutBtn => _driver.FindElement(By.XPath("//button[text()='" + _button + "']"));

        public BasketPage(IWebDriver driver)
        {
            _driver = driver;
        }
       public void VerifyTheYourBasketCount(int count)
        {
            ReusableSetMethods.WaitForSeconds(1);
            var actualCountText = YourBasketCount.Text;
            int actualCount = int.Parse(actualCountText);
            Assert.AreEqual(count, actualCount, $"Count mismatch! Expected: {count}, Actual: {actualCount}");
        }
        public void ClickOnEmptyBasketButton()
        {
            ReusableSetMethods.WaitForSeconds(1);
            EmptyBasketBtn.Click();
            ReusableSetMethods.HandleAlert(_driver);
        }
        public void EnterDetailsToBillingAdress(DataTable table)
        {
            var billingDetails = ReusableSetMethods.GetKeyValuesFromTable(table, "Field", "Value");

            foreach (var field in billingDetails)
            {
                ReusableSetMethods.WaitForSeconds(2);
                try
                {
                    var inputField = _driver.FindElement(By.XPath("//label[text()='" + field.Key + "']/following-sibling::input"));
                    inputField.SendKeys(field.Value);
                }
                catch (Exception)
                {
                    var emailInputField = _driver.FindElement(By.XPath("//label[contains(text(), '" + field.Key + "')]/following-sibling::*[@id='email']"));
                    emailInputField.SendKeys(field.Value);
                }
                
            }
        }
        public void SelectDropdownOptions(DataTable table)
        {
            var dropdownDetails = ReusableSetMethods.GetKeyValuesFromTable(table, "Dropdown", "Value");
            foreach (var option in dropdownDetails)
            {
                var dropdown = _driver.FindElement(By.XPath("//label[text()='" + option.Key + "']/..//select"));
                ReusableSetMethods.SelectDropdownByText(dropdown, option.Value);
            }
        }
        public void EnterPaymentDetails(DataTable table)
        {
            var paymentDetails = ReusableSetMethods.GetKeyValuesFromTable(table, "Field", "Value");
            foreach (var field in paymentDetails)
            {
                ReusableSetMethods.WaitForSeconds(2);
                var inputField = _driver.FindElement(By.XPath("//label[text()='" + field.Key + "']/following-sibling::input"));
                inputField.SendKeys(field.Value);
            }
        }
        public void ClickOnCheckoutBtn(string button)
        {
            _button = button;
            ReusableSetMethods.WaitForSeconds(2);
            checkoutBtn.Click();
        }
    }
}
