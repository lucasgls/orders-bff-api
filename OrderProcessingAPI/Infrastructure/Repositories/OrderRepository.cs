using Microsoft.EntityFrameworkCore;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Domain.Entities;
using OrderProcessingAPI.Infrastructure.Data;

namespace OrderProcessingAPI.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Order?> GetByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .FindAsync(orderId);
        }

        public async Task<IReadOnlyList<Order?>> GetAllAsync()
        {
            return await _context.Orders
                .ToListAsync();
        }
        
        public async Task<Order?> GetLastOrderNumberAsync()
        {
            return await _context.Orders
                .OrderByDescending(o => o.OrderNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<Order?> CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}