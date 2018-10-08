using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cardstone.Data.Context
{
    public class CardstoneContext : DbContext, ICardstoneContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<CardsDecks> CardsDecks { get; set; }
        public DbSet<Combat> Combats { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardsDecks>()
                .HasKey(c => new { c.CardId, c.DeckId });
          

            modelBuilder.Entity<Player>()
                .HasMany<Combat>(p => p.WonCombats)
                .WithOne(c => c.Winner)
                .HasForeignKey(c => c.WinnerId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
