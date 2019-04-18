using Code.Pages;
using Code.TestDataObjects;
using NUnit.Framework;

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
            var testdata = new FlightsTdo {
                FromAirportCity = "Bangalore",
                ToAirportCity = "Delhi"
            };

            var flightsView = new FlightsView();

            //Act
            bool actual = flightsView.SearchFlights(testdata);

            //Assert
            Assert.True(actual,"Search results not found");
        }
    }
}