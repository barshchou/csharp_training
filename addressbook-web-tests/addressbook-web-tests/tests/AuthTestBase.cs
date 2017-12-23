using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    //Authorization class for tests that require login before running tests
    public class AuthTestBase : TestBase
    {
        [SetUp]

        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
         
        }
    }
}
