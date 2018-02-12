using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            AccountData adminAccount = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectName = new ProjectData(null)
            {
                ProjectName = "test_new",
                Description = "test_description"
            };

            if (!app.manager.CheckElement(adminAccount))
            {
                app.manager.CreateNewProject(adminAccount, projectName);
            }
            
            app.manager.Remove(adminAccount, 0);

        }
    }
}
