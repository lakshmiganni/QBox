using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject1.Utils
{
    public class Utilities
    {
        public void waitForElementClickable(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                Assert.False(false, "Failed the test-");
            }
        }

        public void waitForElementVisibility(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible((By)element));
            }
            catch(Exception)
            {
                Assert.False(false, "Failed the test-");
            }
        }

        //get text from an element
        public String getTextFromElement(IWebDriver driver, IWebElement element)
        {
            waitForElementVisibility(driver, element);
            return element.Text;
        }

        //enter value to a text field
        public void writeText(IWebElement element, String value)
        {
            element.SendKeys(value);
            try
            {
                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         * 
         * 
         * 
                     * long startTime = System.currentTimeMillis();

            driver.get("http://zyxware.com");

            new WebDriverWait(driver, 10).until(ExpectedConditions.

            presenceOfElementLocated(By.id("Calculate")));

            long endTime = System.currentTimeMillis();

            long totalTime = endTime - startTime;

            System.out.println("Total Page Load Time: " + totalTime + "

            milliseconds");

         */

        public void WaitForPageToLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement page = driver.FindElement(By.TagName("html"));
            try
            {
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception pageLoadWaitError)
            {
                throw new TimeoutException("Timeout during page load", pageLoadWaitError);
            }
        }


        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string scenarioName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, scenarioName).Build();
        }

        public string CaptureScreenShot(IWebDriver driver)
        {
            return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }
    }
}
