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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 1; i++)
            {
                contacts.Add(new ContactData
                {
                    Firstname = GenerateRandomString(20),
                    Lastname = GenerateRandomString(20),
                });
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactRemovalTest(ContactData contact)
        {
            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

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

        [Test]
        public void ContactRemovalTest2()
        {
            /*
            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }
            */

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

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

