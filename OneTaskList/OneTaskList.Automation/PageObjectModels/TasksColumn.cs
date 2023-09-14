using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class TasksColumn
    {
        public TasksColumn(IWebElement webElement)
        {
            WebElement = webElement;
        }

        public IWebElement WebElement { get; }

        public IWebElement ContextMenuButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".status-menu-dropdown-button"));
            }
        }

        public IWebElement EditColumnButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".edit-status-link"));
            }
        }

        public IWebElement DeleteColumnDropDownButton
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".delete-status-link"));
            }
        }

        public IWebElement ColumnName
        {
            get
            {
                return WebElement.WaitForElement(By.CssSelector(".status-name"));
            }
        }

        public IWebElement NewTaskNameInput
        {
            get
            {
                return WebElement.WaitForElement(By.Id("NewTaskText"));
            }
        }

        public IWebElement CreateTaskButton
        {
            get
            {
                return WebElement.WaitForElement(By.Id("AddTaskButton"));
            }
        }

        public void AddTask(string taskName)
        {
            this.NewTaskNameInput.SendKeys(taskName);
            this.CreateTaskButton.Click();
        }

        public TaskCard[] TaskCards
        {
            get
            {
                return WebElement.WaitForElements(By.CssSelector(".task-card")).Select(e => new TaskCard(e)).ToArray();
            }
        }
    }
}


