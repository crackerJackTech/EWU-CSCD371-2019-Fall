using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_FilePathIsNull_ThrowsException()
        {
            FileLogger fileLogger = new FileLogger(null);
        }

        public void FileLogger_ContainsData_WritesFile()
        {
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            sut.Log(LogLevel.Warning, "Test");

            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[0].Contains("Test"));
        }
    }
}
