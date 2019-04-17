using Code.Helpers;
using Code.TestDataObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Code.Pages
{
    class HotelsView
    {
        //Locators
        const string LocalityUlId = "ui-id-1";
        const string CheckedLocationsXpath = "//nav[@class='locality']//input[@checked='checked']";
        const string ListTag = "li";

        [FindsBy(How = How.LinkText, Using = "Hotels")]
        private IWebElement _hotelLink;

        [FindsBy(How = How.Id, Using = "Tags")]
        private IWebElement _localityTextBox;

        [FindsBy(How = How.Id, Using = "SearchHotelsButton")]
        private IWebElement _searchButton;

        [FindsBy(How = How.Id, Using = "travellersOnhome")]
        private IWebElement _travellerSelection;

        public HotelsView(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string SearchHotels(HotelsTdo testdata)
        {
            BrowserContext.ClickElement(_hotelLink);
            BrowserContext.WaitFor(1000);
            BrowserContext.SendText(_localityTextBox, testdata.Locality);
            var localities = BrowserContext.GetWebElement(ElementIdentifierType.Id,LocalityUlId)
                .FindElements(By.TagName(ListTag));
            BrowserContext.ClickElement(localities[1]);
            BrowserContext.SelectElementFromDropDown(_travellerSelection, SelectBy.Text, testdata.TravellerSelection);
            BrowserContext.ClickElement(_searchButton);

            return BrowserContext.GetWebElement(ElementIdentifierType.Xpath, CheckedLocationsXpath).GetAttribute("value");
        }
    }
}
