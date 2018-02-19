using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]

    public class ProjectTestsApi : TestBase
    {
    
        [Test]

        public void RemoveProjectTestApi()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                ProjectName = "test_new"
            };

            if (!app.API.ProjectExists(account, project))
            {
                app.API.AddProjectApi(account, project);
            }

            List<ProjectData> oldProjects = app.API.GetProjectsList(account);
            ProjectData toBeRemoved = oldProjects[0];

            app.API.RemoveProjectApi(account);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.Remove(toBeRemoved);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]

        public void AddProjectTestApi()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                ProjectName = "test3"
            };

            if (app.API.ProjectExists(account, project))
            {
                app.API.RemoveProjectApi(account, project);
            }

            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.API.AddProjectApi(account, project);

            //Assert.AreEqual(oldProjects.Count + 1, app.API.GetProjectsList(account));

            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
