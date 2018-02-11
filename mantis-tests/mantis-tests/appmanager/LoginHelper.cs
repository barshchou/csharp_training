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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector(".width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        //Logout method
        //Checks if user is logged in, if not - DO NOTHING
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector(".user-info")).Click();
                driver.FindElements(By.CssSelector(".user-menu.dropdown-menu.dropdown-menu-right.dropdown-yellow.dropdown-caret.dropdown-close>li>a"))[2].Click();
            }

        }

        //Checks for element logout
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector(".user-info"));
        }

        //Checks for element logout and the name of the current logged in user
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector(".user-info")).Text;  //System.String.Format("(${0})", account.Username);
            return text;
        }

    }

    
}
