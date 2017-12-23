using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void GroupCreationTest()
        {
            //Data input
            GroupData group = new GroupData("test2");
            group.Header = "asd";
            group.Footer = "qwe";

            //Action 
            //Execute method using Groups helper
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            //Data input
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //Action 
            //Execute method using Groups helper
            app.Groups.Create(group);
        }
    }
}
