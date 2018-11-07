using Cardstone.Data.Configurations;
using Cardstone.Data.Data;
using Cardstone.Data.Models;
using Cardstone.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cardstone.Database.Data
{
    public class CardstoneContext : IdentityDbContext<Player>, IDesignTimeDbContextFactory<CardstoneContext>
    {
        public CardstoneContext()
        {

        }

        public CardstoneContext(DbContextOptions<CardstoneContext> options)
            : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Combat> Combats { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PlayersCards> PlayersCards { get; set; }


        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletionRules();

            return base.SaveChanges();
        }

        private void ApplyDeletionRules()
        {
            var entitiesForDeletion = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is IDeletable);

            foreach (var entry in entitiesForDeletion)
            {
                var entity = (IDeletable)entry.Entity;
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());

            modelBuilder.ApplyConfiguration(new PlayersCardsConfiguration());

            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "Admin" });

            base.OnModelCreating(modelBuilder);
        }

        public CardstoneContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CardstoneContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new CardstoneContext(optionsBuilder.Options);
        }
    }
}
