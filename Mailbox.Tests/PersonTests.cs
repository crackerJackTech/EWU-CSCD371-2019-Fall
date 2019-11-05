using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithNullFirstName_ThrowsArgumentNullException()
        {
            //Arrange

            var person = new Person(null, "Kramer");

                              //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithNullLastName_ThrowsArgumentNullException()
        {
            //Arrange
            var person = new Person("Devin", null);
            //Act

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithNullFirstNameAndLastName_ThrowsArgumentNullException()
        {
            //Arrange
            var person = new Person(null, null);
            //Act

            //Assert
        }

        [TestMethod]
        public void EqualsMethodSamePersons_ReturnsTrue()
        {
            //Arrange
            var testPerson1 = new Person("Devin", "Kramer");
            var testPerson2 = new Person("Devin", "Kramer");
            //Act

            //Assert
            Assert.IsTrue(testPerson1.Equals(testPerson2));
        }

        [TestMethod]
        public void EqualsMethodNotSamePersons_ReturnsFalse()
        {
            //Arrange
            var testPerson1 = new Person("Devin", "Kramer");
            var testPerson2 = new Person("Angus", "Young");
            //Act

            //Assert
            Assert.IsFalse(testPerson1.Equals(testPerson2));
        }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}
