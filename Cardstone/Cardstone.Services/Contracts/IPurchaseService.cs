using Cardstone.Data.Models;

namespace Cardstone.Services.Contracts
{
    public interface IPurchaseService
    {
        Card PurchaseCard(string userName, string cardName);
    }
}
