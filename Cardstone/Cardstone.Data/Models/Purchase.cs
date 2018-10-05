namespace Cardstone.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public int CardId { get; set; }

        public Player Buyer { get; set; }

        public Card Card { get; set; }
    }
}
