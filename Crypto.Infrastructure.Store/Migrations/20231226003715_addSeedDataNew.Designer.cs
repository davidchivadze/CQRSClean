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
    [Migration("20231226003715_addSeedDataNew")]
    partial class addSeedDataNew
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
                            Email = "Davidchivadze96@gmail.com",
                            FirstName = "Davit",
                            LastName = "Chivadze",
                            Password = "123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "gigaurishalva@gmail.com",
                            FirstName = "Shalva",
                            LastName = "Gigauri",
                            Password = "123"
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
                            Amount = 100000m,
                            ClientId = 1,
                            CurrencyID = 2
                        },
                        new
                        {
                            Id = 3,
                            AccountNumber = "1234567891235",
                            Amount = 50m,
                            ClientId = 2,
                            CurrencyID = 1
                        },
                        new
                        {
                            Id = 4,
                            AccountNumber = "1234567891235",
                            Amount = 100000m,
                            ClientId = 2,
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

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Fee")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("SellAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("SellCurrencyID")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuyCurrencyID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SellCurrencyID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.PriceMonitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FromCurrencyID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ToCurrencyID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("FromCurrencyID");

                    b.HasIndex("ToCurrencyID");

                    b.ToTable("PriceMonitor");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MathchOrderID")
                        .HasColumnType("integer");

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MathchOrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("Trades");
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

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.PriceMonitor", b =>
                {
                    b.HasOne("Crypto.Domain.Models.EntityModels.Currency", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypto.Domain.Models.EntityModels.Currency", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromCurrency");

                    b.Navigation("ToCurrency");
                });

            modelBuilder.Entity("Crypto.Domain.Models.EntityModels.Trade", b =>
                {
                    b.HasOne("Crypto.Domain.Models.EntityModels.OrderBook", "MatchOrder")
                        .WithMany()
                        .HasForeignKey("MathchOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypto.Domain.Models.EntityModels.OrderBook", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchOrder");

                    b.Navigation("Order");
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
