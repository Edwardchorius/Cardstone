﻿using Cardstone.Services.Contracts;
using Cardstone.Web.Models;
using Cardstone.Web.Models.DeckViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cardstone.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ICardService _cardService;

        public GameController(IPlayerService playerService, ICardService cardService)
        {
            this._cardService = cardService;
            this._playerService = playerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var players = this._playerService
                .GetPlayers()
                .Select(p => 
                {
                    return new PlayerViewModel
                    {
                        AvatarURL = p.AvatarImageName,
                        Username = p.UserName,
                        XP = p.XP
                    };
                })
                .Take(10);

            return View(players);
        }


        //[HttpGet]
        //public IActionResult Deck(DeckViewModel model)
        //{
        //    var playerCards = this._cardService.GetCards()
        //}

        [HttpGet]
        public IActionResult Battle()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Leaderboard()
        {
            var players = this._playerService
                .GetPlayers()
                .Select(p =>
                {
                    return new PlayerViewModel
                    {
                        AvatarURL = p.AvatarImageName,
                        Username = p.UserName,
                        XP = p.XP
                    };
                })
                .OrderByDescending(p => p.XP)
                .Take(100);

            return View(players);
        }
    }
}