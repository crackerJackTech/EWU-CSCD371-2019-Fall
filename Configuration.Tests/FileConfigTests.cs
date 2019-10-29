using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileConfig_ValidConstructor_ThrowsException()
        {
            //Arrange

            //Act
            _ = new FileConfig(null);
            //Assert

        }


        [TestMethod]
        public void GetConfigValue_NameMatchesValueInFile_ReturnsTrue()
        {
            //Arrange
            string filePath = Directory.GetCurrentDirectory() + "\\config.settings";
            var file = File.Create(filePath);
            file.Close();

            //Act
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write("testName=testValue");
                streamWriter.Close();
            }
            FileConfig fileConfig = new FileConfig(filePath);

            //Assert
            Assert.IsTrue(fileConfig.GetConfigValue("testName", out string? value));
            
            
            File.Delete(filePath);

        }

        [TestMethod]
        public void GetConfigValue_NameDoesNotMatchValueInFile_ReturnsFalse()
        {
            //Arrange
            string filePath = Directory.GetCurrentDirectory() + "\\config.settings";
            var file = File.Create(filePath);
            file.Close();


            //Act
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write("testName=testValue");
                streamWriter.Close();
            }
            FileConfig fileConfig = new FileConfig(filePath);

            //Assert
            Assert.IsFalse(fileConfig.GetConfigValue("randomTestName", out string? value));

            File.Delete(filePath);

        }

        [TestMethod]
        public void SetFileConfig_NameUpdatedWithNewValue_ReturnsTrue()
        {
            //Arrange
            string filePath = Directory.GetCurrentDirectory() + "\\config.settings";
            var file = File.Create(filePath);
            file.Close();


            //Act
            FileConfig fileConfig = new FileConfig(filePath);

            //Assert
            fileConfig.SetConfigValue("testName", "testValue");
            Assert.IsTrue(fileConfig.SetConfigValue("testName", "aNewTestValue"));


            File.Delete(filePath);

        }

        [TestMethod]
        public void SetFileConfig_FileNotFound_ReturnsFalse()
        {
            //Arrange
            string filePath = Directory.GetCurrentDirectory() + "\\config.settings";
            var file = File.Create(filePath);
            file.Close();


            //Act
            FileConfig fileConfig = new FileConfig(filePath);

            //Assert
            fileConfig.SetConfigValue("testName", "testValue");
            Assert.IsTrue(fileConfig.SetConfigValue("testName", "aNewTestValue"));


            File.Delete(filePath);

        }
    }
}
