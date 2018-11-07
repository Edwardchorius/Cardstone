using Cardstone.Data.Models;

namespace Cardstone.Services.Contracts
{
    public interface ICardService : IService
    {
        Card CreateCard(string name, int attack, int price);

        Card GetCard(string name);

        int CompareCardAttack(string first, string second);
    }
}
