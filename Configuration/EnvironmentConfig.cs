using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        
        
        public bool GetConfigValue(string name, out string? value)
        {

            value = Environment.GetEnvironmentVariable(name) ?? throw new ArgumentNullException(name);
            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(name is null || value is null)
            {
                return false;
            }
            
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
