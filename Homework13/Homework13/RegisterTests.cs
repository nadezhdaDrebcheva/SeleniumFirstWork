using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    public class RegisterTests : BaseTests
    {
        protected override string Url => @"file://tp-share/sda1/Automation/Homeworks/Nadi/Homework13/Homework13/Homework13/Htmls/Register/register.html";


             
        public void EnterNamesInput(string firstName, string lastName)
        {

            IWebElement firstNameInputElement = Driver.FindElement(By.CssSelector("#fname"));
            firstNameInputElement.SendKeys(firstName);

            IWebElement lastNameInputElement = Driver.FindElement(By.CssSelector("#lname"));
            lastNameInputElement.SendKeys(lastName);
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
        public void AcceptAlertMessage()
        {

            Driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void RegisterNewClientWithFavouriteTechnologies()
        {
            EnterNamesInput("Anna", "Smith");
            SelectGender();
            SelectFavouriteTechnologies();
            ClickRegisterButton();
            AcceptAlertMessage();


            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));

            Assert.IsTrue(firstParagraph.Text.Contains("Anna Smith"));

            Assert.IsTrue(firstParagraph.Text.Contains("Gender:Female"));

            IWebElement secondParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));

            Assert.IsTrue(secondParagraph.Text.Contains("HTML,CSS,JavaScript"));
        }

        [Test]
        public void RegisterNewClientWithoutFavouriteTechnologies()
        {
            EnterNamesInput("Anna", "Smith");
            SelectGender();
            ClickRegisterButton();
            AcceptAlertMessage();


            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));

            Assert.IsTrue(firstParagraph.Text.Contains("Anna Smith"));

            Assert.IsTrue(firstParagraph.Text.Contains("Gender:Female"));

            IWebElement secondParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));

            Assert.IsTrue(secondParagraph.Text.Contains("No favourite technologies"));
        }
    }

}
