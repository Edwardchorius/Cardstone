using Cardstone.Data.Models;

namespace Cardstone.Services.Contracts
{
    public interface IPurchaseService : IService
    {
        Card PurchaseCard(string userName, string cardName);
    }
}
