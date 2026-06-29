using OrderProcessingAPI.Application.DTOs;

namespace OrderProcessingAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderResponseDto>> GetOrdersAsync();
        Task<OrderResponseDto> GetOrderAsync(Guid orderId);
        Task<CancelOrderResponseDto> CancelOrderAsync(Guid orderId);
        Task<AdvanceStatusResponseDto> AdvanceOrderStatusAsync(Guid orderId);
    }
}