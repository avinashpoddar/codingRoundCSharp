using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class HotelBookingTest
    {

        WebDriver driver = new ChromeDriver();

        @FindBy(linkText = "Hotels")
    private WebElement hotelLink;

        @FindBy(id = "Tags")
    private WebElement localityTextBox;

        @FindBy(id = "SearchHotelsButton")
    private WebElement searchButton;

        @FindBy(id = "travellersOnhome")
    private WebElement travellerSelection;

        @Test
    public void shouldBeAbleToSearchForHotels()
        {
            setDriverPath();

            driver.get("https://www.cleartrip.com/");
            hotelLink.click();

            localityTextBox.sendKeys("Indiranagar, Bangalore");

            new Select(travellerSelection).selectByVisibleText("1 room, 2 adults");
            searchButton.click();

            driver.quit();

        }

        private void setDriverPath()
        {
             if (PlatformUtil.isMac()) {
                 System.setProperty("webdriver.chrome.driver", "chromedriver");
             }
             if (PlatformUtil.isWindows()) {
                 System.setProperty("webdriver.chrome.driver", "chromedriver.exe");
             }
             if (PlatformUtil.isLinux()) {
                 System.setProperty("webdriver.chrome.driver", "chromedriver_linux");
             }
        }

    }
}
