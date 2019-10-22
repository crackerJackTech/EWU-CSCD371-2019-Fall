using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests : Actor
    {
        [TestMethod]
        public void ExtensionMethodTest_Raj_WomenArePresentIsTrue()
        {
            Raj raj = new Raj();
            raj.WomenArePresent = true;

            Assert.AreEqual("*mumble*", raj.Speak());
            
        }

        [TestMethod]
        public void ExtensionMethodTest_Raj_WomenArePresentIsFalse()
        {
            Raj raj = new Raj();
            raj.WomenArePresent = false;

            Assert.AreEqual("My name is Raj", raj.Speak());
        }

        [TestMethod]
        public void ExtensionMethodTest_Penny_Speak()
        {
            Actor penny = new Penny();

            Assert.AreEqual("My name is Penny", penny.Speak());
        }

        [TestMethod]
        public void ExtensionMethodTest_Sheldon_Speak()
        {
            Actor sheldon = new Sheldon();

            Assert.AreEqual("My name is Sheldon", sheldon.Speak());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExtensionMethodTest_IfActorIsNull()
        {
            ExtensionMethods.Speak(null);
            
        }
    }
}
