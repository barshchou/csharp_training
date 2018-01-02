using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            //Data input
            ContactData contact = new ContactData()
            {
            Firstname = "h",
            Lastname = "g",
            Nickname = "nickn",
            Bday = "6",
            Bmonth = "May",
            Aday = "12",
            Amonth = "June"
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //Create contact using Contact helper 
            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

