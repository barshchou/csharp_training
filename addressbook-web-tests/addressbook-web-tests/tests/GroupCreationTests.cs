using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("test2");
            group.Header = "asd";
            group.Footer = "qwe";
            app.Groups.FillGroupForm(group);
            app.Groups.Submit();
            app.Groups.ReturnToGroupPage();
            app.Logout.Logout();
        }
    }
}
