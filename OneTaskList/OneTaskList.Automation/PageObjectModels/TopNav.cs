using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class TopNav
    {
        protected IWebDriver Driver;

        public TopNav(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void OpenTasksTab()
        {
            this.TasksButton.Click();
            TestHelper.Pause(1000);
        }

        public void OpenConnectionsTab()
        {
            this.ConnectionsButton.Click();
            TestHelper.Pause(1000);
        }

        public void OpenNumbersTab()
        {
            this.NumbersButton.Click();
            TestHelper.Pause(1000);
        }

        public void OpenHiddenTasksTab()
        {
            this.HiddenTasksButton.Click();
            TestHelper.Pause(1000);
        }

        public void OpenSettingsTab()
        {
            this.SettingsButton.Click();
            TestHelper.Pause(1000);
        }

        private IWebElement TasksButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("TasksLink"));
            }
        }

        private IWebElement ConnectionsButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("ConnectionsLink"));
            }
        }

        private IWebElement NumbersButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("NumbersLink"));
            }
        }

        private IWebElement HiddenTasksButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("HiddenTasksLink"));
            }
        }

        private IWebElement SettingsButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("SettingsLink"));
            }
        }

        public IWebElement UserMenuDropdownButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("userMenuDropdown"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("LogoutLink"));
            }
        }
    }
}