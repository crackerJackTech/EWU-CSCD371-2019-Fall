using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingListItemTests
    {
        [TestMethod]
        public void Constructor_ShoppingListItemCreatedWithValidInput_Success()
        {
            //Arrange
            var testItem = new ShoppingListItem("testName");
            //Act

            //Assert
            Assert.IsNotNull(testItem);
            Assert.AreEqual<string>("testName", testItem.ListItemName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ShoppingListItemCreatedWithInvalidInput_Throws()
        {
            //Arrange
            var testItem = new ShoppingListItem(null);
            //Act

            //Assert
        }

        [TestMethod]
        public void ToString_ObjectReturnsCorrectFormat_Success()
        {
            //Arrange
            var testItem = new ShoppingListItem("testName");
            //Act
            var expectedResult = "testName";
            //Assert
            Assert.AreEqual<string>(expectedResult, testItem.ListItemName);
        }
    }
}
