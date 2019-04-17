using System.Collections.Generic;
using Code.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Code
{
    public class FlightBookingTest
    {
        BrowserContext Browser = new BrowserContext();

        public FlightBookingTest()
        {
            Browser.LaunchChromeBrowser();
        }

        [Test]
        public void TestThatResultsAppearForAOneWayJourney()
        {
            //Browser.SetDriverPath();
            
            Browser.NavigateToUrl("https://www.cleartrip.com/");
            Browser.WaitFor(2000);
            Browser.ClickElement(ElementIdentifierType.Id, "OneWay");
            Browser.ClearField(ElementIdentifierType.Id, "FromTag");
            Browser.SendText(ElementIdentifierType.Id, "FromTag", "Bangalore");
            
            //wait for the auto complete options to appear for the origin

            Browser.WaitFor(2000);
            
            IReadOnlyList <IWebElement> originOptions = Browser.CurrentDriver.FindElement(By.Id("ui-id-1")).FindElements(By.TagName("li"));
            originOptions[0].Click();

            Browser.ClearField(ElementIdentifierType.Id, "ToTag");
            Browser.SendText(ElementIdentifierType.Id, "ToTag", "Delhi");

            //wait for the auto complete options to appear for the destination

            Browser.WaitFor(2000);
            //select the first item from the destination auto complete list

            IReadOnlyList<IWebElement> destinationOptions = Browser.CurrentDriver.FindElement(By.Id("ui-id-2")).FindElements(By.TagName("li"));
            destinationOptions[0].Click();

            Browser.ClickElement(ElementIdentifierType.Xpath, "//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[3]/td[7]/a");

            //all fields filled in. Now click on search
            //driver.FindElement(By.Id("SearchBtn")).Click();
            Browser.ClickElement(ElementIdentifierType.Id, "SearchBtn");

            Browser.WaitFor(5000);
            //verify that result appears for the provided journey search
            Assert.True(Browser.IsElementPresent(By.ClassName("searchSummary")));

            //close the browser
            Browser.QuitDriver();
        }
    }
}