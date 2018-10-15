using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cardstone.Test.Services.CardServiceTest
{
    [TestClass]
    public class GetCard_Should
    {

        [TestMethod]
        [DataRow("TestCard")]
        public void ReturnTheCard_When_PassedValidName(string name)
        {
            // TODO
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_ParameterIsNull()
        {
            // Arrange
            using (var context = new CardstoneContext())
            {
                var sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() 
                    => sut.GetCard(null));
            }
        }

        [TestMethod]
        public void ThrowCardDoesNotExistException_When_PassedSuchName()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ThrowCardDoesNotExistException_When_PassedSuchName")
                .Options;

            using (var context = new CardstoneContext(contextOptions))
            {
                var sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<CardDoesNotExistException>(()
                    => sut.GetCard("NonExistingCard"));
            }
        }
    }
}
