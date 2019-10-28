using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LogFactory_NotConfigured_ReturnsNull()
        {
            LogFactory factory = new LogFactory();

            var logger = factory.CreateLogger(nameof(LogFactoryTests));

            Assert.IsNull(logger);
        }

        [TestMethod]
        public void LogFactory_FactoryCreated_ReturnsFileLogger()
        {
            LogFactory logFactory = new LogFactory();
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            logFactory.ConfigureFileLogger(filePath);

            BaseLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            Assert.IsTrue(logger is FileLogger);
            Assert.AreEqual(nameof(LogFactoryTests), logger.ClassName);
        }
    }
}
