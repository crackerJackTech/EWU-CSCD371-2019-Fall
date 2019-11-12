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
            var test1 = new ArrayCollection<int>(size);
            var test2 = new ArrayCollection<string>(size);
            var test3 = new ArrayCollection<long>(size);
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
            var _ = new ArrayCollection<string>(sizeOfArray)
            {
                "testString1"
            };
            //Act

            //Assert
        }

        [TestMethod]
        public void Constructor_SupportsCollectionInitializationWithEqualSizeAndData_Success()
        {
            //Arrange
            var sizeOfArray = 1;

            //Act
            var testArray = new ArrayCollection<string>(sizeOfArray)
            {
                "testString1",
            };

            //Assert
            Assert.AreEqual(1, testArray.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_ItemsNotContainedInCurrentArrayIsNull_ThrowsException()
        {
            //Arrange
            var testArray = new ArrayCollection<string>(1)
            {
                "testString1"
            };
            //Act
            testArray.Contains(null!);
            //Assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Contains_ItemDoesntExistInArray_ThrowsException()
        {
            //Arrange
            var testArray = new ArrayCollection<string>(1)
            {
                "testString1"
            };
            //Act
            testArray.Contains("testString2");
            //Assert

        }

        [TestMethod]
        public void GetEnumerator_SupportsForEachLoopEnumeratingOverArray_Success()
        {
            //Arrange
            var numberOfItemsInArray = 3;
            string arrayResult = "";
            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString1",
                "testString2",
                "testString3"
            };

            foreach (string value in testArray)
            {
                arrayResult += value + " ";
            }


            //Assert
            Assert.AreEqual("testString1 testString2 testString3 ", arrayResult);
        }

        [TestMethod]
        public void Clear_RemovesAllContentsForEmptyArray_ReturnsTrue()
        {
            //Arrange
            var numberOfItemsInArray = 0;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {

            };

            testArray.Clear();

            //Assert
            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void Clear_RemovesAllContentsInArray_ReturnsTrue()
        {
            //Arrange
            var numberOfItemsInArray = 3;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString1",
                "testString2",
                "testString3"
            };

            testArray.Clear();

            //Assert
            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void IndexingOperator_UsingBracketForElementLocationInArray_Success()
        {
            //Arrange
            var numberOfItemsInArray = 1;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString"
            };

            //Assert
            Assert.AreEqual("testString", testArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexingOperator_VariableAssignedInvalid_ThrowsException()
        {
            //Arrange
            var numberOfItemsInArray = 0;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {

            };
            _ = testArray[1];
            //Assert
        }

        [TestMethod]
        public void Remove_ArrayRemovesValidItemInArray_Success()
        {
            //Arrange
            var numberOfItemsInArray = 1;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString1"
            };



            //Assert
            Assert.IsTrue(testArray.Remove("testString1"));
            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void Remove_ArrayRemovesIncorrectDateValue_ThrowsException()
        {
            //Arrange
            var numberOfItemsInArray = 1;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString1"
            };

            //Assert
            Assert.IsFalse(testArray.Remove("testString2"));
            Assert.AreEqual(1, testArray.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_ArrayRemovesNullValue_ThrowsException()
        {
            //Arrange
            var numberOfItemsInArray = 1;

            //Act
            var testArray = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testString1"
            };

            testArray.Remove(null!);

            //Assert
        }

        [TestMethod]
        public void CopyTo_CopyContentsFromFilledArrayToEmptyArray_Success()
        {
            //Arrange
            const int numberOfItemsInArray = 1;
            //Act
            var testArray1 = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testStringInStringTypeArray"
            };

            string[] arrayWithCopiedValues = new string[numberOfItemsInArray];


            testArray1.CopyTo(arrayWithCopiedValues, 0);


            //Assert
            Assert.AreEqual(testArray1[0], arrayWithCopiedValues[0]);
        }

        [TestMethod]
        public void CopyTo_CopyContentsFromFilledArrayToNullDataArray_Success()
        {
            //Arrange
            const int numberOfItemsInArray = 1;

            //Act
            var testArray1 = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testStringInStringTypeArray"
            };

            string[] arrayWithCopiedValues = new string[numberOfItemsInArray]
            {
                null!
            };

            testArray1.CopyTo(arrayWithCopiedValues, 0);

            //Assert
            Assert.AreEqual("testStringInStringTypeArray", arrayWithCopiedValues[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_CopyContentFromFilledArrayAtIncorrectIndex_Fails()
        {
            //Arrange
            const int numberOfItemsInArray = 1;

            //Act
            var testArray1 = new ArrayCollection<string>(numberOfItemsInArray)
            {
                "testStringInStringTypeArray"
            };

            string[] arrayWithCopiedValues = new string[numberOfItemsInArray]
            {
                "testStringInStringArray"
            };

            testArray1.CopyTo(arrayWithCopiedValues, 1);
            //Assert
        }






    }
}
