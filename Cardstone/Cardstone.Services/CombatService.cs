using System;
using System.Linq;
using Cardstone.Data.Data;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts.General;


namespace Cardstone.Services.Contracts
{
    public class CombatService : ICombatService, IService
    {
        private readonly IApplicationDbContext _context;
        private readonly IPlayerService _playerService;
        private readonly ICardService _cardService;
        private readonly IPlayersCardsService _playersCardsService;

        public CombatService(IPlayerService playerService, ICardService cardService,
            IPlayersCardsService playersCardsService,
            IApplicationDbContext context)
        {
            this._playerService = playerService;
            this._cardService = cardService;
            this._playersCardsService = playersCardsService;
            this._context = context;// context 1
        }

        public void CreateBattle(string firstPlayer, string secondPlayer, int coinsReward, int xpReward)
        {
            if (firstPlayer == null || secondPlayer == null)
            {
                throw new ArgumentNullException("Invalid player!");
            }


            var playerOne = this._playerService.GetPlayer(firstPlayer);
            var playerTwo = this._playerService.GetPlayer(secondPlayer);

            var playerOneCards = this._playerService.GetPlayerCards(playerOne.Username).ToList();
            var playerTwoCards = this._playerService.GetPlayerCards(playerTwo.Username).ToList();

            playerOne.PlayersCards = playerOneCards;
            playerTwo.PlayersCards = playerTwoCards;

            if (playerOne.Username == null || playerTwo.Username == null)
            {
                throw new ArgumentNullException("Invalid player!");
            }

            Card firstPlayerCard = BattleCard(playerOne);
            Card secondPlayerCard = BattleCard(playerTwo);

            Combat combat;

            if (this._cardService.CompareCardAttack(firstPlayerCard.Name, secondPlayerCard.Name) == -1)
            {
                combat = new Combat
                {
                    WinnerId = playerOne.Username,
                    LooserId = playerTwo.Username,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerOne.Username, coinsReward);
                this._playerService.XpReward(playerOne.Username, xpReward);
                this._context.Players.Update(playerOne);
            }
            else if (this._cardService.CompareCardAttack(firstPlayerCard.Name, secondPlayerCard.Name) == 1)
            {
                combat = new Combat
                { 
                    WinnerId = playerOne.Username,    
                    LooserId = playerTwo.Username,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerTwo.Username, coinsReward);
                this._playerService.XpReward(playerTwo.Username, xpReward);
                this._context.Players.Update(playerTwo);
            }
             
            this._context.SaveChanges();
        }



        private Card BattleCard(Player player)
        {
            var playerCards = this._playerService.GetPlayerCards(player.Username);
                      
            var cardRandom = playerCards.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var card = this._playersCardsService.CardByCardId(cardRandom.CardId);
                
            return card;
        }
    }
}

