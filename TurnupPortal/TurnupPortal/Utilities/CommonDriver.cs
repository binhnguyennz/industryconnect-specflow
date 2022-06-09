using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnupPortal.Pages;

namespace TurnupPortal.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        LoginPage loginPageObj = new LoginPage();


        [OneTimeSetUp]
        public void LoginActions()
        {
            //open chrome browser
            driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}