using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]

    public class AddProjectTestApi : TestBase
    {
    
        [Test]

        public void AddProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "12"
            };

            app.API.GetProjectsList(account);
        }
    }
}
