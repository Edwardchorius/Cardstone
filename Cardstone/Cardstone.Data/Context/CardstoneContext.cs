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

            modelBuilder.Entity<CardsDecks>()
                .HasOne(c => c.Card)
                .WithMany(cd => cd.CardsDecks)
                .HasForeignKey(c => c.CardId);

            modelBuilder.Entity<CardsDecks>()
                .HasOne(d => d.Deck)
                .WithMany(cd => cd.CardsDecks)
                .HasForeignKey(d => d.DeckId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
