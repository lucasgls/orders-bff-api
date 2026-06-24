using OrderProcessingAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingAPI.Domain.Entities
{
    public class Order
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order()
        {
            
        }

        public Order(string orderNumber, string customerName, decimal totalAmount, OrderStatus status)
        {
            Id = Guid.NewGuid();
            OrderNumber = orderNumber;
            TotalAmount = totalAmount;
            Status = status;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public bool IsAlreadyCanceled() 
        {
            return Status == OrderStatus.CANCELED;
        }
        public bool IsInvoiced() 
        {
            return Status == OrderStatus.INVOICED;
        }
        public void Cancel() 
        {
            Status = OrderStatus.CANCELED;
            UpdatedAt = DateTime.Now;
        }
    }
}