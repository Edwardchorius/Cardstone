using Cardstone.Data.Models;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface IPlayerService : IService
    {
        Player AddPlayer(string username);

        Player GetPlayer(string username);

        IEnumerable<Player> GetPlayers();

        IEnumerable<PlayersCards> GetPlayerCards(string username);

        void CoinReward(Player player, int coins);

        void XpReward(Player player, int xp);
    }
}
