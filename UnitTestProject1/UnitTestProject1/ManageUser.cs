using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CitrixPageObjects
{
    public class ManageUser : NavigationPane
    {
      
        static string uri = "dashboard";
        static IWebDriver _driver;
        static string _uri = "";
        
        public By createEmployeeElement = By.XPath("//div[contains(text(),'Create Employee')]");

        public ManageUser(IWebDriver driver, string uri) : base(driver, uri)
        {
            _driver = driver;
            _uri = uri;
        }

        public void createEmployee()
        {
            Console.WriteLine(createEmployeeElement);
            _driver.FindElement(createEmployeeElement).Click();

        }

    }
}
