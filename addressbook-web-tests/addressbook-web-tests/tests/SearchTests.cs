using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class SearchTests : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]
        public void SearchTest()
        {
            int searchCount = app.Contacts.GetContactCount();

            List<ContactData> contacts = app.Contacts.GetContactList();

            int elements = contacts.Count();

            Assert.AreEqual(searchCount, elements);
        }
    }
}
