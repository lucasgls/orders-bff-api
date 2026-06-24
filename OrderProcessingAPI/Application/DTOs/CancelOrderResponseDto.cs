namespace OrderProcessingAPI.Application.DTOs
{
    public record CancelOrderResponseDto
    (
        Guid OrderId,
        string Message,
        string OrderNumber,
        DateTime Timestamp
    );
}