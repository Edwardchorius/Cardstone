using System;
using System.Collections.Generic;
using System.Linq;
using Cardstone.Data.Data;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Database.Data;
using Cardstone.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cardstone.Services
{
    public class PlayerService : IPlayerService, IService
    {
        private readonly CardstoneContext _context;

        public PlayerService(CardstoneContext context)
        {
            this._context = context;
        }

        public Player AddPlayer(string username, string password, string email, string avatarUrl)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            //if (username == null)
            //    throw new PlayerDoesNotExistException("There is no such username in database");

            Player player = new Player
            {
                UserName = username,
                PasswordHash = password,
                Email = email,
                AvatarImageName = avatarUrl,
                Health = 100,
                XP = 0,
                Coins = 150,
                Level = 1,
                PlayersCards = new List<PlayersCards>(),
                WonCombats = new List<Combat>(),
                LostCombats = new List<Combat>(),
                Purchases = new List<Purchase>(),
                CreatedOn = DateTime.Now,
                IsDeleted = false,
            };

            //this._context.Players.Add(player);
            //this._context.SaveChanges();

            return player;
        }

        public Player GetPlayer(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Username cannot be null");

            Player player = this._context.Players.FirstOrDefault(n => n.UserName == username);

            if (player == null)
                throw new PlayerDoesNotExistException("There is no such username in database");

            return player;
        }

        public IEnumerable<PlayersCards> GetPlayerCards(string username)
        {
            var player = this.GetPlayer(username);

            var playerCards = this._context.PlayersCards.Include(c => c.Card).Where(p => p.Player.UserName == username).ToList();


            return playerCards;
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
