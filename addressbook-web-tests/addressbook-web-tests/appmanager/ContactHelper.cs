using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

        //Contact modification method
        public ContactHelper Modify(ContactData newData, int c)
        {
            manager.Navigator.OpenHomePage();
            EditButton(c);
            FillContactData(newData);
            ModifyContact();
            return this;
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
        private ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        //Find button "Edit" method
        private ContactHelper EditButton(int c)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ c +"]")).Click();
            return this;
        }

        //Submit button accept
        public ContactHelper SubmitDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        //Select checkbox of contact to edit/delet
        public ContactHelper SelectContact(int c)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']["+ c +"]")).Click();
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
            return this;
        }
    }
}
