using OrderProcessingAPI.Domain.Entities;

namespace OrderProcessingAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid orderId);
        Task<IReadOnlyList<Order?>> GetAllAsync();
        Task<Order?> GetLastOrderNumberAsync();
        Task<Order?> CreateAsync(Order order);
        Task SaveAsync();
    }
}