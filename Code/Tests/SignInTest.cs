using Code.Helpers;
using Code.Pages;
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

namespace Code.Tests
{
    public class SignInTest
    {        
        [Test]
        public void ShouldThrowAnErrorIfSignInDetailsAreMissing()
        {
            //Arrange
            string expectedError = "There were errors in your submission";
            BrowserContext Browser = new BrowserContext();
            SignInView signInView = new SignInView();
            
            //Act
            Browser.LaunchChromeBrowser();
            Browser.NavigateToUrl("https://www.cleartrip.com/");
            var actualError = signInView.VerifySignInIfDetailsAreMissing(Browser);

            //Assert
            Assert.True(actualError.Contains(expectedError));

            //Tear Down
            Browser.QuitDriver();
        }
    }
}
