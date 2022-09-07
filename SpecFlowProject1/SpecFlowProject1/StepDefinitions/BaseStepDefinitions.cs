using SpecFlowProject1.PageObjects;
using SpecFlowProject1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    public class BaseStepDefinitions
    {
        protected Utilities utilities;
        protected LandingPage landingPage;
        protected DemoFormPage demoFormPage;


        public BaseStepDefinitions()
        {
            utilities = new Utilities();
            landingPage = new LandingPage();
            demoFormPage = new DemoFormPage();

        }

    }
}
