using System.Collections.Generic;
using Code.Helpers;
using Code.Pages;
using Code.TestDataObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Code.Tests
{
    public class FlightBookingTest : BaseSetup
    {
        public override void TestSetUp()
        {
            base.TestSetUp();
            NavigateTo("https://www.cleartrip.com/");
        }

        [Test]
        public void TestThatResultsAppearForAOneWayJourney()
        {
            //Arrange
            bool expected = true;

            var testdata = new FlightsTdo {
                FromAirportCity = "Bangalore",
                ToAirportCity = "Delhi"
            };

            var flightsView = new FlightsView();

            //Act
            bool actual = flightsView.SearchFlights(testdata);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}