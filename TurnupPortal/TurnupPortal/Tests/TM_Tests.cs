using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnupPortal.Pages;
using System.Threading;
using System;
using TurnupPortal.Utilities;
using NUnit.Framework;

namespace TurnupPortal.Tests // Note: actual namespace depends on the project name.
{
    [TestFixture]
    [Parallelizable]
    internal class TM_Tests : CommonDriver
    {
        //Page objects initilization and definition
        TMPage tmPageObj = new TMPage();
        HomePage homePageObj = new HomePage();

        [Test, Order(1), Description("Create time and material record with valid data")]
        public void CreateTM()
        {
            homePageObj.GoToTMPage(driver);
            //Create TM
            tmPageObj.CreateRecord(driver);
        }

        [Test, Order(2), Description("Edit time and material record created in test number 1")]
        public void EditTM()
        {
            homePageObj.GoToTMPage(driver);
            //Edit TM
            tmPageObj.EditRecord(driver,"null","null","null");
        }

        [Test, Order(3), Description("Delete time and material record edited in test number 2")]
        public void DeleteTM()
        {
            homePageObj.GoToTMPage(driver);
            //Delete TM
            tmPageObj.DeleteRecord(driver);
        }
    }
}