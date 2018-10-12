﻿// <auto-generated />
using Cardstone.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cardstone.Data.Migrations
{
    [DbContext(typeof(CardstoneContext))]
    [Migration("20181012145837_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cardstone.Data.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Cardstone.Data.Models.Combat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoinsWin");

                    b.Property<int>("LooserId");

                    b.Property<int>("WinnerId");

                    b.Property<int>("XpWin");

                    b.HasKey("Id");

                    b.HasIndex("LooserId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Combats");
                });

            modelBuilder.Entity("Cardstone.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Coins");

                    b.Property<int>("Health");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("XP");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Cardstone.Data.Models.PlayersCards", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("PlayerId");

                    b.HasKey("CardId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayersCards");
                });

            modelBuilder.Entity("Cardstone.Data.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyerId");

                    b.Property<int>("CardId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CardId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Cardstone.Data.Models.Combat", b =>
                {
                    b.HasOne("Cardstone.Data.Models.Player", "Loser")
                        .WithMany("LostCombats")
                        .HasForeignKey("LooserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Cardstone.Data.Models.Player", "Winner")
                        .WithMany("WonCombats")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Cardstone.Data.Models.PlayersCards", b =>
                {
                    b.HasOne("Cardstone.Data.Models.Card", "Card")
                        .WithMany("PlayersCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cardstone.Data.Models.Player", "Player")
                        .WithMany("PlayersCards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cardstone.Data.Models.Purchase", b =>
                {
                    b.HasOne("Cardstone.Data.Models.Player", "Buyer")
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cardstone.Data.Models.Card", "Card")
                        .WithMany("Purchases")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
