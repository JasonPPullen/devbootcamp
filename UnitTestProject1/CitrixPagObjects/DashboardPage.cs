using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CitrixPageObjects
{
    public class DashboardPage: NavigationPane
    {
        static string uri = "dashboard";
        static IWebDriver _driver;
        public DashboardPage(IWebDriver driver) : base(driver, uri)
        {
           
            _driver = driver;
        }

       /* public override void waitForPageLoaded()
        {
            base.waitForPageLoaded();
        }*/
    }
}
