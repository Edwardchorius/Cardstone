using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cardstone.Test.Services.CardServiceTest
{
    [TestClass]
    public class GetCard_Should
    {

        //[TestMethod]
        [DataRow("TestCard")]
        public void ReturnTheCard_When_PassedValidName(string name)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ReturnTheCard_When_PassedValidName")
                .Options;

            using (var context = new CardstoneContext(contextOptions))
            {
                var sut = new CardService(context);

                context.Cards.Add(new Card { Name = name, Attack = 50, Price = 50 });

                Card resultCard = sut.GetCard(name);

                Assert.AreEqual(resultCard.Name, name);
            }
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
