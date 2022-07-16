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
 
       

        [Test]
        public void RegisterNewClientWithFavouriteTechnologies()
        {
            EnterFirstNameInput("Anna");
            EnterLastNameInput("Smith");
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
            EnterFirstNameInput("Anna");
            EnterLastNameInput("Smith");
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
