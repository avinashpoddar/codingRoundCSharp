using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Helpers
{
    public class BrowserContext
    {
        public IWebDriver CurrentDriver { get; set; }
        ChromeOptions options = new ChromeOptions();

        public IWebDriver LaunchChromeBrowser()
        {
            options.AddArgument("--disable-notifications");
            CurrentDriver = new ChromeDriver(options);
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return CurrentDriver;
        }

        public void NavigateToUrl(string url)
        {
            CurrentDriver.Navigate().GoToUrl(url);
        }

        private IWebElement GetWebElement(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            switch (elementIdentifierType)
            {
                case ElementIdentifierType.Id:
                    {
                        return CurrentDriver.FindElement(By.Id(locatorPath));
                    }
                case ElementIdentifierType.Name:
                    {
                        return CurrentDriver.FindElement(By.Name(locatorPath));
                    }
                case ElementIdentifierType.Xpath:
                    {
                        return CurrentDriver.FindElement(By.XPath(locatorPath));
                    }
                case ElementIdentifierType.CSS:
                    {
                        return CurrentDriver.FindElement(By.CssSelector(locatorPath));
                    }
                case ElementIdentifierType.ClassName:
                    {
                        return CurrentDriver.FindElement(By.ClassName(locatorPath));
                    }
                case ElementIdentifierType.TagName:
                    {
                        return CurrentDriver.FindElement(By.TagName(locatorPath));
                    }
            }
            return null;
        }

        private IReadOnlyCollection<IWebElement> GetWebElements(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            switch (elementIdentifierType)
            {
                case ElementIdentifierType.Id:
                    {
                        return CurrentDriver.FindElements(By.Id(locatorPath));
                    }
                case ElementIdentifierType.Name:
                    {
                        return CurrentDriver.FindElements(By.Name(locatorPath));
                    }
                case ElementIdentifierType.Xpath:
                    {
                        return CurrentDriver.FindElements(By.XPath(locatorPath));
                    }
                case ElementIdentifierType.CSS:
                    {
                        return CurrentDriver.FindElements(By.CssSelector(locatorPath));
                    }
                case ElementIdentifierType.ClassName:
                    {
                        return CurrentDriver.FindElements(By.ClassName(locatorPath));
                    }
                case ElementIdentifierType.TagName:
                    {
                        return CurrentDriver.FindElements(By.TagName(locatorPath));
                    }
            }
            return null;
        }

        public void Clear(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            GetWebElement(elementIdentifierType, locatorPath).Clear();
        }

        public void SendText(ElementIdentifierType elementIdentifierType, string locatorPath, string value)
        {
            GetWebElement(elementIdentifierType, locatorPath).SendKeys(value);
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public void ClickElement(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            GetWebElement(elementIdentifierType, locatorPath).Click();
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void QuitDriver()
        {
            CurrentDriver.Quit();
        }

        public void WaitFor(int durationInMilliSeconds)
        {
            try
            {
                Thread.Sleep(durationInMilliSeconds);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);  //To change body of catch statement use File | Settings | File Templates.
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                CurrentDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
        public bool IsElementPresent(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            try
            {
                GetWebElement(elementIdentifierType, locatorPath);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public void SelectElementFromDropDown(IWebElement element, SelectBy selectBy, string value)
        {
            SelectElement select = new SelectElement(element);
            switch (selectBy)
            {
                case SelectBy.Index:
                    select.SelectByIndex(int.Parse(value));
                    break;
                case SelectBy.Text:
                    select.SelectByText(value);
                    break;
                case SelectBy.Value:
                    select.SelectByValue(value);
                    break;
            }
        }
        /// <summary>
        /// This method is not relevant for now for the current scenario
        /// However it seems that this Method was used to get the OS and according set the Chrome Driver Property in Java
        /// </summary>
        public void SetDriverPath()
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

    public enum ElementIdentifierType
    {
        Id,
        Name,
        Xpath,
        CSS,
        ClassName,
        TagName
    }
    public enum SelectBy
    {
        Index,
        Text,
        Value
    }
}
