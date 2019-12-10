using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private void OnTestMethod() { }
        
        
        [TestMethod]
        public void Constructor_MainWindowViewModelContainsCommands_Success()
        {
            //Arrange
            var testViewModel = new MainWindowViewModel();
            //Act
            Command AddListItemCommand = new Command(OnTestMethod);
            Command RemoveListItemCommand = new Command(OnTestMethod);
            ICommand ChangeListItemNameCommand = new Command(OnTestMethod);
            //Assert
            Assert.AreEqual<Type>(AddListItemCommand.GetType(), testViewModel.AddListItemCommand.GetType());
            Assert.AreEqual<Type>(RemoveListItemCommand.GetType(), testViewModel.RemoveListItemCommand.GetType());
            Assert.AreEqual<Type>(ChangeListItemNameCommand.GetType(), testViewModel.ChangeListItemNameCommand.GetType());
        }

        [TestMethod]
        public void ShoppingList_ListContainsItems_Success()
        {
            //Arrange
            var testList = new ObservableCollection<ShoppingListItem>()
            {
                new ShoppingListItem("testItem1"),
                new ShoppingListItem("testItem2")
            };
            var testViewModel = new MainWindowViewModel();
            var viewModelList = testViewModel.ShoppingList;
            //Act

            //Assert
            Assert.AreEqual<int>(testList.Count, testViewModel.ShoppingList.Count);
            Assert.AreEqual<Type>(testList.GetType(), viewModelList.GetType());
        }

        [TestMethod]
        public void OnAddListItem_ItemIsAddedToListFromExecute_Fails()
        {
            //Arrange
            var testViewModel = new MainWindowViewModel();
            var expectedItem = new ShoppingListItem("Item3");
            var viewModelList = testViewModel.ShoppingList;

            //Act
            testViewModel.AddListItemCommand.Execute(expectedItem);

            //Assert
            Assert.IsFalse(viewModelList.Contains(expectedItem));
        }

        [TestMethod]
        public void OnRemoveListItem_AttemptRemovalOfFirstItem_Fails()
        {
            //Arrange
            var testViewModel = new MainWindowViewModel();
            var expectedItem = new ShoppingListItem("Item1");
            var viewModelList = testViewModel.ShoppingList;

            //Act
            testViewModel.RemoveListItemCommand.Execute(expectedItem);

            //Assert
            Assert.AreNotEqual<ShoppingListItem>(expectedItem, viewModelList[0]);
        }
    }
}
