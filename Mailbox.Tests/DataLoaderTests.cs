using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StreamSourceIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var source = new DataLoader(null);

            //Act

            //Assert
        }

/*        [TestMethod]
        public void LoadMethodLoadsMailListAndStreamList_IsEqual()
        {
            //Assert
            var mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.Medium)
            };

            

            //Act

            string jsonData = JsonConvert.SerializeObject(mailboxList);
            
            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, leaveOpen: true);
            writer.WriteLine(jsonData);
            writer.Flush();
            var dataLoader = new DataLoader(ms);
            var mailboxes = new Mailboxes(dataLoader.Load(), 10, 10);


            //Assert
            Assert.AreEqual(mailboxList.Count, mailboxes.Capacity);
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveMethodReceivesNull_ThrowsArgumentNullException()
        {
            //Arrange
            using var ms = new MemoryStream();
            //Act
            var dataLoader = new DataLoader(ms);
            //Assert
            dataLoader.Save(null);
        }

/*        [TestMethod]
        public void SaveMethodSavesCurrentList_IsEqual()
        {
            //Assert
            var mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.Medium),
                new Mailbox(new Person("Angus", "Young"), (0, 1), Sizes.PremiumLarge)
            };

            //Act

            string jsonData = JsonConvert.SerializeObject(mailboxList);

            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, leaveOpen: true);
            writer.WriteLine(jsonData);
            var dataLoader = new DataLoader(ms);

            dataLoader.Save(mailboxList);
            
            List<Mailbox>? mailboxes = dataLoader.Load();
            
            mailboxList.Add(new Mailbox(new Person("test", "AfterSave"), (0, 4), Sizes.Medium));

            //Assert
            Assert.AreEqual("" , mailboxes?.ToString());
        }*/
    }
}
