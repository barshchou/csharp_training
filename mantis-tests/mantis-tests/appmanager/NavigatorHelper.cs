using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{ 
    public class NavigatorHelper : HelperBase 
    {
        protected string baseURL;

        public NavigatorHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "mantisbt-2.2.0/"
                && IsElementPresent(By.XPath("input[@value='Login']")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "mantisbt-2.2.0/");
        }

        public void GoToManagePage()
        {
            if (driver.Url == baseURL + "mantisbt-2.2.0/manage_overview_page.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.XPath("//span[contains(text(),'Manage')]")).Click();
        }
    }
}
