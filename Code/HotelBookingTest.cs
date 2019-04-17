using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class HotelBookingTest
    {

        IWebDriver driver = new ChromeDriver();

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
            PageFactory.InitElements(driver, this);
        }

        [Test]
        public void ShouldBeAbleToSearchForHotels()
        {
           // SetDriverPath();

            driver.Navigate().GoToUrl("https://www.cleartrip.com/");
            hotelLink.Click();

            localityTextBox.SendKeys("Indiranagar, Bangalore");

            new SelectElement(travellerSelection).SelectByText("1 room, 2 adults");
            searchButton.Click();

            driver.Quit();
        }

        private void SetDriverPath()
        {
            if (Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                //System.setProperty("webdriver.chrome.driver", "chromedriver");
            }
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                // System.setProperty("webdriver.chrome.driver", "chromedriver.exe");
            }
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                // System.setProperty("webdriver.chrome.driver", "chromedriver_linux");
            }
        }

    }
}