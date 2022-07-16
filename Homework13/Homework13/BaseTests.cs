using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    public abstract class BaseTests
    {
        protected abstract string Url { get; }

        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(Url);
            Driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }

        public void EnterFirstNameInput(string firstName)
        {

            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys(firstName);

        }


        public void EnterLastNameInput(string lastName)
        {

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys(lastName);
        }

        public void ClearFirstNameInput()
        {

            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.Clear();
        }
        public void ClearLastNameInput()
        {

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.Clear();
        }


        public void SelectGender()
        {
            IWebElement femaleRadioLabel = Driver.FindElement(By.CssSelector("label[for='female']"));
            femaleRadioLabel.Click();

            IWebElement femaleRadioInput = Driver.FindElement(By.CssSelector("input[id='female']"));
            Assert.IsTrue(femaleRadioInput.Selected);
        }
        public void SelectFavouriteTechnologies()
        {


            IWebElement htmlCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='html']"));
            htmlCheckBoxLabel.Click();

            IWebElement htmlCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='html']"));
            Assert.IsTrue(htmlCheckBoxInput.Selected);

            IWebElement cssCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='css']"));
            cssCheckBoxLabel.Click();

            IWebElement cssCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='css']"));
            Assert.IsTrue(cssCheckBoxInput.Selected);

            IWebElement jsCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='js']"));
            jsCheckBoxLabel.Click();

            IWebElement jsCheckBoxInput = Driver.FindElement(By.CssSelector("input[id='js']"));
            Assert.IsTrue(jsCheckBoxInput.Selected);
        }
        public void ClickRegisterButton()
        {
            IWebElement registerButton = Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            registerButton.Click();
        }

        public void ClickClearButton()
        {
            IWebElement clearButton = Driver.FindElement(By.CssSelector("button[onclick='clearData()']"));
            clearButton.Click();
        }
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }


        public void AcceptAlertMessage()
        {

            Driver.SwitchTo().Alert().Accept();
        }

    }
}