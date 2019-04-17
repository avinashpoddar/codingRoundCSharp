using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    public class SignInTest
    {

        IWebDriver driver = new ChromeDriver();

        [Test]
        public void ShouldThrowAnErrorIfSignInDetailsAreMissing()
        {

            setDriverPath();

            driver.Navigate().GoToUrl("https://www.cleartrip.com/");
            waitFor(2000);

            driver.FindElement(By.LinkText("Your trips")).Click();
            driver.FindElement(By.Id("SignIn")).Click();

            driver.FindElement(By.Id("signInButton")).Click();

            string errors1 = driver.FindElement(By.Id("errors1")).Text;
            Assert.True(errors1.Contains("There were errors in your submission"));
            driver.Quit();
        }

        private void waitFor(int durationInMilliSeconds)
        {
            try
            {
                Thread.Sleep(durationInMilliSeconds);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);  //To change body of catch statement use File | Settings | File Templates.
            }
        }

        private void setDriverPath()
        {
            if (Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                //System.setProperty("webdriver.chrome.driver", "chromedriver");
            }
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                // System.setProperty("webdriver.chrome.driver", "chromedriver.exe");
            }
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                // System.setProperty("webdriver.chrome.driver", "chromedriver_linux");
            }
        }
    }
}
