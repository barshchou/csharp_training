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

            app.Groups.CheckElementBeforeRemove(group,1);
        }
    }
}
