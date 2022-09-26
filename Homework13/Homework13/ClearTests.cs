using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    public class ClearTests : BaseTests
    {
        protected override string Url => @"file://tp-share/sda1/Automation/Homeworks/Nadi/Homework13/Homework13/Homework13/Htmls/Register/register.html";
        [Test]
        public void ValidateClearButtonResetsData()
        {
            EnterFirstNameInput("Sarah");
            EnterLastNameInput("Connor");
            SelectGender();
            SelectFavouriteTechnologies();
            ClickClearButton();

            Assert.That(Driver.FindElement(By.CssSelector("#fname")).Text, Is.EqualTo(""));
            Assert.That(Driver.FindElement(By.CssSelector("#lname")).Text, Is.EqualTo(""));
            Assert.IsTrue(Driver.FindElement(By.CssSelector("input[id='male']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='java']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='cs']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='html']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='css']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("input[id='js']")).Selected);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);

        }
        [Test]
        public void ValidateRefreshPageResetsData()
        {
            EnterFirstNameInput("Sarah");
            EnterLastNameInput("Connor");
            SelectGender();
            SelectFavouriteTechnologies();
            RefreshPage();

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
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);
        }

        [Test]
        public void ValidateRegisterAndClearButtonsBothEnabled()
        {
            EnterFirstNameInput("Sarah");
            EnterLastNameInput("Connor");

            Driver.FindElement(By.TagName("body")).Click();

            Assert.IsTrue(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsTrue(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);

            ClearFirstNameInput();

            Driver.FindElement(By.TagName("body")).Click();

            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsTrue(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);


            ClearLastNameInput();

            Driver.FindElement(By.TagName("body")).Click();

            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='submitData()']")).Enabled);
            Assert.IsFalse(Driver.FindElement(By.CssSelector("button[onclick='clearData()']")).Enabled);

        }

        [Test]
        public void ValidateDivIsDashed()
        {
            IWebElement divElement = Driver.FindElement(By.CssSelector("div"));

            Assert.That(divElement.GetAttribute("style"), Does.Contain("dashed"));
        }

        [Test]
        public void ValidateMaleRadioIsOnTheLeft()
        {

            int xMale = Driver.FindElement(By.CssSelector("input[id='male']")).Location.X;
            int yMale = Driver.FindElement(By.CssSelector("input[id='male']")).Location.Y;

            int xFemale = Driver.FindElement(By.CssSelector("input[id='female']")).Location.X;
            int yFemale = Driver.FindElement(By.CssSelector("input[id='female']")).Location.Y;

            Assert.IsTrue(yFemale == yMale);
            Assert.IsTrue(xFemale > xMale);
        }
        [Test]
        public void ValidateOnlyOneElementSubmitData()
        {
            List<IWebElement> submitDataAttributeElements = Driver.FindElements(By.CssSelector("[onclick='submitData()']")).ToList();
            Assert.That(submitDataAttributeElements.Count, Is.EqualTo(1));
    }
    }
}

