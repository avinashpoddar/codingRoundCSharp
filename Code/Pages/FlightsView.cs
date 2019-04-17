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
        /// <param name="BrowserContext"></param>
        /// <param name="testdata"></param>
        /// <returns>Whether search results appear or not</returns>
        public bool SearchFlights(FlightsTdo testdata)
        {
            //Click oneway radio button
            BrowserContext.ClickElement(ElementIdentifierType.Id, OneWayRadioBtnId);

            //Select origin
            BrowserContext.SendText(ElementIdentifierType.Id, FromAirportCityId, testdata.FromAirportCity);
            var originOptions = BrowserContext.GetWebElement(ElementIdentifierType.Id, FromAutoCompleteULId)
                .FindElements(By.TagName(ListTag));
            BrowserContext.ClickElement(originOptions.FirstOrDefault());

            //Select to
            BrowserContext.SendText(ElementIdentifierType.Id, ToAirportCityId, testdata.ToAirportCity);
            var destinationOptions = BrowserContext.GetWebElement(ElementIdentifierType.Id, ToAutoCompleteULId)
                .FindElements(By.TagName(ListTag));
            BrowserContext.ClickElement(destinationOptions.FirstOrDefault());

            //Set Travel Date
            BrowserContext.ClickElement(ElementIdentifierType.Xpath, UiDatePickerXpath);

            //Search
            BrowserContext.ClickElement(ElementIdentifierType.Id, SearchButtonId);
            
            //verify that result appears for the provided journey search
            return BrowserContext.IsElementPresent(By.ClassName(SearchSummaryClass));
        }
    }
}
