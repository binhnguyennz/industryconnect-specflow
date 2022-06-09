using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnupPortal.Pages;
using TurnupPortal.Utilities;
namespace TurnupPortal.Tests
{


    [TestFixture]
    [Parallelizable]
    public class Employee_Tests: CommonDriver
    {
        //Page objects initialization	
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [Test, Order(1), Description("Test create employee using valid data")]
        public void CreateEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(2), Description("Test edit employee created in Test1")]
        public void EditEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(3), Description("Test Delete employee in Test 2")]
        public void DeleteEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.DeleteEmployee(driver);
        }
    }
}