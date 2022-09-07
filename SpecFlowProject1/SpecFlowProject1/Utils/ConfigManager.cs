using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Utils
{
    public static class ConfigManager
    {
        public static T Get<T>(string name)
        {
            try {
                var value = ConfigurationManager.AppSettings[name];
                if (string.IsNullOrEmpty(value)) throw new ConfigurationErrorsException("Invalid Config Key");

                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), value);
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch(Exception ex)
            {
                throw new ConfigurationErrorsException("Invalid Config Key"); ;
            }
            
        }
    }
}
