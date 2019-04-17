using Code.Helpers;
using Code.TestDataObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Pages
{
    class FlightsView
    {
        //Locators
        const string OneWayRadioBtnId = "OneWay";
        const string FromAirportCityId = "FromTag";
        const string FromAutoCompleteULId = "ui-id-1";
        const string ToAutoCompleteULId = "ui-id-2";
        const string ListTag = "li";
        const string ToAirportCityId = "ToTag";
        const string UiDatePickerXpath = "//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[3]/td[7]/a";
        const string SearchButtonId = "SearchBtn";
        const string SearchSummaryClass = "searchSummary";

        /// <summary>
        /// A method to Search flights based on the test data
        /// </summary>
        /// <param name="Browser"></param>
        /// <param name="testdata"></param>
        /// <returns>Whether search results appear or not</returns>
        public bool SearchFlights(BrowserContext Browser, FlightsTdo testdata)
        {
            //Click oneway radio button
            Browser.ClickElement(ElementIdentifierType.Id, OneWayRadioBtnId);

            //Select origin
            Browser.SendText(ElementIdentifierType.Id, FromAirportCityId, testdata.FromAirportCity);
            var originOptions = Browser.GetWebElement(ElementIdentifierType.Id, FromAutoCompleteULId)
                .FindElements(By.TagName(ListTag));
            Browser.ClickElement(originOptions.FirstOrDefault());

            //Select to
            Browser.SendText(ElementIdentifierType.Id, ToAirportCityId, testdata.ToAirportCity);
            var destinationOptions = Browser.GetWebElement(ElementIdentifierType.Id, ToAutoCompleteULId)
                .FindElements(By.TagName(ListTag));
            Browser.ClickElement(destinationOptions.FirstOrDefault());

            //Set Travel Date
            Browser.ClickElement(ElementIdentifierType.Xpath, UiDatePickerXpath);

            //Search
            Browser.ClickElement(ElementIdentifierType.Id, SearchButtonId);
            
            //verify that result appears for the provided journey search
            return Browser.IsElementPresent(By.ClassName(SearchSummaryClass));
        }
    }
}
