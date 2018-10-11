using System;
using System.Linq;
using Cardstone.Data.Context;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class PurchaseService : IPurchaseService
    {
        private ICardstoneContext context;

        public PurchaseService(ICardstoneContext carstoneContext)
        {
            this.context = carstoneContext ?? throw new ArgumentNullException(nameof(carstoneContext));
        }

        public Card PurchaseCard(string username, string cardName)
        {
            if (username == null)
            {

            }

            if (cardName == null)
            {

            }

            Player player = context.Players.SingleOrDefault(p => p.Username == username);
            Card card = context.Cards.SingleOrDefault(c => c.Name == cardName);

            if (player == null)
            {
                // UserDoesNotExistException();
            }

            if (card == null)
            {
                // CardDoesNotExistException();
            }

            if (player.Coins < card.Price)
            {
                // Custom exception - "Not enough coins to buy this card. Check money balance");
            }

            Deck deck = player.Deck;

            CardsDecks cardsDecks = new CardsDecks
            {
                CardId = card.Id,
                DeckId = deck.Id,
                Card = card,
                Deck = deck
            };

            deck.CardsDecks.Add(cardsDecks);

            return card;
        }
    }
}
