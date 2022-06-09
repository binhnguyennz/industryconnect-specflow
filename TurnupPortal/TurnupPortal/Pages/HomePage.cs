using System;
using OpenQA.Selenium;

namespace TurnupPortal.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            //After login successfully, click on Administration"
            IWebElement administrationButton = driver.FindElement(By.LinkText("Administration"));
            administrationButton.Click();

            //Select Time & Materials from dropdown list
            IWebElement tmDropdown = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
            tmDropdown.Click();
        }
        public void GoToEmployeePage(IWebDriver driver)
        {
            //After login successfully, click on Administration
            IWebElement administrationButton = driver.FindElement(By.LinkText("Administration"));
            administrationButton.Click();

            //Select Employees from dropdown list
            IWebElement employeeDropdown = driver.FindElement(By.XPath("//a[contains(text(),'Employees')]"));
            employeeDropdown.Click();
        }
    }
}