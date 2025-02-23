using NatwestCushon_Automation_Test.Support;
namespace NatwestCushon_Automation_Test.PageObjects
{
    class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement UsernameField => _driver.FindElement(By.XPath("//*[@id='exampleInputEmail']"));
        public IWebElement PasswordField => _driver.FindElement(By.XPath("//*[@id='exampleInputPassword']"));
        public IWebElement LoginBtn => _driver.FindElement(By.XPath("//button[text()='Login']"));
       

        public void EnterUsername(string username)
        {
            ReusableSetMethods.WaitForSeconds(2);
            UsernameField.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            ReusableSetMethods.WaitForSeconds(2);
            PasswordField.SendKeys(password);
        }
        public void ClickOnLoginBtn()
        {
            ReusableSetMethods.WaitForSeconds(2);
            LoginBtn.Click();
            ReusableSetMethods.WaitForSeconds(2);
        }
        public void Message(string message)
        {
            ReusableSetMethods.WaitForSeconds(2);
            Assert.True(_driver.FindElement(By.XPath("//*[contains(text(), '" + message + "')]")).Displayed);
            ReusableSetMethods.WaitForSeconds(2);
        }
    }
}
