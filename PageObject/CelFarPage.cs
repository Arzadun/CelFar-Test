using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CelFar_Test.PageObject
{
    public class CelFarPage
    {
        protected IWebDriver Driver;

        static void Main(string[] args)

        { 

        }

        //Locators
        protected By InputField = By.Id("input");
        protected By InputButton = By.ClassName("button");
        
        
        //Constructor. If the title of the page is not right throws an exception
        public CelFarPage (IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("Conversor CelFar"))
                throw new Exception("this is not the CelFar page");
        }
            
        //set the information on the locators
        public void FillInput(string input)
        {
            Driver.FindElement(InputField).SendKeys(input);
        }

        public void ClickSubmit()
        {
            Driver.FindElement(InputButton).Click();
        }

        //Method for the assert
        public string ConversorCelFar(int celsius)
        {
            int expectedResult = (celsius * 9 / 5) + 32;
            string FinalResult = expectedResult.ToString();
            return FinalResult;
        }
        
        //Submit the number for the assert 
        //Wait for two seconds until the page changes the output field
        public string SubmitInfo(string input)
        {
            FillInput(input);
            ClickSubmit();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            return input;
        }






        
         
        

    }
}
