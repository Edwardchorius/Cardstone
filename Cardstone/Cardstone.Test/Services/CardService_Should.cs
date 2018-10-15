using Cardstone.Data.Context;
using Cardstone.Data.Models;
using Cardstone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cardstone.Test.Services
{
    [TestClass]
    public class CardService_Should
    {
        [TestMethod]
        public void CreateCard_When_PassedValidParameters()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "PostsService_ShouldDeletePost_WhenPassedValidParameter")
                .Options;

            Card card = new Card() { Name = "TestCard", Attack = 100, Price = 25 };

            // Act
            using (var actContext = new CardstoneContext(contextOptions))
            {
                var sut = new CardService(actContext);

                sut.CreateCard(card.Name, card.Attack, card.Price);
            }

            // Assert
            using (var assertContext = new CardstoneContext(contextOptions))
            {
                Assert.IsTrue(assertContext.Cards.Count() == 1);

                Card cardInDatabase = assertContext.Cards.First();

                Assert.AreEqual(card.Name, cardInDatabase.Name);
                Assert.AreEqual(card.Attack, cardInDatabase.Attack);
                Assert.AreEqual(card.Price, cardInDatabase.Price);
            }
        }
    }
}
