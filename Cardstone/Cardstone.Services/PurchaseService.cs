using Cardstone.Data.Data;
using Cardstone.Data.Exceptions;
using Cardstone.Data.Models;
using Cardstone.Database.Data;
using Cardstone.Services.Contracts;

namespace Cardstone.Services
{
    public class PurchaseService : IPurchaseService, IService
    {
        private readonly CardstoneContext context;
        private readonly ICardService cardService;
        private readonly IPlayerService playerService;


        public PurchaseService(CardstoneContext context,
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
               throw new NotEnoughCoinsException($"Purchase too expensive. The {card.Name} card costs {card.Price}. {player.UserName} have {player.Coins}");

            var playersCards = new PlayersCards { Card = card, Player = player };
            var purchase = new Purchase
            {
                Buyer = player,
                Card = card
            };

            BalancePlayerBudget(this.playerService.GetPlayer(username), card.Price);

            this.context.PlayersCards.Update(playersCards);
            this.context.Purchases.Update(purchase);

            this.context.SaveChanges();

            return card;
        }

        private void BalancePlayerBudget(Player player, int price)
        {
            this.playerService.GetPlayer(player.UserName).Coins -= price;
        }
    }
}
