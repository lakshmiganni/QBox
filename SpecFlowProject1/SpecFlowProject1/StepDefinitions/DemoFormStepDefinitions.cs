using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.PageObjects;
using SpecFlowProject1.Utils;
using System;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1.StepDefinitions
{
    
    [Binding]
    public class DemoFormStepDefinitions : BaseStepDefinitions
    {
        Utilities utilities = new Utilities();
        long startTime;
        long endTime;

        [Given(@"I navigated to the url")]
        public void GivenINavigatedToTheUrl()
        {
            startTime = DateTime.Now.Millisecond;
            landingPage.GoToUrl(); 
        }

        [When(@"I click on See a Demo button")]
        public void WhenIClickOnSeeADemoButton()
        {
            landingPage.clickDemoButton();
        }

        [Then(@"I navigated to the Demo form Modal with title ""([^""]*)""")]
        public void ThenINavigatedToTheDemoFormModalWithTitle(string demoFormTitle)
        {
            Assert.IsTrue((demoFormPage.demoFormModalText()).Contains(demoFormTitle));
        }

        [When(@"I select reCAPTCHA checkbox")]
        public void WhenISelectReCAPTCHACheckbox()
        {
            demoFormPage.clickCaptchaCheckBox();
        }

        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            demoFormPage.clickSubmit();
        }

        [Then(@"I should see an error message for all the mandatory fields as ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessageForAllTheMandatoryFieldsAs(string errMsg)
        {
            Assert.AreEqual(errMsg, demoFormPage.emailErrorMsgText());
            Assert.AreEqual(errMsg, demoFormPage.firstNameErrorMsgText());
            Assert.AreEqual(errMsg, demoFormPage.lastNameErrorMsgText());
            Assert.AreEqual(errMsg, demoFormPage.jobTitleErrorMsgText());
            Assert.AreEqual(errMsg, demoFormPage.industryErrorMsgText());
        }

        [When(@"I enter field Company Email Address as ""([^""]*)""")]
        public void WhenIEnterFieldCompanyEmailAddressAs(string companyEmail)
        {
            demoFormPage.enterCompanyEmailAddress(companyEmail);
        }

        [When(@"I enter field First Name as ""([^""]*)""")]
        public void WhenIEnterFieldFirstNameAs(string firstName)
        {
            demoFormPage.enterFirstName(firstName);
        }

        [When(@"I enter field Last Name as ""([^""]*)""")]
        public void WhenIEnterFieldLastNameAs(string lastName)
        {
            demoFormPage.enterLastName(lastName);        
        }

        [When(@"I enter field Job Title as ""([^""]*)""")]
        public void WhenIEnterFieldJobTitleAs(string jobTitle)
        {
            demoFormPage.enterJobTitle(jobTitle);
        }

        [When(@"I enter field Industry as ""([^""]*)""")]
        public void WhenIEnterFieldIndustryAs(string industry)
        {
            demoFormPage.enterIndustry(industry);
        }

        [Then(@"I should see company email error message as ""([^""]*)""")]
        public void ThenIShouldSeeCompanyEmailErrorMessageAs(string errMsg)
        {
            Assert.AreEqual(errMsg, demoFormPage.emailFormatErrorMsgText());
        }
    }
}
