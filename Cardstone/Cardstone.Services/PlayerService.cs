using System;
using System.Collections.Generic;
using System.Linq;

using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class PlayerService : IPlayerService, IService
    {
        private ICardstoneContext context;

        public PlayerService(ICardstoneContext context)
        {
            this.context = context;
        }

        public Player AddPlayer(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            if (username == null)
                throw new PlayerDoesNotExistException("There is no such username in database");

            Player player = new Player
            {
                Username = username,
                Health = 100,
                XP = 0,
                Coins = 150,
                Deck = new Deck(),
                WonCombats = new List<Combat>(),
                LostCombats = new List<Combat>(),
                Purchases = new List<Purchase>()
            };

            this.context.Players.Add(player);
            this.context.SaveChanges();

            return player;
        }

        public Player GetPlayer(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            Player player = this.context.Players.SingleOrDefault(p => p.Username == username);

            if (player == null)
                throw new PlayerDoesNotExistException("There is no such username in database");

            return player;
        }

        public IEnumerable<Player> GetPlayers()
            => this.context.Players;
    }
}
