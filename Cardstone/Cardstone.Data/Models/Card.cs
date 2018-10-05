using System.Collections.Generic;

namespace Cardstone.Data.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Attack { get; set; }

        public int Price { get; set; }

        public ICollection<CardsDecks> CardsDecks { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
