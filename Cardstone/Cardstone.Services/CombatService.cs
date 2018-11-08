using System;
using System.Linq;
using Cardstone.Data.Data;
using Cardstone.Data.Models;
using Cardstone.Database.Data;
using Cardstone.Services.Contracts.General;


namespace Cardstone.Services.Contracts
{
    public class CombatService : ICombatService, IService
    {
        private readonly CardstoneContext _context;
        private readonly IPlayerService _playerService;
        private readonly ICardService _cardService;
        private readonly IPlayersCardsService _playersCardsService;

        public CombatService(IPlayerService playerService, ICardService cardService,
            IPlayersCardsService playersCardsService,
            CardstoneContext context)
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

            var playerOneCards = this._playerService.GetPlayerCards(playerOne.UserName).ToList();
            var playerTwoCards = this._playerService.GetPlayerCards(playerTwo.UserName).ToList();

            playerOne.PlayersCards = playerOneCards;
            playerTwo.PlayersCards = playerTwoCards;

            if (playerOne.UserName == null || playerTwo.UserName == null)
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
                    WinnerId = playerOne.UserName,
                    LooserId = playerTwo.UserName,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerOne.UserName, coinsReward);
                this._playerService.XpReward(playerOne.UserName, xpReward);
                this._context.Players.Update(playerOne);
            }
            else if (this._cardService.CompareCardAttack(firstPlayerCard.Name, secondPlayerCard.Name) == 1)
            {
                combat = new Combat
                { 
                    WinnerId = playerOne.UserName,    
                    LooserId = playerTwo.UserName,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerTwo.UserName, coinsReward);
                this._playerService.XpReward(playerTwo.UserName, xpReward);
                this._context.Players.Update(playerTwo);
            }
             
            this._context.SaveChanges();
        }



        private Card BattleCard(Player player)
        {
            var playerCards = this._playerService.GetPlayerCards(player.UserName);
                      
            var cardRandom = playerCards.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var card = this._playersCardsService.CardByCardId(cardRandom.CardId);
                
            return card;
        }
    }
}

