using OrderProcessingAPI.Application.DTOs;

namespace OrderProcessingAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderResponseDto>> GetOrderListAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId);
        Task<CancelOrderResponseDto> CancelOrderByIdAsync(Guid orderId);
    }
}