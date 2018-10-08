using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cardstone.Data.Context
{
    public interface ICardstoneContext
    {
        DbSet<Card> Cards { get; set; }

        DbSet<Deck> Decks { get; set; }

        DbSet<CardsDecks> CardsDecks { get; set; }

        DbSet<Combat> Combats { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Purchase> Purchases { get; set; }

        int SaveChanges();
    }
}
