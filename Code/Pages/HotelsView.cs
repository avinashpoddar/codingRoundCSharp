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
        private IWebElement hotelLink;

        [FindsBy(How = How.Id, Using = "Tags")]
        private IWebElement localityTextBox;

        [FindsBy(How = How.Id, Using = "SearchHotelsButton")]
        private IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "travellersOnhome")]
        private IWebElement travellerSelection;

        public HotelsView(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SearchHotels(HotelsTdo testdata)
        {
            BrowserContext.ClickElement(hotelLink);
            BrowserContext.SendText(localityTextBox, testdata.Localtity);
            BrowserContext.SelectElementFromDropDown(travellerSelection, SelectBy.Text, testdata.TravellerSelection);
            BrowserContext.ClickElement(searchButton);
        }

    }
}
