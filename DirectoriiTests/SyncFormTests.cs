using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Directorii;

namespace DirectoriiTests
{
    [TestClass]
    public class SyncFormTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            User user = new User("matt", "matt", "price", "matt@matt.com", "GUID");

            //Act

            //Assert
            Assert.AreEqual("price", user.LastName);
            
        }
    }
}
