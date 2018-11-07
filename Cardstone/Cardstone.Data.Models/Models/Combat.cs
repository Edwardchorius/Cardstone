using Cardstone.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Models
{
    public class Combat : DataModel
    {
        public string LooserId { get; set; }

        public string WinnerId { get; set; }

        public Player Winner { get; set; }

        public Player Loser { get; set; }

        public int CoinsWin { get; set; }

        public int XpWin { get; set; }
    }
}
