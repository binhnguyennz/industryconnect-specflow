using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TurnupPortal.Pages
{
	public class EmployeePage
	{
		public void CreateEmployee(IWebDriver driver)
		{
			Thread.Sleep(1000);

			//Click button Create
			IWebElement buttonCreate = driver.FindElement(By.LinkText("Create"));
				buttonCreate.Click();
			Thread.Sleep(1000);

			//Send text to Name Textbox
			IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
				nameTextbox.SendKeys("John Lennon");

			//Send text to username textbox
			IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
				usernameTextbox.SendKeys("johnlennon");

			//Send text to Contact textbox
			IWebElement contactTextbox = driver.FindElement(By.Id("EditContactButton"));
				contactTextbox.Click();
			
			//Switch to Contact frame
			driver.SwitchTo().Frame(0);
			
			//Input contact
			IWebElement firstName = driver.FindElement(By.Id("FirstName"));
				firstName.SendKeys("John");
			
			IWebElement lastName = driver.FindElement(By.Id("LastName"));
				lastName.SendKeys("Lennon");
			
			IWebElement preferedName = driver.FindElement(By.Id("PreferedName")); 
				preferedName.SendKeys("John");
			
			IWebElement phone = driver.FindElement(By.Id("Phone"));
				phone.SendKeys("022090355389");
			
			IWebElement mobile = driver.FindElement(By.Id("Mobile"));
				mobile.SendKeys("022090223389");
			
			IWebElement email = driver.FindElement(By.Id("email"));
				email.SendKeys("johnlennon@gmail.com");
			//address
			IWebElement street = driver.FindElement(By.Id("Street"));
				street.SendKeys("6 Liverpool Street");

			IWebElement city = driver.FindElement(By.Id("City"));
				city.SendKeys("Auckland");
			
				
			IWebElement postCode = driver.FindElement(By.Id("Postcode"));
				postCode.SendKeys("1001");
			
			IWebElement country = driver.FindElement(By.Id("Country"));
				country.SendKeys("New Zealand");
			
			IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
				submitButton.Click();

			//switch back to window
			driver.SwitchTo().DefaultContent();
			Thread.Sleep(1000);

			//Send text to Password textbox
			IWebElement password = driver.FindElement(By.Id("Password"));
				password.SendKeys("T3st@n@lyst");

			//Send text to Retype passowrd textbox
			IWebElement retypePassword = driver.FindElement(By.Id("RetypePassword"));
				retypePassword.SendKeys("T3st@n@lyst");

			//Click checkbox IsAdmin
			IWebElement isAdminCheckbox = driver.FindElement(By.Id("IsAdmin"));
				isAdminCheckbox.Click();

			//Select Vehicle
			IWebElement vehicle = driver.FindElement(By.XPath("//input[@name='VehicleId_input']"));
				vehicle.SendKeys("Honda");

			//Move screen to button "Back to List"
			Actions action = new Actions(driver);
			IWebElement moveToBackToList = driver.FindElement(By.LinkText("Back to List"));
			action.MoveToElement(moveToBackToList);
			action.Perform();

			Thread.Sleep(1000);

			//Click on Groups textbox
			IWebElement groupTextbox = driver.FindElement(By.XPath("//div[@class='k-multiselect-wrap k-floatwrap']"));
				groupTextbox.Click();
			Thread.Sleep(1000);

			//Hover popup list and click on nztest option
			IWebElement groupOptions = driver.FindElement(By.XPath("//li[normalize-space()='nztest']"));
			action.MoveToElement(groupOptions).Perform();
			Thread.Sleep(1000);
			action.Click().Build().Perform();

			//Click Save button
			IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
				saveButton.Click();

			//Click Back to List
			IWebElement backToListButton = driver.FindElement(By.LinkText("Back to List"));
				backToListButton.Click();
			Thread.Sleep(1000);

			//Click go to Last page
			IWebElement gotoLastPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
				gotoLastPageButton.Click();
			Thread.Sleep(1000);

			//Check if record created.
			IWebElement nameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
			IWebElement usernameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[2]"));
			Assert.That(nameCheck.Text == "John Lennon", "Actual name and expected name do not match");
			Assert.That(usernameCheck.Text == "johnlennon", "Actual username and expected username do not match");
		}

		public void EditEmployee(IWebDriver driver)
		{
			//Click go to Last page
			Thread.Sleep(1500);
			driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]")).Click();
			Thread.Sleep(1500);

			IWebElement nameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
			if (nameCheck.Text == "John Lennon")
			{
				driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]/a[1]")).Click();
				Thread.Sleep(1000);

				//edit Name
				IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
				nameTextbox.Clear();
				nameTextbox.SendKeys("George Lennon");

				//username
				IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
				usernameTextbox.Clear();
				usernameTextbox.SendKeys("georgelennon");

				//Click save button
				driver.FindElement(By.Id("SaveButton")).Click();

				//click Back to list
				driver.FindElement(By.LinkText("Back to List")).Click();
				Thread.Sleep(1500);

				//Go to last page
				driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]")).Click();

				Thread.Sleep(1500);

				IWebElement editedNameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
				IWebElement editedUsernameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[2]"));

				Assert.That(editedNameCheck.Text == "George Lennon", "Actual name and expected Name do not match. Record is not edited.");
				Assert.That(editedUsernameCheck.Text == "georgelennon", "Actual Username and expected Username do not match. Record is not edited.");

			}
			else
			{
				Assert.Fail("Record found doesn't contain Name as expected");
			}

		}

		public void DeleteEmployee(IWebDriver driver)
		{
			//Click go to Last page
			Thread.Sleep(1500);
			driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]")).Click();
			Thread.Sleep(1500);

			IWebElement nameCheck = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
			if (nameCheck.Text == "George Lennon")
			{
				driver.FindElement(By.XPath("//tbody/tr[last()]/td[3]/a[2]")).Click();
				Thread.Sleep(1000);
				driver.SwitchTo().Alert().Accept();

				Thread.Sleep(1000);

				IWebElement deletedName = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
				IWebElement deletedUsername = driver.FindElement(By.XPath("//tbody/tr[last()]/td[2]"));

				Assert.That(deletedName.Text !="George Lennon","Original Name is found. Record is not deleted.");
				Assert.That(deletedUsername.Text != "georgelennon", "Original Username is found. Record is not deleted");
			}
			else
			{
				Assert.Fail("Record found doesn't contain Name as expected");
			}
		}
	}
}

