using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cardstone.Data.Context;
using Cardstone.Data.Models;

namespace Cardstone.Services.Contracts
{
    public class CombatService //: ICombatService
    {
        private ICardstoneContext context;

        public CombatService(ICardstoneContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public Combat CreateBattle(string firstPlayer, string secondPlayer, int coinsReward, int xpReward)
        //{
        //    if (firstPlayer == null || secondPlayer== null)
        //    {
        //        // Custom Exception
        //    }

        //    var playerOne = this.context.Players.FirstOrDefault(n => n.Username == firstPlayer);
        //    var playerTwo = this.context.Players.FirstOrDefault(n => n.Username == secondPlayer);

        //    if (playerOne == null || playerTwo == null)
        //    {
        //        // Custom Exception
        //    }

            


        //}
    }
}
