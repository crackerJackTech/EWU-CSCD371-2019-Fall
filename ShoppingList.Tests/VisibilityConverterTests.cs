using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class VisibilityConverterTests : VisibilityConverter
    {
        [TestMethod]
        public void Convert_ValueGivenIsValid_ReturnsTestName()
        {
            //Arrange
            var testItem = new ShoppingListItem("testName");
            //Act
            Object result = Convert(testItem.ListItemName, testItem.GetType(), null, CultureInfo.CurrentCulture);
            //Assert
            Assert.AreEqual(testItem.ListItemName, result);
            
        }

        [TestMethod]
        public void Convert_ValueGivenIsNull_ReturnsVisibilityCollapsed()
        {
            //Arrange
            var testItem = new ShoppingListItem("testName");
            //Act
            Object result = Convert(null, testItem.GetType(), null, CultureInfo.CurrentCulture);
            //Assert
            Assert.AreEqual<string>("Collapsed", result.ToString());
        }

        [TestMethod]
        public void ConvertBack_ArgumentsGivenAreValid_ReturnsNull()
        {
            //Arrange
            var testItem = new ShoppingListItem("testName");
            //Act
            Object result = ConvertBack(null, testItem.GetType(), null, CultureInfo.CurrentCulture);
            //Assert
            Assert.IsNull(result);
        }
    }
}
