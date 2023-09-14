using OneTaskList.Automation.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;

namespace OneTaskList.Automation
{
    [Trait("Category", "Applications")]
    public class OneTaskListAutomationTests : IDisposable, IClassFixture<WebsiteFixture>
    {
        private bool disposedValue;
        private readonly WebsiteFixture websiteFixture;

        public OneTaskListAutomationTests(WebsiteFixture websiteFixture)
        {
            try
            {
                TestHelper.Pause(2000);

                this.websiteFixture = websiteFixture;

                var page = new TasksPage(this.websiteFixture.Driver);

                page.LeftNav.CreateNewBoard();
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("constructor");
                throw;
            }
        }

        [Fact]
        public void BoardCreationAndDeletionTest()
        {
            try
            {
                var tasksPage = new TasksPage(this.websiteFixture.Driver);

                var navItemsBefore = this.websiteFixture.Driver.FindElements(By.CssSelector(".sidebar-nav .nav-item"));

                tasksPage.LeftNav.CreateNewBoard();

                tasksPage.TopNav.OpenTasksTab();

                tasksPage.ToDoDoneBoardTemplateButton.Click();

                TestHelper.Pause(1000);

                var navItemsAfter = this.websiteFixture.Driver.FindElements(By.CssSelector(".sidebar-nav .nav-item"));
                Assert.NotEqual(navItemsBefore.Count, navItemsAfter.Count);

                DeleteBoard();

                TestHelper.Pause(1000);

                var navItemsAfterDelete = this.websiteFixture.Driver.FindElements(By.CssSelector(".sidebar-nav .nav-item"));
                Assert.Equal(navItemsBefore.Count, navItemsAfterDelete.Count);
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("BoardCreationAndDeletionTest");
                throw;
            }
            
        }

        [Fact]
        public void NewColumnCreationEditAndDeletion()
        {
            try
            {
                var tasksPage = new TasksPage(this.websiteFixture.Driver);
                var columnSettings = new ColumnSettings(this.websiteFixture.Driver);

                tasksPage.TopNav.OpenTasksTab();

                tasksPage.ToDoDoneBoardTemplateButton.Click();

                var newColumnName = Guid.NewGuid().ToString();

                tasksPage.NewColumnButton.Click();

                var column5 = tasksPage.Columns[4];

                var nameBeforeChange = column5.ColumnName.Text;

                column5.ContextMenuButton.Click();
                column5.EditColumnButton.Click();

                columnSettings.ColumnNameInput.Clear();
                columnSettings.ColumnNameInput.SendKeys(newColumnName);
                columnSettings.ColumnSettingsSaveButton.Click();

                var nameAfterFirstChange = tasksPage.Columns[4].ColumnName.Text;
                Assert.NotEqual(nameAfterFirstChange, nameBeforeChange);

                column5.ContextMenuButton.Click();

                TestHelper.Pause(2000);

                column5.DeleteColumnDropDownButton.Click();

                tasksPage.ConfirmButton.Click();
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("NewColumnCreationEditAndDeletion");
                throw;
            }
        }

        [Fact]
        public void ChangingTaskCollumn()
        {
            try
            {
                var tasksPage = new TasksPage(this.websiteFixture.Driver);

                tasksPage.TopNav.OpenTasksTab();

                tasksPage.ToDoDoneBoardTemplateButton.Click();

                var newTaskName = Guid.NewGuid().ToString();

                var firstColumn = tasksPage.Columns[0];
                firstColumn.AddTask(newTaskName);

                var firstCard = firstColumn.TaskCards[0];
                firstCard.ContextMenuButton.Click();
                firstCard.TaskEditButton.Click();
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("ChangingTaskCollumn");
                throw;
            }
        }

        [Fact]
        public void TaskCreationEditAndDeletionTest()
        {
            try
            {
                var tasksPage = new TasksPage(this.websiteFixture.Driver);

                tasksPage.TopNav.OpenTasksTab();

                tasksPage.ToDoDoneBoardTemplateButton.Click();

                var newTaskName = Guid.NewGuid().ToString();

                var firstColumn = tasksPage.Columns[0];
                firstColumn.AddTask(newTaskName);

                var firstCard = firstColumn.TaskCards[0];
                firstCard.ContextMenuButton.Click();
                firstCard.TaskEditButton.Click();

                var taskSettings = new TaskSettings(this.websiteFixture.Driver);
                taskSettings.NewTaskNameInput.Clear();
                taskSettings.NewTaskNameInput.SendKeys(newTaskName);
                taskSettings.SaveAndCloseButton.Click();

                firstCard.ContextMenuButton.Click();
                firstCard.TaskHideArchiveButton.Click();

                tasksPage.TopNav.OpenHiddenTasksTab();

                this.websiteFixture.Driver.FindElement(By.XPath("/html/body/app-dashboard/div/main/app-board/div/app-archive/div/div/table/tbody/tr/td[1]"));
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("TaskCreationEditAndDeletionTest");
                throw;
            }
        }

        [Fact]
        public void BoardSettingsChangeTest()
        {
            try
            {
                var model = new BoardSettingsPage(this.websiteFixture.Driver);

                TestHelper.Pause(1000);

                model.NavigateTo();

                var newName = Guid.NewGuid().ToString();

                model.BoardNameInput.Clear();

                model.BoardNameInput.SendKeys(newName);

                model.SaveButton.Click();

                var title = this.websiteFixture.Driver.FindElement(By.LinkText(newName));
                Assert.NotNull(title);
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("BoardSettingsChangeTest");
                throw;
            }
        }

        private void DeleteBoard()
        {
            try
            {
                var boardSettingsPage = new BoardSettingsPage(this.websiteFixture.Driver);

                TestHelper.Pause(2000);

                boardSettingsPage.TopNav.OpenSettingsTab();

                TestHelper.Pause(2000);

                boardSettingsPage.DeleteButton.Click();

                TestHelper.Pause(3000);

                boardSettingsPage.ConfirmDeleteButton.Click();
            }
            catch
            {
                this.websiteFixture.Driver.TakeScreenshot("DeleteBoard");
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                this.DeleteBoard();
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
