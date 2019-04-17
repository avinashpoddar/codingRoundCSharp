using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Code
{
    public class FlightBookingTest
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void testThatResultsAppearForAOneWayJourney()
        {

            setDriverPath();

            driver.Navigate().GoToUrl("https://www.cleartrip.com/");
            waitFor(2000);
            driver.FindElement(By.Id("OneWay")).Click();

            driver.FindElement(By.Id("FromTag")).Clear();
            driver.FindElement(By.Id("FromTag")).SendKeys("Bangalore");

            //wait for the auto complete options to appear for the origin

            waitFor(2000);
            IReadOnlyList<IWebElement> originOptions = driver.FindElement(By.Id("ui-id-1")).FindElements(By.TagName("li"));
            originOptions[0].Click();

            driver.FindElement(By.Id("toTag")).Clear();
            driver.FindElement(By.Id("toTag")).SendKeys("Delhi");

            //wait for the auto complete options to appear for the destination

            waitFor(2000);
            //select the first item from the destination auto complete list
            IReadOnlyList<IWebElement> destinationOptions = driver.FindElement(By.Id("ui-id-2")).FindElements(By.TagName("li"));
            destinationOptions[0].Click();

            driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[3]/td[7]/a")).Click();

            //all fields filled in. Now click on search
            driver.FindElement(By.Id("SearchBtn")).Click();

            waitFor(5000);
            //verify that result appears for the provided journey search
            Assert.True(isElementPresent(By.ClassName("searchSummary")));

            //close the browser
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


        private bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
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