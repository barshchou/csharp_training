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
    [TestFixture]

    public class LocatorTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void TestLocators()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.OpenDetailsPage(0);
            string s = app.Contacts.CheckLocator();
            System.Console.Out.Write(s);
        }
    }
}
