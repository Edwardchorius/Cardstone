using Cardstone.CLI.Contracts;
using Cardstone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardstone.CLI.Commands
{
    public class RegisterPlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public RegisterPlayerCommand(IPlayerService playerService)

        {
            this._playerService = playerService;
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();

            var playerName = args[0];

            if (this._playerService.GetPlayers()
                .Any(u => u.UserName == playerName))
            {
                throw new Exception("User already exists!");
            }

            this._playerService.AddPlayer(args[0]);
        }
    }
}
