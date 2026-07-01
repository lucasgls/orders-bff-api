using OrderProcessingAPI.Domain.Enum;

namespace OrderProcessingAPI.Domain.Entities
{
    public class Order
    {
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

        public Order(string orderNumber, string customerName, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            OrderNumber = orderNumber;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            Status = OrderStatus.OrderPlaced;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public bool IsAlreadyCanceled() 
        {
            return Status == OrderStatus.Canceled;
        }

        public bool IsInvoiced() 
        {
            return Status == OrderStatus.Invoiced;
        }

        public void Cancel() 
        {
            Status = OrderStatus.Canceled;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AdvanceStatus()
        {
            Status = (OrderStatus)((int)Status + 1);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}