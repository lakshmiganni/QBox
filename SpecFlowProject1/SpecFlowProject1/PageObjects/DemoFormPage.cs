using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProject1.Utils;

namespace SpecFlowProject1.PageObjects
{

    public class DemoFormPage : BasePage
    {
        Utilities utils = new Utilities();

        //DemoModal
        [FindsBy(How = How.ClassName, Using = "request-demo-form")]
        private IWebElement demoFormModal { get; set; }

        //reCaptcha Checkbox
        [FindsBy(How = How.ClassName, Using = "recaptcha-checkbox-border")]
        private IWebElement reCaptchaChkBox { get; set; }

        //Submit button
        [FindsBy(How = How.Id, Using = "btnSubmitDemo")]
        private IWebElement submitBtn { get; set; }

        //See a demo
        [FindsBy(How = How.XPath, Using = "//div[@class = 'form request-demo-form']/h4")]
        private IWebElement seeDemoText { get; set; }

        //EmailErrorMessage
        [FindsBy(How = How.Id, Using = "email-demo-error-msg")]
        private IWebElement emailComapnyErrMsg { get; set; }


        //EmailErrorMessageLabel
        [FindsBy(How = How.Id, Using = "email-demo-error")]
        private IWebElement emailError { get; set; }

        //FirstNameErrorMessage
        [FindsBy(How = How.Id, Using = "firstname-demo-error")]
        private IWebElement firstNameError { get; set; }

        //LastNameErrorMessage
        [FindsBy(How = How.Id, Using = "lastname-demo-error")]
        private IWebElement lastNameError { get; set; }

        //jobTitleErrorMessage
        [FindsBy(How = How.Id, Using = "jobtitle-demo-error")]
        private IWebElement jobTitleError { get; set; }

        //industryDemoErrorMessage
        [FindsBy(How = How.Id, Using = "industry-demo-error")]
        private IWebElement industryError { get; set; }

        //Company email address text field
        [FindsBy(How = How.Id, Using = "email-demo")]
        private IWebElement companyEmailAddress { get; set; }

        //First Name text field
        [FindsBy(How = How.Id, Using = "firstname-demo")]
        private IWebElement firstName { get; set; }

        //Last Name text field
        [FindsBy(How = How.Id, Using = "lastname-demo")]
        private IWebElement lastName { get; set; }

        //Job title text field
        [FindsBy(How = How.Id, Using = "jobtitle-demo")]
        private IWebElement jobTitle { get; set; }

        //Industry text field
        [FindsBy(How = How.Id, Using = "industry-demo")]
        private IWebElement industry { get; set; }

       // String firstName_Input = _driver.FindElement(By.Id("firstname-demo"));

        public void clickCaptchaCheckBox()
        {
            utils.waitForElementVisibility(_driver, demoFormModal);

            _driver.SwitchTo().Frame(_driver.FindElement(By.CssSelector("iframe[title*='reCAPTCHA']")));
            utils.waitForElementClickable(_driver, reCaptchaChkBox);
            reCaptchaChkBox.Click();
            _driver.SwitchTo().DefaultContent();
        }

        public void clickSubmit()
        {
            utils.waitForElementClickable(_driver, submitBtn);
            submitBtn.Click();
        }

        public String demoFormModalText()
        {
           return utils.getTextFromElement(_driver, seeDemoText);
        }

        public String emailErrorMsgText()
        {
            return utils.getTextFromElement(_driver, emailError);           
        }

        public String emailFormatErrorMsgText()
        {
            return utils.getTextFromElement(_driver, emailComapnyErrMsg);
        }
        public String firstNameErrorMsgText()
        {
            return utils.getTextFromElement(_driver, firstNameError);
        }

        public String lastNameErrorMsgText()
        {
            return utils.getTextFromElement(_driver, lastNameError);          
        }

        public String jobTitleErrorMsgText()
        {
            return utils.getTextFromElement(_driver, jobTitleError);           
        }

        public String industryErrorMsgText()
        {
            return utils.getTextFromElement(_driver, industryError);
        }

        public void enterCompanyEmailAddress(String value)
        {
            utils.writeText(companyEmailAddress, value);
        }
        public void enterFirstName(String value)
        {
            utils.writeText(firstName, value);
        }
        public void enterLastName(String value)
        {
            utils.writeText(lastName, value);
        }
        public void enterIndustry(String value)
        {
            utils.writeText(industry, value);
        }
        public void enterJobTitle(String value)
        {
            utils.writeText(jobTitle, value);
        }

    }
}
