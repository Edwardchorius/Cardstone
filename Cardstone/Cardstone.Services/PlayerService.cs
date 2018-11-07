using System;
using System.Collections.Generic;
using System.Linq;
using Cardstone.Data.Data;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;


namespace Cardstone.Services
{
    public class PlayerService : IPlayerService, IService
    {
        private readonly IApplicationDbContext _context;

        public PlayerService(IApplicationDbContext context)
        {
            this._context = context;
        }

        public Player AddPlayer(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            //if (username == null)
            //    throw new PlayerDoesNotExistException("There is no such username in database");

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

            this._context.Players.Add(player);
            this._context.SaveChanges();

            return player;
        }

        public Player GetPlayer(string playerId)
        {
            if (playerId == null)
                throw new ArgumentNullException("Username cannot be null");

            Player player = this._context.Players.Find(playerId);

            if (player == null)
                throw new PlayerDoesNotExistException("There is no such username in database");

            return player;
        }

        public IEnumerable<PlayersCards> GetPlayerCards(string username)
        {
            var cards = this._context.PlayersCards.Where(k => k.Player.Username == username).ToList();

            return cards;
        }

        public void CoinReward(string playerId, int coins)
        {
            var playerToWin = this._context.Players.Find(playerId);
            playerToWin.Coins += coins;
        }

        public void XpReward(string playerId, int xp)
        {
            var playerToWin = this._context.Players.Find(playerId);
            playerToWin.XP += xp;
        }

        public IEnumerable<Player> GetPlayers()
            => this._context.Players;
    }
}
