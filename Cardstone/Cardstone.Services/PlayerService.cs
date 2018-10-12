using System;
using System.Collections.Generic;
using System.Linq;

using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class PlayerService : BaseService, IPlayerService, IService
    {
        public PlayerService(ICardstoneContext context)
            : base(context)
        {

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
                PlayersCards = new List<PlayersCards>(),
                WonCombats = new List<Combat>(),
                LostCombats = new List<Combat>(),
                Purchases = new List<Purchase>()
            };

            this.Context.Players.Add(player);
            this.Context.SaveChanges();

            return player;
        }

        public Player GetPlayer(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            Player player = this.Context.Players.SingleOrDefault(p => p.Username == username);

            if (player == null)
                throw new PlayerDoesNotExistException("There is no such username in database");

            return player;
        }

        public IEnumerable<Player> GetPlayers()
            => this.Context.Players;
    }
}
