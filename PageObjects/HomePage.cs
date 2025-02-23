using NatwestCushon_Automation_Test.Support;

namespace NatwestCushon_Automation_Test.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private string _title;

        // Page Elements
        public IWebElement LoginBtn => _driver.FindElement(By.XPath("//a[text()='Login']"));
        public IWebElement BrowseSweetBtn => _driver.FindElement(By.XPath("//*[text() = 'Browse Sweets']"));
        public IWebElement Title => _driver.FindElement(By.XPath("//h1[text()='"+ _title + "']"));
        public IWebElement BasketButton => _driver.FindElement(By.XPath("//a[@href='/basket']"));
      
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void VerifyTheTitleOnHomePage(string title)
        {
            _title = title;
            Assert.True(Title.Displayed);
        }
        public void ClickOnLoginButton()
        {
            ReusableSetMethods.WaitForSeconds(2);
            LoginBtn.Click();
        }
        public void VerifyTheBrowseSweetButton(string button)
        {
            ReusableSetMethods.WaitForSeconds(2);
            Assert.True(BrowseSweetBtn.Text.Contains(button));
        }
        public void VerifyTheMenuOptionsOnNavigationBar(DataTable dataTable)
        {
            var options = ReusableSetMethods.AsStrings(dataTable, "Options");
            foreach (var option in options)
            {
                ReusableSetMethods.WaitForSeconds(1);
                try
                {
                    Assert.True(_driver.FindElement(By.XPath("//a[text()='" + option + "']")).Displayed);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("no such element"))
                    {
                        Assert.True(_driver.FindElement(By.XPath("//span[@class='badge badge-success']/../../a[contains(text(), '" + option + "')]")).Displayed);
                    }
                    else
                    {
                        Assert.Fail($"Test failed due to an unexpected exception: {e.Message}");
                    }
                }  
            }
        }
        public void ClickOnTheMenuOptionsOnNavigationBar(string button)
        {
            ReusableSetMethods.WaitForSeconds(2);
            try
            {
                _driver.FindElement(By.XPath("//a[text()='" + button + "']")).Click();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("no such element"))
                {
                    BasketButton.Click();
                }
                else
                {
                    Assert.Fail($"Test failed due to an unexpected exception: {e.Message}");
                }             
            }
        }
        public void VerifyTheTitleOnDifferentPages(string title)
        {
            ReusableSetMethods.WaitForSeconds(2);
            _title = title;
            Assert.True(Title.Displayed);
        }
    }
}
