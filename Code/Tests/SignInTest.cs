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
    public class SignInTest : BaseSetup
    {        
        public override void TestSetUp()
        {
            base.TestSetUp();
            NavigateTo("https://www.cleartrip.com/");
        }

        [Test]
        public void ShouldThrowAnErrorIfSignInDetailsAreMissing()
        {
            //Arrange
            string expectedError = "There were errors in your submission";

            var signInView = new SignInView();
            
            //Act
            string actualError = signInView.VerifySignInIfDetailsAreMissing();

            //Assert
            Assert.True(actualError.Contains(expectedError));        
        }
    }
}
