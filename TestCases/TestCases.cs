using CelFar_Test.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelFar_Test.TestCases
{   
    [TestFixture]
    public class TestCases
    {
        protected IWebDriver Driver;

        [SetUp]
        //Go to the URL and maximize the page
        public void BeforeTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://nahual.github.io/qc-celfar/");
            

        }

        [Test]

        public void ActualTest()
        {
            //Set the info to submit and compare
            CelFarPage celFarPage = new CelFarPage(Driver);
            var Result = celFarPage.SubmitInfo("30");
            IWebElement ResultOutput = Driver.FindElement(By.Id("output"));
            //Assert 
            String ActualResult = ResultOutput.Text;
            string ExpectedResult = celFarPage.ConversorCelFar(30);
            Assert.AreEqual(ActualResult, ExpectedResult);
        }

        [TearDown]
        //close the page and finish test
        public void AfterTestCase()
        {
            Driver.Quit();
        }



    }
}
