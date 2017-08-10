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
        public By emailAddress = By.XPath("//input[@type='email']");
        public By firstName = By.XPath("//label[contains(text(),'First Name:')]/following-sibling::div/child::input");
        public By lastName = By.XPath("//label[contains(text(),'Last Name:')]/following-sibling::div/child::input");
        public By createAndContine = By.XPath("//button[@type='submit']");


        public ManageUser(IWebDriver driver, string uri) : base(driver, uri)
        {
            _driver = driver;
            _uri = uri;
        }

        public void createEmployee()
        {
            Console.WriteLine(createEmployeeElement);
            _driver.FindElement(createEmployeeElement).Click();
            WebDriverWait waiter = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter.Until(t =>
            {
                return t.FindElement(emailAddress).Displayed;
            });
            _driver.FindElement(emailAddress).Clear();
            _driver.FindElement(emailAddress).SendKeys("kelly.leeman@citrix.com");
            _driver.FindElement(firstName).SendKeys("Kelly");
            _driver.FindElement(lastName).SendKeys("Leeman");
            _driver.FindElement(createAndContine).Click();

        }

    }
}
