using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModifyTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData newData = new GroupData("test3");
            newData.Header = "dsa";
            newData.Footer = "ewq";

            app.Groups.Modify(newData, 1);
        }
    }
}
