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

            app.loginHelper.Login(adminAccount);
            app.navigator.GoToManagePage();

            /*
            CreateNewProject();
            FillProjectForm();
            SubmitAddingProject();
            */
        }
    }
}
