using Code.Pages;
using NUnit.Framework;

namespace Code.Tests
{
    public class SignInTest : BaseSetup
    {        
        public override void TestSetUp()
        {
            base.TestSetUp();
            NavigateTo("https://www.cleartrip.com/");
        }

        [Test]
        public void ShouldThrowAnErrorIfSignInDetailsAreMissing()
        {
            //Arrange
            string expectedError = "There were errors in your submission";

            var signInView = new SignInView();
            
            //Act
            string actualError = signInView.VerifySignInIfDetailsAreMissing();

            //Assert
            Assert.True(actualError.Contains(expectedError));        
        }
    }
}
