using Cardstone.CLI.Contracts;
using Cardstone.Data.Context;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardstone.CLI.Commands
{
    public class AddCardToDeckCommand :  ICommand
    {
        private ICardService _cardService;
        private IPlayerService _playerService;

        public AddCardToDeckCommand(ICardService cardService, IPlayerService playerService)
        {
            this._cardService = cardService;
            this._playerService = playerService;
        }

        public void Execute(IEnumerable<string> parameters)
        {
            
        }
    }
}
