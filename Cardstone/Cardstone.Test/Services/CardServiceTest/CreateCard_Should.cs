using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cardstone.Test.Services.CardServiceTest
{
    [TestClass]
    public class CreateCard_Should
    {
        [TestMethod]
        [DataRow("TestCard", 100, 20)]
        [DataRow("AnotherCard", 20, 0)]
        [DataRow("Jo", 500, 500)]
        [DataRow("Long card name but still valid", 1000000, 1000000)]
        public void AddCardToDatabase_When_PassedValidParameters(string name, int attack, int price)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "AddCardToDatabase_When_PassedValidParameters") // TODO
                .Options;

            Card card = new Card() { Name = name, Attack = attack, Price = price };

            int beforeCardsCount;
            using (var arrangeContext = new CardstoneContext(contextOptions))
            {
                beforeCardsCount = arrangeContext.Cards.Count();
            }

            // Act
            using (var actContext = new CardstoneContext(contextOptions))
            {
                var sut = new CardService(actContext);

                sut.CreateCard(card.Name, card.Attack, card.Price);
            }

            // Assert
            using (var assertContext = new CardstoneContext(contextOptions))
            {
                int afterCardsCount = assertContext.Cards.Count();

                int newCardsCount = afterCardsCount - beforeCardsCount;

                Assert.IsTrue(newCardsCount == 1);

                Card cardInDatabase = assertContext.Cards.Last();

                Assert.AreEqual(cardInDatabase.Name, name);
                Assert.AreEqual(cardInDatabase.Attack, attack);
                Assert.AreEqual(cardInDatabase.Price, price);
            }
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_NullNameIsPassed()
        {
            // Arrange
            using (var context = new CardstoneContext())
            {
                CardService sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(
                    () => sut.CreateCard(null, 0, 0));
            }
        }

        [TestMethod]
        [DataRow("God", 7777, 7777, "God", 666, 666)]
        [DataRow("YukiCard", 69, 69, "YukiCard", 69, 69)]
        [DataRow("Sonic", 54253, 223, "Sonic", 23432, 32432)]
        public void ThrowCardAlreadyExistException_When_PassedExsistingName(
            string firstCardName, int firstCardAttack, int firstCardPrice, 
            string secondCardName, int secondCardAttack, int secondCardPrice)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ThrowCardAlreadyExistException_When_PassedExsistingName")
                .Options;

            // Act
            using (var actContext = new CardstoneContext(contextOptions))
            {
                var sut = new CardService(actContext);

                sut.CreateCard(firstCardName, firstCardAttack, firstCardPrice);

                // Assert
                Assert.ThrowsException<CardAlreadyExistException>(
                    () => sut.CreateCard(secondCardName, secondCardAttack, secondCardPrice));
            }
        }

        [TestMethod]
        [DataRow("o", 50, 50)]
        [DataRow("Very very very very very very long card name", 10, 15)]
        public void ThrowInvalidNameException_When_PassedExsistingName(string name, int attack, int price)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ThrowInvalidNameException_When_PassedExsistingName")
                .Options;

            using (var context = new CardstoneContext(contextOptions))
            {
                CardService sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<InvalidNameException>(
                    () => sut.CreateCard(name, attack, price));
            }
        }

        [TestMethod]
        [DataRow("Kxitty", -700, 500)]
        [DataRow("Medusa", -1, 200)]
        public void ThrowInvalidAttackException_When_PassedNegativeAttack(string name, int attack, int price)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ThrowInvalidAttackException_When_PassedNegativeAttack")
                .Options;

            using (var context = new CardstoneContext(contextOptions))
            {
                CardService sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<InvalidAttackException>(
                    () => sut.CreateCard(name, attack, price));
            }
        }

        [TestMethod]
        [DataRow("Codex", 50000, -7)]
        [DataRow("Lovin' Cucumber", 2, -1)]
        public void ThrowInvalidPriceException_When_PassedNegativePrice(string name, int attack, int price)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "ThrowInvalidPriceException_When_PassedNegativePrice")
                .Options;

            using (var context = new CardstoneContext(contextOptions))
            {
                CardService sut = new CardService(context);

                // Act & Assert
                Assert.ThrowsException<InvalidPriceException>(
                    () => sut.CreateCard(name, attack, price));
            }
        }
    }
}
