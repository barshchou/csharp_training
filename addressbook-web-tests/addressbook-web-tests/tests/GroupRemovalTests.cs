using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //Check if element is present and if not add new
            if (!app.Groups.CheckElement())
            {
                app.Groups.Create(group);
            }

            app.Groups.Remove(0);

            //Check if count of elements are equal
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData _group in newGroups)
            {
                Assert.AreNotEqual(_group.Id, toBeRemoved.Id);
            }
        }
    }
}
