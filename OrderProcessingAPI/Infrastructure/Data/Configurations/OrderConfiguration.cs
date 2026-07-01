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
                new Order { Id = Guid.Parse("03d7c953-166b-4005-aebd-9b7452f7895c"), OrderNumber = "PED-0001", CustomerName = "Ana Silva", TotalAmount = 250.00m, Status = OrderStatus.OrderPlaced, CreatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 0, 0, DateTimeKind.Utc) },
                new Order { Id = Guid.Parse("fa10850e-3be4-46b6-9b94-16289600b049"), OrderNumber = "PED-0002", CustomerName = "Carlos Souza", TotalAmount = 1340.00m, Status = OrderStatus.PaymentApproved, CreatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 10, 0, DateTimeKind.Utc) },
                new Order { Id = Guid.Parse("5951a1b8-e09a-465c-8635-e633c7f8d15a"), OrderNumber = "PED-0003", CustomerName = "Fernanda Lima", TotalAmount = 89.90m, Status = OrderStatus.Handling, CreatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 20, 0, DateTimeKind.Utc) },
                new Order { Id = Guid.Parse("2ac64cde-d27a-47d2-9f12-f3d0fb8ff35c"), OrderNumber = "PED-0004", CustomerName = "Ricardo Mendes", TotalAmount = 499.00m, Status = OrderStatus.Invoiced, CreatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 30, 0, DateTimeKind.Utc) },
                new Order { Id = Guid.Parse("e8d80e2a-15f6-4902-ab16-ddf48b4137e0"), OrderNumber = "PED-0005", CustomerName = "Juliana Costa", TotalAmount = 720.50m, Status = OrderStatus.Canceled, CreatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2026, 6, 20, 12, 40, 0, DateTimeKind.Utc) }
            );
        }
    }
}