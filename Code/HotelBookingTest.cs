using Code.Helpers;
using Code.Pages;
using Code.TestDataObjects;
using NUnit.Framework;

namespace Code
{
    public class HotelBookingTest
    {
        [Test]
        public void ShouldBeAbleToSearchForHotels()
        {
            //Arrange
            HotelsTdo testdata = new HotelsTdo
            {
                Localtity = "Indiranagar, Bangalore",
                TravellerSelection = "1 room, 2 adults"
            };

            BrowserContext Browser = new BrowserContext();
            Browser.LaunchChromeBrowser();
            HotelsView hotelsView = new HotelsView(Browser.CurrentDriver);
            
            //Act
            Browser.NavigateToUrl("https://www.cleartrip.com/");
            hotelsView.SearchHotels(Browser, testdata);

            //Assert
            // No assertion as per the test written

            //Tear Down
            Browser.QuitDriver();
        }
    }
}