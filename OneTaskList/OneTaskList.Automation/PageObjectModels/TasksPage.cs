using OpenQA.Selenium;
using System.Linq;

namespace OneTaskList.Automation.PageObjectModels
{

    internal class TasksPage : BasePage
    {
        public TasksPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TasksSearchBar
        {
            get
            {
                return Driver.WaitForElement(By.Id("TaskSearchInput"));
            }
        }

        public IWebElement NewColumnButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("AddStatusButton"));
            }
        }

        public TasksColumn[] Columns
        {
            get
            {
                return Driver.WaitForElements(By.TagName("app-column")).Select(e => new TasksColumn(e)).ToArray();
            }
        }

        public IWebElement ToDoDoneBoardTemplateButton
        {
            get
            {
                return Driver.WaitForElement(By.CssSelector("button.btn-primary"));
            }
        }
    }
}


