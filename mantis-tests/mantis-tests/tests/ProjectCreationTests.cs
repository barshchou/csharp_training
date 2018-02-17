using System;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData adminAccount = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            /*
            ProjectData projectName = new ProjectData(null)
            {
                ProjectName = "test_new",
                Description = "test_description"
            };

            if (app.manager.ProjectExists(adminAccount, projectName))
            {
                app.manager.Remove(adminAccount, projectName);
            }

            app.manager.CreateNewProject(adminAccount, projectName);
            */
        }
    }
}
