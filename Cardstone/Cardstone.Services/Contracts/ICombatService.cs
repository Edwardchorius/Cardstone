using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Services.Contracts
{
    public interface ICombatService
    {
        Combat CreateBattle(string firstPlayer, string secondPlayer, int coinsReward, int xpReward);
    }
}
