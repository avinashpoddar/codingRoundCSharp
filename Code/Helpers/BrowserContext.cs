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
        public static IWebDriver CurrentDriver { get; set; }
        
        public static IWebElement GetWebElement(ElementIdentifierType elementIdentifierType, string locatorPath)
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
                case ElementIdentifierType.LinkText:
                    {
                        return CurrentDriver.FindElement(By.LinkText(locatorPath));
                    }
            }
            return null;
        }

        public static void SendText(ElementIdentifierType elementIdentifierType, string locatorPath, string value)
        {
            GetWebElement(elementIdentifierType, locatorPath).SendKeys(value);
        }

        public static void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void ClickElement(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            GetWebElement(elementIdentifierType, locatorPath).Click();
        }

        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void WaitFor(int durationInMilliSeconds)
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

        public static bool IsElementPresent(By by)
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
        public static bool IsElementPresent(ElementIdentifierType elementIdentifierType, string locatorPath)
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

        public static void SelectElementFromDropDown(IWebElement element, SelectBy selectBy, string value)
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

        public static void SwitchToIframe(string frameName)
        {
            CurrentDriver.SwitchTo().Frame(frameName);
        }

        public static void SwitchToDefault()
        {
            CurrentDriver.SwitchTo().DefaultContent();
        }

        public static string GetTextOfElement(ElementIdentifierType elementIdentifierType, string locatorPath)
        {
            return GetWebElement(elementIdentifierType, locatorPath).Text;
        }

        /// <summary>
        /// This method is not relevant for now for the current scenario
        /// However it seems that this Method was used to get the OS and accordingly set the Chrome Driver Property in Java
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
        TagName,
        LinkText
    }
    public enum SelectBy
    {
        Index,
        Text,
        Value
    }
}
