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
			driver.FindElement(By.LinkText("Create")).Click();
			Thread.Sleep(1000);

			//Send text to Name Textbox
			driver.FindElement(By.Id("Name")).SendKeys("John Lennon");

			//Send text to username textbox
			driver.FindElement(By.Id("Username")).SendKeys("johnlennon");

			//Send text to Contact textbox
			driver.FindElement(By.Id("EditContactButton")).Click();
			driver.SwitchTo().Frame(0);
			driver.FindElement(By.Id("FirstName")).SendKeys("John");
			driver.FindElement(By.Id("LastName")).SendKeys("Lennon");
			driver.FindElement(By.Id("PreferedName")).SendKeys("John");
			driver.FindElement(By.Id("Phone")).SendKeys("022090355389");
			driver.FindElement(By.Id("Mobile")).SendKeys("022090223389");
			driver.FindElement(By.Id("email")).SendKeys("johnlennon@gmail.com");
			//address
			driver.FindElement(By.Id("Street")).SendKeys("6 Liverpool Street");
			driver.FindElement(By.Id("City")).SendKeys("Auckland");
			driver.FindElement(By.Id("Postcode")).SendKeys("1001");
			driver.FindElement(By.Id("Country")).SendKeys("New Zealand");
			driver.FindElement(By.Id("submitButton")).Click();

			//switch back to window
			driver.SwitchTo().DefaultContent();
			Thread.Sleep(1000);

			//Send text to Password textbox
			driver.FindElement(By.Id("Password")).SendKeys("T3st@n@lyst");

			//Send text to Retype passowrd textbox
			driver.FindElement(By.Id("RetypePassword")).SendKeys("T3st@n@lyst");

			//Click checkbox IsAdmin
			driver.FindElement(By.Id("IsAdmin")).Click();

			//Select Vehicle
			driver.FindElement(By.XPath("//input[@name='VehicleId_input']")).SendKeys("Honda");

			//View screen at button "Back to List"
			Actions action = new Actions(driver);
			IWebElement moveToBackToList = driver.FindElement(By.LinkText("Back to List"));
			action.MoveToElement(moveToBackToList);
			action.Perform();

			Thread.Sleep(1000);

			//Click on Groups textbox
			driver.FindElement(By.XPath("//div[@class='k-multiselect-wrap k-floatwrap']")).Click();
			Thread.Sleep(1000);

			//Hover popup list and click on nztest option
			IWebElement childElement = driver.FindElement(By.XPath("//li[normalize-space()='nztest']"));
			action.MoveToElement(childElement).Perform();
			Thread.Sleep(1000);
			action.Click().Build().Perform();

			//Click Save button
			driver.FindElement(By.Id("SaveButton")).Click();

			//Click Back to List
			driver.FindElement(By.LinkText("Back to List")).Click();
			Thread.Sleep(1000);

			//Click go to Last page
			driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]")).Click();
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

