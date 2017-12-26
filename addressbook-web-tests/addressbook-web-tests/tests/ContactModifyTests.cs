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
            ContactData contact = new ContactData("aaa", "aaa", "aaa");
            contact.Nickname = "aaaa";
            contact.Bday = "1";
            contact.Bmonth = "May";
            contact.Aday = "2";
            contact.Amonth = "September";

            ContactData newData = new ContactData("bbbb", "tttttttt", "sssssssssss");
            newData.Nickname = "ppppppp";
            newData.Bday = "12";
            newData.Bmonth = "July";
            newData.Aday = "24";
            newData.Amonth = "August";

            //Action 
            //Execute method using Contacts helper
            
            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.Modify(newData, 1);
        }
    }
}
