namespace OrderProcessingAPI.Domain.Enum
{
    public enum OrderStatus
    {
        ORDER_PLACED = 0,
        PAYMENT_PENDING = 1,
        PAYMENT_APPROVED = 2,
        READY_FOR_HANDLING = 3,
        HANDLING = 4,
        INVOICED = 5,
        CANCELED = 6
    }
}