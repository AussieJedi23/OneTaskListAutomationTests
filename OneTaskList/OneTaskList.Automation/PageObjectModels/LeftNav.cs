using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class LeftNav
    {
        protected IWebDriver Driver;

        public LeftNav(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void CreateNewBoard()
        {
            this.NewBoardButton.Click();
            TestHelper.Pause(2000);
        }

        private IWebElement NewBoardButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("NewBoardLink"));
            }
        }
        
        public ReadOnlyCollection<IWebElement> BoardLinks
        {
            get
            {
                return Driver.WaitForElements(By.CssSelector("[id^=BoardLink_]"));
            }
        }
    }
}