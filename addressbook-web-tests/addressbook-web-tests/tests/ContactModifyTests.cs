using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void ContactModifyTest()
        {
            // Data input
            ContactData contact = new ContactData()
            {
                Firstname = "aaa",
                Lastname = "aaa",
                Nickname = "aaaa",
                Bday = "1",
                Bmonth = "May",
                Aday = "2",
                Amonth = "September"
        };
            

            ContactData newData = new ContactData()
            {
                Firstname = "tttt",
                Lastname = "yyyyyyy",
                Nickname = "ppppppp",
                Bday = "12",
                Bmonth = "July",
                Aday = "24",
                Amonth = "August"
        };
            

            //Action 
            //Execute method using Contacts helper

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];


            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.Modify(newData, 0);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData _contact in newContacts)
            {
                if (_contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, _contact.Firstname);
                    Assert.AreEqual(newData.Lastname, _contact.Lastname);
                }
            }
        }
    }
}
