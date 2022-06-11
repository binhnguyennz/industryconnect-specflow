using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TurnupPortal.Utilities;

namespace TurnupPortal.Pages
{
	public class TMPage
	{
		public void CreateRecord(IWebDriver driver)
		{
            //Wait to load page
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//a[contains(text(),'Create New')]", 5);

            //Click Create New button
            IWebElement createnewButton = driver.FindElement(By.XPath("//a[contains(text(),'Create New')]"));
            createnewButton.Click();

            WaitHelpers.WaitToBeClickable(driver, "Id", "Code", 5);

            //Click Material and Select Time
            IWebElement TypeCodeListbox = driver.FindElement(By.XPath("//span[contains(text(),'Material')]"));
            TypeCodeListbox.Click();
            IWebElement typeCodeOption = driver.FindElement(By.XPath("//li[contains(text(),'Time')]"));
            typeCodeOption.Click();

            //Enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Selenium Webdriver");

            //Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("This is my first automated test project.");
            //Enter Price per unit

            IWebElement priceTextbox = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
            priceTextbox.Click();
            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("34");

            //Click on Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);
            Thread.Sleep(1500);

            //Check if record has been created successfully by navigate to last page and check last item
            IWebElement gotoLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageButton.Click();

            WaitHelpers.WaitToBeVisible(driver, "XPath", "//tbody/tr[last()]/td[1]", 5);
		}

        public void EditRecord(IWebDriver driver, string description, string code, string price)
        {
            //EDIT A RECORD
            //
            //Click last page*/

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 5);

            Thread.Sleep(1000);
            IWebElement gotoLastPageButton2 = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            gotoLastPageButton2.Click();

            Thread.Sleep(1000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//tbody/tr[last()]/td[5]/a[1]", 5);
            //Identify a record and click edit
            IWebElement editButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            WaitHelpers.WaitToBeVisible(driver, "Id", "Code", 5);
            //Edit Code
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys(code);

            //Edit Description
            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys(description);
            
            //Edit price
            IWebElement editPriceTextbox = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
            editPriceTextbox.Click();
            Thread.Sleep(1000);
            
            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPrice.Clear();
            Thread.Sleep(1000);
            
            editPriceTextbox.Click();
            Thread.Sleep(1000);
            
            editPrice.SendKeys(price);
            Thread.Sleep(1000);

            //Click Save button
            driver.FindElement(By.Id("SaveButton")).Click();
            
            Thread.Sleep(2000);
            //WaitHelpers.WaitToBeClickable(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 5);
            driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]")).Click();
			
            //WaitHelpers.WaitToBeVisible(driver, "XPath", "//tbody/tr[last()]/td[1]", 5);
            Thread.Sleep(1500);
            //Check if Record has been edited successfully by comparing Code text and Description text are same as inputs.
        }
        
        public string GetNewCode(IWebDriver driver)
        {
	        IWebElement newCode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
	        return newCode.Text;  
        }
        /*public string GetNewTypeCode(IWebDriver driver)
        {
	        IWebElement newTypeCode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[2]"));
	        return newTypeCode.Text;
        }*/
        
        public string GetNewDescription(IWebDriver driver)
        {
	        IWebElement newDescription = driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]"));
	        return newDescription.Text;
        }
        /*
        public string GetNewPrice(IWebDriver driver)
        {
	        IWebElement newPrice = driver.FindElement(By.XPath("//tbody/tr[last()]/td[4]"));
	        return newPrice.Text;
        }
        */

        public string GetEditedCode(IWebDriver driver)
        {
	        IWebElement editedCode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
	        return editedCode.Text;
        }

        public string GetEditedDescription(IWebDriver driver)
        {
	        IWebElement editedDescription = driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]"));
	        return editedDescription.Text;
        }

        public string GetEditedPrice(IWebDriver driver)
        {
	        IWebElement editedPrice = driver.FindElement(By.XPath("//tbody/tr[last()]/td[4]"));
	        return editedPrice.Text;
        }

        public void DeleteRecord(IWebDriver driver, string code)
        {
            //Click last page*/
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 2);

            Thread.Sleep(1000);
            IWebElement gotoLastPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            gotoLastPageButton.Click();

            Thread.Sleep(1000);
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//tbody/tr[last()]/td[5]/a[2]", 2);

            string deletedCode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;
            //string deletedDescription = driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]")).Text;
            
            if (deletedCode==code)
            {
	            //Select last record of TurnUp table and Click Delete button.
	            driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[2]")).Click();
	            //Switch to popup window and click OK button.
	            driver.SwitchTo().Alert().Accept();
	            //SwitchTo .Alert(), .Window(), .Frame() 
	            //actions: Text, Accept(), Dismiss(), SendKeys("abc"), SetAuthenticationCredentials()
	            
	            //WaitHelpers.WaitToBeVisible(driver, "XPath", "//tbody/tr[last()]/td[1]", 2);
	            Thread.Sleep(1000);
            }
            else
            {
	            Assert.Fail("Couldn't find the expected record.");
	            driver.Close();
            }
            //Read and store the last record's details
        }

        public string GetCurrentCode(IWebDriver driver)
        {
	        IWebElement currentCode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
	        return currentCode.Text;
        }

        public string GetCurrentDescription(IWebDriver driver)
        {
	        IWebElement currentDescription = driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]"));
	        return currentDescription.Text;
        }
	}
}

