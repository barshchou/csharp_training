using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests :TestBase
    {
        [Test]

        public void AddNewIssueTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "Test_project",
            };

            IssueData issue = new IssueData()
            {
                Summary = "some_short_text",
                Description = "some_long_text",
                Category  = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
