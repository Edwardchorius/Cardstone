using Cardstone.Data.Context;
using Cardstone.Data.Models;
using Cardstone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cardstone.Test.Services.PlayerServiceTest
{
    [TestClass]
    public class AddPlayer_Should
    {
        [TestMethod]
        [DataRow("Niki")]
        [DataRow("Edo")]
        [DataRow("Stivi")]
        [DataRow("Marto")]
        public void AddPlayerToDatabase_When_PassedValidParameter(string username)
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "AddPlayerToDatabase_When_PassedValidParameter")
                .Options;

            Player card = new Player() { Username = username };

            int beforePlayersCount;
            using (var arrangeContext = new CardstoneContext(contextOptions))
            {
                beforePlayersCount = arrangeContext.Players.Count();
            }

            // Act
            using (var actContext = new CardstoneContext(contextOptions))
            {
                var sut = new PlayerService(actContext);

                sut.AddPlayer(username);
            }

            // Assert
            using (var assertContext = new CardstoneContext(contextOptions))
            {
                int afterPlayersCount = assertContext.Players.Count();
                int newPlayersCount = afterPlayersCount - beforePlayersCount;

                Player playerInDatabase = assertContext.Players.Last();

                Assert.IsTrue(newPlayersCount == 1);
                Assert.AreEqual(playerInDatabase.Username, username);
            }
        }

        [TestMethod]
        public void ThrowArgumentNullException_When_ParameterIsNull()
        {
            // Arrange
            using (var context = new CardstoneContext())
            {
                var sut = new PlayerService(context);

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(
                    () => sut.AddPlayer(null));
            }
        }
    }
}
