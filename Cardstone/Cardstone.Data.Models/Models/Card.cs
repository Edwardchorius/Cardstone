using Cardstone.Data.Models.Contracts;
using System.Collections.Generic;

namespace Cardstone.Data.Models
{
    public class Card : DataModel
    {      
        public string Name { get; set; }

        public string ImageURL { get; set; }

        public int Attack { get; set; }

        public int Armor { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<PlayersCards> PlayersCards { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
