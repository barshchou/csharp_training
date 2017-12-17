using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModifyTests : TestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData newData = new ContactData("bbbb", "tttttttt", "sssssssssss");
            newData.Nickname = "ppppppp";
            newData.Bday = "12";
            newData.Bmonth = "July";
            newData.Aday = "24";
            newData.Amonth = "August";

            app.Contacts.Modify(newData, 1);
        }
    }
}
