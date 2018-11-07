using System;
using System.Collections.Generic;
using System.Text;
using Cardstone.Data.Models;
using Cardstone.Services;
using Cardstone.Test.Services.Mock;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cardstone.Test.Services.PlayerServiceTest
{
    [TestClass]

    public class GetPlayer_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedNullValue()
        {
            //Arrange
            string invalidUser = null;

            var playerMock = new PlayerMock(invalidUser);


            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            playerMock.GetPlayer(invalidUser));
        }

        //[TestMethod]
        [DataRow("Blitzkrank")]
        [DataRow("Steven")]
        [DataRow("Edo")]
        public void Should_ReturnPlayer_WhenPassedValidUsername(string username)
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<CardstoneContext>()
                .UseInMemoryDatabase(databaseName: "Should_ReturnPlayer_WhenPassedValidUsername")
                .Options;

            //Assert
            using (var assertContext = new CardstoneContext(contextOptions))
            {
                var sut = new PlayerService(assertContext);

                Player player = sut.GetPlayer(username);

                Assert.IsNotNull(player);
            }
        }
    }
}
