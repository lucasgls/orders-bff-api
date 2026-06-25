using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Domain.Entities;

namespace OrderProcessingAPI.Application.Interfaces
{
    public interface IOrderMapper
    {
        OrderResponseDto ToResponse(Order order);
        CancelOrderResponseDto ToCancelOrderResponse(Order order, string message);
    }
}