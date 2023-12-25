using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crypto.Infrastructure.Store.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, null, "Davit", "Chivadze", null });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "BTC" },
                    { 2, "USDT" }
                });

            migrationBuilder.InsertData(
                table: "ClientAccounts",
                columns: new[] { "Id", "AccountNumber", "Amount", "ClientId", "CurrencyID" },
                values: new object[,]
                {
                    { 1, "123456789123", 50m, 1, 1 },
                    { 2, "123456789123", 50m, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
