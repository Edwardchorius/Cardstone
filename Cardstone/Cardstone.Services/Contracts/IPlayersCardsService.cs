using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Services.Contracts.General
{
    public interface IPlayersCardsService : IService
    {
        Card CardByCardId(int cardId);
    }
}
