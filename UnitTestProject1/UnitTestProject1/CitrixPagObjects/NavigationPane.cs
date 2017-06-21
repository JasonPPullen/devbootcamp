using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CitrixPageObjects
{
    public class NavigationPane : BasePage
    {
        static IWebDriver _driver;

        #region nav bar
        public By FolderFileSearchIcon = By.XPath("//div[@id='item-search']//span");
        public By SearchInput = By.XPath("//div[@class='Select-input']//input");
        #endregion

        #region toplevel
        public By DashboardLink = By.XPath("//a[contains(@href, 'dashboard')]");
        public By PeopleMenu = By.XPath("//span[contains(text(),'People')]");
        #endregion

        #region folders submenu#endregion
        #endregion

        #region workflows submenu 
        #endregion

        #region inbox submenus
        #endregion

        #region people submenus
        public By ManageUsersHome = By.XPath("//span[contains(text(),'Manage Users Home')]");
        #endregion

        #region settings submenu
        #endregion
        public NavigationPane(IWebDriver driver, string uri): base(driver, uri)
        {
            _driver = driver;
        }

        public DashboardPage NavigateToDashboard()
        {
            _driver.FindElement(DashboardLink).Click();
            return new DashboardPage(_driver);
        }

        public void clickPeople()
        {
            _driver.FindElement(PeopleMenu).Click();

            WebDriverWait waiter = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter.Until(t => {
                return t.FindElement(ManageUsersHome).Displayed;
            }
            );
        }

        public bool isPeopleSubMenuOpen()
        {
            return _driver.FindElement(ManageUsersHome).Displayed;
        }

        public void NavigateToManageUsersHome()
        {
            _driver.FindElement(ManageUsersHome).Click();
        }

        public void folderSearch(string searchText)
        {
            _driver.FindElement(FolderFileSearchIcon).Click();
            WebDriverWait waiter = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            waiter.Until(t => {
                return t.FindElement(SearchInput).Displayed;
            }
            );
            _driver.FindElement(SearchInput).SendKeys(searchText + Keys.Enter);
        }
    }
}
