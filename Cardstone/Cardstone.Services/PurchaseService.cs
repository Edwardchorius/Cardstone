using Cardstone.Data.Data;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Database.Data;
using Cardstone.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardstone.Services
{
    public class PurchaseService : IPurchaseService, IService
    {
        private readonly CardstoneContext _context;
        private readonly ICardService cardService;
        private readonly IPlayerService playerService;


        public PurchaseService(CardstoneContext context,
                               ICardService cardService,
                               IPlayerService playerService)
        {
            this._context = context;
            this.cardService = cardService;
            this.playerService = playerService;
        }

        public Card PurchaseCard(string username, string cardName)
        {
           Player player = playerService.GetPlayer(username);
           Card card = cardService.GetCard(cardName);

           if (player.Coins < card.Price)
               throw new NotEnoughCoinsException($"Purchase too expensive. The {card.Name} card costs {card.Price}. {player.UserName} have {player.Coins}");

            var playersCards = new PlayersCards { Card = card, Player = player };
            var purchase = new Purchase
            {
                Buyer = player,
                Card = card
            };

            BalancePlayerBudget(this.playerService.GetPlayer(username), card.Price);

            this._context.PlayersCards.Update(playersCards);
            this._context.Purchases.Update(purchase);

            this._context.SaveChanges();

            return card;
        }

        public IEnumerable<Card> StartingCards(Player player)
        {
            var startingCards = this._context.Cards.OrderBy(k => k.Attack).Take(6);
            var listCards = new List<PlayersCards>();

            foreach (var card in startingCards)
            {
                var playerCards = new PlayersCards { Card = card, Player = player };
                listCards.Add(playerCards);
            }

            this._context.PlayersCards.UpdateRange(listCards);
            //this._context.SaveChanges();

            return startingCards;
        }

        private void BalancePlayerBudget(Player player, int price)
        {
            this.playerService.GetPlayer(player.UserName).Coins -= price;
        }
    }
}
