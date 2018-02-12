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
            LoginAndNavigate(adminAccount);
            OpenCreateNewProjectForm();
            FillNewProjectForm(projectName);
            SubmitProjectCreation();
        }

        private void LoginAndNavigate(AccountData adminAccount)
        {
            manager.loginHelper.Login(adminAccount);
            manager.navigator.GoToManagePage();
            manager.menuHelper.NavigateToManageProjectTab();
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList(AccountData adminAccount)
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                LoginAndNavigate(adminAccount);

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody//a[@href]"));

                foreach (IWebElement element in elements)
                {
                    ProjectData project = new ProjectData(null)
                    {
                        ProjectName = element.FindElement(By.XPath("//tbody//a[@href]")).Text
                    };
                    projectCache.Add(project);
                }
            }
            return new List<ProjectData>(projectCache);
        }

        public bool ProjectExists(AccountData adminAccount, ProjectData projectName)
        {
            int i = 0;
            GetProjectList(adminAccount);
            foreach(ProjectData project in projectCache)
            {
                if (projectName.ProjectName == project.ProjectName)
                {
                    i++;
                }
            }
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SubmitProjectCreation()
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

        public void DeleteProject(ProjectData projectName)
        {
            SelectProjectToDelete(projectName);
            SubmiteRemove();
        }

        private void SelectProjectToDelete(int index)
        {
            driver.FindElements(By.XPath("//tbody//a[@href]"))[index].Click();
        }

        private void SelectProjectToDelete(ProjectData projectName)
        {
            driver.FindElement(By.XPath("//tbody//a[contains(text(),'"+ projectName.ProjectName +"')]")).Click();
        }

        public void SubmiteRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public bool CheckElement(AccountData adminAccount)
        {
            LoginAndNavigate(adminAccount);
            return (IsElementPresent(By.XPath("//td[contains(text(), 'development')]")));
        }

        public void Remove(AccountData adminAccount, int index)
        {
            LoginAndNavigate(adminAccount);
            DeleteProject(index);
        }

        public void Remove(AccountData adminAccount, ProjectData projectName)
        {
            LoginAndNavigate(adminAccount);
            DeleteProject(projectName);
        }

        public int GetProjectCount(AccountData adminAccount)
        {
            LoginAndNavigate(adminAccount);
            return driver.FindElements(By.XPath("//td[contains(text(), 'development')]")).Count;
        }
    }
        
}
