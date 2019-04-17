using Code.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class BaseSetup
    {
        [SetUp]
        public virtual void TestSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            options.AddArguments("--start-maximized");
            BrowserContext.CurrentDriver = new ChromeDriver(options);
            BrowserContext.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TestTearDown()
        {
            BrowserContext.CurrentDriver.Quit();
        }

        public void NavigateTo(string url)
        {
            BrowserContext.CurrentDriver.Navigate().GoToUrl(url);
        }
    }
}