using System.Collections.Generic;

namespace Cardstone.Data.Models
{
    public class Deck
    {
        public int Id { get; set; }

        public ICollection<CardsDecks> CardsDecks { get; set; }

        public int PlayerID { get; set; }

        public Player Player { get; set; }
    }
}
