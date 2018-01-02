using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTest : AuthTestBase //Наследование от TestAuth потому что предварительный логин требуется
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromForm, fromDetails);
            Assert.AreEqual(fromForm.AllPhonesCleanUp, fromDetails.AllPhones);
            Assert.AreEqual(fromForm.Fullname, fromDetails.Fullname);
            Assert.AreEqual(fromForm.AllEmailsCleanUp, fromDetails.AllEmails);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}
