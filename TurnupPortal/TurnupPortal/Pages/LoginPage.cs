using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TurnupPortal.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            //Maximize window
            driver.Manage().Window.Maximize();

            //navigate to TurnUp portal enter URL
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            try
            {
                //identify username and enter hari
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                //identify password and enter password
                IWebElement password = driver.FindElement(By.Id("Password"));
                password.SendKeys("123123");


                //Click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("//input[@value='Log in']"));
                loginButton.Click();
            }
            catch(Exception ex)
            {
                Assert.Fail("TurnUp portal does not launch.",ex.Message);
            }
 
            Assert.That(driver.FindElement(By.LinkText("Hello hari!")).Text == "Hello hari!", "Login failed. User profile does not appear");
        }
        
    }
}