using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_ItemListIsNull_ThrowsException()
        {
            //Arrange
            int[] testItems = null!;
            //Act
            SortUtility.InsertionSort(testItems, delegate (int first, int second)
            {
                return first < second;
            });
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_SortingDelegateIsNull_ThrowsException()
        {
            //Arrange
            int[] testItems = new int[5]
            {
                1, 4, 60, 3, 40
            };
            //Act
            SortUtility.InsertionSort(testItems, null!);
            //Assert
        }

        [TestMethod]
        [DataRow(new int[] {9,8,7,5,3,6,4,2,1}, new int[] {1,2,3,4,5,6,7,8,9})]
        [DataRow(new int[] {5,5,5,5,5,4,4,3,1}, new int[] {1,3,4,4,5,5,5,5,5})]
        public void SortUtility_InsertionSortAscending_UsingAnAnonymousMethod(int[] unsortedArray, int[] sortedArray)
        {
            //Arrange

            //Act
            SortUtility.InsertionSort(unsortedArray, delegate (int first, int second)
            {
                return first > second;
            });

            //Assert
            CollectionAssert.AreEqual(sortedArray, unsortedArray);
        }

        [TestMethod]
        [DataRow(new int[] {1,2,3,4,5,6,7,8,9}, new int[] {9,8,7,6,5,4,3,2,1})]
        [DataRow(new int[] {1,1,1,1,11,1,1,2}, new int[] {11,2,1,1,1,1,1,1})]
        public void SortUtility_ShouldSortDecending_UsingALambdaExpression(int[] unsortedArray, int[] sortedArray)
        {
            //Arrange

            //Act
            SortUtility.InsertionSort(unsortedArray, (int i, int j) => i < j);

            //Assert
            CollectionAssert.AreEqual(sortedArray, unsortedArray);

        }

        [TestMethod]
        [DataRow(new int[] {70, 100, 50, 30, 5, 10}, new int[] {50, 30, 10, 5, 70, 100})]
        [DataRow(new int[] {100, 52, 51, 30, 50, 10, 5 }, new int[] { 50, 30, 10, 5, 51, 52, 100})]

        public void SortUtility_InsertionSortDecendingBelowFiftyAscendingAboveFifty_UsingALambdaStatement(int[] unsortedArray, int[] sortedArray)
        {
            //Arrange

            //Act
            SortUtility.InsertionSort(unsortedArray, (int first, int second) =>
            {
                if(first > 50)
                {
                    return first > second;
                }
                return first < second;
            });

            //Assert
            CollectionAssert.AreEqual(sortedArray, unsortedArray);
        }
    }
}
