using Cardstone.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cardstone.Web.Models.StoreViewModels
{
    // NOT NECESSARY FOR NOW
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
        }

        public PurchaseViewModel(Purchase purchase)
        {
            this.Id = purchase.Id;
            this.Buyer = purchase.Buyer;
            this.Card = purchase.Card;
            this.CreatedOn = purchase.CreatedOn ?? DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public Player Buyer { get; set; }

        [Required]
        public Card Card { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
