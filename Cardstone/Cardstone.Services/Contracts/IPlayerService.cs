using Cardstone.Data.Models;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface IPlayerService : IService
    {
        Player AddPlayer(string username);

        Player GetPlayer(string username);

        IEnumerable<Player> GetPlayers();
    }
}
