using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TurnupPortal.Pages;
using TurnupPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TurnupPortal.StepDefinitions
{
    [Binding]
    internal class TMTestDefinition : CommonDriver
    {
        [Given(@"I logged into Turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            //Open Chrome Browser
            driver = new ChromeDriver();

            //login page object initialisation and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }
        
        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // TM page object initialisation and definition
            HomePage homepageObj = new HomePage();
            homepageObj.GoToTMPage(driver);
        }

        [When(@"I created a new Time and Material record")]
        public void WhenICreateNewTimeAndMaterialRecord()
        {
            //home page object initialisation and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateRecord(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObj = new TMPage();
            string newCode = tmPageObj.GetNewCode(driver);
            //string newTypeCode = tmPageObj.GetNewTypeCode(driver);
            string newDescription = tmPageObj.GetNewDescription(driver);
            //string newPrice = tmPageObj.GetNewPrice(driver);
            
            Assert.That(newCode == "Selenium Webdriver", "Actual code and expected code do not match.");
            //Assert.That(newTypeCode == "M", "Actual typecode and expected typecode do not match.");
            Assert.That(newDescription == "This is my first automated test project.", "Actual description and expected description do not match.");
            //Assert.That(newPrice == "$22.00", "Actual price and expected price do not match.");
            driver.Close();
        }

        [When(@"I edit '(.*)', '(.*)', '(.*)' on an existing time and material record")]
        public void WhenIEditOnAnExistingTimeAndMaterialRecord(string description, string code, string price)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditRecord(driver, description, code, price);
        }

        [Then(@"The record should have the updated '(.*)', '(.*)', '(.*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p1, string p2, int p3)
        {
            TMPage tmPageObj = new TMPage();
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);
            
            Assert.That(editedCode == p2, "Expected code and actual code do not match. Record hasn't been edited successfully.");
            Assert.That(editedDescription == p1,
                "Expected description and actual description do not match. Record hasn't been edited successfully.");
            Assert.That(editedPrice == (p3.ToString("C", CultureInfo.CurrentCulture)),"Expected price and actual price do not match. Record hasn't been edited successfully.");
            driver.Close();
        }
        
        [When(@"I delete an extisting Time and Material record matching '(.*)' & '(.*)'")]
        public void WhenIDeleteAnExtistingTimeAndMaterialRecordMatching(string code, string description)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteRecord(driver, code);
        }
        
        [Then(@"The record matching '(.*)' & '(.*)' should be deleted successfully")]
        public void ThenTheRecordMatchingShouldBeDeletedSuccessfully(string p1, string p2)
        {
            TMPage tmPageObj = new TMPage();
            string currentCode = tmPageObj.GetCurrentCode(driver);
            string currentDescription = tmPageObj.GetCurrentDescription(driver);
            Assert.That(currentCode != p1, "Expected code and actual code do not match. Delete record Failed");
            Assert.That(currentDescription != p2, "Expected description and actual description do not match. Delete record Failed");
            driver.Close();
        }
    }
}