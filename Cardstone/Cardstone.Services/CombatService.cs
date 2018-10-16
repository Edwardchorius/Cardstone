using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cardstone.Data.Context;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts.General;
using Microsoft.EntityFrameworkCore;

namespace Cardstone.Services.Contracts
{
    public class CombatService : ICombatService, IService
    {
        private ICardstoneContext _context;
        private IPlayerService _playerService;
        private ICardService _cardService;
        private ICardService _other_cardService;
        private IPlayersCardsService _playersCardsService;

        public CombatService(IPlayerService playerService, ICardService cardService,
            IPlayersCardsService playersCardsService, ICardService other_cardService,
            ICardstoneContext context)
        {
            this._playerService = playerService;
            this._cardService = cardService;
            this._playersCardsService = playersCardsService;
            this._other_cardService = other_cardService;
            this._context = context; // context 1
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

            if (playerOne == null || playerTwo == null)
            {
                throw new ArgumentNullException("Invalid player!");
            }

            Card firstPlayerCard = BattleCard(playerOne);
            Card secondPlayerCard = BattleCard(playerTwo);

            Combat combat;

            if (this._cardService.Compare(firstPlayerCard.Name, secondPlayerCard.Name, _other_cardService) == -1)
            {
                combat = new Combat
                {
                    WinnerId = playerOne.Id,
                    LooserId = playerTwo.Id,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerOne, coinsReward);
                this._playerService.XpReward(playerOne, xpReward);
                this._context.Players.Update(playerOne);
            }
            else if (this._cardService.Compare(firstPlayerCard.Name, secondPlayerCard.Name, _other_cardService) == 1)
            {
                combat = new Combat
                { 
                    WinnerId = playerTwo.Id,    
                    LooserId = playerOne.Id,
                    CoinsWin = coinsReward,
                    XpWin = xpReward
                };
                //Adding combat
                this._context.Combats.Add(combat);

                //Update players statuses
                this._playerService.CoinReward(playerTwo, coinsReward);
                this._playerService.XpReward(playerTwo, xpReward);
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

