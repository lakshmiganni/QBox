using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SpecFlowProject1.Utils;
using SpecFlowProject1.Variables;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1.Drivers
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Firefox
    }
    public static class SeleniumDriver
    {
        static IWebDriver driver;
        public static ConfigSettings config = new ConfigSettings();
        
        //creating driver instance
        public static IWebDriver GetWebDriver()
        {
            if (driver != null) return driver;

            var driverToUse = SeleniumDriver.config.DriverToUse;

            switch (driverToUse)
            {
                case DriverToUse.InternetExplorer:
                    new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver();
                    break;
                case DriverToUse.Firefox:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case DriverToUse.Chrome:
                default:

                    ChromeOptions chromeOptions = new ChromeOptions();
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                
            }
            driver.Manage().Window.Maximize();
            return driver;
        }

       //closing the driver
       public static void TearDown()
       {
          driver.Quit();
          driver = null;
        }
    }
}
