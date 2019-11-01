using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizeTests
    {
        [TestMethod]
        public void EnumBitwiseOperation_ReturnsCorrectValue()
        {
            //Arrange

            //Act

            //Assert
            Assert.AreEqual("0", Sizes.None);
            Assert.AreEqual("1", Sizes.Small);
            Assert.AreEqual("2", Sizes.Medium);
            Assert.AreEqual("4", Sizes.Large);

        }
    }
}
