

namespace Cardstone.Data.Models
{
    public class PlayersCards
    {
        public int CardId { get; set; }

        public int PlayerId { get; set; }

        public Card Card { get; set; }

        public Player Player { get; set; }
    }
}
