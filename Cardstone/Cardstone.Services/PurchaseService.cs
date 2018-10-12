using System;

using Cardstone.Data.Context;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class PurchaseService  :IPurchaseService, IService
    {
        private ICardstoneContext context;
        private ICardService cardService;
        private IPlayerService playerService;

        public PurchaseService(ICardstoneContext context,
                               ICardService cardService,
                               IPlayerService playerService)
        {
            this.context = context;
            this.cardService = cardService;
            this.playerService = playerService;
        }

        public Card PurchaseCard(string username, string cardName)
        {
            Player player = playerService.GetPlayer(username);
            Card card = cardService.GetCard(cardName);

            if (player.Coins < card.Price)
                throw new NotEnoughCoinsException($"Purchase too expensive. The {card.Name} card costs {card.Price}. {player.Username} have {player.Coins}");

            Deck deck = player.Deck;

            CardsDecks cardsDecks = new CardsDecks
            {
                CardId = card.Id,
                DeckId = deck.Id,
                Card = card,
                Deck = deck
            };

            deck.CardsDecks.Add(cardsDecks);
            this.context.SaveChanges();

            return card;
        }
    }
}
