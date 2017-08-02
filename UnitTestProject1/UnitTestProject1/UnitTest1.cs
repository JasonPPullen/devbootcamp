using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CitrixPageObjects;
using System.Threading;

namespace UnitTestProject1
{
    [TestFixture]
    public class Login
    {
        static IWebDriver driver;
        static LoginPage loginPage;
        static DashboardPage dashboard;
        static ManageUser manageUser;

        [OneTimeSetUp]
        protected static void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            
            loginPage = new LoginPage(driver);
            dashboard = new DashboardPage(driver);
            manageUser = new ManageUser(driver, "");
        }

        [OneTimeTearDown]
        protected void Dispose()
        {
            driver.Quit();
        }

        [Test, Order(1)]
        public void performLogin()
        {
            driver.Navigate().GoToUrl("https://drpullentest.sharefile.com/Authentication/Login");

            loginPage.Login("jason.pullen@citrix.com", "Jaspul_1987");
            
            dashboard.waitForPageLoaded();
        }

        [Test, Order(2)]
        public void clickPeople()
        {
            //navigate to People page
            dashboard.clickPeople();

            
        }

        [Test, Order(3)]
        public void  goToManageUsersHome()
        {
            manageUser.NavigateToManageUsersHome();
            manageUser.waitForPageLoaded();
            manageUser.createEmployee();
        }
       /* [Test, Order(3)]
        public void SearchFolder()
        {
            
        } */
    }
}
