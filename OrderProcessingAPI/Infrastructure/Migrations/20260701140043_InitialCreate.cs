using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderProcessingAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "OrderNumber", "Status", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03d7c953-166b-4005-aebd-9b7452f7895c"), new DateTime(2026, 6, 20, 12, 0, 0, 0, DateTimeKind.Utc), "Ana Silva", "PED-0001", 0, 250.00m, new DateTime(2026, 6, 20, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("2ac64cde-d27a-47d2-9f12-f3d0fb8ff35c"), new DateTime(2026, 6, 20, 12, 30, 0, 0, DateTimeKind.Utc), "Ricardo Mendes", "PED-0004", 5, 499.00m, new DateTime(2026, 6, 20, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5951a1b8-e09a-465c-8635-e633c7f8d15a"), new DateTime(2026, 6, 20, 12, 20, 0, 0, DateTimeKind.Utc), "Fernanda Lima", "PED-0003", 4, 89.90m, new DateTime(2026, 6, 20, 12, 20, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e8d80e2a-15f6-4902-ab16-ddf48b4137e0"), new DateTime(2026, 6, 20, 12, 40, 0, 0, DateTimeKind.Utc), "Juliana Costa", "PED-0005", 6, 720.50m, new DateTime(2026, 6, 20, 12, 40, 0, 0, DateTimeKind.Utc) },
                    { new Guid("fa10850e-3be4-46b6-9b94-16289600b049"), new DateTime(2026, 6, 20, 12, 10, 0, 0, DateTimeKind.Utc), "Carlos Souza", "PED-0002", 2, 1340.00m, new DateTime(2026, 6, 20, 12, 10, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
