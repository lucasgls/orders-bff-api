using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Domain.Entities;

namespace OrderProcessingAPI.Application.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        public OrderResponseDto ToResponse(Order order)
        {
            return new(
            Id: order.Id,
            OrderNumber: order.OrderNumber,
            CustomerName: order.CustomerName,
            TotalAmount: order.TotalAmount,
            Status: order.Status,
            CreatedAt: order.CreatedAt,
            UpdatedAt: order.UpdatedAt
            );
        }

        public CancelOrderResponseDto ToCancelOrderResponse(Order order, string message)
        {
            return new(
            OrderId: order.Id,
            Message: message,
            OrderNumber: order.OrderNumber,
            CanceledAt: order.UpdatedAt
            );
        }
    }
}