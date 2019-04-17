using Code.Helpers;
using Code.Pages;
using Code.TestDataObjects;
using NUnit.Framework;

namespace Code.Tests
{
    public class HotelBookingTest : BaseSetup
    {
        public override void TestSetUp()
        {
            base.TestSetUp();
            NavigateTo("https://www.cleartrip.com/");
        }

        [Test]
        public void ShouldBeAbleToSearchForHotels()
        {
            //Arrange
            var testdata = new HotelsTdo {
                Localtity = "Indiranagar, Bangalore",
                TravellerSelection = "1 room, 2 adults"
            };

            var hotelsView = new HotelsView(BrowserContext.CurrentDriver);

            //Act
            hotelsView.SearchHotels(testdata);

            //Assert
            // No assertion as per the test written
        }
    }
}