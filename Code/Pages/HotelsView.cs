using Code.Helpers;
using Code.TestDataObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Pages
{
    class HotelsView
    {
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

        public void SearchHotels(HotelsTdo testdata)
        {
            BrowserContext.ClickElement(_hotelLink);
            BrowserContext.SendText(_localityTextBox, testdata.Localtity);
            BrowserContext.SelectElementFromDropDown(_travellerSelection, SelectBy.Text, testdata.TravellerSelection);
            BrowserContext.ClickElement(_searchButton);
        }
    }
}
