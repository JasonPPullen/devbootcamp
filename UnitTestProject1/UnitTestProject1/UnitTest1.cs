using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            driver.Navigate().GoToUrl("https://drpullentest.sharefile.com/Authentication/Login");



            //entering email address
            driver.FindElement(By.Id("credentials-email")).Clear();
            driver.FindElement(By.Id("credentials-email")).SendKeys("jason.pullen@citrix.com");

            //entering password
            driver.FindElement(By.Id("credentials-password")).Clear();
            driver.FindElement(By.Id("credentials-password")).SendKeys("Jaspul_1987");

            //clicking on Sign In
            driver.FindElement(By.Id("start-button")).Click();

            //check URL
            //String currentURL = driver.Url;
            // driver.Url = "https://drpullentest.sharefile.com/app/#/dashboard";

            //check for folders
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //driver.FindElement(By.XPath("//span[@class='text>Folders<']"));
            driver.PageSource.Contains("Folders");


            //navigate to People page
            //driver.FindElement(By.LinkText(“People”)).click();
        }
    }
}
