using Configuration;
using Configuration.Tests;
using System;
using System.Collections.Generic;
using System.IO;

namespace SampleApp
{
    public class Program
    {

        public static void Main()
        {
          
            MockConfig mockConfig = new MockConfig();

            foreach((string, string?) elements in mockConfig.ConfigData)
            {
                mockConfig.GetConfigValue(elements.Item1, out string? value);
                Console.WriteLine($"{elements.Item1}={value}");
            }
        }
    }
}
