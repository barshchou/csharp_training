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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        //Group creation method
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            Submit();
            ReturnToGroupPage();
            return this;
        }

        public bool CheckElement()
        {
            manager.Navigator.OpenHomePage();
            return (IsElementPresent(By.XPath("//input[@name='selected[]']")));
        }

        //Remove group method
        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            DeleteGroup();
            ReturnToGroupPage();
            return this;
        }

        //Modify group method
        public GroupHelper Modify(GroupData newData, int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            ModifyGroup();
            FillGroupForm(newData);
            SubmitModifyGroup();
            return this;
        }

        //Find button "Update"
        public GroupHelper SubmitModifyGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        //Find button "Edit"
        public GroupHelper ModifyGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        //Fill group form with data method
        public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + index + "]")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
