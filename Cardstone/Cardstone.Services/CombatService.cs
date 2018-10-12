using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cardstone.Data.Context;
using Cardstone.Data.Models;

namespace Cardstone.Services.Contracts
{
    public class CombatService : BaseService //ICombatService, IService
    {
        private IPlayerService playerService;

        public CombatService(ICardstoneContext context)
            : base(context)
        {

        }

        /*public Combat CreateBattle(string firstPlayer, string secondPlayer, int coinsReward, int xpReward)
        {
            if (firstPlayer == null || secondPlayer == null)
            {
                throw new ArgumentNullException("Invalid player!");
            }

            var playerOne = this.playerService.GetPlayer(firstPlayer);
            var playerTwo = this.playerService.GetPlayer(secondPlayer);

            if (playerOne == null || playerTwo == null)
            {
                 Custom Exception
            }

            

    */
    }
}

