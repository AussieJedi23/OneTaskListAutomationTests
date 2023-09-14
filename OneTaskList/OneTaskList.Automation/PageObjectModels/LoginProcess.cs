using OpenQA.Selenium;
using System;

namespace OneTaskList.Automation.PageObjectModels
{
    class LoginProcess : BasePage
    {
        public LoginProcess(IWebDriver driver) : base(driver) { }

        public IWebElement AcceptTermsandConditions
        {
            get
            {
                return Driver.FindElement(By.TagName("button"));
            }
        }
        
        public IWebElement MicrosoftLogin
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".provider-microsoft"));
            }
        }
        public IWebElement EmailInput
        {
            get
            {
                return Driver.FindElement(By.Id("i0116"));
            }
        }

        public IWebElement NextButton
        {
            get
            {
                return Driver.FindElement(By.Id("idSIButton9"));
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                return Driver.FindElement(By.Id("i0118"));
            }
        }

        public IWebElement SignInButton
        {
            get
            {
                return Driver.FindElement(By.Id("idSIButton9"));
            }
        }

        public IWebElement StaySignedInButton
        {
            get
            {
                return Driver.FindElement(By.Id("idSIButton9"));
            }
        }
    }
}
