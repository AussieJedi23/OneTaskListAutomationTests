using OneTaskList.Automation.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace OneTaskList.Automation
{
    public class WebsiteFixture : IDisposable
    {
        public ChromeDriver Driver;
        private bool disposedValue;

        public WebsiteFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");

            this.Driver = new ChromeDriver(options);

            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            this.Login();
        }

        private void Login()
        {
            var configuration = TestHelper.GetIConfigurationBase();
            var page = new LoginProcess(this.Driver);

            this.Driver.Navigate().GoToUrl(configuration["LoginUrl"]);

            this.Driver.Manage().Window.Maximize();

            page.MicrosoftLogin.Click();

            TestHelper.Pause(1000);

            page.EmailInput.SendKeys(configuration["Email"]);

            page.NextButton.Click();

            TestHelper.Pause(1000);

            page.PasswordInput.SendKeys(configuration["Password"]);

            page.SignInButton.Click();

            TestHelper.Pause(1000);

            page.StaySignedInButton.Click();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Driver.Dispose();
                    this.Driver.Quit();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
