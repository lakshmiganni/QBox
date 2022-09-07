using SpecFlowProject1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Variables
{
    public class ConfigSettings
    {   
        public String url { get; set; }
        public DriverToUse DriverToUse { get; set; }
        public bool Debug { get; set; } = false;

        public string ReportPath { get; set; }

        public int ImplicitlyWait { get; set; }

        public int DriverTimeOutinSeconds { get; set; }
        public int PageLoadTimeout { get; set; }
    }
}


