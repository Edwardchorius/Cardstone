using System.Collections.Generic;
using System.Linq;

using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class CardService : ICardService, IService
    {
        private ICardstoneContext context;

        public CardService(ICardstoneContext context)
        {
            this.context = context;
        }

        

        public Card CreateCard(string name, int attack, int price)
        {
            if (this.context.Cards.Any(n => n.Name == name))
                throw new CardDoesNotExistException($"Card {name} already exists!");

            if (name.Length < 2)
                throw new CardDoesNotExistException($"Invalid name length!");

            if (attack < 0)
                throw new InvalidAttackException($"Attack can not be less than zero!");

            if (price < 0)
                throw new InvalidPriceException($"Price can not be less than zero!");

            Card card = new Card
            {
                Name = name,
                Attack = attack,
                Price = price,
                PlayersCards = new List<PlayersCards>(),
                Purchases = new List<Purchase>()
            };

            this.context.Cards.Add(card);
            this.context.SaveChanges();

            return card;
        }

        public Card GetCard(string name)
        {
            if (name == null)
                throw new CardDoesNotExistException($"Invalid name!");

            Card card = this.context.Cards.SingleOrDefault(n => n.Name == name);

            if (card == null)
                throw new CardDoesNotExistException($"Card {name} does not exist!");

            return card;
        }
    }
}
