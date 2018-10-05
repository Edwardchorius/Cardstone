namespace Cardstone.Data.Models
{
    public class CardsDecks
    {
        public int CardId { get; set; }

        public int DeckId { get; set; }

        public Card Card { get; set; }

        public Deck Deck { get; set; }
    }
}
