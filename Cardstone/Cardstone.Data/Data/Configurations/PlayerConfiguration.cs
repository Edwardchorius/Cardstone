﻿using Cardstone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Configurations
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasMany<Combat>(p => p.WonCombats)
               .WithOne(c => c.Winner)
               .HasForeignKey(c => c.WinnerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<Combat>(p => p.LostCombats)
                .WithOne(c => c.Loser)
                .HasForeignKey(c => c.LooserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<Purchase>(pch => pch.Purchases)
                .WithOne(b => b.Buyer)
                .HasForeignKey(b => b.BuyerId);

            builder.Property(p => p.UserName)
                 .IsRequired()
                 .HasMaxLength(20);
        }
    }
}
