using System;
using System.Collections.Generic;
using System.Linq;

using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;
using static Cardstone.Data.Utilities.Globals;

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
            if (name == null)
                throw new ArgumentNullException($"Card name cannot be null");

            if (this.context.Cards.Any(n => n.Name == name))
                throw new CardAlreadyExistException($"Card {name} already exists!");

            if (name.Length < MIN_CARD_NAME_LENGTH || name.Length > MAX_CARD_NAME_LENGTH)
                throw new InvalidNameException(string.Format("Card length is {0}. It must be between {1} and {2}",
                    name.Length, MIN_CARD_NAME_LENGTH, MAX_CARD_NAME_LENGTH));

            if (attack < 0)
                throw new InvalidAttackException($"Attack is {attack}. It cannot be negative!");

            if (price < 0)
                throw new InvalidPriceException($"Price is {price}. It cannot be negative!");

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
                throw new ArgumentNullException($"Card name cannot be null");

            Card card = this.context.Cards.SingleOrDefault(n => n.Name == name);

            if (card == null)
                throw new CardDoesNotExistException($"Card {name} does not exist!");

            return card;
        }


        public int Compare(string first, string second, ICardService other)
        {
            if (this.GetCard(first).Attack > other.GetCard(second).Attack)
            {
                return -1;
            }
            if (this.GetCard(first).Attack == other.GetCard(second).Attack)
            {
                return 0;
            }

            return 1;
        }
    }
}
