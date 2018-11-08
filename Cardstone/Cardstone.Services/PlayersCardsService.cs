using Cardstone.Data.Data;
using Cardstone.Data.Models;
using Cardstone.Database.Data;
using Cardstone.Services.Contracts;
using Cardstone.Services.Contracts.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Services
{
    public class PlayersCardsService : IPlayersCardsService, IService
    {
        CardstoneContext _context;

        public PlayersCardsService(CardstoneContext context)
        {
            this._context = context;
        }

        public Card CardByCardId(int cardId)
        {
            var playerCard = this._context.Cards.Find(cardId);
            return playerCard;
        }
    }
}
