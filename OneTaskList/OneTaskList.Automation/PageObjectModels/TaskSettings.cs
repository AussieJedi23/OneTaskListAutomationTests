using OpenQA.Selenium;

namespace OneTaskList.Automation.PageObjectModels
{
    public class TaskSettings
    {
        public TaskSettings(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public IWebElement NewTaskNameInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("Name"));
            }
        }

        public IWebElement SaveAndCloseButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("SaveAndCloseButton"));
            }
        }
    }
}


