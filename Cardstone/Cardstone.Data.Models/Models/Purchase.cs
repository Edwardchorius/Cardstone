using Cardstone.Data.Models.Contracts;

namespace Cardstone.Data.Models
{
    public class Purchase : DataModel
    {
        public string BuyerId { get; set; }

        public int CardId { get; set; }

        public Player Buyer { get; set; }

        public Card Card { get; set; }
    }
}
