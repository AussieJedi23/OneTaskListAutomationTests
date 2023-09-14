using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class TaskCard
    {
        public TaskCard(IWebElement webElement)
        {
            WebElement = webElement;
        }

        public IWebElement WebElement { get; }

        public IWebElement ContextMenuButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".task-context-menu-button"));
            }
        }

        public IWebElement TaskEditButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".edit-task-link"));
            }
        }

        public IWebElement TaskHideArchiveButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".archive-task-link"));
            }
        }
    }
}


