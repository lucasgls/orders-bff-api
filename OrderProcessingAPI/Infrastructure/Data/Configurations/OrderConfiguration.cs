using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProcessingAPI.Domain.Entities;
using OrderProcessingAPI.Domain.Enum;

namespace OrderProcessingAPI.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .IsUnicode()
                .ValueGeneratedOnAdd();

            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.TotalAmount)
                .IsRequired()    
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.CreatedAt)
                .IsRequired();

            builder.Property(o => o.UpdatedAt)
                .IsRequired();

            builder.HasData(
                new { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), SequentialNumber = 1, CustomerName = "Ana Silva", TotalAmount = 250.00m, Status = OrderStatus.OrderPlaced, CreatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc) },
                new { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), SequentialNumber = 2, CustomerName = "Carlos Souza", TotalAmount = 1340.00m, Status = OrderStatus.PaymentApproved, CreatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc) },
                new { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), SequentialNumber = 3, CustomerName = "Fernanda Lima", TotalAmount = 89.90m, Status = OrderStatus.Handling, CreatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc) },
                new { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), SequentialNumber = 4, CustomerName = "Ricardo Mendes", TotalAmount = 499.00m, Status = OrderStatus.Invoiced, CreatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc) },
                new { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), SequentialNumber = 5, CustomerName = "Juliana Costa", TotalAmount = 720.50m, Status = OrderStatus.Canceled, CreatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc) }
            );
        }
    }
}