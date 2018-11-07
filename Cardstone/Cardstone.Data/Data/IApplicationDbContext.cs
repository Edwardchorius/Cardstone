using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Card> Cards { get; set; }

        DbSet<Combat> Combats { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Purchase> Purchases { get; set; }

        DbSet<PlayersCards> PlayersCards { get; set; }

        int SaveChanges();
    }
}
