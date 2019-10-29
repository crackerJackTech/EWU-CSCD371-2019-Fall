using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    public class MockConfig : IConfig
    {
        public List<(string, string?)> ConfigData { get; }

        public MockConfig()
        {
            ConfigData = new List<(string, string?)>
            {
                ("testName1", "testValue1"),
                ("testName2", "testValue2"),
                ("testName3", "testValue3"),
                ("testName4", "testValue4"),
                ("testName5", "testValue5"),
                ("testName6", "testValue6"),

            };
        }
        
        public bool GetConfigValue(string name, out string? value)
        {
            if(name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            foreach ((string, string) element in ConfigData)
            {
                if(name.Equals(element.Item1))
                {
                    value = element.Item2;
                    return true;
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null || value is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            ConfigData.Add((name, value));
            return true;
        }
    }
}
