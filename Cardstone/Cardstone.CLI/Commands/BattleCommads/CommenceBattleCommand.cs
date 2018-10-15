using Cardstone.CLI.Contracts;
using Cardstone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cardstone.CLI.Commands.BattleCommads
{
    public class CommenceBattleCommand : ICommand
    {
        private ICombatService _combatService;
        private ILogger logger;

        public CommenceBattleCommand(ICombatService combatService, ILogger logger)
        {
            this._combatService = combatService;
            this.logger = logger;
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();

            string playerOne = args[0];
            string playerTwo = args[1];
            int coinsReward = int.Parse(args[2]);
            int xpReward = int.Parse(args[3]);

            _combatService.CreateBattle(playerOne, playerTwo, coinsReward, xpReward);
            /*try
            {
                _combatService.CreateBattle(playerOne, playerTwo, coinsReward, xpReward);
            }
            catch (Exception)
            {
                // Custom Exception
            }
            */
        }
    }
}
