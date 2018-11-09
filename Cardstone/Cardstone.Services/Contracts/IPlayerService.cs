using Cardstone.Data.Models;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface IPlayerService : IService
    {
        Player AddPlayer(string username, string password, string email, string avatarUrl);

        Player GetPlayer(string playerId);

        IEnumerable<Player> GetPlayers();

        IEnumerable<PlayersCards> GetPlayerCards(string username);

        void CoinReward(string playerId, int coins);

        void XpReward(string playerId, int xp);
    }
}
