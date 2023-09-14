using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskList.Automation.PageObjectModels
{
    internal class HiddenTasksPage : BasePage
    {
        public HiddenTasksPage(IWebDriver driver) : base(driver)
        {
        }
    }
}