﻿// <auto-generated />
using System;
using Crypto.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crypto.Infrastructure.Store.Migrations
{
    [DbContext(typeof(CryptoContext))]
    [Migration("20231224200105_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Davit",
                            LastName = "Chivadze"
                        });
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.ClientAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrencyID");

                    b.ToTable("ClientAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "123456789123",
                            Amount = 50m,
                            ClientId = 1,
                            CurrencyID = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "123456789123",
                            Amount = 50m,
                            ClientId = 1,
                            CurrencyID = 2
                        });
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "BTC"
                        },
                        new
                        {
                            Id = 2,
                            Description = "USDT"
                        });
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.OrderBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BuyAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("BuyCurrencyID")
                        .HasColumnType("integer");

                    b.Property<int>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Fee")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("SellAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("SellCurrencyID")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("TradeType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuyCurrencyID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SellCurrencyID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.ClientAccount", b =>
                {
                    b.HasOne("Crypto.Domain.Models.EntityModels.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypto.Domain.Models.EntityModels.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.OrderBook", b =>
                {
                    b.HasOne("Crypto.Domain.Models.EntityModels.Currency", "BuyCurrency")
                        .WithMany()
                        .HasForeignKey("BuyCurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypto.Domain.Models.EntityModels.Client", "Client")
                        .WithMany("Trades")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypto.Domain.Models.EntityModels.Currency", "SellCurrency")
                        .WithMany()
                        .HasForeignKey("SellCurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuyCurrency");

                    b.Navigation("Client");

                    b.Navigation("SellCurrency");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.Client", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}
