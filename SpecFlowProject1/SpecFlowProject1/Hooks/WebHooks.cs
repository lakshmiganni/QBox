using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Utils;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class WebHooks : BasePage
    {
        public static IWebDriver _driver;

        public static WebDriverWait wait;
        private static Utilities common = new Utilities();


        public static ConfigurationBuilder builder = new ConfigurationBuilder();

        //report setup
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        [BeforeScenario]
        public static void BeforeScenario()
        {
           _driver = SeleniumDriver.GetWebDriver();
           wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(SeleniumDriver.config.DriverTimeOutinSeconds));
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        { 

            //read Config file
            String configSettingPath = Directory.GetParent(@"../../../").FullName
                                      + Path.DirectorySeparatorChar + "Configuration\\test.json";


            builder.AddJsonFile(configSettingPath);

            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(SeleniumDriver.config);

            //report setup
            var htmlReporter = new ExtentHtmlReporter(SeleniumDriver.config.ReportPath);

            htmlReporter.Config.Theme = Theme.Dark;
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [AfterScenario]
        public static void After()
        {
            SeleniumDriver.TearDown();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
                extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //report setup
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            //report setup
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            //report setup
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                string media = string.Empty;

                if (SeleniumDriver.config.Debug)
                {
                    media = common.CaptureScreenShot(_driver);
                }

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromBase64String(media);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromBase64String(media);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromBase64String(media);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromBase64String(media);
            }
            else if (scenarioContext.TestError != null)
            {
                var media = common.CaptureScreenShot(_driver, scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, media);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, media);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, media);
            }
            else if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }
    }







    }
