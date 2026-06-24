using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderProcessingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "OrderNumber", "Status", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 6, 20, 12, 0, 0, 0, DateTimeKind.Utc), "Ana Silva", "PED-0001", 0, 250.00m, new DateTime(2026, 6, 20, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 6, 20, 12, 10, 0, 0, DateTimeKind.Utc), "Carlos Souza", "PED-0002", 1, 1340.00m, new DateTime(2026, 6, 20, 12, 10, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 6, 20, 12, 20, 0, 0, DateTimeKind.Utc), "Fernanda Lima", "PED-0003", 4, 89.90m, new DateTime(2026, 6, 20, 12, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 6, 20, 12, 30, 0, 0, DateTimeKind.Utc), "Ricardo Mendes", "PED-0004", 5, 499.00m, new DateTime(2026, 6, 20, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 6, 20, 12, 40, 0, 0, DateTimeKind.Utc), "Juliana Costa", "PED-0005", 6, 720.50m, new DateTime(2026, 6, 20, 12, 40, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
