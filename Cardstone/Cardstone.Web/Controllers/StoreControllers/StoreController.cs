using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cardstone.Data.Models;
using Cardstone.Services.Contracts;
using Cardstone.Web.Models.StoreViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cardstone.Web.Controllers.StoreControllers
{
    public class StoreController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly ICardService _cardService;

        public StoreController(UserManager<Player> userManager, ICardService cardService)
        {
            this._userManager = userManager;
            this._cardService = cardService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Store(StoreViewModel model)
        {
            var currentUser = HttpContext.User.Identity.Name;
            var cards = this._cardService.GetStoreCards(currentUser);

            model.Cards = cards;

            return View(model);
        }
    }
}