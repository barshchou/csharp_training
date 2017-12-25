using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void GroupRemovalTest()
        {
            //Remove group using Group hepler
            GroupData group = new GroupData("test_new");
            group.Header = "aaa";
            group.Footer = "bbb";

            if (app.Groups.CheckElement())
            {
                app.Groups.Remove(1);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Remove(1);
            }
        }
    }
}
