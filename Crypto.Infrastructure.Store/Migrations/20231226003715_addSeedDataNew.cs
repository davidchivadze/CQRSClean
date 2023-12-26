using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crypto.Infrastructure.Store.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 100000m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "Davidchivadze96@gmail.com", "123" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "gigaurishalva@gmail.com", "Shalva", "Gigauri", "123" });

            migrationBuilder.InsertData(
                table: "ClientAccounts",
                columns: new[] { "Id", "AccountNumber", "Amount", "ClientId", "CurrencyID" },
                values: new object[,]
                {
                    { 3, "1234567891235", 50m, 2, 1 },
                    { 4, "1234567891235", 100000m, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ClientAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { null, null });
        }
    }
}
