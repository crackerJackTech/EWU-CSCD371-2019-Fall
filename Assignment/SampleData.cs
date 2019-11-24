using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("X:\\Documents\\Repos\\EWU-CSCD371-2019-Fall\\Assignment\\People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> list = CsvRows
            .OrderBy(item => item.Split(',')[(int)Column.ColumnHeader.State])
            .Select(item => item.Split(',')[(int)Column.ColumnHeader.State])
            .Distinct();

            return list;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            List<string> csvRows = GetUniqueSortedListOfStatesGivenCsvRows().ToList();

            return csvRows.Aggregate((stateOne, stateTwo) => $"{stateOne},{stateTwo}");

        }

        // 4.
        public IEnumerable<IPerson> People => (IEnumerable<IPerson>)CsvRows
                .OrderBy(item => item.Split(',')[(int)Column.ColumnHeader.State])
                .ThenBy(item => item.Split(',')[(int)Column.ColumnHeader.City])
                .ThenBy(item => item.Split(',')[(int)Column.ColumnHeader.Zip])
                .Select(item =>
                {

                    string[] addressColumns = item.Split(',');
                    var currectAddress = new Address()
                    {
                        StreetAddress = addressColumns[(int)Column.ColumnHeader.StreetAddress],
                        City = addressColumns[(int)Column.ColumnHeader.City],
                        State = addressColumns[(int)Column.ColumnHeader.State],
                        Zip = addressColumns[(int)Column.ColumnHeader.Zip],
                    };

                    return new Person()
                    {
                        FirstName = addressColumns[(int)Column.ColumnHeader.FirstName],
                        LastName = addressColumns[(int)Column.ColumnHeader.LastName],
                        Address = currectAddress,
                        Email = addressColumns[(int)Column.ColumnHeader.Email]
                    };
                });

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
