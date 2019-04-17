using Code.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Code
{
    public class HotelBookingTest
    {
        IWebDriver driver;

        BrowserContext Browser = new BrowserContext();        

        [FindsBy(How = How.LinkText, Using = "Hotels")]
        private IWebElement hotelLink;

        [FindsBy(How = How.Id, Using = "Tags")]
        private IWebElement localityTextBox;

        [FindsBy(How = How.Id, Using = "SearchHotelsButton")]
        private IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "travellersOnhome")]
        private IWebElement travellerSelection;

        public HotelBookingTest()
        {
            driver = Browser.LaunchChromeBrowser();
            PageFactory.InitElements(driver, this);
        }

        [Test]
        public void ShouldBeAbleToSearchForHotels()
        {
            //Browser.SetDriverPath();
            Browser.NavigateToUrl("https://www.cleartrip.com/");            
            Browser.ClickElement(hotelLink);
            Browser.SendText(localityTextBox, "Indiranagar, Bangalore");
            Browser.SelectElementFromDropDown(travellerSelection, SelectBy.Text, "1 room, 2 adults");
            Browser.ClickElement(searchButton);
            Browser.QuitDriver();
        }
    }
}