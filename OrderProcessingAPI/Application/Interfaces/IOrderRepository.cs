using OrderProcessingAPI.Domain.Entities;

namespace OrderProcessingAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid orderId);
        Task<IReadOnlyList<Order?>> GetAllAsync();
        Task SaveAsync();
    }
}