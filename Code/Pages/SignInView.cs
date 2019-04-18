using Code.Helpers;

namespace Code.Pages
{
    class SignInView
    {
        //Locators
        const string YourTripsLinkText = "Your trips";
        const string SignInBtnId = "SignIn";
        const string SignInWindowIframeName = "modal_window";
        const string SignInBtnInIframeId = "signInButton";
        const string SignInErrorMsgId = "errors1";

        /// <summary>
        /// A method to get the error message when Details are missing
        /// </summary>
        /// <returns>Error Message</returns>
        public string GetErrorMessageIfSignInDetailsAreMissing()
        {
            BrowserContext.ClickElement(ElementIdentifierType.LinkText, YourTripsLinkText);
            BrowserContext.ClickElement(ElementIdentifierType.Id, SignInBtnId);
            BrowserContext.SwitchToIframe(SignInWindowIframeName);
            BrowserContext.ClickElement(ElementIdentifierType.Id, SignInBtnInIframeId);
            return BrowserContext.GetTextOfElement(ElementIdentifierType.Id, SignInErrorMsgId);
        }
    }
}
