using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorHasNullPerson_ThrowsArgumentNullException()
        {
            //Arrange
            var mailbox = new Mailbox(new Person(null, null), (0, 0), Sizes.None);
            //Act

            //Assert
        }

        [TestMethod]
        public void MailboxToStringHasSmallSize_IsEqual()
        {
            //Arrange
            var mailbox = new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.None);
            //Act

            //Assert
            Assert.AreEqual("Kramer, Devin 0,0", mailbox.ToString());
        }

        [TestMethod]
        public void MailboxToStringHasLargePremiumSize_IsEqual()
        {
            //Arrange
            var mailbox = new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.PremiumLarge);
            //Act

            //Assert
            Assert.AreEqual("Kramer, Devin 0,0 Large Premium", mailbox.ToString());
        }
    }
}
