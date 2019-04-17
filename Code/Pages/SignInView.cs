using Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="Browser"></param>
        /// <returns></returns>
        public string VerifySignInIfDetailsAreMissing(BrowserContext Browser)
        {
            Browser.ClickElement(ElementIdentifierType.LinkText, YourTripsLinkText);
            Browser.ClickElement(ElementIdentifierType.Id, SignInBtnId);
            Browser.SwitchToIframe(SignInWindowIframeName);
            Browser.ClickElement(ElementIdentifierType.Id, SignInBtnInIframeId);
            return Browser.GetTextOfElement(ElementIdentifierType.Id, SignInErrorMsgId);
        }
    }
}
