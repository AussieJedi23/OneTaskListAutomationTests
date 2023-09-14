using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace OneTaskList.Automation
{
    internal static class TestHelper
    {
        public static void Pause(int milliseconds = 3000)
        {
            Thread.Sleep(milliseconds);
        }

        public static IWebElement WaitForElement(this ISearchContext driver, By by)
        {
            bool retry = true;

            while (retry)
            {
                try
                {
                    return driver.FindElement(by);
                }
                catch (StaleElementReferenceException)
                {
                    retry = true;
                }
                catch (ElementClickInterceptedException)
                {
                    retry = true;
                }
                catch (NoSuchElementException)
                {
                    retry = false;
                }

                Pause(1000);
            }

            return null;
        }

        public static ReadOnlyCollection<IWebElement> WaitForElements(this ISearchContext searchContext, By by)
        {
            bool retry = true;

            while (retry)
            {
                try
                {
                    var result = searchContext.FindElements(by);

                    //if (result.Count() > 0)
                    {
                        return searchContext.FindElements(by);
                    }
                }
                catch (StaleElementReferenceException)
                {
                    retry = true;
                }
                catch (ElementClickInterceptedException)
                {
                    retry = true;
                }
                catch (NoSuchElementException)
                {
                    retry = false;
                }

                Pause(1000);
            }

            return null;
        }

        public static IConfigurationRoot GetIConfigurationBase()
        {
            return new ConfigurationBuilder()
            .AddJsonFile("config.json", optional: true)
            .AddUserSecrets("OneTaskList-Automation")
            .AddEnvironmentVariables()
            .Build();
        }

        public static void TakeScreenshot(this IWebDriver driver, string StepDescription)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var outputPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\Screenshots"));
            string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@outputPath + "\\" + dateTime + "_" + StepDescription + ".png", ScreenshotImageFormat.Png);
        }
    }
}
