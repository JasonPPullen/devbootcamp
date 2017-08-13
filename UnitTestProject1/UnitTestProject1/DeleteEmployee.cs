using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CitrixPageObjects
{
    public class DeleteEmployee : ManageUser
    {
        static string uri = "dashboard";
        static IWebDriver _driver;
        static string _uri = "";

        public DeleteEmployee(IWebDriver driver, string uri) : base(driver, uri)
        {
            _driver = driver;
            _uri = uri;
        }

        public void deleteEmployee()
        {
            Console.WriteLine(config);
            _driver.FindElement(config).Click();
            WebDriverWait waiter = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter.Until(t =>
            {
                return t.FindElement(delete).Displayed;
            });
            _driver.FindElement(delete).Click();
            WebDriverWait waiter2 = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter2.Until(t =>
            {
                return t.FindElement(remove).Displayed;
            });
            _driver.FindElement(remove).Click();
        }
    }
}
