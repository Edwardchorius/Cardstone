﻿using Cardstone.Data.Configurations;
using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cardstone.Data.Context
{
    public class CardstoneContext : DbContext, ICardstoneContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Combat> Combats { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public CardstoneContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());

            modelBuilder.ApplyConfiguration(new PlayersCardsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=tcp:cardstoneproject.database.windows.net,1433;
                Initial Catalog = Cardstone; Persist Security Info = False;
                User ID = TelerikAcademyProject; Password =CardstoneProject1;
                MultipleActiveResultSets = False; Encrypt = True;
                TrustServerCertificate = False; Connection Timeout = 30;");
            }
        }
    }
}
