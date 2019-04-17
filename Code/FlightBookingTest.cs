using System.Collections.Generic;
using Code.Helpers;
using Code.Pages;
using Code.TestDataObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Code
{
    public class FlightBookingTest
    {
        [Test]
        public void TestThatResultsAppearForAOneWayJourney()
        {
            //Arrange
            bool expected = true;

            FlightsTdo testdata = new FlightsTdo
            {
                FromAirportCity = "Bangalore",
                ToAirportCity = "Delhi"
            };

            BrowserContext Browser = new BrowserContext();
            FlightsView flightsView = new FlightsView();

            //Act
            Browser.LaunchChromeBrowser();
            Browser.NavigateToUrl("https://www.cleartrip.com/");
           bool actual = flightsView.SearchFlights(Browser, testdata);

            //Assert
            Assert.AreEqual(expected, actual);

            //close the browser
            Browser.QuitDriver();
        }
    }
}