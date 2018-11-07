using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Configurations
{
    internal class CombatConfiguration : IEntityTypeConfiguration<Combat>
    {
        public void Configure(EntityTypeBuilder<Combat> builder)
        {
            
        }
    }
}
