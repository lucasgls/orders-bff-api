namespace OrderProcessingAPI.Domain.Enum
{
    public enum OrderStatus
    {
        OrderPlaced = 0,
        PaymentPending = 1,
        PaymentApproved = 2,
        ReadyForHandling = 3,
        Handling = 4,
        Invoiced = 5,
        Canceled = 6
    }
}