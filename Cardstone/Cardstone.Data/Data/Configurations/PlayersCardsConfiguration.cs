using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cardstone.Data.Models;

namespace Cardstone.Data.Configurations
{
    internal class PlayersCardsConfiguration : IEntityTypeConfiguration<PlayersCards>
    {
        public void Configure(EntityTypeBuilder<PlayersCards> builder)
        {
            builder.HasKey(pc => new { pc.CardId, pc.});          
        }
    }
}
