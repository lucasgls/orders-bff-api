using Microsoft.EntityFrameworkCore;
using OrderProcessingAPI.Domain.Entities;
using OrderProcessingAPI.Models.Enum;

namespace OrderProcessingAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    OrderNumber = "PED-0001",
                    CustomerName = "Ana Silva",
                    TotalAmount = 250.00m,
                    Status = OrderStatus.ORDER_PLACED,
                    CreatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    OrderNumber = "PED-0002",
                    CustomerName = "Carlos Souza",
                    TotalAmount = 1340.00m,
                    Status = OrderStatus.PAYMENT_PENDING,
                    CreatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    OrderNumber = "PED-0003",
                    CustomerName = "Fernanda Lima",
                    TotalAmount = 89.90m,
                    Status = OrderStatus.HANDLING,
                    CreatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    OrderNumber = "PED-0004",
                    CustomerName = "Ricardo Mendes",
                    TotalAmount = 499.00m,
                    Status = OrderStatus.INVOICED,
                    CreatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    OrderNumber = "PED-0005",
                    CustomerName = "Juliana Costa",
                    TotalAmount = 720.50m,
                    Status = OrderStatus.CANCELED,
                    CreatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}