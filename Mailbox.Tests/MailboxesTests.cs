using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        public void MailboxesContainsCorrectAmountOfBoxes_IsEqualCount()
        {
            //Arrange
            var mailboxes = new List<Mailbox>()
            {
                new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.None),
                new Mailbox(new Person("Angus", "Young"), (0, 1), Sizes.PremiumLarge),
                new Mailbox(new Person("Jimi", "Hendrix"), (0, 2), Sizes.PremiumSmall)
            };

            //Act

            //Assert
            Assert.AreEqual(3, mailboxes.Count);
        }

        [TestMethod]
        public void MailboxesContainsCorrectOccupiedPosition_ReturnsTrue()
        {
            //Arrange
            var mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.None),
                new Mailbox(new Person("Devin", "Kramer"), (0, 2), Sizes.PremiumLarge),
                new Mailbox(new Person("Jimi", "Hendrix"), (0, 1), Sizes.PremiumSmall)
            };

            //Act
            var mailboxes = new Mailboxes(mailboxList, 10, 30);

            //Assert
            Assert.IsTrue(mailboxes.GetAdjacentPeople(0, 0, out HashSet<Person> adjacentPeople));
            Assert.IsTrue(mailboxes.GetAdjacentPeople(0, 1, out adjacentPeople));
            Assert.IsTrue(mailboxes.GetAdjacentPeople(0, 2, out adjacentPeople));
        }

        [TestMethod]
        public void MailboxesContainsUnoccupiedPosition_ReturnsFalse()
        {
            //Arrange
            var mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Devin", "Kramer"), (0, 0), Sizes.None),
                new Mailbox(new Person("Devin", "Kramer"), (0, 2), Sizes.PremiumLarge),
                new Mailbox(new Person("Jimi", "Hendrix"), (0, 1), Sizes.PremiumSmall)
            };

            //Act
            var mailboxes = new Mailboxes(mailboxList, 10, 30);

            //Assert
            Assert.IsFalse(mailboxes.GetAdjacentPeople(0, 4, out HashSet<Person> adjacentPeople));
            Assert.IsFalse(mailboxes.GetAdjacentPeople(1, 6, out adjacentPeople));
            Assert.IsFalse(mailboxes.GetAdjacentPeople(1, 2, out adjacentPeople));
        }

    }
}
