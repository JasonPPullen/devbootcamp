using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CitrixPageObjects
{
    public class LoginPage: BasePage
    {
        static IWebDriver _driver;
        static string uri = "/Authentication/Login";

        public By emailField = By.Id("credentials-email");
        public By passwordFiled = By.Id("credentials-password");
        public By loginButton = By.Id("start-button");

        public LoginPage(IWebDriver driver): base(driver, uri)
        {
            _driver = driver;
        }

        public void waitForPageLoaded()
        {
            string currentUrl = _driver.Url;

        }

        public void Login(string email, string password)
        {
            //entering email address
            _driver.FindElement(emailField).Clear();
            _driver.FindElement(emailField).SendKeys("jason.pullen@citrix.com");

            //entering password
            _driver.FindElement(passwordFiled).Clear();
            _driver.FindElement(passwordFiled).SendKeys("Jaspul_1987");

            //clicking on Sign In
            _driver.FindElement(loginButton).Click();
        }
    }
}
