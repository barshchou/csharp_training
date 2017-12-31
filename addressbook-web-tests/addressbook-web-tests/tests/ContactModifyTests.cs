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
            ContactData contact = new ContactData("aaa", "aaa");
            contact.Nickname = "aaaa";
            contact.Bday = "1";
            contact.Bmonth = "May";
            contact.Aday = "2";
            contact.Amonth = "September";

            ContactData newData = new ContactData("bbbb", "tttttttt");
            newData.Nickname = "ppppppp";
            newData.Bday = "12";
            newData.Bmonth = "July";
            newData.Aday = "24";
            newData.Amonth = "August";

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
