using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace OneTaskList.Automation.PageObjectModels
{
    internal abstract class BasePage
    {
        protected IWebDriver Driver;
        private LeftNav leftNav;
        private readonly TopNav topNav;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.topNav = new TopNav(driver);
            this.leftNav = new LeftNav(driver);

            TestHelper.Pause(1000);
        }

        public TopNav TopNav => topNav;
        public LeftNav LeftNav => leftNav;

        public IWebElement ConfirmButton
        {
            get
            {
                return Driver.FindElement(By.Id("ConfirmButton"));
            }
        }
    }
}