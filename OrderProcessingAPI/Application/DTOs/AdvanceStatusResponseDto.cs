using OrderProcessingAPI.Domain.Enum;

namespace OrderProcessingAPI.Application.DTOs
{
    public record AdvanceStatusResponseDto
    (
        Guid OrderId,
        string OrderNumber,
        OrderStatus CurrentStatus,
        DateTime UpdatedAt
    );
}