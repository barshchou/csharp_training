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

        [SetUp]
            public void SetupApplicationManager()
            {
                //Creating new ApplicationManager instance for tests
                app = ApplicationManager.GetInstance();

                //Some Selenium class?
                StringBuilder verificationErrors = new StringBuilder();
            }
    }
}

