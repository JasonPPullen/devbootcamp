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
        public By createAndContinue = By.XPath("//button[contains(text(),'Create & Continue')]");
        public By continueAnyway = By.XPath("//button[contains(text(),'Continue Anyway')]");
        public By skip = By.XPath("//button[contains(text(),'Skip')]");
        public By config = By.XPath("//span[contains(text(),'Leeman, Kelly')]/parent::div/parent::div/parent::a");
        public By delete = By.XPath("//span[contains(text(),'Delete from the System')]");
        public By remove = By.XPath("//button[contains(text(),'Remove')]");
        public By assignFolders = By.XPath("//span[contains(text(),'Assign Folders')]");
        public By sharedFolders = By.XPath("//span[contains(text(),'Shared Folders')]/preceding-sibling::*[2]");
        public By seleniumTest = By.XPath("//span[contains(text(),'Selenium Test')]/parent::div/parent::div");
        public By assign = By.XPath("//button[contains(text(),'Assign')]");

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
            _driver.FindElement(assignFolders).Click();
            WebDriverWait waiter2 = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter2.Until(t =>
            {
                return t.FindElement(sharedFolders).Displayed;
            });
            _driver.FindElement(sharedFolders).Click();
            _driver.FindElement(seleniumTest).Click();
            _driver.FindElement(assign).Click();
            WebDriverWait waiter4 = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter4.Until(t =>
            {
                return t.FindElement(createAndContinue).Displayed;
            });
            _driver.FindElement(createAndContinue).Click();
            /* _driver.FindElement(continueAnyway).Click();*/
             WebDriverWait waiter5 = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
             waiter5.Until(t =>
             {
                 return t.FindElement(skip).Displayed;
             });
             _driver.FindElement(skip).Click();
             WebDriverWait waiter3 = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
             waiter3.Until(t =>
             {
                 return t.FindElement(config).Displayed;
             });
        }

    }
}
