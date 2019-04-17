using Code.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    public class SignInTest
    {
        BrowserContext Browser = new BrowserContext();
        [Test]
        public void ShouldThrowAnErrorIfSignInDetailsAreMissing()
        {
            //Browser.SetDriverPath();
            Browser.LaunchChromeBrowser();
            Browser.NavigateToUrl("https://www.cleartrip.com/");
            Browser.WaitFor(2000);
            Browser.ClickElement(ElementIdentifierType.LinkText, "Your trips");
            Browser.ClickElement(ElementIdentifierType.Id, "SignIn");

            //switching to iframe
            Browser.SwitchToIframe("modal_window");

            Browser.ClickElement(ElementIdentifierType.Id, "signInButton");
            string errors1 = Browser.GetTextOfElement(ElementIdentifierType.Id, "errors1");
            Assert.True(errors1.Contains("There were errors in your submission"));
            Browser.QuitDriver();
        }
    }
}
