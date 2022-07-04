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

    }
}