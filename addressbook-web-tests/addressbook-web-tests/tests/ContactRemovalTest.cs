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
            ContactData contact = new ContactData("bbb", "bbb", "bbb");
            contact.Nickname = "bbbv";
            contact.Bday = "2";
            contact.Bmonth = "October";
            contact.Aday = "3";
            contact.Amonth = "December";

            app.Contacts.CheckElementBeforeRemove(contact, 1);
         }
    }
}

