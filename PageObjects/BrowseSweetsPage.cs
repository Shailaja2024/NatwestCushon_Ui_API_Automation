using NatwestCushon_Automation_Test.Support;

namespace NatwestCushon_Automation_Test.PageObjects
{
    public class BrowseSweetsPage
    {
        private readonly IWebDriver _driver;

        public IWebElement BasketButton => _driver.FindElement(By.XPath("//a[@href='/basket']"));
        public IWebElement NavBarBasketCount => _driver.FindElement(By.XPath("//a//span[@class='badge badge-success']"));

        public BrowseSweetsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void VerifyListOfSweetsDisplayed(DataTable table)
        {
            var names = ReusableSetMethods.AsStrings(table, "Sweets Names");
            foreach (var name in names)
            {
                ReusableSetMethods.WaitForSeconds(2);
                Assert.True(_driver.FindElement(By.XPath("//h4[text()='" + name + "']")).Displayed);
            }
        }
        public void AddAnItemToTheBasket(string button, string name)
        {
            ReusableSetMethods.WaitForSeconds(1);
            _driver.FindElement(By.XPath("//h4[text()='" + name + "']/.././following-sibling::*/a[contains(text(), '" + button + "')]")).Click();
        }
        public void VerifyTheCountOnNavBarBasket(int count)
        {
            ReusableSetMethods.WaitForSeconds(1);
            var actualCountText = NavBarBasketCount.Text;
            int actualCount = int.Parse(actualCountText);
            Assert.AreEqual(count, actualCount, $"Count mismatch! Expected: {count}, Actual: {actualCount}");
        }

    }
}
