using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardstone.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        public int Health { get; set; }

        public int XP { get; set; }

        public int Coins { get; set; }
        
        
        public int DeckId { get; set; }

        public Deck Deck { get; set; }

        public ICollection<Combat> WonCombats { get; set; }

        public ICollection<Combat> LostCombats { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
