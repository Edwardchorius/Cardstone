using Cardstone.Services.Contracts;
using Cardstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cardstone.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IPlayerService _playerService;

        public GameController(IPlayerService playerService)
        {
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

        [HttpPost]
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