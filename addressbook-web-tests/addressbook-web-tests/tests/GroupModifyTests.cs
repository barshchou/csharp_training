using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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

            //Action
            //Execute method using Groups helper
            if (app.Groups.CheckElement())
            {
                app.Groups.Modify(newData, 1);
            }
            else
            {
                app.Groups.Create(group);
                app.Groups.Modify(newData, 1);
            }

        }
    }
}
