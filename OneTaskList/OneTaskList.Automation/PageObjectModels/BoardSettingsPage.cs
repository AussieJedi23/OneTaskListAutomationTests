using OpenQA.Selenium;
using System;

namespace OneTaskList.Automation.PageObjectModels
{
    class BoardSettingsPage : BasePage
    {
        public BoardSettingsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement BoardNameInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("Name"));
            }
        }

        public IWebElement DescriptionInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("Description"));
            }
        }

        public IWebElement IconTypeDropDown
        {
            get
            {
                return Driver.WaitForElement(By.Name("Type"));
            }
        }

        public IWebElement ImportFrequencyInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("RefreshFrequency"));
            }
        }

        public IWebElement HideTasksInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("AutoHideDoneTasksAfterDays"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("DeleteButton"));
            }
        }

        public IWebElement ConfirmDeleteButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("ConfirmButton"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("UpdateButton"));
            }
        }

        internal void NavigateTo()
        {
            IWebElement settingsButton =
                   Driver.WaitForElement(By.Id("SettingsLink"));
            settingsButton.Click();

            TestHelper.Pause(2000);
        }
    }
}
