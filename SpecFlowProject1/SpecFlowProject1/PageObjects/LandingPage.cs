using OpenQA.Selenium;
using SpecFlowProject1.Utils;
using System.Configuration;
using SeleniumExtras.PageObjects;
using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.PageObjects
{
    [Binding]
    public class LandingPage : BasePage
    {
        Utilities utils = new Utilities();

    
        //Demo button
        [FindsBy(How = How.XPath, Using = "//a[@title = 'See a demo']")]
        private IWebElement seeDemoBtn { get; set; }

        //cookie button
        [FindsBy(How = How.Id, Using = "btnCookieHide")]
        private IWebElement cookieBtn { get; set; }

        public void GoToUrl()
        {
            var url = "https://volume-cognisense-webapp-wwwuat.azurewebsites.net";//ConfigurationManager.AppSettings["URL"];
            _driver.Navigate().GoToUrl(url);
        }

        public void clickDemoButton()
        {
            if(cookieBtn.Displayed)
            {
                cookieBtn.Click();
            }
            utils.waitForElementClickable(_driver, seeDemoBtn);
            seeDemoBtn.Click();
        }
    }
}
