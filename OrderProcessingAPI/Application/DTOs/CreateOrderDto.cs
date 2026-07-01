namespace OrderProcessingAPI.Application.DTOs
{
    public record CreateOrderDto
    (
        String CustomerName,
        decimal TotalAmount
    );
}
