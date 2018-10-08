using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Models
{
    public class Combat
    {
        public int Id { get; set; }

        public int LooserId { get; set; }

        public int WinnerId { get; set; }

        public Player Winner { get; set; }

        public Player Loser { get; set; }

        public int CoinsWin { get; set; }
    }
}
