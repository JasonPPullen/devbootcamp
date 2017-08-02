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
        public By PersonalFolders = By.XPath("//span[contains(text(), 'Personal Folders')]");
        public By SharedFolders = By.XPath("//span[contains(text(), 'Shared Folders')]");
        public By Favorites = By.XPath("//span[contains(text(), 'Favorites')]");
        public By FileBox = By.XPath("//span[contains(text(), 'File Box')]");
        public By RecycleBin = By.XPath("//span[contains(text(), 'Recycle Bin')]");
        #endregion

        #region workflows submenu
        public By FeedbackAndApproval = By.XPath("//span[contains(text(), 'Feedback and Approval')]");
        #endregion

        #region inbox submenus
        public By Received = By.XPath("//span[contains(text(), 'Received')]");
        public By Sent = By.XPath("//span[contains(text(), 'Sent')]");
        public By Archived = By.XPath("//span[contains(text(), 'Archived')]");
        #endregion

        #region people submenus
        public By ManageUsersHome = By.XPath("//span[contains(text(),'Manage Users Home')]");
        public By BrowseEmployees = By.XPath("//span[contains(text(),'Browse Employees')]");
        public By BrowseClients = By.XPath("//span[contains(text(),'Browse Clients')]");
        public By SharedAddressBook = By.XPath("//span[contains(text(),'Shared Address Book')]");
        public By PersonalAddressBook = By.XPath("//span[contains(text(),'Personal Address Book')]");
        public By DistributionGroup = By.XPath("//span[contains(text(),'Distribution Groups')]");
        public By ResendWelcomeEmails = By.XPath("//span[contains(text(),'Resend Welcome Emails')]");
        #endregion

        #region settings submenu
        public By PersonalSettings = By.XPath("//span[contains(text(),'Personal Settings')]");
        public By AdminSettings = By.XPath("//span[contains(text(),'AdminSettings')]");
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
