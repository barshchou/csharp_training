using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    //Base class for Tests
    public class TestBase
    {
        protected ApplicationManager app;

        public static Random rnd = new Random();

        [SetUp]
            public void SetupApplicationManager()
            {
                //Creating new ApplicationManager instance for tests
                app = ApplicationManager.GetInstance();

                //Some Selenium class?
                StringBuilder verificationErrors = new StringBuilder();
            }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(32 + rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}

