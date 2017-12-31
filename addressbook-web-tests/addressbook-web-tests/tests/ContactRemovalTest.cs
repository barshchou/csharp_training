using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactRemovalTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void ContactRemovalTest()
        {
            //Action 
            //Execute method using Contacts helper
            ContactData contact = new ContactData("bbb", "bbb");
            contact.Nickname = "bbbv";
            contact.Bday = "2";
            contact.Bmonth = "October";
            contact.Aday = "3";
            contact.Amonth = "December";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];

            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData _contact in newContacts)
            {
                Assert.AreNotEqual(_contact.Id, toBeRemoved.Id);
            }
        }
    }
}

