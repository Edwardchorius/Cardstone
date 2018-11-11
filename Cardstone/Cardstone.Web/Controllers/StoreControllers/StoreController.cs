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
        private readonly IPurchaseService _purchaseService;

        public StoreController(UserManager<Player> userManager,
                               ICardService cardService,
                               IPurchaseService purchaseService)
        {
            this._userManager = userManager;
            this._cardService = cardService;
            this._purchaseService = purchaseService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Store(StoreViewModel model)
        {
            var singedUser = HttpContext.User.Identity.Name;
            var cards = this._cardService.GetStoreCards(singedUser);

            model.Cards = cards;

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Buy(string cardName)
        {
            var singedUser = HttpContext.User.Identity.Name;
            _purchaseService.PurchaseCard(singedUser, cardName);

            return this.RedirectToAction("Deck", "Game");
        }
    }
}