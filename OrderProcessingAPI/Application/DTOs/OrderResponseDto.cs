using OrderProcessingAPI.Domain.Enum;

namespace OrderProcessingAPI.Application.DTOs
{
    public record OrderResponseDto
    (
        Guid Id,
        string OrderNumber,
        string CustomerName,
        decimal TotalAmount,
        OrderStatus Status,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
