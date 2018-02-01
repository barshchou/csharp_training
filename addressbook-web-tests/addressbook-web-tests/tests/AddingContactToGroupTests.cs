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
    public class AddingContactToGroupTests : AuthTestBase
    {
        
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }
        
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }
        

        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void TestAddingContactToGroup(GroupData group)
        {
            
            //Check if contact is created
            if (!app.Groups.CheckElement())
            {   
                app.Groups.Create(group);
            }

            //No idea how to use multiple testcase source to grab contactdata for creation new contact
            ContactData contact = new ContactData() 
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
           
            if (ContactData.GetAll().Except(oldGroup.GetContacts()).Count() == 0)
            {
                app.Contacts.Create(contact);
            }

            ContactData contacts = ContactData.GetAll().Except(oldGroup.GetContacts()).First();

            //actions
            app.Contacts.AddContactToGroup(contacts, oldGroup);

            List<ContactData> newList = oldGroup.GetContacts();
            oldList.Add(contacts);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
