using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crypto.Infrastructure.Store.Migrations
{
    /// <inheritdoc />
    public partial class addPriceMonitorAndTrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceMonitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromCurrencyID = table.Column<int>(type: "integer", nullable: false),
                    ToCurrencyID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PriceMonitor_Currencies_FromCurrencyID",
                        column: x => x.FromCurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceMonitor_Currencies_ToCurrencyID",
                        column: x => x.ToCurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitor_FromCurrencyID",
                table: "PriceMonitor",
                column: "FromCurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitor_ToCurrencyID",
                table: "PriceMonitor",
                column: "ToCurrencyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceMonitor");
        }
    }
}
