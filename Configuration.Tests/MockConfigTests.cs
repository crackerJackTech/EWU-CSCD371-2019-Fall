using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [TestMethod]
        [DataRow("testName100", "testValue100")]
        [DataRow("testName200", "testValue200")]
        [DataRow("testName300", "testValue300")]
        [DataRow("testName400", "testValue400")]
        [DataRow("testName500", "testValue500")]
        public void MockConfig_EnteringNewValidData_ReturnsFalse(string name, string? value)
        {
            MockConfig mockConfig = new MockConfig();
            Assert.IsFalse(mockConfig.GetConfigValue(name, out _));
        }
    }
}
