using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Configurations
{
    internal class CardsDecksConfiguration : IEntityTypeConfiguration<CardsDecks>
    {
        public void Configure(EntityTypeBuilder<CardsDecks> builder)
        {
            builder.HasKey(c => new { c.CardId, c.DeckId });
        }
    }
}
