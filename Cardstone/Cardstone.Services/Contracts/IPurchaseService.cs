using Cardstone.Data.Models;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface IPurchaseService : IService
    {
        Card PurchaseCard(string userName, string cardName);

        IEnumerable<Card> StartingCards(Player player);
    }
}
