using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CitrixPageObjects
{
    public class BasePage
    {
        static IWebDriver _driver;
        static string _uri = "";

        public BasePage(IWebDriver driver, string uri)
        {
            _driver = driver;
            _uri = uri;
        }

        
        public virtual void waitForPageLoaded()
        {
            if(_uri != "")
            {
                WebDriverWait waiter = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
                waiter.Until(t =>
                {
                    return t.Url.Contains(_uri);
                }
                );
            }
            else
            {
                // Log no uri passed.
            }
            
        }
    }
}
