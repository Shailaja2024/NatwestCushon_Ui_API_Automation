using OpenQA.Selenium.Support.UI;

namespace NatwestCushon_Automation_Test.Support
{
    public static class ReusableSetMethods
    {
        public static void WaitForSeconds(int secs)
        {
            try
            {
                Thread.Sleep(secs * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }
        }
        public static string[] AsStrings(this DataTable table, string column)
        {
            var tableList = table.Rows.Select(r => r[column]).ToArray();
            return tableList;
        }
        public static Dictionary<string, string> GetKeyValuesFromTable(this DataTable table, string key, string value)
        {
            var tableList = table.Rows
       .ToDictionary(row => row[key], row => row[value]);
            return tableList;
        }
        public static void HandleAlert(IWebDriver driver)
        {
            // Switch to the alert
            IAlert alert = driver.SwitchTo().Alert();

            // Optionally, get the alert text (for verification or logging)
            string alertText = alert.Text;
            Console.WriteLine("Alert Text: " + alertText);

            // Accept (click OK) on the alert
            alert.Accept();
        }
        // Extended Method for select dropdown by text
        public static void SelectDropdownByText(this IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
        // Extended Method for select dropdown by value
        public static void SelectDropdownByValue(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }
    }
}
