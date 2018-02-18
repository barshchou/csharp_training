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

            app.API.RemoveProjectApi(account,project);
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
                ProjectName = "test_new"
            };

            if (app.API.ProjectExists(account, project))
            {
                app.API.RemoveProjectApi(account, project);
            }

            app.API.AddProjectApi(account, project);
        }
    }
}
