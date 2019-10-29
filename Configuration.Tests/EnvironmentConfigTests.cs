using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests : EnvironmentConfig
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValue_NameIsNull_ThrowsArgumentNullException()
        {
            //Arrange

            //Act
            GetConfigValue("", out string? value);

            //Assert

        }

        [TestMethod]
        public void GetConfigValue_NameIsValid_ReturnsTrue()
        {
            //Arrange
            Environment.SetEnvironmentVariable("testName", "testValue");
            
            //Act


            //Assert
            Assert.IsTrue(GetConfigValue("testName", out string? value));
        }



        [TestMethod]
        public void SetConfigValue_NameIsNull_ReturnsFalse()
        {
            //Arrange
            bool value = false;
            //Act
            value = SetConfigValue(null, "Hello");
            //Assert
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void SetConfigValue_NameIsValid_ReturnsTrue()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsTrue(SetConfigValue("testName", "testValue"));
        }
    }
}
