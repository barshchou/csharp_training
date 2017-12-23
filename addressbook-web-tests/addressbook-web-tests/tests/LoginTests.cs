using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class LoginTests : TestBase //Наследование от TestBase потому что предварительный логин не требуется
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            // Preperation
            app.Auth.Logout();

            // Action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //Check
            Assert.IsTrue(app.Auth.IsLoggedIn(account));

        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            // Preperation
            app.Auth.Logout();

            // Action
            AccountData account = new AccountData("admin", "qwerty");
            app.Auth.Login(account);

            //Check
            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

    }
}
