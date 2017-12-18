using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("vasya", "petrovich", "skovorodkin");
            contact.Nickname = "nickn";
            contact.Bday = "6";
            contact.Bmonth = "May";
            contact.Aday = "12";
            contact.Amonth = "June";

            app.Contacts.Create(contact);

        }
    }
}

