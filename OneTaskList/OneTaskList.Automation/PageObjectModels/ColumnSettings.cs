using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class ColumnSettings : BasePage
    {
        public ColumnSettings(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TasksSearchBar
        {
            get
            {
                return Driver.WaitForElement(By.Id("TaskSearchInput"));
            }
        }
        public IWebElement ColumnNameInput
        {
            get
            {
                return Driver.WaitForElement(By.Name("name"));
            }
        }

        public IWebElement ColumnSettingsSaveButton
        {
            get
            {
                return Driver.WaitForElement(By.Id("SaveButton"));
            }
        }
    }
}

