using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    internal class WaitTestsHW15 : BaseTests
    {
        protected override string Url => @"file:///C:/Users/nadez/source/repos/SeleniumFirstWork/Homework13/Homework13/Htmls/Register/register.html";


        public void OpenContextMenu()
        {
            IWebElement body = Driver.FindElement(By.TagName("body"));
            Actions actions = new Actions(Driver);
            actions.ContextClick(body).Perform();
        }

        public void HoverOverSubmitButton()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Driver.FindElement(By.Id("submit"))).Perform();
        }

        [Test]
        public void DoubleClickTheRegisterAnEmployeeHeading()
        {
            Actions actions = new Actions(Driver);

            IWebElement registerAnEmployeeHeading = Driver.FindElement(By.Id("mainHeading"));

            actions.DoubleClick(registerAnEmployeeHeading).Perform();

            WebDriverWait webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            IAlert alert = webDriverWait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);


        }
        [Test]
        public void ContextMenuClearOptionResetsData()
        {
            EnterFirstNameInput("Peter");
            EnterLastNameInput("Sagan");
            SelectGender();
            SelectFavouriteTechnologies();

            OpenContextMenu();

            IWebElement contextMenu = Driver.FindElement(By.Id("contextMenu"));
            IWebElement contextClearButton = contextMenu.FindElement(By.Id("contextClear"));
            contextClearButton.Click();


            Assert.That(Driver.FindElement(By.CssSelector("#fname")).Text, Is.EqualTo(""));
            Assert.That(Driver.FindElement(By.CssSelector("#lname")).Text, Is.EqualTo(""));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("input[id='male']")).Selected);
            Assert.That(Driver.FindElement(By.CssSelector("#fname")).Text, Is.EqualTo(""));
            Assert.That(Driver.FindElement(By.CssSelector("#lname")).Text, Is.EqualTo(""));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("input[id='male']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='java']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='cs']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='html']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='css']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='js']")).Selected);

            OpenContextMenu();
            contextMenu = Driver.FindElement(By.Id("contextMenu"));
            Assert.IsFalse(contextMenu.FindElement(By.Id("contextClear")).Enabled);
            Assert.IsFalse(contextMenu.FindElement(By.Id("contextRegister")).Enabled);

        }
        [Test]
        public void ClickingOutsideClosesTheContextMenu()
        {
            OpenContextMenu();

            IWebElement contextMenu = Driver.FindElement(By.Id("contextMenu"));

            IWebElement body = Driver.FindElement(By.TagName("body"));
            body.Click();

            Assert.IsFalse(contextMenu.Displayed);
        }
        [Test]
        public void ClearingTextInputDisablesOnlyContextSubmit()
        {
            EnterFirstNameInput("Fani");
            EnterLastNameInput("Manolova");

            IWebElement body = Driver.FindElement(By.TagName("body"));
            body.Click();

            Assert.IsTrue(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);

            OpenContextMenu();
            IWebElement contextMenu = Driver.FindElement(By.Id("contextMenu"));
            Assert.IsTrue(contextMenu.FindElement(By.Id("contextRegister")).Enabled);

            ClearFirstNameInput();


            Assert.IsTrue(contextMenu.FindElement(By.Id("contextClear")).Enabled);
            Assert.IsFalse(contextMenu.FindElement(By.Id("contextRegister")).Enabled);

            ClearLastNameInput();

            contextMenu = Driver.FindElement(By.Id("contextMenu"));


            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);

            Assert.IsFalse(contextMenu.FindElement(By.Id("contextRegister")).Enabled);

        }
        [Test]
        public void ValidateThatTooltipChangesProperly()
        {
            HoverOverSubmitButton();

            string tooltipBefore = Driver.FindElement(By.ClassName("tooltiptext")).Text;


            Assert.IsTrue(Driver.FindElement(By.ClassName("tooltiptext")).Displayed);
            Assert.That(tooltipBefore, Is.EqualTo("Enter First name and Last name to enable Register button."));

            EnterFirstNameInput("Sara");
            EnterLastNameInput("Logan");

            IWebElement body = Driver.FindElement(By.TagName("body"));
            body.Click();

            HoverOverSubmitButton();

            string tooltipAfter = Driver.FindElement(By.ClassName("tooltiptext")).Text;

            Assert.IsTrue(Driver.FindElement(By.ClassName("tooltiptext")).Displayed);
            Assert.That(tooltipAfter, Is.EqualTo("Click Register button to submit data."));
        }

        [Test]
        public void RegisterUserAndValidateData()
        {

            EnterFirstNameInput("John");
            EnterLastNameInput("Doe");

            IWebElement job = Driver.FindElement(By.Id("job"));
            SelectElement selectJob = new SelectElement(job);
            selectJob.SelectByText("Developer");

            

            ClickRegisterButton();
            AcceptAlertMessage();

            IWebElement firstParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(1)"));

            Assert.IsTrue(firstParagraph.Text.Contains("John Doe"));

            IWebElement secondParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(2)"));

            Assert.IsTrue(secondParagraph.Text.Contains("No favourite technologies"));

            IWebElement thirdParagraph = Driver.FindElement(By.CssSelector("body p:nth-child(3)"));
            Assert.IsTrue(thirdParagraph.Text.Contains("Currently working as Developer"));

        }
    }
}

