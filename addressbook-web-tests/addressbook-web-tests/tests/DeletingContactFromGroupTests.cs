using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void TestDeletingContactFromGroup(GroupData group)
        {
            //Check if contact is created
            if (!app.Groups.CheckElement())
            {
                app.Groups.Create(group);
            }

            ContactData contact = new ContactData() //No idea how to use multiple testcase source to grab contactdata for creation new contact
            {
                Firstname = "firstname_test",
                Lastname = "lastname_test"
            };
            //Check if contact is created
            if (!app.Contacts.CheckElement())
            {
                app.Contacts.Create(contact);
            }

            GroupData oldGroup = GroupData.GetAll()[0];
            List<ContactData> oldList = oldGroup.GetContacts();
            contact = ContactData.GetAll().First();

            if (oldList.Count == 0)
            {
                app.Contacts.AddContactToGroup(contact, oldGroup);
            }

            oldList = oldGroup.GetContacts();
            ContactData contacts = oldList.First();

            //actions
            app.Contacts.RemoveContactFromGroup(contacts, oldGroup);

            List<ContactData> newList = oldGroup.GetContacts();
            oldList.Remove(contacts);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
