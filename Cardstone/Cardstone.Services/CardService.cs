using Cardstone.Data.Context;
using Cardstone.Data.Exceptions.CardExceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardstone.Services
{
    public class CardService : ICardService
    {
        private ICardstoneContext context;

        public CardService(ICardstoneContext context)
        {
            this.context = context;
        }

        public Card CreateCard(string name, int attack, int price)
        {
            if (this.context.Cards.Any(n => n.Name == name))
            {
                throw new InvalidNameException($"Card {name} already exists!");  
            }

            if (name.Length < 2)
            {
                throw new InvalidNameException($"Invalid name length!");
            }

            if (attack < 0)
            {
                throw new InvalidAttackException($"Attack can not be less than zero!");
            }

            if (price < 0)
            {
                throw new InvalidPriceException($"Price can not be less than zero!");
            }

            var card = new Card
            {
                Name = name,
                Attack = attack,
                Price = price,
                CardsDecks = new List<CardsDecks>(),
                Purchases = new List<Purchase>()
            };

            this.context.Cards.Add(card);
            this.context.SaveChanges();

            return card;
        }

        public Card GetCard(string name)
        {
            var cards = this.context.Cards;

            if (name == null)
            {
                throw new InvalidNameException($"Invalid name!");
            }

            Card card = cards.SingleOrDefault(n => n.Name == name);

            if (card == null)
            {
                throw new InvalidNameException($"Card {name} does not exist!");
            }

            return card;
        }
    }
}
