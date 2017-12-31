using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModifyTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void GroupModifyTest()
        {
            //Data input
            GroupData group = new GroupData("test-new");
            group.Header = null;
            group.Footer = null;
            
            GroupData newData = new GroupData("test-new-modified");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0]; //Save element that will be modified

            //Action
            //Execute method using Groups helper
            if (!app.Groups.CheckElement())
            {
                app.Groups.Create(group);
            }

            app.Groups.Modify(newData, 0);

            //Check if count of elements are equal
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name; //Add to the newgroup list the name of modified element
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData _group in newGroups)
            {
                if (_group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, _group.Name);
                }
            }
        }
    }
}
