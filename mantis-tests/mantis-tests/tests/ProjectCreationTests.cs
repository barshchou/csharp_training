﻿using System;
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

            ProjectData projectName = new ProjectData()
            {
                ProjectName = "test_new",
                Description = "test_description"
            };

            app.manager.CreateNewProject(adminAccount, projectName);
        }
    }
}
