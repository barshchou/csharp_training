using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Contact creation method
        public ContactHelper Create(ContactData contact)
        {
            AddContact();
            FillContactData(contact);
            Submit();
            return this;
        }

        public string CheckLocator()
        {
            string text = driver.FindElement(By.CssSelector("#content")).Text;
            return text;
        }
        
        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenDetailsPage(index);
                        
            string content = driver.FindElement(By.CssSelector("#content")).Text;
            
            string[] s = content.Split('\n');

            for (int i = 0; i < s.Length; i++)
            {
               s[i] = Regex.Replace(s[i], "[\n\r]", "");
            }
            
            string[] fullName = s[0].Split(' ');
            string firstname = fullName[0];
            string lastname = fullName[1];
            string fullname = firstname + lastname;

            string address = s[1];
            string allPhones = s[3]+s[4]+s[5];
            string allEmails = s[7]+s[8];

            return new ContactData(firstname, lastname)
            {
               Fullname = fullname,
               Address = address,
               AllPhones = allPhones,
               AllEmails = allEmails
            };
        }
        
        public ContactHelper OpenDetailsPage(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones =  allPhones,
                AllEmails = allEmails
            };

        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            EditButton(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        //Contact modification method
        public ContactHelper Modify(ContactData newData, int c)
        {
            manager.Navigator.OpenHomePage();
            EditButton(c);
            FillContactData(newData);
            ModifyContact();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement element in elements)
                {
                    string[] s = element.Text.Split(' ');
                    string firstname = s[0];
                    string lastname = s[1];

                    ContactData contact = new ContactData(lastname, firstname) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") };
                    contactCache.Add(contact);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.OpenHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public bool CheckElement()
        {
            manager.Navigator.OpenHomePage();
            return (IsElementPresent(By.XPath("//input[@name='selected[]']")));
        }

        //Contact removal method
        public ContactHelper Remove(int c)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(c);
            SubmitDelete();
            return this;
        }

        //Find button "Update" method
        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        //Find button "Edit" method
        public ContactHelper EditButton(int c)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ (c + 1) +"]")).Click();
            return this;
        }

        //Submit button accept
        public ContactHelper SubmitDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        //Select checkbox of contact to edit/delet
        public ContactHelper SelectContact(int c)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']["+ (c + 1) +"]")).Click();
            return this;
        }

        //Find button "Add new"
        public ContactHelper AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        //Find form's fields and fill
        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Tittle);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        //Submit button action
        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
