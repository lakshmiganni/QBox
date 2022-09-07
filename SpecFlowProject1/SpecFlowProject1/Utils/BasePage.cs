using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProject1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Utils
{
    public class BasePage
    {
        protected IWebDriver _driver;
        public BasePage()
        {
            this.setup();
        }

        public void setup()
        {
            this._driver = SeleniumDriver.GetWebDriver();
            PageFactory.InitElements(_driver, this);
        }

    }
}
