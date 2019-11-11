using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Arrays.Tests
{
    [TestClass]
    public class ArrayTests
    {

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(100)]
        public void Constructor_SizeHasCorrectValue_ArraysAreCreated(int size)
        {
            //Arrange
            var test1 = new Array<int>(size);
            var test2 = new Array<string>(size);
            var test3 = new Array<long>(size);
            //Act

            //Assert
            Assert.AreEqual(test1.Capacity, size);
            Assert.AreEqual(test2.Capacity, size);
            Assert.AreEqual(test3.Capacity, size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InitializedArrayWithMoreDataThanSize_ThrowsException()
        {
            //Arrange
            var sizeOfArray = 0;
            var testArray = new Array<string>(sizeOfArray)
            {
                "testString1"
            };
            //Act

            //Assert
        }

        [TestMethod]
        public void Constructor_SupportsCollectionInitialization_Success()
        {
            //Arrange
            var sizeOfArray = 1;

            //Act
            var testArray = new Array<string>(sizeOfArray)
            {
                "testString1",
            };

            //Assert
            Assert.AreEqual(1, testArray.Count);
        }






    }
}
