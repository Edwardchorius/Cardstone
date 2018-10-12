using Cardstone.CLI.Contracts;
using Cardstone.Data.Context;
using Cardstone.Data.Models;
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
            IPlayerService _playerService = playerService;
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();

            if (this._playerService.GetPlayers()
                .Any(u => u.Username == args[0]))
            {
                throw new Exception("User already exists!");
            }

            this._playerService.AddPlayer(args[0]);
        }
    }
}
