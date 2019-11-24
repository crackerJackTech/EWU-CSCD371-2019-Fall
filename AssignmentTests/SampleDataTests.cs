using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentTests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_ReceiveRowsDataContainsData_Success()
        {
            //Arrange
            var sampleData = new SampleData();
            int countOfData = 0;
            //Act
            IEnumerable<string> incomingData = sampleData.CsvRows;
            
            foreach(string item in incomingData)
            {
                countOfData++;
            }

            //Assert
            Assert.IsTrue(countOfData > 0);
            
        }

        [TestMethod]
        public void CsvRows_ReceiveFirstRowIsNotColumnNames_Success()
        {
            //Arrange
            var sampleData = new SampleData();

            //Act
            IEnumerable<string> incomingData = sampleData.CsvRows;

            //Assert
            Assert.IsFalse(Enumerable.Contains<string>(incomingData, "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsDataFilledList_Success()
        {
            //Arrange
            ISampleData sampleData = new SampleData();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            //Act

            //Assert
            Assert.IsTrue(data.Count() > 0);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedList_Success()
        {
            //Arrange
            ISampleData sampleData = new SampleData();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            //Act
            IEnumerable<string> sortedDataList = sampleData.CsvRows
            .OrderBy(item => item.Split(',')[(int)Column.ColumnHeader.State])
            .Select(item => item.Split(',')[(int)Column.ColumnHeader.State])
            .Distinct();

            //Assert
            Assert.IsTrue(Enumerable.SequenceEqual(sortedDataList, data));
        }


        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsNonEmptyStringList_Success()
        {
            //Arrange
            SampleData sampleData = new SampleData();
            string sortedList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            //Act

            //Assert
            Assert.IsTrue(sortedList.Length > 0);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCommaSeperatedStringState_Success()
        {
            //Arrange
            SampleData sampleData = new SampleData();
            string sortedDataListOfStates = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedStates = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            //Act

            //Assert
            Assert.AreEqual<string>(expectedStates, sortedDataListOfStates);
        }

        [TestMethod]
        public void People_ChecksListIfPersonExists_Success()
        {
            //Arrange
            var sampleData = new SampleData();
            List<string> incomingCsvDataRows = sampleData.CsvRows.ToList();
            List<IPerson> personList = sampleData.People.ToList();


            //Act

            //Assert

            
        }

    }
}
