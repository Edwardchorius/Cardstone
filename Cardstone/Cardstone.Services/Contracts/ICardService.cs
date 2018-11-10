using Cardstone.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface ICardService : IService
    {
        Card CreateCard(string name, int attack, int price);

        Card GetCard(string name);

        IEnumerable<PlayersCards> GetCards(string player);

        int CompareCardAttack(string first, string second);
    }
}
