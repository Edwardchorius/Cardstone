using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardstone.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int Health { get; set; }

        public int XP { get; set; }

        public int Coins { get; set; }           

        public ICollection<PlayersCards> PlayersCards { get; set; }

        public ICollection<Combat> WonCombats { get; set; }

        public ICollection<Combat> LostCombats { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
