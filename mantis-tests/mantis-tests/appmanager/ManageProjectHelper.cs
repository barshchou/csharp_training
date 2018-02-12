using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ManageProjectHelper : HelperBase
    {
        public ManageProjectHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CreateNewProject(AccountData adminAccount, ProjectData projectName)
        {
            manager.loginHelper.Login(adminAccount);
            manager.navigator.GoToManagePage();
            manager.menuHelper.NavigateToManageProjectTab();
            OpenCreateNewProjectForm();
            FillNewProjectForm(projectName);
            SubmitProjectCreation();
        }

        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void FillNewProjectForm(ProjectData projectName)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(projectName.ProjectName);
            driver.FindElement(By.Id("project-description")).SendKeys(projectName.Description);
        }

        public void OpenCreateNewProjectForm()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
        }

        public void DeleteProject(int index)
        {
            SelectProjectToDelete(index);
            SubmiteRemove();
        }

        private void SelectProjectToDelete(int index)
        {
            driver.FindElements(By.XPath("//tbody//a[@href]"))[index].Click();
        }

        public void SubmiteRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public bool CheckElement(AccountData adminAccount)
        {
            manager.loginHelper.Login(adminAccount);
            manager.navigator.GoToManagePage();
            manager.menuHelper.NavigateToManageProjectTab();
            return (IsElementPresent(By.XPath("//td[contains(text(), 'development')]")));
        }

        public void Remove(AccountData adminAccount, int index)
        {
            manager.loginHelper.Login(adminAccount);
            manager.navigator.GoToManagePage();
            manager.menuHelper.NavigateToManageProjectTab();
            DeleteProject(index);
        }

        public int GetProjectCount()
        {
            manager.navigator.GoToManagePage();
            manager.menuHelper.NavigateToManageProjectTab();
            return driver.FindElements(By.XPath("//td[contains(text(), 'development')]")).Count;
        }
    }
        
}
